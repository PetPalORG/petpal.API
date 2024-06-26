using Org.BouncyCastle.Crypto.Utilities;
using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Model.Commands;

namespace PetPalBack.Pet_Care.Domain.Model.Entities
{
    public class Meal
    {
        public int Id { get; set; }
        public string Food { get; set; }
        public string description { get; set; }
        public int petId { get; set; }
        public string hour { get; set; }
        public Pet pet { get; set; }

        public Meal(string Food, string description, string hour, int petId)
        {
            this.Food = Food;
            this.description = description;
            this.hour = hour;
            this.petId = petId;
        }
        public Meal(CreateMealCommand command)
        {
            this.Food = command.Food;
            this.description = command.description;
            this.hour = command.hour;
            this.petId = command.petId;
        }
    }
}
