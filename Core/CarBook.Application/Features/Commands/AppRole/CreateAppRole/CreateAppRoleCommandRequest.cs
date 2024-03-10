using MediatR;

namespace CarBook.Application.Features.Commands.AppRole.CreateAppRole
{
	public class CreateAppRoleCommandRequest : IRequest<CreateAppRoleCommandResponse>
	{
		public string Role {  get; set; }
	}
}