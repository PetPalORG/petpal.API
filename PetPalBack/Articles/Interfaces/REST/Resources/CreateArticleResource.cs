namespace PetPalBack.Articles.Interfaces.REST.Resources
{
    public record CreateArticleResource(string title, string content, string author, DateTime date, string imagePath, string authorImage);
}
