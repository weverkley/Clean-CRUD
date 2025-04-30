using System.Reflection;
using Backend.Infrastructure.Configurations;
using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
#if (DEBUG)
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.LogTo(Console.WriteLine);
#endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var assembly = typeof(DataContext).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var insertedEntries = this.ChangeTracker.Entries()
                               .Where(x => x.State == EntityState.Added)
                               .Select(x => x.Entity);
            foreach (var insertedEntry in insertedEntries)
            {
                var baseEntity = insertedEntry as BaseEntity;
                //If the inserted object is a BaseEntity. 
                if (baseEntity != null)
                {
                    baseEntity.CreatedAt = DateTime.UtcNow;
                }
            }

            var modifiedEntries = this.ChangeTracker.Entries()
                       .Where(x => x.State == EntityState.Modified)
                       .Select(x => x.Entity);
            foreach (var modifiedEntry in modifiedEntries)
            {
                //If the inserted object is a BaseEntity. 
                var baseEntity = modifiedEntry as BaseEntity;
                if (baseEntity != null)
                {
                    baseEntity.UpdatedAt = DateTime.UtcNow;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
