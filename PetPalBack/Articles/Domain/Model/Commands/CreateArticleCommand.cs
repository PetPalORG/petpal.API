namespace PetPalBack.Articles.Domain.Model.Commands
{
    public record CreateArticleCommand(string title, string content, string author, DateTime date, string imagePath, string authorImage);

}
