using Entities;
using System.Collections.Generic;

namespace Core.ApplicationService
{
    public interface IQuoteService
    {
        List<Quote> GetAllQuotes();

        Quote GetQuoteWithId(uint id);

        Quote AddQuote(Quote quote);

        Quote UpdateQuote(Quote quote);

        Quote DeleteQuote(uint id);
    }
}