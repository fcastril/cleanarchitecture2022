using Application.DTO;
using MediatR;

namespace Application.Features.Options.Queries.GetAllOption
{
    public class GetAllOptionQuery : IRequest<List<OptionDto>>
    {
    }
}
