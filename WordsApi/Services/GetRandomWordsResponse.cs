using System.Collections.Generic;
using System.Linq;
using WordsApi.Model;

namespace WordsApi.Services
{
    public class GetRandomWordsResponse
    {
        public GetRandomWordsResponse(IEnumerable<WordResponse> words)
        {
            Words = words.ToList();
        }

        public List<WordResponse> Words { get; private set; }
    }
}