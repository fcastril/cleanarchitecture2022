using CleanArchitecture.Application.DTO;
using MediatR;

namespace CleanArchitecture.Application.Features.Options.Queries.GetOptionById
{
    public class GetOptionByIdQuery : IRequest<OptionDto>
    {
        public Guid _Id { get; set; }

        public GetOptionByIdQuery(Guid id)
        {
            _Id = id;
        }
    }
}
