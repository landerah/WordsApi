using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordsApi.Services
{
    [JsonObject]
    public class SearchResults
    {
        [JsonProperty("totalResults")]
        public int? TotalNumberOfResults { get; private set; }
        [JsonProperty("searchResults")]
        public List<SearchResult> SearchResultList { get; private set; } = new List<SearchResult>();
    }
}