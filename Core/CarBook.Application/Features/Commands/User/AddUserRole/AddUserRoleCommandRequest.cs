using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Commands.User.AddUserRole
{
	public class AddUserRoleCommandRequest : IRequest<AddUserRoleCommandResponse>
	{
		public string Username { get; set; }
		public string Role {  get; set; }
	}
}