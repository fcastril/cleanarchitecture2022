﻿using AutoMapper;
using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Application.DTO;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Features.Options.Queries.GetOptionById
{
    public class GetOptionByIdQueryHandler : IRequestHandler<GetOptionByIdQuery, OptionDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOptionByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OptionDto> Handle(GetOptionByIdQuery request, CancellationToken cancellationToken)
        {
            var ListOption = await _unitOfWork.Repository<Option>().GetByIdAsync(request._Id);
            return _mapper.Map<OptionDto>(ListOption);

        }
    }
}
