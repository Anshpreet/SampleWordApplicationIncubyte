using SampleWord.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleWord.Repositories;
using AutoMapper;
using SampleWord.Services.AutoMapper;

namespace SampleWord.Services
{
    public class WordService : IWordService
    {
        private IWordRepository _wordRepository;
        AutoMapperProfile _mapper;
        public WordService(IWordRepository wordRepository, AutoMapperProfile mapper)
        {
            _wordRepository = wordRepository;
            _mapper = mapper;
        }
        public bool AddWordAsync(WordData word)
        {
            Word tempWord = _mapper.WordDataToWord(word);
            bool result= _wordRepository.AddWordAsync(tempWord);
            return result;
        }

        public List<WordData> GetAllWordsAsync()
        {
            List<Word> wordsList= _wordRepository.GetAllWordsAsync();
            return _mapper.WordDataListToWordList(wordsList);
        }

        public bool RemoveWordAsync(WordData word)
        {
            Word tempWord = _mapper.WordDataToWord(word);
            bool result =  _wordRepository.RemoveWordAsync(tempWord);
            return result;
        }

        public bool UpdateWordAsync(WordData word)
        {
            Word tempWord = _mapper.WordDataToWord(word);
            bool result =  _wordRepository.UpdateWordAsync(tempWord);
            return result;
        }
        public WordData GetWordById(int id)
        {
            Word word =  _wordRepository.GetWordById(id);
            WordData result= _mapper.WordToWordData(word);
            return result;
        }
    }
}
