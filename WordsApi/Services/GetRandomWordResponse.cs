using WordsApi.Model;

namespace WordsApi.Services
{
    public class GetRandomWordResponse
    {
        public GetRandomWordResponse(WordResponse word)
        {
            Word = word;
        }

        public WordResponse Word { get; private set; }
    }
}