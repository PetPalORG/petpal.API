﻿using PetPalBack.IAM.Domain.Model.Commands;
using PetPalBack.IAM.Interfaces.REST.Resources;

namespace PetPalBack.IAM.Interfaces.REST.Transform
{
    public static class SignUpCommandFromResourceAssembler
    {
        public static SignUpCommand ToCommandFromResource(SignUpResource resource)
        {
            return new SignUpCommand(resource.Username, resource.Password);
        }
    }
}
