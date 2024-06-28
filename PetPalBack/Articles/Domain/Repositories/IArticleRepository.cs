using PetPalBack.Articles.Domain.Model.Aggregates;
using PetPalBack.Shared.Domain.Repositories;

namespace PetPalBack.Articles.Domain.Repositories
{
    public interface IArticleRepository: IBaseRepository<Article>
    {
    }
}
