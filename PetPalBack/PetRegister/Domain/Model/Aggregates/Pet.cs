using PetPalBack.PetRegister.Domain.Model.Commands;

namespace PetPalBack.PetRegister.Domain.Model.Aggregates
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public int UserId { get; set; }
        
        protected Pet()
        {
            this.Name = string.Empty;
            this.Species = string.Empty;
            this.Breed = string.Empty;
            this.BirthDate = DateTime.Now;
            this.Weight = 0;
            this.UserId = 0;
        }

        public Pet(CreatePetCommand command)
        {
            this.Name = command.Name;
            this.Breed = command.Breed;
            this.Species = command.Species;
            this.BirthDate = command.BirthDate;
            this.Weight = command.Weight;
            this.UserId = command.UserId;
        }
    }
}
