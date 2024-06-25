using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using PetPalBack.Shared.Infrastructure.Persistance.EPC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;
using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Model.Entities;
using System.Reflection.Emit;

namespace PetPalBack.Shared.Infrastructure.Persistance.EPC.Configuration
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

            builder.Entity<Pet>().ToTable("Pets");
            builder.Entity<Pet>().HasKey(p => p.Id);
            builder.Entity<Pet>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Pet>().Property(p => p.Name).IsRequired();
            builder.Entity<Pet>().Property(p => p.Species).IsRequired();
            builder.Entity<Pet>().Property(p => p.Breed).IsRequired();
            builder.Entity<Pet>().Property(p => p.BirthDate).IsRequired();
            builder.Entity<Pet>().Property(p => p.Weight).IsRequired();

            builder.Entity<Appointment>().ToTable("Appointments");
            builder.Entity<Appointment>().HasKey(a => a.id);
            builder.Entity<Appointment>().Property(a => a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Appointment>().Property(a => a.reason).IsRequired();
            builder.Entity<Appointment>().Property(a => a.date).IsRequired();

            builder.Entity<Appointment>().HasOne<Pet>(a => a.pet)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.petId);

            builder.Entity<Appointment>().HasOne(a => a.treatment)
                .WithOne(t => t.appointment)
                .HasForeignKey<Treatment>(t => t.appointmentId);

            builder.Entity<Treatment>()
        .HasOne(t => t.treatmentDetail)
        .WithOne(td => td.treatment)
        .HasForeignKey<TreatmentDetail>(td => td.treatmentId);

            builder.Entity<TreatmentDetail>()
                .HasOne(td => td.medication)
                .WithOne(m => m.treatmentDetail)
                .HasForeignKey<Medication>(m => m.treatmentDetailId);


            //apply SnakeCase Naming Convention
            builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        }

    }
}
