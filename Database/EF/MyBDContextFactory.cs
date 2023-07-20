using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Database.EF
{    
    class MyBDContextFactory : IDesignTimeDbContextFactory<MyBDContext>
    {
        public MyBDContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json")
                     .Build();
            var connectString = configuration.GetConnectionString("dbConStr");
            var optionsBuilder = new DbContextOptionsBuilder<MyBDContext>();
            optionsBuilder.UseSqlServer(connectString);
            return new MyBDContext(optionsBuilder.Options);
        }
    }
}
