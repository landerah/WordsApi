using Newtonsoft.Json;

namespace WordsApi.Services
{
    [JsonObject]
    public class SimpleExample
    {
        [JsonProperty("id")]
        public long? Id { get; private set; }
        [JsonProperty("title")]
        public string Title { get; private set; }
        [JsonProperty("text")]
        public string Text { get; private set; }
        [JsonProperty("url")]
        public string Url { get; private set; }
    }
}