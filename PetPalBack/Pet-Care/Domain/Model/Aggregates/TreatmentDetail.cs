using PetPalBack.Pet_Care.Domain.Model.Commands;

namespace PetPalBack.Pet_Care.Domain.Model.Entities
{
    public class TreatmentDetails
    {
        public int TreatmentId { get; set; }
        public int MedicationId { get; set; }
        public int DietId { get; set; }

        protected TreatmentDetails()
        {
            this.TreatmentId = 0;
            this.MedicationId = 0;
            this.DietId = 0;
        }

        public TreatmentDetails(CreateTreatmentDetailsCommand command)
        {
            this.TreatmentId = command.TreatmentId;
            this.MedicationId = command.MedicationId;
            this.DietId = command.DietId;
        }
    }
}
