using PetPalBack.Articles.Domain.Model.Aggregates;
using PetPalBack.Articles.Domain.Repositories;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Configuration;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace PetPalBack.Articles.Infrastructure.Persistence.EFC.Repositories
{
    public class ArticleRepository(AppDbContext context): BaseRepository<Article>(context), IArticleRepository
    {
    }
}
