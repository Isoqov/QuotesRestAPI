using QuotesRestAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesRestAPI.Service.Implementation
{
    public class DataStorage : IDataStorage
    {
        public void Creat(QuoteModel quote)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int id, QuoteModel quoteModel)
        {
            throw new NotImplementedException();
        }

        public List<QuoteModel> Get()
        {
            throw new NotImplementedException();
        }

        public List<QuoteModel> GetByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public QuoteModel GetRandomQuote()
        {
            throw new NotImplementedException();
        }

        public void Worker()
        {
            throw new NotImplementedException();
        }
    }
}
