using Org.BouncyCastle.Crypto.Utilities;
using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Model.Commands;

namespace PetPalBack.Pet_Care.Domain.Model.Entities
{
    public class Diet
    {
        public int Id { get; set; }
        public string Food { get; set; }
        public int petId { get; set; }
        public DateTime Date { get; set; }
        public Pet pet { get; set; }

        public Diet(string Food, DateTime Date, int petId)
        {
            this.Food = Food;
            this.Date = Date;
            this.petId = petId;
        }
        public Diet(CreateDietCommand command)
        {
            this.Food = command.Food;
            this.Date = command.Date;
            this.petId = command.petId;
        }
    }
}
