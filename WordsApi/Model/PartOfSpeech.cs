using System.Runtime.Serialization;

namespace WordsApi.Model
{
    public enum PartOfSpeech
    {
        Verb,
        Adjective,
        Noun,
        Adverb,
        Interjection,
        Pronoun,
        Preposition,
        Abbreviation,
        Affix,
        Article,
        [EnumMember(Value = "auxilliary-verb")]
        AuxilliaryVerb,
        Conjunction,
        [EnumMember(Value = "definite-article")]
        DefiniteArticle,
        FamilyName,
        GivenName,
        Idiom,
        Imperative,
        [EnumMember(Value = "noun-plural")]
        NounPlural,
        [EnumMember(Value = "noun-possessive")]
        NounPossessive,
        [EnumMember(Value = "past-participle")]
        PastParticiple,
        [EnumMember(Value = "phrasal-prefix")]
        PhrasalPrefix,
        [EnumMember(Value = "proper-noun")]
        ProperNoun,
        [EnumMember(Value = "proper-noun-plural")]
        ProperNounPlural,
        [EnumMember(Value = "proper-noun-possessive")]
        ProperNounPossesive,
        [EnumMember(Value = "verb-intransitive")]
        VerbIntransitive,
        [EnumMember(Value = "verb-transitive")]
        VerbTransitive,
        Suffix
    }
}