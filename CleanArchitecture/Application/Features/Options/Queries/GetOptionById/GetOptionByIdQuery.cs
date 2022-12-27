using Application.DTO;
using MediatR;

namespace Application.Features.Options.Queries.GetOptionById
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
