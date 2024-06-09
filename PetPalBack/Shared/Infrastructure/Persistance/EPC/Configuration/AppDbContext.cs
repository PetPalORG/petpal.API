using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using PetPalBack.shared.Infrastructure.Persistance.EFC.Configurations.Extensions;
using Microsoft.EntityFrameworkCore;
using PetPalBack.PetRegister.Domain.Model.Aggregates;
using PetPalBack.Domain.Model.Entities;

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

            builder.Entity<User>().ToTable("users");
            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(u => u.Name).IsRequired();
            builder.Entity<User>().Property(u => u.Email).IsRequired();
            builder.Entity<User>().Property(u => u.Password).IsRequired();
            builder.Entity<User>().Property(u => u.RegistrationDate).IsRequired();

            //apply SnakeCase Naming Convention
            builder.UseSnakeCaseWithPluralizedTableNamingConvention();

        }
    }
}

