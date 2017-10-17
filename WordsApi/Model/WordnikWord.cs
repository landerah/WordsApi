using System;
using Newtonsoft.Json;

namespace WordsApi.Model
{
    [JsonObject]
    public class WordnikWord
    {
        [JsonProperty(PropertyName = "word")]
        public string Word { get; set; }

        [JsonProperty(PropertyName = "id")]
        public long Id { get; set; }

        [JsonProperty(PropertyName = "originalWord")]
        public string OriginalWord { get; set; }

        [JsonProperty(PropertyName = "suggestions")]
        public string[] Suggestions { get; set; }

        [JsonProperty(PropertyName = "canonicalForm")]
        public string CanonicalForm { get; set; }

        [JsonProperty(PropertyName = "vulgar")]
        public string Vulgar { get; set; }
    }
}