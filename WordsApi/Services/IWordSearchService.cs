namespace WordsApi.Services
{
    public interface IWordSearchService
    {
        SearchResults SearchWords(WordSearchRequest wordSearchRequest);
    }
}