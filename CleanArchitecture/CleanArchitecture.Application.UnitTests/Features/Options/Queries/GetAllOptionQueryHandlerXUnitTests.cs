using AutoMapper;
using CleanArchitecture.Application.DTO;
using CleanArchitecture.Application.Features.Options.Queries.GetAllOption;
using CleanArchitecture.Application.Mappings;
using CleanArchitecture.Application.UnitTests.Mocks;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Repositories;
using Moq;
using Shouldly;
using Xunit;

namespace CleanArchitecture.Application.UnitTests.Features.Options.Queries
{
    public class GetAllOptionQueryHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public GetAllOptionQueryHandlerXUnitTests()
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
    }
}
