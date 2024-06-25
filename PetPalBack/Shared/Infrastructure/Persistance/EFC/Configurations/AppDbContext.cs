using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using PetPalBack.shared.Infrastructure.Persistance.EFC.Configurations.Extensions;
using Microsoft.EntityFrameworkCore;
using PetPalBack.IAM.Domain.Model.Aggregates;

namespace PetPalBack.shared.Infrastructure.Persistance.EFC.Configurations
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
