using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Domain.Model.Entities;

namespace PetPalBack.Pet_Care.Domain.Model.Aggregates
{
    public class Treatment
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int appointmentId { get; set; }
        public Appointment appointment { get; set; }
        public TreatmentDetail treatmentDetail { get; set; }

        protected Treatment()
        {
            this.Diagnosis = string.Empty;
            this.StartDate = DateTime.Now;
            this.EndDate = DateTime.Now;
        }

        public Treatment(CreateTreatmentCommand command)
        {
            this.Diagnosis = command.Diagnosis;
            this.StartDate = command.StartDate;
            this.EndDate = command.EndDate;
            this.appointmentId = command.AppointmentId;
        }

        public int getId()
        {
            return this.Id;
        }

        public void SetAppointment(int appointmentId)
        {
            this.appointmentId = appointmentId;
        }
    }
}
