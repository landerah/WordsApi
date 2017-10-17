using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordsApi.Model
{
    [JsonObject]
    public class Related
    {
        [JsonProperty("label1")]
        public string Label1 { get; set; }
        [JsonProperty("relationshipType")]
        public string RelationshipType { get; set; }
        [JsonProperty("label2")]
        public string Label2 { get; set; }
        [JsonProperty("label3")]
        public string Label3 { get; set; }
        [JsonProperty("words")]
        public List<string> Words { get; set; }
        [JsonProperty("gram")]
        public string Gram { get; set; }
        [JsonProperty("label4")]
        public string Label4 { get; set; }
    }
}