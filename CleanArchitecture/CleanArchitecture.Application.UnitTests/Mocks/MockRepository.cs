using AutoFixture;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Infrastructure.Persistence;

namespace CleanArchitecture.Application.UnitTests.Mocks
{
    public static class MockRepository<T> where T : BaseEntity
    {
        public static void AddDataRepository(MainContext mainContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var mockDataList = fixture.CreateMany<T>().ToList();

            mainContextFake.Set<T>().AddRange(mockDataList);
            mainContextFake.SaveChanges();

        }

        public static void AddDataRepository(MainContext mainContextFake, List<T> mockDataList)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            mainContextFake.Set<T>().AddRange(mockDataList);
            mainContextFake.SaveChanges();
        }

    }
}
