using QuotesRestAPI.Model;
using System;
using System.Collections.Generic;

namespace QuotesRestAPI.Service
{
    public interface IDataStorage
    {
        public Boolean Edit(int id, QuoteModel quote);
        public Boolean Delete(int id);
        public List<QuoteModel> Get();
        public List<QuoteModel> GetByCategory(string category);
        public QuoteModel RandomQuote { get; }
        void Create(QuoteModel quote);
        void Worker();
    }
}
