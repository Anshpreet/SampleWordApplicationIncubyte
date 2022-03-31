using System.Collections.Generic;
using System.Web.Mvc;
using SampleWord.Services;
using SampleWord.Entities;
using SampleWordWebApplication.Models;
using SampleWordWebApplication.AutoMapperEntityModel;
using System;

namespace SampleWordWebApplication.Controllers
{
    public class WordController : Controller
    {
        static int wordId=0;
        private IWordService _wordService;
        ModelBinder _mapper;
        public WordController(IWordService wordService, ModelBinder mapper)
        {
            _wordService=wordService;
            _mapper=mapper;
        }

        public  ActionResult Index() 
        {
            List<WordModel> result= new List<WordModel>();
            try
            {
                List<WordData> wordsList = _wordService.GetAllWordsAsync();
                result = _mapper.WordDataListToWordModelList(wordsList);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View(result);
        }
        [HttpGet]
        public ActionResult Details(int id) 
        {
            WordModel wordModel= new WordModel();
            try
            {
                WordData word = _wordService.GetWordById(id);
                wordModel = _mapper.WordDataToWordModel(word);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View(wordModel);
        }
        public ActionResult AddWord()
        {
            return View();
        }
        [HttpPost]
        public  ActionResult AddWord(WordModel wordModel)
        {
            var result = false;
            try
            {
                WordData word = _mapper.WordModelToWordData(wordModel);
                result = _wordService.AddWordAsync(word);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if (result == true)
                return RedirectToAction("Index");
            else
            {
                ViewBag.ErrorMessage = "Cannot add duplicate word";
                return RedirectToAction("AddWord");
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            WordModel wordModel= new WordModel();
            try
            {
                wordId = id;
                WordData word = _wordService.GetWordById(id);
                wordModel = _mapper.WordDataToWordModel(word);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View(wordModel);
        }
        [HttpPost]
        public ActionResult Edit(WordModel item, int id=0)
        {
            var result = false;
            try
            {
                item.WordId = wordId;
                WordData word = _mapper.WordModelToWordData(item);
                result = _wordService.UpdateWordAsync(word);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            if(result == true)
                return RedirectToAction("Index");
            else
            {
                ViewBag.ErrorMessage = "Cannot add duplicate word";
                return RedirectToAction("Edit", item);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            WordModel wordModel= new WordModel();
            try
            {
                wordId = id;
                WordData word = _wordService.GetWordById(id);
                wordModel = _mapper.WordDataToWordModel(word);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return View(wordModel);
        }
        [HttpPost]
        public ActionResult Delete(WordModel item, int id = 0)
        {
            try
            {
                item.WordId = wordId;
                WordData word = _mapper.WordModelToWordData(item);
                var result = _wordService.RemoveWordAsync(word);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return RedirectToAction("Index");
        }
    }
}