using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleWord.Entities;

namespace SampleWord.Services
{
    public interface IWordService
    {
        List<WordData> GetAllWordsAsync();
        WordData GetWordById(int id);
        bool AddWordAsync(WordData word);
        bool UpdateWordAsync(WordData word);
        bool RemoveWordAsync(WordData word);
    }
}
