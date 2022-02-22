using CleanArchitecture.Application.DTO;
using MediatR;

namespace CleanArchitecture.Application.Features.Options.Queries.GetAllOption
{
    public class GetAllOptionQuery : IRequest<List<OptionDto>>
    {
    }
}
