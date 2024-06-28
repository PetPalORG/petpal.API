using PetPalBack.Articles.Domain.Model.Aggregates;
using PetPalBack.Articles.Domain.Model.Queries;

namespace PetPalBack.Articles.Domain.Services
{
    public interface IArticleQueryService
    {
        Task<IEnumerable<Article>> Handle(GetAllArticlesQuery query);
        Task<Article?> Handle(GetArticleByIdQuery query);
    }
}
