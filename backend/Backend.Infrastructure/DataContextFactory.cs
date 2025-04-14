using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Backend.Infrastructure.Contexts;

namespace Backend.Infrastructure
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Database;User Id=root;Password=12345678;");

            return new DataContext(optionsBuilder.Options);
        }
    }
}
