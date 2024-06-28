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
        public IEnumerable<Medication> medication { get; set; }

        public Treatment(string Diagnosis, DateTime StartDate, DateTime EndDate, int appointmentId)
        {
            this.Diagnosis = Diagnosis;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.appointmentId = appointmentId;
        }

        public Treatment(CreateTreatmentCommand command)
        {
            this.Diagnosis = command.Diagnosis;
            this.StartDate = command.StartDate;
            this.EndDate = command.EndDate;
            this.appointmentId = command.AppointmentId;
        }
    }
}
