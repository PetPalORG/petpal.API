using Org.BouncyCastle.Crypto.Utilities;
using PetPalBack.Pet_Care.Domain.Model.Commands;

namespace PetPalBack.Pet_Care.Domain.Model.Entities
{
    public class Diet
    {
        public int Id { get; set; }
        public string Food { get; set; }
        public DateTime Date { get; set; }
        public int PetId { get; set; }

        protected Diet()
        {
            this.Food = string.Empty;
            this.Date = DateTime.Now;
            this.PetId = 0;
        }
        public Diet(CreateDietCommand command)
        {
            this.Food = command.Food;
            this.Date = command.Date;
            this.PetId = command.PetId;
        }
    }
}
