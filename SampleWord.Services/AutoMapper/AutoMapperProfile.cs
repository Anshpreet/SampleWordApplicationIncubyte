using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SampleWord.Entities;
using SampleWord.Repositories;

namespace SampleWord.Services.AutoMapper
{
    public class AutoMapperProfile 
    {
        
        public WordData WordToWordData(Word word)
        {
            return new WordData()
            {
                WordId = word.word_id,
                WordParam = word.word_param,
                IsDeleted = word.is_deleted,
                UpdatedAt = word.updated_at,
                DeletedAt = word.deleted_at,
            };
        }

        public Word WordDataToWord (WordData word)
        {
            return new Word()
            {
                word_id = word.WordId,
                word_param = word.WordParam,
                is_deleted = word.IsDeleted,
                updated_at = word.UpdatedAt,
                deleted_at = word.DeletedAt
            };
        }

        internal List<WordData> WordDataListToWordList(List<Word> wordsList)
        {
            List<WordData> wordDataList = new List<WordData>();
            foreach (Word word in wordsList)
            {
                wordDataList.Add(WordToWordData(word));
            }
            return wordDataList;
        }
    }
}
