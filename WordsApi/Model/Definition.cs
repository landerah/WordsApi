using System.Collections.Generic;
using Newtonsoft.Json;

namespace WordsApi.Model
{
    [JsonObject]
    public class Definition
    {
        [JsonProperty("extendedText")]
        public string ExtendedText { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("sourceDictionary")]
        public string SourceDictionary { get; set; }
        [JsonProperty("citations")]
        public List<Citation> Citations { get; set; }
        [JsonProperty("labels")]
        public List<Label> Labels { get; set; }
        [JsonProperty("score")]
        public float Score { get; set; }
        [JsonProperty("exampleUses")]
        public List<ExampleUsage> ExampleUses { get; set; }
        [JsonProperty("attributionUrl")]
        public string AttributionUrl { get; set; }
        [JsonProperty("seqString")]
        public string SeqString { get; set; }
        [JsonProperty("attributionText")]
        public string AttributionText { get; set; }
        [JsonProperty("relatedWords")]
        public List<Related> RelatedWords { get; set; }
        [JsonProperty("sequence")]
        public string Sequence { get; set; }
        [JsonProperty("word")]
        public string Word { get; set; }
        [JsonProperty("notes")]
        public List<Note> Notes { get; set; }
        [JsonProperty("textProns")]
        public List<TextPron> TextProns { get; set; }
        [JsonProperty("partOfSpeech")]
        public string PartOfSpeech { get; set; }
    }
}