using PetPalBack.Articles.Domain.Model.Aggregates;
using PetPalBack.Articles.Domain.Model.Queries;
using PetPalBack.Articles.Domain.Repositories;
using PetPalBack.Articles.Domain.Services;

namespace PetPalBack.Articles.Application.Internal.QueryServices
{
    public class ArticleQueryService(IArticleRepository articleRepository) : IArticleQueryService
    {
        public async Task<IEnumerable<Article>> Handle(GetAllArticlesQuery query)
        {
            return await articleRepository.ListAsync();
        }

        public async Task<Article?> Handle(GetArticleByIdQuery query)
        {
            return await articleRepository.FindByIdAsync(query.id);
        }
    }
}
