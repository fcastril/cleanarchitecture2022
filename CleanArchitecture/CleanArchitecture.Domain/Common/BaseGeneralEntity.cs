﻿using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Common
{
    public abstract class BaseGeneralEntity : BaseEntity
    {
        public Guid CompanyId { get; set; }
        public virtual Company? Company { get; set; }
        public Guid UserCreatedId { get; set; }
        public virtual User? UserCreated { get; set; }
        public Guid UserUpdatedId { get; set; }
        public virtual User? UserUpdated { get; set; }

    }
}