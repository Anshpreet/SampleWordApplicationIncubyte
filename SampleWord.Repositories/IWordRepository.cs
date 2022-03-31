using System.Collections.Generic;


namespace SampleWord.Repositories
{
    public interface IWordRepository
    {
        List<Word> GetAllWordsAsync(); 
        Word GetWordById(int id);
        bool AddWordAsync(Word word);
        bool UpdateWordAsync(Word word);
        bool RemoveWordAsync(Word word);

    }
}
