using Newtonsoft.Json;

namespace WordsApi.Model
{
    [JsonObject]
    public class Citation
    {
        [JsonProperty("cite")]
        public string Cite { get; set; }
        [JsonProperty("source")]
        public string Source { get; set; }
    }
}