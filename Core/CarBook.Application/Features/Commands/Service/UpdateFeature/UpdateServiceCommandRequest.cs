using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Commands.Service.UpdateService
{
    public class UpdateServiceCommandRequest : IRequest<UpdateServiceCommandResponse>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }

    }
}