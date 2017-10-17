namespace WordsApi.Services
{
    public interface IRandomWordsService
    {
        GetRandomWordsResponse GetRandomWords(GetRandomWordsRequest getRandomWordsRequest);
        GetRandomWordResponse GetRandomWord(GetRandomWordRequest getRandomWordRequest);
    }
}
