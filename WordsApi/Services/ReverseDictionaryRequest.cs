using System.Collections.Generic;
using WordsApi.Model;

namespace WordsApi.Services
{
    public class ReverseDictionaryRequest
    {
        public ReverseDictionaryRequest(string apiKey, string query)
        {
            Query = query;
            MinCorpusCount = 1;
            MinimumLength = 1;
            Limit = 10;
            ApiKey = apiKey;
        }
        public string ApiKey { get; private set; }
        /// <summary>
        /// Search term
        /// </summary>
        public string Query { get; private set; }
        /// <summary>
        /// Restricts words and finds closest sense
        /// </summary>
        public string FindSenseForWord { get; set; }
        /// <summary>
        /// Only include these source dictionaries
        /// </summary>
        public List<string> IncludeSourceDictionary { get; set; }
        /// <summary>
        /// Exclude these source dictionaries
        /// </summary>
        public List<string> ExcludeSourceDictionary { get; set; }
        /// <summary>
        /// Only include these parts of speech
        /// </summary>
        public List<PartOfSpeech> IncludePartsOfSpeech { get; set; }
        /// <summary>
        /// Exclude these parts of speech
        /// </summary>
        public List<PartOfSpeech> ExcludePartsOfSpeech { get; set; }
        /// <summary>
        /// Minimum corpus frequency for terms
        /// </summary>
        public int MinCorpusCount { get; set; }
        /// <summary>
        /// Maximum corpus frequency for terms
        /// </summary>
        public int? MaxCorpusCount { get; set; }
        /// <summary>
        /// Minimum word length
        /// </summary>
        public int MinimumLength { get; set; }
        /// <summary>
        /// Maximum word length
        /// </summary>
        public int? MaximumLength { get; set; }
        /// <summary>
        /// Expand terms
        /// </summary>
        public ExpandTerms? ExpandTerms { get; set; }
        // TODO: Implement returning the tags.
        ///// <summary>
        ///// Return a tags in response
        ///// </summary>
        //public bool IncludeTags { get; set; }
        /// <summary>
        /// Attribute to sort by
        /// </summary>
        public Sorting SortBy { get; set; }
        /// <summary>
        /// Sort direction
        /// </summary>
        public SortOrder SortOrder { get; set; }
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