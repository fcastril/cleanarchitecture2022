using AutoMapper;
using Application.Contracts.Persistence;
using Application.DTO;
using Domain.Entities;
using MediatR;

namespace Application.Features.Options.Queries.GetOptionByCode
{
    public class GetOptionByCodeQueryHandler : IRequestHandler<GetOptionByCodeQuery, OptionDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOptionByCodeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OptionDto> Handle(GetOptionByCodeQuery request, CancellationToken cancellationToken)
        {
            var option = await _unitOfWork.Repository<Option>().GetAsync(x => x.Code == request._Code);
            return _mapper.Map<OptionDto>(option.FirstOrDefault());

        }
    }
}
