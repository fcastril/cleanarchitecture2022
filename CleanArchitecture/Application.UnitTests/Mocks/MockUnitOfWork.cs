using Domain.Common;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Application.UnitTests.Mocks
{
    public static class MockUnitOfWork<T> where T : BaseEntity
    {

        public static Mock<UnitOfWork> GetUnitOfWork()
        {

            MainContext mainContextFake = GenerateDBContext();

            mainContextFake.Database.EnsureDeleted();
            
            var mockUnifOfWork = new Mock<UnitOfWork>(mainContextFake);

            return mockUnifOfWork;
        }

        private static MainContext GenerateDBContext()
        {
            var options = new DbContextOptionsBuilder<MainContext>()
                .UseInMemoryDatabase(databaseName: $"MainContext-{Guid.NewGuid()}")
                .Options;

            var mainContextFake = new MainContext(options);

            return mainContextFake;
        }
    }
}
