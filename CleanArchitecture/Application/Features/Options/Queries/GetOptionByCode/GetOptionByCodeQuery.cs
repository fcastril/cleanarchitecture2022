using Application.DTO;
using MediatR;

namespace Application.Features.Options.Queries.GetOptionByCode
{
    public class GetOptionByCodeQuery : IRequest<OptionDto>
    {
        public string _Code { get; set; } = string.Empty;

        public GetOptionByCodeQuery(string code)
        {
            _Code = code??throw new ArgumentNullException(nameof(code)); ;
        }
    }
}
