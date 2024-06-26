using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using PetPalBack.IAM.Domain.Model.Aggregates;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Articles.Domain.Model.Aggregates;


namespace PetPalBack.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.AddCreatedUpdatedInterceptor();
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(u => u.Username).IsRequired();
            builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();

            builder.Entity<Article>().ToTable("articles");
            builder.Entity<Article>().HasKey(a => a.id);
            builder.Entity<Article>().Property(a => a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Article>().Property(a => a.title).IsRequired();
            builder.Entity<Article>().Property(a => a.content).IsRequired();
            builder.Entity<Article>().Property(a => a.author).IsRequired();
            builder.Entity<Article>().Property(a => a.date).IsRequired();
            builder.Entity<Article>().Property(a => a.imagePath).IsRequired();
            builder.Entity<Article>().Property(a => a.authorImage).IsRequired();


            builder.Entity<Pet>().HasKey(p => p.Id);
            builder.Entity<Pet>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Pet>().Property(p => p.Name).IsRequired();
            builder.Entity<Pet>().Property(p => p.Species).IsRequired();
            builder.Entity<Pet>().Property(p => p.Breed).IsRequired();
            builder.Entity<Pet>().Property(p => p.age).IsRequired();
            builder.Entity<Pet>().Property(p => p.Weight).IsRequired();
            builder.Entity<Pet>().Property(p => p.imagePath).IsRequired();
            builder.Entity<Pet>().Property(p => p.description).IsRequired();

            builder.Entity<Pet>()
                .HasOne(p => p.user)
                .WithMany(u => u.pet)
                .HasForeignKey(p => p.userId)
                .HasPrincipalKey(u => u.Id);

            builder.Entity<Appointment>().HasKey(a => a.id);
            builder.Entity<Appointment>().Property(a => a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Appointment>().Property(a => a.vet).IsRequired();
            builder.Entity<Appointment>().Property(a => a.reason).IsRequired();
            builder.Entity<Appointment>().Property(a => a.detail).IsRequired();
            builder.Entity<Appointment>().Property(a => a.date).IsRequired();
            builder.Entity<Appointment>().Property(a => a.hour).IsRequired();

            builder.Entity<Appointment>()
                .HasOne(a => a.pet)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.petId)
                .HasPrincipalKey(p => p.Id);

            builder.Entity<Appointment>()
                .HasOne(a => a.treatment)
                .WithOne(t => t.appointment)
                .HasForeignKey<Treatment>(t => t.appointmentId)
                .HasPrincipalKey<Appointment>(a => a.id);

            builder.Entity<Meal>().HasKey(m => m.Id);
            builder.Entity<Meal>().Property(m => m.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Meal>().Property(m => m.Food).IsRequired();
            builder.Entity<Meal>().Property(m => m.description).IsRequired();
            builder.Entity<Meal>().Property(m => m.hour).IsRequired();


            builder.Entity<Meal>()
                .HasOne(d => d.pet)
                .WithMany(p => p.diet)
                .HasForeignKey(d => d.petId)
                .HasPrincipalKey(p => p.Id);


            builder.Entity<Treatment>().HasKey(m => m.Id);
            builder.Entity<Treatment>().Property(m => m.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Treatment>().Property(m => m.Diagnosis).IsRequired();
            builder.Entity<Treatment>().Property(m => m.StartDate).IsRequired();


            builder.Entity<Treatment>()
                .HasOne(t => t.treatmentDetail)
                .WithOne(td => td.treatment)
                .HasForeignKey<TreatmentDetail>(td => td.treatmentId)
                .HasPrincipalKey<Treatment>(t => t.Id);

            builder.Entity<Medication>().HasKey(m => m.Id);
            builder.Entity<Medication>().Property(m => m.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Medication>().Property(m => m.Name).IsRequired();
            builder.Entity<Medication>().Property(m => m.Dosage).IsRequired();
            builder.Entity<Medication>().Property(m => m.indications).IsRequired();

            builder.Entity<Medication>()
                .HasOne(m => m.treatmentDetail)
                .WithOne(td => td.medication)
                .HasForeignKey<TreatmentDetail>(td => td.medicationId)
                .HasPrincipalKey<Medication>(m => m.Id);

            builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        }
    }
}
