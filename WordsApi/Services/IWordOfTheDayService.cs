namespace WordsApi.Services
{
    public interface IWordOfTheDayService
    {
        WordOfTheDayResponse GetWordOfTheDay(WordOfTheDayRequest wordOfTheDayRequest);
    }
}