using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Domain.Model.Queries;

namespace PetPalBack.Pet_Care.Domain.Model.Aggregates
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Diet> diet { get; set; }

        public Pet(string Name, string Species, string Breed, DateTime BirthDate, double Weight)
        {
            this.Name = Name;
            this.Species = Species;
            this.Breed = Breed;
            this.BirthDate = BirthDate;
            this.Weight = Weight;

        }

        public Pet(CreatePetCommand command)
        {
            this.Name = command.Name;
            this.Breed = command.Breed;
            this.Species = command.Species;
            this.BirthDate = command.BirthDate;
            this.Weight = command.Weight;
        }
    }
}
