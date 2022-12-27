using AutoMapper;
using Application.Contracts.Persistence;
using Application.Exceptions;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Options.Commands.DeleteOption
{
    public class DeleteOptionCommandHandler : IRequestHandler<DeleteOptionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteOptionCommandHandler> _logger;

        public DeleteOptionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteOptionCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteOptionCommand request, CancellationToken cancellationToken)
        {
            Option optionToDelete = await _unitOfWork.Repository<Option>().GetByIdAsync(request.Id);

            if (optionToDelete == null)
            {
                _logger.LogError($"No se encontro la Option Id {request.Id}");
                throw new NotFoundException(nameof(Option), request.Id);
            }

            _unitOfWork.Repository<Option>().DeleteEntity(optionToDelete);
            await _unitOfWork.Complete();


            _logger.LogInformation($"Se eliminó de forma éxitosamente Option: {request.Id}");

            return Unit.Value;

        }
    }
}
