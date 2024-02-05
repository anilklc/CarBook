using CarBook.Application.Features.Commands.Feature.UpdateFeature;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Commands.Location.UpdateLocation
{
    public class UpdateLocationCommandRequest : IRequest<UpdateLocationCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        

    }
}