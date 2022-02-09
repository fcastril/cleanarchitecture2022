using MediatR;

namespace CleanArchitecture.Application.Features.Options.Commands.CreateOpion
{
    public class CreateOptionCommand: IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
