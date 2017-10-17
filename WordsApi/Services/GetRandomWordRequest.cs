using System.Collections.Generic;
using WordsApi.Model;

namespace WordsApi.Services
{
    public class GetRandomWordRequest
    {
        public GetRandomWordRequest(string apiKey)
        {
            ApiKey = apiKey;
            IncludePartsOfSpeech = new List<PartOfSpeech>();
            ExcludePartsOfSpeech = new List<PartOfSpeech>();
            WithDictionaryDefinitions = true;
        }

        public string ApiKey { get; private set; }

        /// <summary>
        /// Only return words with dictionary definitions
        /// </summary>
        public bool WithDictionaryDefinitions { get; set; }

        /// <summary>
        /// Minimum dictionary count
        /// </summary>
        public int? MinimumDictionaryCount { get; set; }

        /// <summary>
        /// Maximum dictionary count
        /// </summary>
        public int? MaximumDictionaryCount { get; set; }

        /// <summary>
        /// Minimum word length
        /// </summary>
        public int? MinimumLength { get; set; }

        /// <summary>
        /// Maximum word length
        /// </summary>
        public int? MaximumLength { get; set; }

        /// <summary>
        /// Minimum corpus frequency for terms
        /// </summary>
        public int? MinCorpusCount { get; set; }

        /// <summary>
        /// Maximum corpus frequency for terms
        /// </summary>
        public int? MaxCorpusCount { get; set; }

        /// <summary>
        /// CSV part-of-speech values to include
        /// </summary>
        public List<PartOfSpeech> IncludePartsOfSpeech { get; set; }

        /// <summary>
        /// CSV part-of-speech values to exclude
        /// </summary>
        public List<PartOfSpeech> ExcludePartsOfSpeech { get; set; }
    }
}