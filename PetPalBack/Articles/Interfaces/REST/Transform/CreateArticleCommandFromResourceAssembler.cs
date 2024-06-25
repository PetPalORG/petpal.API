using PetPalBack.Articles.Domain.Model.Commands;
using PetPalBack.Articles.Interfaces.REST.Resources;

namespace PetPalBack.Articles.Interfaces.REST.Transform
{
    public class CreateArticleCommandFromResourceAssembler
    {
        public static CreateArticleCommand ToCommandFromResource(CreateArticleResource resource)
        {
            return new CreateArticleCommand(resource.title, resource.content, resource.author, resource.date, resource.imagePath, resource.authorImage);
        }
    }
}
