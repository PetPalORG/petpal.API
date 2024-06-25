using PetPalBack.Pet_Care.Domain.Model.Commands;

namespace PetPalBack.Pet_Care.Domain.Model.Aggregates
{
    public class Appointment
    {
        public int id { get; set; }
        public string reason { get; set; }
        public DateTime date { get; set; }
        public int petId { get; set; }
        public Pet pet { get; set; }
        public Treatment treatment { get; set; }

        public Appointment(string reason, DateTime date, int petId)
        {
            this.reason = reason;
            this.date = date;
            this.petId = petId;
        }
        public Appointment(CreateAppointmentCommand command)
        {
            this.reason = command.reason;
            this.date = command.date;
            this.petId = command.petId;
        }
    }
}
