using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordsApi.Model
{
    [JsonObject]
    public class WordnikWordList
    {
        [JsonProperty(PropertyName="list")]
        public List<WordnikWord> List { get; set; }= new List<WordnikWord>();
    }
}