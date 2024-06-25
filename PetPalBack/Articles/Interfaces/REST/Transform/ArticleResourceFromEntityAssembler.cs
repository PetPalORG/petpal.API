using PetPalBack.Articles.Domain.Model.Aggregates;
using PetPalBack.Articles.Interfaces.REST.Resources;

namespace PetPalBack.Articles.Interfaces.REST.Transform
{
    public class ArticleResourceFromEntityAssembler
    {
        public static ArticleResource ToResourceFromEntity(Article article)
        {
            return new ArticleResource(article.id, article.title, article.content, article.author, article.date, article.imagePath, article.authorImage);
        }
    }
}
