﻿using PetPalBack.IAM.Domain.Model.Commands;
using PetPalBack.IAM.Interfaces.REST.Resources;

namespace PetPalBack.IAM.Interfaces.REST.Transform
{
    public static class SignInCommandFromResourceAssembler
    {
        public static SignInCommand ToCommandFromResource(SignInResource resource)
        {
            return new SignInCommand(resource.Username, resource.Password);
        }
    }
}
