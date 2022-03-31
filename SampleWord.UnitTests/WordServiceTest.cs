using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SampleWord.Entities;
using SampleWord.Repositories;
using SampleWord.Services;
using SampleWord.Services.AutoMapper;
using System.Collections.Generic;

namespace SampleWord.UnitTests
{
    [TestClass]
    public class WordServiceTest
    {
        Mock<IWordRepository> wordRepoObj;
        Mock<AutoMapperProfile> _mapper = new Mock<AutoMapperProfile>();
        Word word;
        WordData wordData;

        [TestInitialize]
        public void InitializeForTests()
        {
            wordRepoObj = new Mock<IWordRepository>();
            word = new Word()
            {
                word_id = 1,
                word_param = "Example",
                is_deleted = false,
                updated_at = null,
                deleted_at = null
            };
            wordData = new WordData()
            {
                WordId = 1,
                WordParam = "Example",
                IsDeleted = false,
                UpdatedAt = null,
                DeletedAt = null
            };

        }

        [TestMethod]
        public void GetAllWordsAsync_Returns_TypeOfListOfWord()
        {
            
            List<Word> tempWord = new List<Word>();
            wordRepoObj.Setup(p => p.GetAllWordsAsync()).Returns(tempWord);
            WordService wordService = new WordService(wordRepoObj.Object, _mapper.Object);
            var result = wordService.GetAllWordsAsync();
            Assert.IsInstanceOfType(result, typeof(List<WordData>));
            
        }

        [TestMethod]
        public void AddWordAsync_Returns_TrueOrFalse()
        {
            wordRepoObj.Setup(p => p.AddWordAsync(word)).Returns(true);
            WordService wordService = new WordService(wordRepoObj.Object, _mapper.Object);
            var result = wordService.AddWordAsync(wordData);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveWordAsync_Returns_TrueOrFalse()
        {
            wordRepoObj.Setup(p => p.RemoveWordAsync(word)).Returns(false);
            WordService wordService = new WordService(wordRepoObj.Object, _mapper.Object);
            var result = wordService.RemoveWordAsync(wordData);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void UpdateWordAsync_Returns_TrueOrFalse()
        {
            wordRepoObj.Setup(p => p.UpdateWordAsync(word)).Returns(true);
            WordService wordService = new WordService(wordRepoObj.Object, _mapper.Object);
            var result = wordService.UpdateWordAsync(wordData);
            Assert.AreEqual(false,result);
        }

        [TestMethod]
        public void GetWordById_Returns_TypeOfWord() 
        {
            wordRepoObj.Setup(p => p.GetWordById(1)).Returns(word);
            WordService wordService = new WordService(wordRepoObj.Object, _mapper.Object);
            var result = wordService.GetWordById(1);
            Assert.IsInstanceOfType(result, typeof(WordData));
        }
    }
}
