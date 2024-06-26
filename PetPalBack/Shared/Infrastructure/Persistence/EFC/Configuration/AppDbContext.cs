using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using PetPalBack.IAM.Domain.Model.Aggregates;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace PetPalBack.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.AddCreatedUpdatedInterceptor();
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(u => u.Username).IsRequired();
            builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();

            //apply SnakeCase Naming Convention
            builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        }

    }
}
