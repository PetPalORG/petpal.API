using PetPalBack.Pet_Care.Domain.Model.Commands;

namespace PetPalBack.Pet_Care.Domain.Model.Entities
{
    public class Vaccine
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public int PetId { get; set; }
        public int TreatmentId { get; set; }

        protected Vaccine()
        {
            this.Type = string.Empty;
            this.Date = DateTime.Now;
            this.PetId = 0;
            this.TreatmentId = 0;
        }

        public Vaccine(CreateVaccineCommand command)
        {
            this.Type = command.Type;
            this.Date = command.Date;
            this.PetId = command.PetId;
            this.TreatmentId = command.TreatmentId;
        }
    }
}
