using AutoMapper;
using Application.Contracts.Persistence;
using Application.Exceptions;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Options.Commands.UpdateOption
{
    public class UpdateOptionCommandHandler : IRequestHandler<UpdateOptionCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateOptionCommandHandler> _logger;

        public UpdateOptionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateOptionCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Guid> Handle(UpdateOptionCommand request, CancellationToken cancellationToken)
        {

            Option optionToUpdate = await _unitOfWork.Repository<Option>().GetByIdAsync(request.Id);


            if (optionToUpdate == null)
            {
                _logger.LogError($"No se encontro la Option Id {request.Id}");
                throw new NotFoundException(nameof(Option), request.Id);
            }
            _mapper.Map(request, optionToUpdate, typeof(UpdateOptionCommand), typeof(Option));

            _unitOfWork.Repository<Option>().UpdateEntity(optionToUpdate);
            await _unitOfWork.Complete();

            _logger.LogInformation($"Se actualizó de forma éxitosamente Option: {request.Id}");

            return optionToUpdate.Id;
        }
    }
}
