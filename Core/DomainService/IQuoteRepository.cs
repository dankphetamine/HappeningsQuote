using Entities;
using System.Collections.Generic;

namespace Core.DomainService
{
    public interface IQuoteRepository
    {
        Quote AddQuote(Quote quote);

        Quote GetQuoteWithId(uint id);

        IEnumerable<Quote> GetAllQuotes();

        Quote UpdateQuote(Quote quote);

        Quote Delete(uint id);
    }
}