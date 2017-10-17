using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordsApi.Model
{
    [JsonObject]
    public class DefinitionSearchResults
    {
        public DefinitionSearchResults()
        {
            Results = new List<Definition>();
        }
        [JsonProperty("Results")]
        public List<Definition> Results { get; set; }
        [JsonProperty("totalResults")]
        public int TotalResults { get; set; }
    }
}