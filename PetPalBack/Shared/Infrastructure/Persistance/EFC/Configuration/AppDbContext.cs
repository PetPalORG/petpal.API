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

           

            //apply SnakeCase Naming Convention
            builder.UseSnakeCaseWithPluralizedTableNamingConvention();

        }
    }
}

