using PetPalBack.Pet_Care.Domain.Model.Commands;

namespace PetPalBack.Pet_Care.Domain.Model.Aggregates
{
    public class Appointment
    {
        public int id { get; set; }
        public string reason { get; set; }
        public DateTime date { get; set; }
        public int petId { get; set; }
        public Treatment treatment { get; set; }
        public Pet pet { get; set; }

        public Appointment() {
            this.reason = string.Empty;
            this.date = DateTime.Now;
            this.petId = 0;
        }
        public Appointment(CreateAppointmentCommand command)
        {
            this.reason = command.reason;
            this.date = command.date;
            this.petId = command.petId;
        }

        public int getId()
        {
            return this.id;
        }

        public void setTreatment(Treatment treatment)
        {
            this.treatment = treatment;
        }
    }
}
