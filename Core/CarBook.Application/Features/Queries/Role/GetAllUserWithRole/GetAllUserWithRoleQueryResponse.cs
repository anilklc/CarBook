using CarBook.Application.DTOs;

namespace CarBook.Application.Features.Queries.Role.GetAllUserWithRole
{
    public class GetAllUserWithRoleQueryResponse
    {
        public List<UserWithRoleDto> UsersWithRoles { get; set; }
    }
}