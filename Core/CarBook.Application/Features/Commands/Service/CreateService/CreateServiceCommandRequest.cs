using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Commands.Service.CreateService
{
    public class CreateServiceCommandRequest : IRequest<CreateServiceCommandResponse>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}