using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetPalBack.Domain.Model.Commands;
using System.Threading.Tasks;

namespace PetPalBack.Interfaces.REST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
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

            return Unauthorized();
        }
    }
}
