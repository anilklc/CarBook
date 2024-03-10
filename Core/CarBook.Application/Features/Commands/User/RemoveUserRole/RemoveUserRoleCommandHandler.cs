using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.User.RemoveUserRole
{
    public class RemoveUserRoleCommandHandler : IRequestHandler<RemoveUserRoleCommandRequest, RemoveUserRoleCommandResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<Domain.Entities.AppRole> _roleManager;

        public RemoveUserRoleCommandHandler(UserManager<AppUser> userManager, RoleManager<Domain.Entities.AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<RemoveUserRoleCommandResponse> Handle(RemoveUserRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            await _userManager.RemoveFromRoleAsync(user, request.Role);
            return new();
        }
    }
}
