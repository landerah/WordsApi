using Newtonsoft.Json;

namespace WordsApi.Services
{
    [JsonObject]
    public class ContentProvider
    {
        [JsonProperty("id")]
        public int? Id { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }
    }
}