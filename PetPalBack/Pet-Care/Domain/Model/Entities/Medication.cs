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
        public TreatmentDetail treatmentDetail { get; set; }
       
        public Medication(string Name, string Dosage, string Frequency, string Duration)
        {
            this.Name = Name;
            this.Dosage = Dosage;
            this.Frequency = Frequency;
            this.Duration = Duration;
        }

        public Medication(CreateMedicationCommand command)
        {
            this.Name = command.Name;
            this.Dosage = command.Dosage;
            this.Frequency = command.Frequency;
            this.Duration = command.Duration;
        }
    }
}
