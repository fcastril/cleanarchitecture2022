﻿using CleanArchitecture.Application.UnitTests.Common.DataBuilder;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.UnitTests.Features.Options.Builder

{
    public class OptionDataBuilder : BaseEntityDataBuilder<Option>
    {

        public OptionDataBuilder() : base()
        {
        }

        public OptionDataBuilder WithCode(string value)
        {
            this.entity!.Code = value;
            return this;
        }

        public OptionDataBuilder WithName(string value)
        {
            this.entity!.Name = value;
            return this;
        }

    }
}
