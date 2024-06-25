using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Model.Commands;

namespace PetPalBack.Pet_Care.Domain.Model.Entities
{
    public class TreatmentDetail
    {
        public int id { get; set; }
        public int treatmentId { get; set; }
        public Medication medication { get; set; }

        public Treatment treatment { get; set; }

        public TreatmentDetail()
        {
            this.treatmentId = 0;
        }

        public TreatmentDetail(CreateTreatmentDetailsCommand command)
        {
            this.treatmentId = command.treatmentId;
        }

    }
}
