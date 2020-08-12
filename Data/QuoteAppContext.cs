using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class QuoteAppContext: DbContext
    {
        public QuoteAppContext(DbContextOptions<QuoteAppContext> options) : base(options)
        {
            // Sole purpose is to provide options for Startup class
        }
        public DbSet<Quote> Quotes { get; set; }
    }
}
