using Newtonsoft.Json;

namespace WordsApi.Services
{
    [JsonObject]
    public class SearchResult
    {
        [JsonProperty("count")]
        public long? Count { get; private set; }
        [JsonProperty("lexicality")]
        public double? Lexicality { get; private set; }
        [JsonProperty("word")]
        public string Word { get; private set; }
    }
}