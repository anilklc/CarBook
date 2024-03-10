using Azure.Identity;
using CarBook.Application.Features.Commands.AppRole.CreateAppRole;
using CarBook.Application.Features.Commands.Service.RemoveService;
using CarBook.Application.Features.Commands.User.AddUserRole;
using CarBook.Application.Features.Commands.User.RemoveUserRole;
using CarBook.Application.Features.Queries.Role.GetAllRole;
using CarBook.Application.Features.Queries.Role.GetAllUserWithRole;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RolesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public RolesController(IMediator mediator)
		{
			_mediator = mediator;
		}
		//[Authorize(Roles ="Admin")]
		[HttpGet("[action]")]
		public async Task<IActionResult> GetAllRole()
		{
			GetAllRoleQueryResponse response = await _mediator.Send(new GetAllRoleQueryRequest());
			return Ok(response);
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> CreateRole([FromBody] CreateAppRoleCommandRequest request)
		{
			CreateAppRoleCommandResponse response = await _mediator.Send(request);
			return Ok(response);
		}

		[HttpPost("[action]")]
		public async Task<IActionResult> AddRoleUser([FromBody] AddUserRoleCommandRequest request)
		{
			AddUserRoleCommandResponse response = await _mediator.Send(request);
			return Ok(response);
		}

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUserWithRole()
        {
            GetAllUserWithRoleQueryResponse response = await _mediator.Send(new GetAllUserWithRoleQueryRequest());
            return Ok(response);
        }

        [HttpDelete("[action]/{username}/{role}")]
        public async Task<IActionResult> RemoveRole(string username,string role)
        {
            RemoveUserRoleCommandRequest request = new RemoveUserRoleCommandRequest { Username =username,Role = role };
            RemoveUserRoleCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
