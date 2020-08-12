using Core.ApplicationService;
using Core.DomainService;
using Data;
using Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RestAPI
{
    public class Startup
    {
        private const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // For local testing, IN MEMORY database, comment this out when using SQL/SQLite db.
            //services.AddDbContext<QuoteAppContext>(options => options.UseInMemoryDatabase("QuoteDB"));

            // SQLite database, comment this out when using In Memory db.
            services.AddDbContext<QuoteAppContext>(options => options.UseSqlite("Data Source=Quote.db"));

            // Adds the Core dependencies to the scope
            services.AddScoped<IQuoteRepository, QuoteRepository>();
            services.AddScoped<IQuoteService, QuoteService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Implemented this to fix CORS related issues
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins, builder =>
                {
                    builder.WithOrigins("https://localhost:44356/", "http://localhost:4200/")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<QuoteAppContext>();

                    // Ensures that the DB (not in memory) gets DELETED, on startup. ONLY IN USE FOR DEVELOPMENT. Either use this or remove the 'addInitialQuoteToDB' region.
                    // context.Database.EnsureDeleted();

                    // Ensures that the DB (not in memory) gets created, on startup. Handles creation of tables, etc.
                    context.Database.EnsureCreated();

                    #region addInitialQuoteToDB
                    /*
                    context.Quotes.Add(new Quote()
                    {
                        Author = "MLK",
                        Text = "I have a dream",
                        Date = new DateTime(1963, 8, 28),
                    });
                    context.SaveChanges();
                    */
                    #endregion
                }
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}