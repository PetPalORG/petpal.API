﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using PetPalBack.IAM.Domain.Model.Aggregates;

namespace PetPalBack.IAM.Infrastructure.Pipeline.Middleware.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
            {
                Console.WriteLine("Skipping Authorization");
                return;
            }
            // If user is logged in, this will be set
            var user = (User?)context.HttpContext.Items["User"];

            if (user == null) context.Result = new UnauthorizedResult();
        }
    }
}
