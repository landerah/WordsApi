using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using WordsApi.Queries;
using WordsApi.Services.Helpers;

namespace WordsApi.Services
{
    public class WordOfTheDayService: IWordOfTheDayService
    {
        private readonly IGetWordnikBaseUrlQuery _getWordnikBaseUrlQuery;
        private readonly string WordSearchPath = "/v4/words.json/wordOfTheDay/";

        public WordOfTheDayService(IGetWordnikBaseUrlQuery getWordnikBaseUrlQuery)
        {
            _getWordnikBaseUrlQuery = getWordnikBaseUrlQuery;
        }

        public WordOfTheDayResponse GetWordOfTheDay(WordOfTheDayRequest wordOfTheDayRequest)
        {
            var url = GetWordOfTheDayUrl(wordOfTheDayRequest);

            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            using (WebResponse webResponse = request.GetResponse())
            {
                using (Stream stream = webResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    string responseFromWordnik = reader.ReadToEnd();
                    var wordOfTheDayResponse = JsonConvert.DeserializeObject<WordOfTheDayResponse>(responseFromWordnik);
                    return wordOfTheDayResponse;
                }
            }
        }

        private string GetWordOfTheDayUrl(WordOfTheDayRequest wordOfTheDayRequest)
        {
            StringBuilder urlBuilder = new StringBuilder();
            urlBuilder.Append(_getWordnikBaseUrlQuery.Query());
            urlBuilder.Append(WordSearchPath);
            var args = GetArgs(wordOfTheDayRequest).ToList();
            if (args.Any())
            {
                urlBuilder.Append("?");
                urlBuilder.Append(string.Join("&", args));
            }

            var url = urlBuilder.ToString();
            return url;
        }
        
        private IEnumerable<string> GetArgs(WordOfTheDayRequest wordOfTheDayRequest)
        {
            foreach (var arg in WordnikUrlHelper.GetDateArguments(wordOfTheDayRequest.Date)) yield return arg;
            yield return WordnikUrlHelper.GetApiKeyArgument(wordOfTheDayRequest.ApiKey);
        }
    }
}
