using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Domain.Model.Entities;

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
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

        protected Pet()
        {
            this.Name = string.Empty;
            this.Species = string.Empty;
            this.Breed = string.Empty;
            this.BirthDate = DateTime.Now;
            this.Weight = 0;
            
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
