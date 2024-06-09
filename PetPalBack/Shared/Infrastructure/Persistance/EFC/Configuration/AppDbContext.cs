using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using PetPalBack.Shared.Infrastructure.Persistance.EPC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace PetPalBack.Shared.Infrastructure.Persistance.EPC.Configuration
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

            /***
             * 
             * 
             * 
             * 
             * 
             */

            //apply SnakeCase Naming Convention
            builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        }

    }
}
