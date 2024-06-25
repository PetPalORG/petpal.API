using PetPalBack.Articles.Domain.Model.Aggregates;
using PetPalBack.shared.Domain.Repositories;

namespace PetPalBack.Articles.Domain.Repositories
{
    public interface IArticleRepository: IBaseRepository<Article>
    {
    }
}
