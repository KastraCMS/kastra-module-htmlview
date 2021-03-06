using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Kastra.Module.HtmlView.DAL
{
    public class HtmlViewDbContextFactory : IDesignTimeDbContextFactory<HtmlViewContext>
    {
        public HtmlViewContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath($"{Directory.GetCurrentDirectory()}/../Kastra.Web")
                .AddJsonFile("appsettings.json")
                .Build();
    
            var builder = new DbContextOptionsBuilder<HtmlViewContext>();
    
            var connectionString = configuration.GetConnectionString("DefaultConnection");
    
            builder.UseSqlServer(connectionString);
    
            return new HtmlViewContext(builder.Options);
        }
    }
}