using Newtonsoft.Json;

namespace WordsApi.Model
{
    [JsonObject]
    public class Label
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}