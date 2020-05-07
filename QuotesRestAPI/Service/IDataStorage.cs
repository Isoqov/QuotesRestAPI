using QuotesRestAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesRestAPI.Service
{
    interface IDataStorage
    {
        void Edit(int id, QuoteModel quoteModel);
        void Delete(int id);
        public List<QuoteModel> Get();
        public List<QuoteModel> GetByCategory(string category);
        public QuoteModel GetRandomQuote();
        void Creat(QuoteModel quote);
        void Worker();
    }
}
