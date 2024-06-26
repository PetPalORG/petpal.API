using PetPalBack.Pet_Care.Domain.Model.Commands;

namespace PetPalBack.Pet_Care.Domain.Model.Entities
{
    public class Medication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dosage { get; set; }
        public string indications { get; set; }
        public TreatmentDetail treatmentDetail { get; set; }
       
        public Medication(string Name, string Dosage, string indications)
        {
            this.Name = Name;
            this.Dosage = Dosage;
            this.indications = indications;
        }

        public Medication(CreateMedicationCommand command)
        {
            this.Name = command.Name;
            this.Dosage = command.Dosage;
            this.indications = command.indications;
        }
    }
}
