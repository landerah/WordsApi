using Newtonsoft.Json;

namespace WordsApi.Model
{
    [JsonObject]
    public class ExampleUsage
    {
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}