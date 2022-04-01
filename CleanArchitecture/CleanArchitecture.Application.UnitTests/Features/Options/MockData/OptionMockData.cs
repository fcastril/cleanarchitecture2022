using CleanArchitecture.Application.UnitTests.Features.Options.Builder;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UnitTests.Features.Options.MockData
{
    public static class OptionMockData
    {
        public static Option? GetOption()
        {
            return new OptionDataBuilder()
                                        .WithCode(nameof(Option.Code))
                                        .WithName(nameof(Option.Name))
                                        .Build();
        }
    }
}
