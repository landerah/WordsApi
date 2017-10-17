using System;
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
    public class ReverseDictionaryService : IReverseDictionaryService
    {
        private readonly IGetWordnikBaseUrlQuery _getWordnikBaseUrlQuery;

        private static string ReverseDictionaryPath = @"/words.json/reverseDictionary";

        public ReverseDictionaryService(IGetWordnikBaseUrlQuery getWordnikBaseUrlQuery)
        {
            _getWordnikBaseUrlQuery = getWordnikBaseUrlQuery;
        }

        public ReverseDictionaryResponse ReverseDictionarySearch(ReverseDictionaryRequest reverseDictionaryRequest)
        {
            var url = GetRandomWordUrl(reverseDictionaryRequest);

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

        private string GetRandomWordUrl(ReverseDictionaryRequest reverseDictionaryRequest)
        {
            StringBuilder urlBuilder = new StringBuilder();
            urlBuilder.Append(_getWordnikBaseUrlQuery.Query());
            urlBuilder.Append(ReverseDictionaryPath);

            var args = GetArgs(reverseDictionaryRequest).ToList();
            if (args.Any())
            {
                urlBuilder.Append("?");
                urlBuilder.Append(string.Join("&", args));
            }

            var url = urlBuilder.ToString();
            return url;
        }

        private IEnumerable<string> GetArgs(ReverseDictionaryRequest getRandomWordsRequest)
        {

            yield return WordnikUrlHelper.GetQueryArgument(getRandomWordsRequest.Query);
            foreach (var arg in WordnikUrlHelper.GetFindSenseForWordArgument(getRandomWordsRequest.FindSenseForWord)) yield return arg;
            foreach (var arg in WordnikUrlHelper.GetWithIncludeSourceDictionaryArguments(getRandomWordsRequest.IncludeSourceDictionary)) yield return arg;
            foreach (var arg in WordnikUrlHelper.GetWithExcludeSourceDictionaryArguments(getRandomWordsRequest.ExcludeSourceDictionary)) yield return arg;
            yield return WordnikUrlHelper.GetMinCorpusCountArgument(getRandomWordsRequest.MinCorpusCount);
            yield return WordnikUrlHelper.GetMaxCorpusCountArgument(getRandomWordsRequest.MaxCorpusCount);
            yield return WordnikUrlHelper.GetMaximumLengthArgument(getRandomWordsRequest.MinimumLength);
            yield return WordnikUrlHelper.GetMinimumLengthArgument(getRandomWordsRequest.MaximumLength);
            yield return WordnikUrlHelper.GetMinimumLengthArgument(getRandomWordsRequest.MaximumLength);
            foreach (var arg in WordnikUrlHelper.GetSortByArguments(getRandomWordsRequest.SortBy)) yield return arg;
            foreach (var arg in WordnikUrlHelper.GetExpandTermsArguments(getRandomWordsRequest.ExpandTerms)) yield return arg;
            foreach (var arg in WordnikUrlHelper.GetSortOrderArguments(getRandomWordsRequest.SortOrder)) yield return arg;
            foreach (var arg in WordnikUrlHelper.GetExpludePartsOfSpeechArguments(getRandomWordsRequest.ExcludePartsOfSpeech)) yield return arg;
            foreach (var arg in WordnikUrlHelper.GetIncludePartsOfSpeechArguments(getRandomWordsRequest.IncludePartsOfSpeech)) yield return arg;
            yield return WordnikUrlHelper.GetLimitArgument(getRandomWordsRequest.Limit);
            yield return WordnikUrlHelper.GetApiKeyArgument(getRandomWordsRequest.ApiKey);
        }
    }

    public class ReverseDictionaryResponse
    {
    }
}
