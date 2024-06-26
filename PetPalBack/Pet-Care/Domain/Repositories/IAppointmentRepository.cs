﻿using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Shared.Domain.Repositories;

namespace PetPalBack.Pet_Care.Domain.Repositories
{
    public interface IAppointmentRepository: IBaseRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> FindByPetIdAsync(int petId);
    }
}
