using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Domain.Model.Entities;

namespace PetPalBack.Pet_Care.Domain.Model.Aggregates
{
    public partial class Appointment
    {
        public int id { get; set; }
        public string vet { get; set; }
        public string reason { get; set; }
        public string detail { get; set; }
        public DateTime date { get; set; }
        public string hour { get; set; }
        public int petId { get; set; }
        public Pet pet { get; set; }
        public Treatment treatment { get; set; }

        public Appointment(string vet, string reason, string detail, DateTime date, string hour, int petId)
        {
            this.vet = vet;
            this.reason = reason;
            this.detail = detail;
            this.date = date;
            this.hour = hour;
            this.petId = petId;
        }
        public Appointment(CreateAppointmentCommand command)
        {
            this.vet = command.vet;
            this.reason = command.reason;
            this.detail = command.detail;
            this.date = command.date;
            this.hour = command.hour;
            this.petId = command.petId;
        }
    }
}
