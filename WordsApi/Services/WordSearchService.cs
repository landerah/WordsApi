using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using WordsApi.Queries;
using WordsApi.Services.Helpers;

namespace WordsApi.Services
{
    public class WordSearchService : IWordSearchService
    {
        private readonly IGetWordnikBaseUrlQuery _getWordnikBaseUrlQuery;
        private readonly string WordSearchPath = "/v4/words.json/search/";

        public WordSearchService(IGetWordnikBaseUrlQuery getWordnikBaseUrlQuery)
        {
            _getWordnikBaseUrlQuery = getWordnikBaseUrlQuery;
        }

        public SearchResults SearchWords(WordSearchRequest wordSearchRequest)
        {
            var url = GetWordSearchUrl(wordSearchRequest);

            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            using (WebResponse webResponse = request.GetResponse())
            {
                using (Stream stream = webResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    string responseFromWordnik = reader.ReadToEnd();
                    var settings = new JsonSerializerSettings
                    {
                        Converters = new List<JsonConverter> { new StringEnumConverter { CamelCaseText = true } },
                        NullValueHandling = NullValueHandling.Ignore
                    };
                    var searchResults = JsonConvert.DeserializeObject<SearchResults>(responseFromWordnik, settings);
                    return searchResults;
                }
            }
        }

        private string GetWordSearchUrl(WordSearchRequest wordSearchRequest)
        {
            StringBuilder urlBuilder = new StringBuilder();
            urlBuilder.Append(_getWordnikBaseUrlQuery.Query());
            urlBuilder.Append(WordSearchPath);
            urlBuilder.Append(wordSearchRequest.Query);
            var args = GetArgs(wordSearchRequest).ToList();
            if (args.Any())
            {
                urlBuilder.Append("?");
                urlBuilder.Append(string.Join("&", args));
            }

            var url = urlBuilder.ToString();
            return url;
        }

        private IEnumerable<string> GetArgs(WordSearchRequest wordSearchRequest)
        {
            foreach (var arg in WordnikUrlHelper.GetCaseSensitiveArguments(wordSearchRequest.CaseSensitive)) yield return arg;
            yield return WordnikUrlHelper.GetMinimumDictionaryCountArgument(wordSearchRequest.MinimumDictionaryCount);
            yield return WordnikUrlHelper.GetMaximumDictionaryCountArgument(wordSearchRequest.MaximumDictionaryCount);
            yield return WordnikUrlHelper.GetMaximumLengthArgument(wordSearchRequest.MaximumLength);
            yield return WordnikUrlHelper.GetMinimumLengthArgument(wordSearchRequest.MinimumLength);
            foreach (var arg in WordnikUrlHelper.GetExpludePartsOfSpeechArguments(wordSearchRequest.ExcludePartsOfSpeech)) yield return arg;
            foreach (var arg in WordnikUrlHelper.GetIncludePartsOfSpeechArguments(wordSearchRequest.IncludePartsOfSpeech)) yield return arg;
            yield return WordnikUrlHelper.GetLimitArgument(wordSearchRequest.Limit);
            yield return WordnikUrlHelper.GetSkipArgument(wordSearchRequest.Skip);
            yield return WordnikUrlHelper.GetApiKeyArgument(wordSearchRequest.ApiKey);
        }
    }
}
