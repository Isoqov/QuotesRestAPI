using Microsoft.AspNetCore.Mvc;
using QuotesRestAPI.Model;
using QuotesRestAPI.Service;
using System.Collections.Generic;

namespace QuotesRestAPI.Controller
{
    [Route("api/quote")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private IDataStorage _dataStorage;
        public QuoteController(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }

        [HttpGet]
        public ActionResult<List<QuoteModel>> Get()
        {
            return _dataStorage.Get();
        }

        [HttpPost]
        public ActionResult Create([FromBody] QuoteModel value)
        {
            _dataStorage.Create(value);
            return Ok("Quote Created.");
        }

        [HttpGet("category")]
        public ActionResult GetByCategory(string category)
        {
            var quotes=_dataStorage.GetByCategory(category);
            if (quotes == null)
                return NotFound();
            return Ok(quotes);
        }

        [HttpGet("randomQuote")]
        public ActionResult RandomQuote()
        {
            return Ok(_dataStorage.RandomQuote);
        }

        [HttpPut]
        public ActionResult Edit(int id, QuoteModel quote)
        {
            if(_dataStorage.Edit(id, quote))
                return Ok("Quote edit.");
            return Ok("Quote with this Id Does not excist.");
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (_dataStorage.Delete(id))
                return Ok("Quote deleted.");
            return Ok("Quote with this Id Does not excist.");
        }
    }
}