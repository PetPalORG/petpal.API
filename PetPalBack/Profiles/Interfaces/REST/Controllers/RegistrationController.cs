using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetPalBack.Domain.Model.Commands;
using System.Threading.Tasks;

namespace PetPalBack.Interfaces.REST.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegistrationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateUserCommand command)
        {
            if (command == null)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok();
            }

            return BadRequest("User with this email already exists.");
        }
    }
}