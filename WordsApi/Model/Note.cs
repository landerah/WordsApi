using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordsApi.Model
{
    [JsonObject]
    public class Note
    {
        [JsonProperty("noteType")]
        public string NoteType { get; set; }
        [JsonProperty("appliesTo")]
        public List<string> AppliesTo { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
        [JsonProperty("pos")]
        public int Pos { get; set; }
    }
}