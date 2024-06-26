using PetPalBack.Articles.Domain.Model.Commands;

namespace PetPalBack.Articles.Domain.Model.Aggregates
{
    public class Article
    {
        public int id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string author { get; set; }
        public DateTime date { get; set; }
        public string imagePath { get; set; }
        public string authorImage { get; set; }

        public Article(string title, string content, string author, DateTime date, string imagePath, string authorImage)
        {
            this.title = title;
            this.content = content;
            this.author = author;
            this.date = date;
            this.imagePath = imagePath;
            this.authorImage = authorImage;
        }

        public Article(CreateArticleCommand command)
        {
            this.title = command.title;
            this.content = command.content;
            this.author = command.author;
            this.date = command.date;
            this.imagePath = command.imagePath;
            this.authorImage = command.authorImage;
        }
    }
}
