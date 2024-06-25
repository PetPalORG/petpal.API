﻿using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Pet_Care.Domain.Services;
using PetPalBack.Shared.Domain.Repositories;

namespace PetPalBack.Pet_Care.Application.Internal.CommandServices
{
    public class DietCommandService(IDietRepository dietRepository, IUnitOfWork unitOfWork) : IDietCommandService
    {
        public async Task<Diet?> Handle(CreateDietCommand command)
        {
            var diet = new Diet(command);
            try
            {
                await dietRepository.AddAsync(diet);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
            return diet;
        }

        public async Task Handle(DeleteDietCommand command)
        {
            var diet = await dietRepository.FindByIdAsync(command.id);
            if (diet == null) { throw new Exception("Diet not found"); }
            try
            {
                dietRepository.Remove(diet);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting diet");
            }
        }
    }
}
