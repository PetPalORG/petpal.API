using PetPalBack.Articles.Domain.Model.Aggregates;
using PetPalBack.Articles.Domain.Model.Commands;

namespace PetPalBack.Articles.Domain.Services
{
    public interface IArticleCommandService
    {
        Task<Article?> Handle(CreateArticleCommand command);
    }
}
