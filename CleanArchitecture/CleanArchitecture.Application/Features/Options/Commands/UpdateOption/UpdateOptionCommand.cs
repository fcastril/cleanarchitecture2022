using MediatR;

namespace CleanArchitecture.Application.Features.Options.Commands.UpdateOption
{
    public class UpdateOptionCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
