using Core.ApplicationService;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        // Dependency inject service
        private readonly IQuoteService _quoteService;

        public QuotesController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Quote>> Get()
        {
            return Ok(_quoteService.GetAllQuotes());
        }

        // GET api/orders/5
        [HttpGet("{id}")]
        public ActionResult<Quote> Get(uint id)
        {
            if (id < 1) return BadRequest("Id must be greater than 0");
            var q = _quoteService.GetQuoteWithId(id);
            if (q != null) return Ok(q);
            return NotFound($"Unable to find quote with id: {id}");
        }

        // POST api/quotes
        [HttpPost]
        public ActionResult<Quote> Post([FromBody] Quote quote)
        {
            // Attempt to add a quote in a try-catch, will return corresponding HTTP status.
            try
            {
                return Ok(_quoteService.AddQuote(quote));
            }
            catch (Exception e)
            {
                return BadRequest($"Unable to add quote. Error: {e}");
            }
        }

        // PUT api/quotes/5
        [HttpPut("{id}")]
        public ActionResult<Quote> Put(uint id, [FromBody] Quote quote)
        {
            // Attempt to update a quote in a try-catch, will return corresponding HTTP status
            if (id < 1 || id != quote.Id)
            {
                return BadRequest("Parameter Id and quote Id must match");
            }

            return Ok(_quoteService.UpdateQuote(quote));
        }

        // DELETE api/quotes/5
        [HttpDelete("{id}")]
        public ActionResult<Quote> Delete(uint id)
        {
            try
            {
                return Ok(_quoteService.DeleteQuote(id));
            }
            catch
            {
                return BadRequest($"Unable to delete quote with id: {id}");
            }
        }
    }
}