using PetPalBack.Pet_Care.Domain.Model.Commands;

namespace PetPalBack.Pet_Care.Domain.Model.Entities
{
    public class Medication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Duration { get; set; }
        public int treatmentDetailId { get; set; }
        public TreatmentDetail treatmentDetail { get; set; }
       

        protected Medication()
        {
            this.Name = string.Empty;
            this.Dosage = string.Empty;
            this.Frequency = string.Empty;
            this.Duration = string.Empty;
            this.treatmentDetailId = 0;
        }

        public Medication(CreateMedicationCommand command)
        {
            this.Name = command.Name;
            this.Dosage = command.Dosage;
            this.Frequency = command.Frequency;
            this.Duration = command.Duration;
            this.treatmentDetailId = command.treatmentDetailId;
        }
    }
}
