using Newtonsoft.Json;

namespace WordsApi.Model
{
    [JsonObject]
    public class TextPron {
        [JsonProperty("raw")]
        public string Raw { get; set; }
        [JsonProperty("seq")]
        public int Seq { get; set; }
        [JsonProperty("rawType")]
        public string RawType { get; set; }
    }
}