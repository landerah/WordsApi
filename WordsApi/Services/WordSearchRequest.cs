using System.Collections.Generic;
using WordsApi.Model;

namespace WordsApi.Services
{
    public class WordSearchRequest
    {
        public WordSearchRequest(string query, string apiKey)
        {
            Query = query;
            ApiKey = apiKey;
            IncludePartsOfSpeech = new List<PartOfSpeech>();
            ExcludePartsOfSpeech = new List<PartOfSpeech>();
            CaseSensitive = true;
        }

        public string ApiKey { get; private set; }

        /// <summary>
        /// Search query
        /// </summary>
        public string Query { get; set; }
        /// <summary>
        /// Search case sensitive
        /// </summary>
        public bool CaseSensitive { get; set; } 
        /// <summary>
        /// Only include these parts of speech
        /// </summary>
        public List<PartOfSpeech> IncludePartsOfSpeech { get; set; }
        /// <summary>
        /// Exclude these parts of speech
        /// </summary>
        public List<PartOfSpeech> ExcludePartsOfSpeech { get; set; }
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
        /// Results to skip
        /// </summary>
        public int Skip { get; set; }
        /// <summary>
        /// Maximum number of results to return
        /// </summary>
        public int Limit { get; set; }
    }
}