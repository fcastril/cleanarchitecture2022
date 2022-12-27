using AutoMapper;
using Application.DTO;
using Application.Features.Options.Queries.GetAllOption;
using Application.Features.Options.Queries.GetOptionByCode;
using Application.Features.Options.Queries.GetOptionById;
using Application.Mappings;
using Application.UnitTests.Features.Options.MockData;
using Application.UnitTests.Mocks;
using Domain.Entities;
using Infrastructure.Repositories;
using Moq;
using Shouldly;
using Xunit;

namespace Application.UnitTests.Features.Options.Tests
{
    public class Queries
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public Queries()
        {
            _unitOfWork = MockUnitOfWork<Option>.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            MockRepository<Option>.AddDataRepository(_unitOfWork.Object.MainContext);
        }

        [Fact]
        public async Task GetOptionListTest()
        {
            var handler = new GetAllOptionQueryHandler(_unitOfWork.Object, _mapper);
            var request = new GetAllOptionQuery();

            var result = await handler.Handle(request, CancellationToken.None);

            result.ShouldBeOfType<List<OptionDto>>();
            result.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task GetOptionByCodeAndId()
        {
            var handlerCode = new GetOptionByCodeQueryHandler(_unitOfWork.Object, _mapper);
            var handlerId = new GetOptionByIdQueryHandler(_unitOfWork.Object, _mapper);

            List<Option> optionList = new List<Option>();
            var option = OptionMockData.GetOption() ?? new();
            optionList.Add(option);

            MockRepository<Option>.AddDataRepository(_unitOfWork.Object.MainContext, optionList);


            var requestCode = new GetOptionByCodeQuery(nameof(Option.Code));
            var resultCode = await handlerCode.Handle(requestCode, CancellationToken.None);
            resultCode.ShouldBeOfType<OptionDto>();
            Assert.Equal(nameof(Option.Code), resultCode.Code);

            var requestId = new GetOptionByIdQuery(resultCode.Id);
            var resultId = await handlerId.Handle(requestId, CancellationToken.None);
            resultCode.ShouldBeOfType<OptionDto>();
            Assert.Equal(resultCode.Id, resultId.Id);
        }

    }
}
