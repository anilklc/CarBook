using CarBook.Application.DTOs;
using CarBook.Application.Features.Commands.Car.CreateCar;
using CarBook.Application.Features.Commands.User.CreateUser;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IMediator _mediator;

		public UsersController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandRequest request)
		{
			CreateUserCommandResponse response = await _mediator.Send(request);
			return Ok(response);
		}



	}
}
