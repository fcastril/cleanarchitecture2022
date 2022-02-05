using MediatR;

namespace CleanArchitecture.Application.Features.Options.Commands.DeleteOption
{
    public class DeleteOptionCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
