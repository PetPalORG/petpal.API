using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Model.Commands;

namespace PetPalBack.Pet_Care.Domain.Model.Entities
{
    public class Medication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dosage { get; set; }
        public string indications { get; set; }
        public int treatmentId { get; set; }
        public Treatment treatment { get; set; }

        public Medication(string Name, string Dosage, string indications, int treatmentId)
        {
            this.Name = Name;
            this.Dosage = Dosage;
            this.indications = indications;
            this.treatmentId = treatmentId;
        }

        public Medication(CreateMedicationCommand command)
        {
            this.Name = command.Name;
            this.Dosage = command.Dosage;
            this.indications = command.indications;
            this.treatmentId = command.treatmentId;
        }
    }
}
