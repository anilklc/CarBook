using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Queries.Role.GetAllRole
{
	public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQueryRequest, GetAllRoleQueryResponse>
	{
		private readonly RoleManager<AppRole> _roleManager;

		public GetAllRoleQueryHandler(RoleManager<AppRole> roleManager)
		{
			_roleManager = roleManager;
		}

		public async Task<GetAllRoleQueryResponse> Handle(GetAllRoleQueryRequest request, CancellationToken cancellationToken)
		{
			var roles = await _roleManager.Roles.ToListAsync();

			return new()
			{
				Roles = roles,
			};

		}
	}
}
