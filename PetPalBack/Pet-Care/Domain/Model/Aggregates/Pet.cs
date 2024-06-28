using PetPalBack.IAM.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Domain.Model.Queries;

namespace PetPalBack.Pet_Care.Domain.Model.Aggregates
{
    public partial class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public int age { get; set; }
        public double Weight { get; set; }
        public string imagePath { get; set; }
        public string description { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Meal> diet { get; set; }

        public Pet(string Name, string Species, string Breed, int age, double Weight, string imagePath, string description, int userId)
        {
            this.Name = Name;
            this.Species = Species;
            this.Breed = Breed;
            this.age = age;
            this.Weight = Weight;
            this.imagePath = imagePath;
            this.description = description;
            this.userId = userId;
        }

        public Pet(CreatePetCommand command)
        {
            this.Name = command.Name;
            this.Breed = command.Breed;
            this.Species = command.Species;
            this.age = command.age;
            this.Weight = command.Weight;
            this.imagePath = command.imagePath;
            this.description = command.description;
            this.userId = command.userId;
        }
    }
}
