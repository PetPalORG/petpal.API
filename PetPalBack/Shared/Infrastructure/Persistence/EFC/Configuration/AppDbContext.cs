using Microsoft.EntityFrameworkCore;
﻿using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;


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


            builder.Entity<Article>().ToTable("articles");
            builder.Entity<Article>().HasKey(a => a.id);
            builder.Entity<Article>().Property(a => a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Article>().Property(a => a.title).IsRequired();
            builder.Entity<Article>().Property(a => a.content).IsRequired();
            builder.Entity<Article>().Property(a => a.author).IsRequired();
            builder.Entity<Article>().Property(a => a.date).IsRequired();
            builder.Entity<Article>().Property(a => a.imagePath).IsRequired();
            builder.Entity<Article>().Property(a => a.authorImage).IsRequi


            builder.Entity<Pet>().HasKey(p => p.Id);
            builder.Entity<Pet>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Pet>().Property(p => p.Name).IsRequired();
            builder.Entity<Pet>().Property(p => p.Species).IsRequired();
            builder.Entity<Pet>().Property(p => p.Breed).IsRequired();
            builder.Entity<Pet>().Property(p => p.BirthDate).IsRequired();
            builder.Entity<Pet>().Property(p => p.Weight).IsRequired();


            builder.Entity<Appointment>().HasKey(a => a.id);
            builder.Entity<Appointment>().Property(a => a.id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Appointment>().Property(a => a.reason).IsRequired();
            builder.Entity<Appointment>().Property(a => a.date).IsRequired();

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

            builder.Entity<Diet>()
                .HasOne(d => d.pet)
                .WithMany(p => p.diet)
                .HasForeignKey(d => d.petId)
                .HasPrincipalKey(p => p.Id);


            builder.Entity<Treatment>()
                .HasOne(t => t.treatmentDetail)
                .WithOne(td => td.treatment)
                .HasForeignKey<TreatmentDetail>(td => td.treatmentId)
                .HasPrincipalKey<Treatment>(t => t.Id);

            builder.Entity<Medication>()
                .HasOne(m => m.treatmentDetail)
                .WithOne(td => td.medication)
                .HasForeignKey<TreatmentDetail>(td => td.medicationId)
                .HasPrincipalKey<Medication>(m => m.Id);


            //apply SnakeCase Naming Convention
            builder.UseSnakeCaseWithPluralizedTableNamingConvention();
        }
    }
}
