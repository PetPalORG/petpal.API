using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using PetPalBack.shared.Infrastructure.Persistance.EFC.Configurations.Extensions;
using Microsoft.EntityFrameworkCore;
using PetPalBack.PetRegister.Domain.Model.Aggregates;

namespace PetPalBack.shared.Infrastructure.Persistance.EFC.Configurations
{
    public class AppDbContext(DbContextOptions options):DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.AddCreatedUpdatedInterceptor();
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Pet>().ToTable("Pets");
            builder.Entity<Pet>().HasKey(p => p.Id);
            builder.Entity<Pet>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Pet>().Property(p => p.Name).IsRequired();
            builder.Entity<Pet>().Property(p => p.Species).IsRequired();
            builder.Entity<Pet>().Property(p => p.Breed).IsRequired();
            builder.Entity<Pet>().Property(p => p.BirthDate).IsRequired();
            builder.Entity<Pet>().Property(p => p.Weight).IsRequired();
            builder.Entity<Pet>().Property(p => p.UserId).IsRequired();

            //apply SnakeCase Naming Convention
            builder.UseSnakeCaseWithPluralizedTableNamingConvention();

        }
    }
}
