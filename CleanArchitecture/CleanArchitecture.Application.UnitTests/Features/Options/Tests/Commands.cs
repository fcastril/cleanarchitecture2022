using AutoMapper;
using CleanArchitecture.Application.Exceptions;
using CleanArchitecture.Application.Features.Options.Commands.CreateOpion;
using CleanArchitecture.Application.Features.Options.Commands.DeleteOption;
using CleanArchitecture.Application.Features.Options.Commands.UpdateOption;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.UnitTests.Mocks;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Features.Options.Tests
{
    public class Commands
    {
        private readonly IMapper _mapper;
        private readonly Mock<ILogger<CreateOptionCommandHandler>> _loggerCreateOptionCommandHandler;
        private readonly Mock<ILogger<UpdateOptionCommandHandler>> _loggerUpdateOptionCommandHandler;
        private readonly Mock<ILogger<DeleteOptionCommandHandler>> _loggerDeleteOptionCommandHandler;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public Commands()
        {
            _unitOfWork = MockUnitOfWork<Option>.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _loggerCreateOptionCommandHandler = new();
            _loggerUpdateOptionCommandHandler = new();
            _loggerDeleteOptionCommandHandler = new();
            MockRepository<Option>.AddDataRepository(_unitOfWork.Object.MainContext);

        }

        [Fact]
        public async Task CreateUpdateOptionTest()
        {
            var handlerCreateOptionCommand = new CreateOptionCommandHandler(_unitOfWork.Object, _mapper, _loggerCreateOptionCommandHandler.Object);
            var requestCreateOptionCommand = new CreateOptionCommand();

            var handlerUpdateOptionCommand = new UpdateOptionCommandHandler(_unitOfWork.Object, _mapper, _loggerUpdateOptionCommandHandler.Object);
            var requestUpdateOptionCommand = new UpdateOptionCommand();

            var handlerDeleteOptionCommand = new DeleteOptionCommandHandler(_unitOfWork.Object, _mapper, _loggerDeleteOptionCommandHandler.Object);
            var requestDeleteOptionCommand = new DeleteOptionCommand();


            var option = new Option();
            option.Id = Guid.NewGuid();
            option.Name = nameof(Option.Name);
            option.Code = nameof(Option.Code);

            requestCreateOptionCommand = _mapper.Map<CreateOptionCommand>(option);

            var resultCreateOptionCommand = await handlerCreateOptionCommand.Handle(requestCreateOptionCommand, CancellationToken.None);
            resultCreateOptionCommand.ShouldBeOfType<Guid>();
            Assert.Equal(resultCreateOptionCommand, option.Id);


            option.Name = $"{nameof(Option.Name)} - Update";
            requestUpdateOptionCommand = _mapper.Map<UpdateOptionCommand>(option);

            var resultUpdateOptionCommand = await handlerUpdateOptionCommand.Handle(requestUpdateOptionCommand, CancellationToken.None);


            resultUpdateOptionCommand.ShouldBeOfType<Guid>();
            Assert.Equal(resultUpdateOptionCommand, option.Id);

            requestDeleteOptionCommand.Id = option.Id;


            var resultDeleteOptionCommand = await handlerDeleteOptionCommand.Handle(requestDeleteOptionCommand, CancellationToken.None);

           resultDeleteOptionCommand.ShouldSatisfyAllConditions();

        }

    }
}
