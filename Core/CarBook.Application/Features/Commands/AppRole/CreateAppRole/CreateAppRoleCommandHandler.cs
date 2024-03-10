using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.AppRole.CreateAppRole
{
	public class CreateAppRoleCommandHandler : IRequestHandler<CreateAppRoleCommandRequest, CreateAppRoleCommandResponse>
	{
		private readonly RoleManager<Domain.Entities.AppRole> _roleManager;

		public CreateAppRoleCommandHandler(RoleManager<Domain.Entities.AppRole> roleManager)
		{
			_roleManager = roleManager;
		}

		public async Task<CreateAppRoleCommandResponse> Handle(CreateAppRoleCommandRequest request, CancellationToken cancellationToken)
		{
			await _roleManager.CreateAsync(new() { Name = request.Role});
			return new();
		}
	}
}
