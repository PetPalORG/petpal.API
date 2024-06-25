using Org.BouncyCastle.Crypto.Utilities;
using PetPalBack.Pet_Care.Domain.Model.Commands;

namespace PetPalBack.Pet_Care.Domain.Model.Entities
{
    public class Diet
    {
        public int Id { get; set; }
        public string Food { get; set; }
        public DateTime Date { get; set; }

        protected Diet()
        {
            this.Food = string.Empty;
            this.Date = DateTime.Now;
            
        }
        public Diet(CreateDietCommand command)
        {
            this.Food = command.Food;
            this.Date = command.Date;
        }
        
        public int getId()
        {
            return this.Id;
        }
    }
}
