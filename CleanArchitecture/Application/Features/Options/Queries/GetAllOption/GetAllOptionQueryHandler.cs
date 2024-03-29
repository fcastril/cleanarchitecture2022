﻿using AutoMapper;
using Application.Contracts.Persistence;
using Application.DTO;
using Domain.Entities;
using MediatR;

namespace Application.Features.Options.Queries.GetAllOption
{
    public class GetAllOptionQueryHandler : IRequestHandler<GetAllOptionQuery, List<OptionDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllOptionQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<OptionDto>> Handle(GetAllOptionQuery request, CancellationToken cancellationToken)
        {
            var ListOption = await _unitOfWork.Repository<Option>().GetAllAsync();
            return _mapper.Map<List<OptionDto>>(ListOption);

        }
    }
}
