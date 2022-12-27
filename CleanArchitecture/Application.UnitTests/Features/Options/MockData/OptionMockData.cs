using Application.UnitTests.Features.Options.Builder;
using Domain.Entities;

namespace Application.UnitTests.Features.Options.MockData
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

        public static object? GetOptionCommand()
        {
            throw new NotImplementedException();
        }
    }
}
