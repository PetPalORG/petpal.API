namespace PetPalBack.Pet_Care.Domain.Model.Entities
{
    public class Medication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Duration { get; set; }

        protected Medication()
        {
            this.Name = string.Empty;
            this.Dosage = string.Empty;
            this.Frequency = string.Empty;
            this.Duration = string.Empty;
        }
    }
}
