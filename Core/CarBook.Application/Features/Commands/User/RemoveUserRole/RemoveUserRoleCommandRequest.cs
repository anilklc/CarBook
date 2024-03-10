using MediatR;

namespace CarBook.Application.Features.Commands.User.RemoveUserRole
{
    public class RemoveUserRoleCommandRequest : IRequest<RemoveUserRoleCommandResponse>
    {
        public string Username { get; set; }
        public string Role { get; set; }
    }
}