namespace PetPalBack.Articles.Interfaces.REST.Resources
{
    public record ArticleResource(int id, string title, string content, string author, DateTime date, string imagePath, string authorImage);

}
