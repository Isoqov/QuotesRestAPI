using QuotesRestAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesRestAPI.Service.Implementation
{
    public class DataStorage : IDataStorage
    {
        public List<QuoteModel> quotes = new List<QuoteModel>();
        private int id;
        public void Create(QuoteModel quote)
        {
            var newQuote = new QuoteModel
            {
                Id = ++id,
                Author = quote.Author,
                Quote = quote.Quote,
                Category = quote.Category,
                CreatedDate = DateTime.Now
            };
            quotes.Add(newQuote);
        }

        public Boolean Delete(int id)
        {
            var quoteToRemove = quotes.Single(r => r.Id == id);
            if (quoteToRemove == null)
                return false;
            quotes.Remove(quoteToRemove);
            return true;
        }

        public Boolean Edit(int id, QuoteModel quote)
        {
            var quoteIndex = quotes.FindIndex(p => p.Id == id);
            if (quoteIndex == null)
                return false;
            quote.Id = id;
            quote.CreatedDate= quotes[quoteIndex].CreatedDate;
            quotes[quoteIndex] = quote;
            return true;
        }

        public List<QuoteModel> Get()
        {
            return quotes;
        }

        public List<QuoteModel> GetByCategory(string category)
        {
            var quote = quotes.Where(q => q.Category == category).ToList();
            return quote;
        }

        public QuoteModel RandomQuote
        {
            get
            {
                if (quotes.Count() == 0)
                    return null;
                Random random = new Random();
                var quoteIndex = random.Next(quotes.Count());
                return quotes[quoteIndex];
            }
        }

        public void Worker()
        {
            throw new NotImplementedException();
        }
    }
}
