using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordsApi.Model;
using WordsApi.Model.Extensions;

namespace WordsApi.Services.Helpers
{
    public static class WordnikUrlHelper
    {
        public static string GetMaxCorpusCountArgument(int? maxCorpusCount)
        {
            if (maxCorpusCount != null)
            {
                return string.Format("maxCorpusCount={0}", maxCorpusCount);
            }
            return string.Format("maxCorpusCount=-1");
        }

        public static string GetMinCorpusCountArgument(int? minCorpusCount)
        {
            if (minCorpusCount != null)
            {
                return string.Format("minCorpusCount={0}", minCorpusCount);
            }
            return string.Format("minCorpusCount=-1");
        }

        public static IEnumerable<string> GetDateArguments(DateTime? date)
        {
            if (date != null)
            {
                yield return string.Format("date={0:yyyy-MM-dd}", date);
            }
        }

        public static IEnumerable<string> GetWithDictionaryDefinitionArguments(bool withDictionaryDefinitions)
        {
            if (!withDictionaryDefinitions) //true by default
            {
                yield return string.Format("hasDictionaryDef=false");
            }
        }
        public static IEnumerable<string> GetCaseSensitiveArguments(bool caseSensitive)
        {
            if (!caseSensitive) //true by default
            {
                yield return string.Format("caseSensitive=false");
            }
        }

        public static string GetMinimumDictionaryCountArgument(int? minimumDictionaryCount)
        {
            if (minimumDictionaryCount != null)
            {
                return string.Format("minDictionaryCount={0}", minimumDictionaryCount);
            }
            return string.Format("minDictionaryCount=-1");
        }

        public static string GetMaximumDictionaryCountArgument(int? maximumDictionaryCount)
        {
            if (maximumDictionaryCount != null)
            {
                return string.Format("maxDictionaryCount={0}", maximumDictionaryCount);
            }
            return string.Format("maxDictionaryCount=-1");
        }

        public static string GetMaximumLengthArgument(int? maximumLength)
        {
            if (maximumLength != null)
            {
                return string.Format("maxLength={0}", maximumLength);
            }
            return string.Format("maxLength=-1");
        }

        public static string GetMinimumLengthArgument(int? minimumLength)
        {
            if (minimumLength != null)
            {
                return string.Format("minLength={0}", minimumLength);
            }
            return string.Format("minLength=-1");
        }

        public static IEnumerable<string> GetSortByArguments(Sorting? sortBy)
        {
            switch (sortBy)
            {
                case Sorting.Alpha:
                    yield return string.Format("sortBy=alpha");
                    break;
                case Sorting.Count:
                    yield return string.Format("sortBy=count");
                    break;
                case null:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static IEnumerable<string> GetSortOrderArguments(SortOrder? sortOrder)
        {
            switch (sortOrder)
            {
                case SortOrder.Ascending:
                    yield return string.Format("sortOrder=asc");
                    break;
                case SortOrder.Descending:
                    yield return string.Format("sortOrder=desc");
                    break;
                case null:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static string GetApiKeyArgument(string apiKey)
        {
            return string.Format("api_key={0}", apiKey);
        }

        public static string GetLimitArgument(int limit)
        {
            return string.Format("limit={0}", limit);
        }

        public static IEnumerable<string> GetExpludePartsOfSpeechArguments(List<PartOfSpeech> partsOfSpeech)
        {
            //https://github.com/jeremybrooks/knicker/pull/5
            //if (partsOfSpeech != null && partsOfSpeech.Any())
            //{
            //    var excludeStringBuilder = new StringBuilder();

            //    excludeStringBuilder.Append("exludePartOfSpeech=");
            //    List<string> excludedPartsOfSpeech = new List<string>();
            //    foreach (var excludedPartOfSpeech in partsOfSpeech.Distinct())
            //    {
            //        excludedPartsOfSpeech.Add(excludedPartOfSpeech.ConvertToWorknikName());
            //    }
            //    excludeStringBuilder.Append(string.Join(",", excludedPartsOfSpeech));
            //    yield return excludeStringBuilder.ToString();
            //}

            if (partsOfSpeech != null && partsOfSpeech.Any())
            {
                foreach (var excludedPartOfSpeech in partsOfSpeech.Distinct())
                {
                    yield return string.Format("exludePartOfSpeech={0}", excludedPartOfSpeech.ConvertToWorknikName());
                }
            }
        }

        public static IEnumerable<string> GetIncludePartsOfSpeechArguments(List<PartOfSpeech> partsOfSpeech)
        {
            //https://github.com/jeremybrooks/knicker/pull/5
            //if (partsOfSpeech != null && partsOfSpeech.Any())
            //{
            //    var includeStringBuilder = new StringBuilder();

            //    includeStringBuilder.Append("includePartOfSpeech=");
            //    List<string> includedPartsOfSpeech = new List<string>();
            //    foreach (var incluidedPartOfSpeech in partsOfSpeech.Distinct())
            //    {
            //        includedPartsOfSpeech.Add(incluidedPartOfSpeech.ConvertToWorknikName());
            //    }
            //    includeStringBuilder.Append(string.Join(",", includedPartsOfSpeech));
            //    yield return includeStringBuilder.ToString();
            //}
            if (partsOfSpeech != null && partsOfSpeech.Any())
            {
                foreach (var partOfSpeech in partsOfSpeech.Distinct())
                {
                    yield return string.Format("includePartOfSpeech={0}", partOfSpeech.ConvertToWorknikName());
                }
            }
        }

        public static string GetSkipArgument(int skip)
        {
            return string.Format("skip={0}", skip);
        }


        public static string GetQueryArgument(string query)
        {
            return string.Format("query={0}", query);
        }

        public static IEnumerable<string> GetFindSenseForWordArgument(string findSenseForWord)
        {
            if (findSenseForWord != null)
            {
                yield return string.Format("findSenseForWord={0}", findSenseForWord);
            }
        }

        public static IEnumerable<string> GetExpandTermsArguments(ExpandTerms? expandTerms)
        {
            switch (expandTerms)
            {
                case ExpandTerms.Synonym:
                    yield return string.Format("expandTerms={0}", "synonym");
                    break;
                case ExpandTerms.Hypernym:
                    yield return string.Format("expandTerms={0}", "hypernym");
                    break;
                case null:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(expandTerms), expandTerms, null);
            }
        }

        public static IEnumerable<string> GetWithIncludeSourceDictionaryArguments(List<string> includeSourceDictionary)
        {
            if (includeSourceDictionary != null && includeSourceDictionary.Any())
            {
                var includeStringBuilder = new StringBuilder();

                includeStringBuilder.Append("includeSourceDictionaries=");
                List<string> includedSourceDictionaries = new List<string>();
                foreach (var includedSourceDictionary in includeSourceDictionary.Distinct())
                {
                    includedSourceDictionaries.Add(includedSourceDictionary);
                }
                includeStringBuilder.Append(string.Join(",", includedSourceDictionaries));
                yield return includeStringBuilder.ToString();
            }
        }

        public static IEnumerable<string> GetWithExcludeSourceDictionaryArguments(List<string> excludeSourceDictionary)
        {
            if (excludeSourceDictionary != null && excludeSourceDictionary.Any())
            {
                var stringBuilder = new StringBuilder();

                stringBuilder.Append("excludeSourceDictionaries=");
                List<string> values = new List<string>();
                foreach (var sourceDictionary in excludeSourceDictionary.Distinct())
                {
                    values.Add(sourceDictionary);
                }
                stringBuilder.Append(string.Join(",", values));
                yield return stringBuilder.ToString();
            }
        }
    }
}