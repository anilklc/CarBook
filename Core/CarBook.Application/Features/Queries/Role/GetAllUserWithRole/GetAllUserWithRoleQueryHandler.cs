using CarBook.Application.DTOs;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Role.GetAllUserWithRole
{
    public class GetAllUserWithRoleQueryHandler : IRequestHandler<GetAllUserWithRoleQueryRequest, GetAllUserWithRoleQueryResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public GetAllUserWithRoleQueryHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<GetAllUserWithRoleQueryResponse> Handle(GetAllUserWithRoleQueryRequest request, CancellationToken cancellationToken)
        {
            var usersWithRoles = new List<UserWithRoleDto>();

            var users = await _userManager.Users.ToListAsync();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                foreach (var roleName in roles)
                {
                    var role = await _roleManager.FindByNameAsync(roleName);
                    usersWithRoles.Add(new UserWithRoleDto
                    {
                        UserId = user.Id.ToString(),
                        Username = user.UserName,
                        RoleId = role.Id.ToString(),
                        RoleName = role.Name
                    });
                }
            }

            return new GetAllUserWithRoleQueryResponse
            {
                UsersWithRoles = usersWithRoles
            };
            
        }

    }
}
