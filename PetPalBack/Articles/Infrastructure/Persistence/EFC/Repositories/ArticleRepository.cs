using PetPalBack.Articles.Domain.Model.Aggregates;
using PetPalBack.Articles.Domain.Repositories;
using PetPalBack.shared.Infrastructure.Persistance.EFC.Configurations;
using PetPalBack.shared.Infrastructure.Persistance.EFC.Repositories;

namespace PetPalBack.Articles.Infrastructure.Persistence.EFC.Repositories
{
    public class ArticleRepository(AppDbContext context): BaseRepository<Article>(context), IArticleRepository
    {
    }
}
