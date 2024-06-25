using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Model.Commands;

namespace PetPalBack.Pet_Care.Domain.Model.Entities
{
    public class TreatmentDetail
    {
        public int id { get; set; }
        public int treatmentId { get; set; }

        public Treatment treatment { get; set; }
        public int medicationId { get; set; }
        public Medication medication { get; set; }

        public TreatmentDetail(int treatmentId, int medicationId)
        {
            this.treatmentId = treatmentId;
            this.medicationId = medicationId;
        }

        public TreatmentDetail(CreateTreatmentDetailsCommand command)
        {
            this.treatmentId = command.treatmentId;
            this.medicationId = command.medicationId;
        }

    }
}
