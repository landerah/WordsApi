using System;

namespace WordsApi.Services
{
    public class WordOfTheDayRequest
    {
        public WordOfTheDayRequest(string apiKey, DateTime date)
        {
            Date = date;
            ApiKey = apiKey;

        }

        public WordOfTheDayRequest(string apiKey)
        {
            ApiKey = apiKey;
        }

        public DateTime? Date { get; private set; }
        public string ApiKey { get; private set; }
    }
}