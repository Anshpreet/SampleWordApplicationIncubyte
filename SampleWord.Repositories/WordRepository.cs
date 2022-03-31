using System;
using System.Collections.Generic;
using System.Linq;
using SampleWord.CustomExceptions;

namespace SampleWord.Repositories
{
    public class WordRepository : IWordRepository
    {
        private WordsDBEntities _Context;

        public WordRepository(WordsDBEntities context)
        {
            _Context = context;
        }
        public bool AddWordAsync(Word word)
        {
            List<Word> wordsList = new List<Word>();
            try
            {
                wordsList = _Context.Words.Where(w => w.word_param == word.word_param && w.is_deleted!=true).ToList();
                if (wordsList.Count==0)
                {
                    int rowsAffected = 0;
                    word.updated_at = DateTimeOffset.UtcNow;
                    _Context.Words.Add(word);
                    rowsAffected = _Context.SaveChanges();
                    if (rowsAffected == 0)
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (DuplicateRecordException ex)
            {
                throw new DuplicateRecordException(ex.Message);
            }
            catch (Exception)
            {
                throw new SqlException("Server error occured!");
            }
        }

        public List<Word> GetAllWordsAsync()
        {
            List<Word> result = new List<Word>();
            try
            {
                result = _Context.Words.Where(s=>s.is_deleted!=true).ToList();
                if (result == null)
                {
                    throw new RecordNotFoundException("No data available.");
                }
                return result;
            }
            catch (RecordNotFoundException ex)
            {
                throw new RecordNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new SqlException("Server error occured!", ex);
            }
        }

        public bool RemoveWordAsync(Word word)
        {
            try
            {
                int rows = 0;
                Word tempWord = _Context.Words.Where(s => s.word_id == word.word_id).FirstOrDefault();
                if (tempWord != null)
                {
                    tempWord.is_deleted = true;
                    tempWord.updated_at=DateTimeOffset.UtcNow;
                    tempWord.deleted_at= DateTimeOffset.UtcNow;
                    rows = _Context.SaveChanges();
                    if (rows == 0)
                        return false;
                    else
                        return true;
                }
                else
                    throw new RecordNotFoundException("No data available.");
            }
            catch (RecordNotFoundException ex)
            {
                throw new RecordNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured", ex);
            }
        }

        public bool UpdateWordAsync(Word word)
        {
            try
            {
                int rows = 0;
                Word tempWord = _Context.Words.Where(s => s.word_id == word.word_id).FirstOrDefault();
                if (tempWord != null)
                {

                    tempWord.word_param = word.word_param;
                    tempWord.updated_at = DateTimeOffset.UtcNow;

                    rows =  _Context.SaveChanges();
                    if (rows == 0)
                        return false;
                    else
                        return true;
                }
                else
                    return false;
            }
            catch (RecordNotFoundException ex)
            {
                throw new RecordNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new SqlException("server error occured", ex);
            }
        }

        public Word GetWordById(int id)
        {
            Word result = new Word();
            try
            {
                result =_Context.Words.Where(s=>s.word_id==id).FirstOrDefault();
                if (result == null)
                {
                    throw new RecordNotFoundException("No data available.");
                }
                return result;
            }
            catch (RecordNotFoundException ex)
            {
                throw new RecordNotFoundException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new SqlException("Server error occured!", ex);
            }
        }
    }
}
