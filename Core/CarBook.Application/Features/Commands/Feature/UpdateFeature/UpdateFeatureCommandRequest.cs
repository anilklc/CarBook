using CarBook.Application.Features.Commands.Feature.UpdateFeature;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Commands.Feature.UpdateFeature
{
    public class UpdateFeatureCommandRequest : IRequest<UpdateFeatureCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }

    }
}