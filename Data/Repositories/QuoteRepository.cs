using System.Collections.Generic;
using System.Linq;
using Core.DomainService;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class QuoteRepository: IQuoteRepository
    {
        //DI Context
        private readonly QuoteAppContext _ctx; 
        public QuoteRepository(QuoteAppContext context)
        {
            _ctx = context;
        }
        public Quote AddQuote(Quote quote)
        {
            // Add state to track in context, added = non existent in db yet.
            _ctx.Attach(quote).State = EntityState.Added;
            _ctx.SaveChanges();
            return quote;
        }

        public Quote GetQuoteWithId(uint id)
        {
            return _ctx.Quotes.FirstOrDefault(q => q.Id == id);
        }

        public IEnumerable<Quote> GetAllQuotes()
        {
                return _ctx.Quotes;
        }

        public Quote UpdateQuote(Quote quote)
        {
            // Add state to track in context, modified = existent in db and one ore more values are changed.
            _ctx.Attach(quote).State = EntityState.Modified;
            _ctx.SaveChanges();
            return quote;
        }

        public Quote Delete(uint id)
        {
            var remQuote = _ctx.Remove(new Quote { Id = id }).Entity;
            _ctx.SaveChanges();
            return remQuote;
        }

        // Thought to be used for implementing Pagination (filtered data). Not implemented as of now.
        public uint Count()
        {
            return (uint) _ctx.Quotes.Count();
        }
    }
}
