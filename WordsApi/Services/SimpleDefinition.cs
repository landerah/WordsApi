using Newtonsoft.Json;
using WordsApi.Model;

namespace WordsApi.Services
{
    [JsonObject]
    public class SimpleDefinition
    {
        [JsonProperty("text")]
        public string Text { get; private set; }
        [JsonProperty("source")]
        public string Source { get; private set; }
        [JsonProperty("note")]
        public string Note { get; private set; }
        [JsonProperty("partOfSpeech")]
        public PartOfSpeech? PartOfSpeech { get; private set; }
    }
}