using PetPalBack.Articles.Domain.Model.Aggregates;
using PetPalBack.Articles.Domain.Model.Commands;
using PetPalBack.Articles.Domain.Repositories;
using PetPalBack.Articles.Domain.Services;
using PetPalBack.shared.Domain.Repositories;

namespace PetPalBack.Articles.Application.Internal.CommandServices
{
    public class ArticleCommandService(IArticleRepository articleRepository, IUnitOfWork unitOfWork) : IArticleCommandService
    {
        public async Task<Article?> Handle(CreateArticleCommand command)
        {
            var article = new Article(command);
            try
            {
                await articleRepository.AddAsync(article);
                await unitOfWork.CompleteAsync();
                return article;
            } catch
            {
                return null;
            }
        }
    }
}
