using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.User.AddUserRole
{
	public class AddUserRoleCommandHandler : IRequestHandler<AddUserRoleCommandRequest, AddUserRoleCommandResponse>
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<Domain.Entities.AppRole> _roleManager;

		public AddUserRoleCommandHandler(UserManager<AppUser> userManager, RoleManager<Domain.Entities.AppRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public async Task<AddUserRoleCommandResponse> Handle(AddUserRoleCommandRequest request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByNameAsync(request.Username);
			await _userManager.AddToRoleAsync(user,request.Role);
			return new();
		}
	}
}
