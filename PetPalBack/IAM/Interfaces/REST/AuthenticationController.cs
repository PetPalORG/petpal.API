using Microsoft.AspNetCore.Mvc;
using PetPalBack.IAM.Domain.Services;
using PetPalBack.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using PetPalBack.IAM.Interfaces.REST.Resources;
using PetPalBack.IAM.Interfaces.REST.Transform;
using System.Net.Mime;

namespace PetPalBack.IAM.Interfaces.REST
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class AuthenticationController(IUserCommandService userCommandService) : ControllerBase
    {
        [HttpPost("sign-up")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromBody] SignUpResource resource)
        {
            var signUpCommand = SignUpCommandFromResourceAssembler.ToCommandFromResource(resource);
            await userCommandService.Handle(signUpCommand);
            return Ok(new { message = "User created successfully" });
        }

        [HttpPost("sign-in")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromBody] SignInResource resource)
        {
            var signInCommand = SignInCommandFromResourceAssembler.ToCommandFromResource(resource);
            var authenticatedUser = await userCommandService.Handle(signInCommand);
            var authenticatedUserResource =
                AuthenticatedUserResourceFromEntityAssembler.ToResourceFromEntity(authenticatedUser.user,
                    authenticatedUser.token);
            return Ok(authenticatedUserResource);
        }
    }
}
