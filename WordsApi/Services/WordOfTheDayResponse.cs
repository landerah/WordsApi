using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordsApi.Services
{
    [JsonObject]
    public class WordOfTheDayResponse
    {
        [JsonProperty("id")]
        public long Id { get; private set; }

        [JsonProperty("parentId")]
        public string ParentId { get; private set; }

        [JsonProperty("category")]
        public string Category { get; private set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; private set; }

        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; private set; }

        [JsonProperty("contentProvider")]
        public ContentProvider ContentProvider { get; private set; }

        [JsonProperty("htmlExtra")]
        public string HtmlExtra { get; private set; }

        [JsonProperty("word")]
        public string Word { get; private set; }

        [JsonProperty("definitions")]
        public List<SimpleDefinition> Definitions { get; private set; } = new List<SimpleDefinition>();

        [JsonProperty("examples")]
        public List<SimpleExample> Examples { get; private set; } = new List<SimpleExample>();

        [JsonProperty("note")]
        public string Note { get; private set; }

        [JsonProperty("publishDate")]
        public DateTime? PublishDate { get; private set; }
    }
}