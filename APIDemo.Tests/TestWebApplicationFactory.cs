using APIDemo.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace APIDemo.Tests
{
    public class TestWebApplicationFactory : WebApplicationFactory<Program>
    {
        private readonly string _database = Guid.NewGuid().ToString();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            builder.ConfigureServices(services =>
            {
                services.AddDbContext<APIDemoContext>(o =>
                {
                    o.UseInMemoryDatabase(_database);
                });

                //todo seed data for more complete testing
            });
        }
    }
}