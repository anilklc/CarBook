using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Commands.User.CreateUser
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly PasswordHasher<AppUser> _passwordHasher;

		public CreateUserCommandHandler(UserManager<AppUser> userManager, PasswordHasher<AppUser> passwordHasher)
		{
			_userManager = userManager;
			_passwordHasher = passwordHasher;
		}

		public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
		{
			var newUser = new AppUser
			{
				Email = request.Email,
				Name = request.Name,
				Surname = request.Surname,
				UserName = request.Email,
			};
			newUser.PasswordHash = _passwordHasher.HashPassword(newUser, request.Password);
			await _userManager.CreateAsync(newUser);
			return new();
		}
	}
}
