using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using WordsApi.Model;
using WordsApi.Queries;
using WordsApi.Services.Helpers;

namespace WordsApi.Services
{
    public class RandomWordsService : IRandomWordsService
    {
        private readonly IGetWordnikBaseUrlQuery _getWordnikBaseUrlQuery;
        private readonly string RandomWordsPath = "/v4/words.json/randomWords";
        private readonly string RandomWordPath = "/v4/words.json/randomWord";

        public RandomWordsService(IGetWordnikBaseUrlQuery getWordnikBaseUrlQuery)
        {
            _getWordnikBaseUrlQuery = getWordnikBaseUrlQuery;
        }

        public GetRandomWordsResponse GetRandomWords(GetRandomWordsRequest getRandomWordsRequest)
        {
            var url = GetRandomWordsUrl(getRandomWordsRequest);

            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            using (WebResponse webResponse = request.GetResponse())
            {
                using (Stream stream = webResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    string responseFromWordnik = reader.ReadToEnd();
                    var listified = "{\"list\":" + responseFromWordnik + "}";
                    var wordnikWordList = JsonConvert.DeserializeObject<WordnikWordList>(listified);

                    return new GetRandomWordsResponse(wordnikWordList.List.Select(w => new WordResponse() {Id = w.Id, Word = w.Word}));
                }
            }
        }

        public GetRandomWordResponse GetRandomWord(GetRandomWordRequest getRandomWordRequest)
        {
            var url = GetRandomWordUrl(getRandomWordRequest);

            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            using (WebResponse webResponse = request.GetResponse())
            {
                using (Stream stream = webResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream);
                    string responseFromWordnik = reader.ReadToEnd();
                    var wordnikWord = JsonConvert.DeserializeObject<WordnikWord>(responseFromWordnik);

                    return new GetRandomWordResponse(new WordResponse() { Id = wordnikWord.Id, Word = wordnikWord.Word });
                }
            }
        }

        private string GetRandomWordsUrl(GetRandomWordsRequest getRandomWordsRequest)
        {
            StringBuilder urlBuilder = new StringBuilder();
            urlBuilder.Append(_getWordnikBaseUrlQuery.Query());
            urlBuilder.Append(RandomWordsPath);

            var args = GetArgs(getRandomWordsRequest).ToList();
            if (args.Any())
            {
                urlBuilder.Append("?");
                urlBuilder.Append(string.Join("&", args));
            }

            var url = urlBuilder.ToString();
            return url;
        }

        private string GetRandomWordUrl(GetRandomWordRequest getRandomWordRequest)
        {
            StringBuilder urlBuilder = new StringBuilder();
            urlBuilder.Append(_getWordnikBaseUrlQuery.Query());
            urlBuilder.Append(RandomWordPath);

            var args = GetArgs(getRandomWordRequest).ToList();
            if (args.Any())
            {
                urlBuilder.Append("?");
                urlBuilder.Append(string.Join("&", args));
            }

            var url = urlBuilder.ToString();
            return url;
        }

        private IEnumerable<string> GetArgs(GetRandomWordsRequest getRandomWordsRequest)
        {
          
            yield return WordnikUrlHelper.GetMinCorpusCountArgument(getRandomWordsRequest.MinCorpusCount);
            yield return WordnikUrlHelper.GetMaxCorpusCountArgument(getRandomWordsRequest.MaxCorpusCount);
            foreach (var arg in WordnikUrlHelper.GetWithDictionaryDefinitionArguments(getRandomWordsRequest.WithDictionaryDefinitions)) yield return arg;
            yield return WordnikUrlHelper.GetMinimumDictionaryCountArgument(getRandomWordsRequest.MinimumDictionaryCount);
            yield return WordnikUrlHelper.GetMaximumDictionaryCountArgument(getRandomWordsRequest.MaximumDictionaryCount);
            yield return WordnikUrlHelper.GetMaximumLengthArgument(getRandomWordsRequest.MaximumLength);
            yield return WordnikUrlHelper.GetMinimumLengthArgument(getRandomWordsRequest.MinimumLength);
            foreach (var arg in WordnikUrlHelper.GetSortByArguments(getRandomWordsRequest.SortBy)) yield return arg;
            foreach (var arg in WordnikUrlHelper.GetSortOrderArguments(getRandomWordsRequest.SortOrder)) yield return arg;
            foreach (var arg in WordnikUrlHelper.GetExpludePartsOfSpeechArguments(getRandomWordsRequest.ExcludePartsOfSpeech)) yield return arg;
            foreach (var arg in WordnikUrlHelper.GetIncludePartsOfSpeechArguments(getRandomWordsRequest.IncludePartsOfSpeech)) yield return arg;
            yield return WordnikUrlHelper.GetLimitArgument(getRandomWordsRequest.Limit);
            yield return WordnikUrlHelper.GetApiKeyArgument(getRandomWordsRequest.ApiKey);
        }
        private IEnumerable<string> GetArgs(GetRandomWordRequest getRandomWordRequest)
        {
            yield return WordnikUrlHelper.GetMinCorpusCountArgument(getRandomWordRequest.MinCorpusCount);
            yield return WordnikUrlHelper.GetMaxCorpusCountArgument(getRandomWordRequest.MaxCorpusCount);
            foreach (var arg in WordnikUrlHelper.GetWithDictionaryDefinitionArguments(getRandomWordRequest.WithDictionaryDefinitions)) yield return arg;
            yield return WordnikUrlHelper.GetMinimumDictionaryCountArgument(getRandomWordRequest.MinimumDictionaryCount);
            yield return WordnikUrlHelper.GetMaximumDictionaryCountArgument(getRandomWordRequest.MaximumDictionaryCount);
            yield return WordnikUrlHelper.GetMaximumLengthArgument(getRandomWordRequest.MaximumLength);
            yield return WordnikUrlHelper.GetMinimumLengthArgument(getRandomWordRequest.MinimumLength);
            foreach (var arg in WordnikUrlHelper.GetExpludePartsOfSpeechArguments(getRandomWordRequest.ExcludePartsOfSpeech)) yield return arg;
            foreach (var arg in WordnikUrlHelper.GetIncludePartsOfSpeechArguments(getRandomWordRequest.IncludePartsOfSpeech)) yield return arg;
            yield return WordnikUrlHelper.GetApiKeyArgument(getRandomWordRequest.ApiKey);
        }
    }
}