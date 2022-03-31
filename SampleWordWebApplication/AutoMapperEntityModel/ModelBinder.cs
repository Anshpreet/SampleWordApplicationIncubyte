using SampleWord.Entities;
using SampleWordWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWordWebApplication.AutoMapperEntityModel
{
    public class ModelBinder
    {
        public WordData WordModelToWordData(WordModel word)
        {
            return new WordData()
            {
                WordId = word.WordId,
                WordParam = word.WordParam,
                IsDeleted = word.IsDeleted,
                UpdatedAt = word.UpdatedAt,
                DeletedAt = word.DeletedAt,
            };
        }

        public WordModel WordDataToWordModel(WordData word)
        {
            return new WordModel()
            {
                WordId = word.WordId,
                WordParam = word.WordParam,
                IsDeleted = word.IsDeleted,
                UpdatedAt = word.UpdatedAt,
                DeletedAt = word.DeletedAt
            };
        }

        public List<WordModel> WordDataListToWordModelList(List<WordData> wordsList)
        {
            List<WordModel> wordModels = new List<WordModel>();
            foreach (var word in wordsList)
            {
                wordModels.Add(WordDataToWordModel(word));
            }
            return wordModels;

        }

        public List<WordData> WordModelListToWordDataList(List<WordModel> wordsList)
        {
            List<WordData> wordData = new List<WordData>();
            foreach (var word in wordsList)
            {
                wordData.Add(WordModelToWordData(word));
            }
            return wordData;
        }
    }
}