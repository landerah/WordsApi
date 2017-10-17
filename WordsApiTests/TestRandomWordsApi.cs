using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using NUnit.Framework;
using WordsApi;
using WordsApi.Model;
using WordsApi.Queries;
using WordsApi.Services;

namespace WordsApiTests
{
    [TestFixture]   
    public class TestRandomWordsApi
    {
        [Test]
        public void CanGetRandomNouns()
        {
            var request = new GetRandomWordsRequest("");
            request.MinCorpusCount = 100000;
            request.ExcludePartsOfSpeech = new List<PartOfSpeech>() {PartOfSpeech.ProperNoun, PartOfSpeech.ProperNounPlural, PartOfSpeech.ProperNounPossesive, PartOfSpeech.Suffix, PartOfSpeech.FamilyName, PartOfSpeech.GivenName, PartOfSpeech.Idiom, PartOfSpeech.Affix, PartOfSpeech.NounPlural, PartOfSpeech.NounPossessive};
            request.IncludePartsOfSpeech = new List<PartOfSpeech>() {PartOfSpeech.Noun};
            request.Limit = 25;
            request.MaximumLength = 10;

            var service = new RandomWordsService(new GetWordnikBaseUrlQuery());
            var response = service.GetRandomWords(request);
            Console.WriteLine(string.Join(", ", response.Words.Select(w => w.Word)));
        }
        [Test]
        public void CanGetRandomNoun()
        {
            var request = new GetRandomWordRequest("");
            request.MinCorpusCount = 100000;
            request.ExcludePartsOfSpeech = new List<PartOfSpeech>() {PartOfSpeech.ProperNoun, PartOfSpeech.ProperNounPlural, PartOfSpeech.ProperNounPossesive, PartOfSpeech.Suffix, PartOfSpeech.FamilyName, PartOfSpeech.GivenName, PartOfSpeech.Idiom, PartOfSpeech.Affix, PartOfSpeech.NounPlural, PartOfSpeech.NounPossessive};
            request.IncludePartsOfSpeech = new List<PartOfSpeech>() {PartOfSpeech.Noun};
            request.MaximumLength = 10;

            var service = new RandomWordsService(new GetWordnikBaseUrlQuery());
            var response = service.GetRandomWord(request);
            Console.WriteLine(response.Word.Word);
        }
        [Test]
        public void CanGetSearchWords()
        {
            var request = new WordSearchRequest("s", "");
            request.ExcludePartsOfSpeech = new List<PartOfSpeech>() {PartOfSpeech.ProperNoun, PartOfSpeech.ProperNounPlural, PartOfSpeech.ProperNounPossesive, PartOfSpeech.Suffix, PartOfSpeech.FamilyName, PartOfSpeech.GivenName, PartOfSpeech.Idiom, PartOfSpeech.Affix, PartOfSpeech.NounPlural, PartOfSpeech.NounPossessive};
            request.IncludePartsOfSpeech = new List<PartOfSpeech>() {PartOfSpeech.Noun};
            request.MaximumLength = 10;

            var service = new WordSearchService(new GetWordnikBaseUrlQuery());
            var response = service.SearchWords(request);
            Console.WriteLine("Num Results = "+ response.TotalNumberOfResults +", " + string.Join(", ", response.SearchResultList.Select(w => w.Word)));
        }
        [Test]
        public void CanGetWordOfTheDay()
        {
            var request = new WordOfTheDayRequest("", new DateTime(2016, 12, 23));

            var service = new WordOfTheDayService(new GetWordnikBaseUrlQuery());
            var response = service.GetWordOfTheDay(request);
            Console.WriteLine(JsonConvert.SerializeObject(response));
        }
        [Test]
        public void CanGetDicitonarySearch()
        {
            var request = new ReverseDictionaryRequest("", "sa");

            var service = new ReverseDictionaryService(new GetWordnikBaseUrlQuery());
            var response = service.ReverseDictionarySearch(request);
            Console.WriteLine(JsonConvert.SerializeObject(response));
        }
    }
}
