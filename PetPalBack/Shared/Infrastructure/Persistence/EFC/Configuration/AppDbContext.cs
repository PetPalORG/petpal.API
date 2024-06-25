using Microsoft.EntityFrameworkCore;
using PetPalBack.Articles.Domain.Model.Aggregates;

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

            builder.Entity<Article>().ToTable("articles");
            builder.Entity<Article>().HasKey(a => a.id);
            builder.Entity<Article>().Property(a => a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Article>().Property(a => a.title).IsRequired();
            builder.Entity<Article>().Property(a => a.content).IsRequired();
            builder.Entity<Article>().Property(a => a.author).IsRequired();
            builder.Entity<Article>().Property(a => a.date).IsRequired();
            builder.Entity<Article>().Property(a => a.imagePath).IsRequired();
            builder.Entity<Article>().Property(a => a.authorImage).IsRequired();

            //apply SnakeCase Naming Convention
            builder.UseSnakeCaseWithPluralizedTableNamingConvention();

        }
    }
}
