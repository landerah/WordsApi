using System;

namespace WordsApi.Model.Extensions
{
    public static class PartOfSpeechExtensions {
        public static string ConvertToWorknikName(this PartOfSpeech partOfSpeech)
        {
            switch (partOfSpeech)
            {
                case PartOfSpeech.Verb:
                    return "verb";
                case PartOfSpeech.Adjective:
                    return "adjective";
                case PartOfSpeech.Noun:
                    return "noun";
                case PartOfSpeech.Adverb:
                    return "adverb";
                case PartOfSpeech.Interjection:
                    return "interjection";
                case PartOfSpeech.Pronoun:
                    return "pronoun";
                case PartOfSpeech.Preposition:
                    return "preposition";
                case PartOfSpeech.Abbreviation:
                    return "abbreviation";
                case PartOfSpeech.Affix:
                    return "affix";
                case PartOfSpeech.Article:
                    return "article";
                case PartOfSpeech.AuxilliaryVerb:
                    return "auxilliary-verb";
                case PartOfSpeech.Conjunction:
                    return "conjunction";
                case PartOfSpeech.DefiniteArticle:
                    return "definite-article";
                case PartOfSpeech.FamilyName:
                    return "family-name";
                case PartOfSpeech.GivenName:
                    return "given-name";
                case PartOfSpeech.Idiom:
                    return "idiom";
                case PartOfSpeech.Imperative:
                    return "imperative";
                case PartOfSpeech.NounPlural:
                    return "noun-plural";
                case PartOfSpeech.NounPossessive:
                    return "noun-possessive";
                case PartOfSpeech.PastParticiple:
                    return "past-participle";
                case PartOfSpeech.PhrasalPrefix:
                    return "phrasal-prefix";
                case PartOfSpeech.ProperNoun:
                    return "proper-noun";
                case PartOfSpeech.ProperNounPlural:
                    return "proper-noun-plural";
                case PartOfSpeech.ProperNounPossesive:
                    return "proper-noun-possessive";
                case PartOfSpeech.VerbIntransitive:
                    return "verb-intransitive";
                case PartOfSpeech.VerbTransitive:
                    return "verb-transitive";
                case PartOfSpeech.Suffix:
                    return "suffix";
                default:
                    throw new ArgumentOutOfRangeException(nameof(partOfSpeech), partOfSpeech, null);
            }
        }
    }
}