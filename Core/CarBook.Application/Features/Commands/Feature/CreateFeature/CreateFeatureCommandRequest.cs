using CarBook.Application.Features.Commands.Feature.CreateFeature;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Commands.Feature.CreateFeature
{
    public class CreateFeatureCommandRequest : IRequest<CreateFeatureCommandResponse>
    {
        public string Name { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
    }
}