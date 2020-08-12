using Core.DomainService;
using Entities;
using System.Collections.Generic;
using System.Linq;

namespace Core.ApplicationService
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRepository _quoteRepo;

        public QuoteService(IQuoteRepository quoteRepo)
        {
            _quoteRepo = quoteRepo;
        }

        public List<Quote> GetAllQuotes()
        {
            return _quoteRepo.GetAllQuotes().ToList();
        }

        public Quote GetQuoteWithId(uint id)
        {
            return _quoteRepo.GetQuoteWithId(id);
        }

        public Quote AddQuote(Quote quote)
        {
            return _quoteRepo.AddQuote(quote);
        }

        public Quote UpdateQuote(Quote quote)
        {
            return _quoteRepo.UpdateQuote(quote);
        }

        public Quote DeleteQuote(uint id)
        {
            return _quoteRepo.Delete(id);
        }
    }
}