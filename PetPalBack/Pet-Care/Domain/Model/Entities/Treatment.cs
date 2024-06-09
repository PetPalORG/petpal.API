using PetPalBack.Pet_Care.Domain.Model.Commands;

namespace PetPalBack.Pet_Care.Domain.Model.Aggregates
{
    public class Treatment
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AppointmentId { get; set; }

        protected Treatment()
        {
            this.Diagnosis = string.Empty;
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now;
            this.AppointmentId = 0;
        }

        public Treatment(CreateTreatmentCommand command)
        {
            this.Diagnosis = command.Diagnosis;
            this.StartDate = command.StartDate;
            this.EndDate = command.EndDate;
            this.AppointmentId = command.AppointmentId;
        }
    }
}
