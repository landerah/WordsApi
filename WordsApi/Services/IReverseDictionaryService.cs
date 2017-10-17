namespace WordsApi.Services
{
    public interface IReverseDictionaryService
    {
        ReverseDictionaryResponse ReverseDictionarySearch(ReverseDictionaryRequest reverseDictionaryRequest);
    }
}