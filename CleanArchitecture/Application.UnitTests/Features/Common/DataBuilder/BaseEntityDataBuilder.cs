using Domain.Common;

namespace Application.UnitTests.Common.DataBuilder
{
    public abstract class BaseEntityDataBuilder<T> where T : BaseEntity
    {
        protected T? entity;
        public BaseEntityDataBuilder()
        {
            entity = Activator.CreateInstance(typeof(T)) as T;
        }

        public BaseEntityDataBuilder<T> WithId(Guid value=new Guid())
        {
            this.entity!.Id = value;
            return this;
        }

        public BaseEntityDataBuilder<T> WithCreatedDataTime(DateTime value=new DateTime())
        {
            this.entity!.CreatedDateTime = value;
            return this;
        }

        public BaseEntityDataBuilder<T> WithUpdatedDateTime(DateTime value = new DateTime())
        {
            this.entity!.UpdatedDateTime = value;
            return this;
        }

        public BaseEntityDataBuilder<T> WithState(bool value=true)
        {
            this.entity!.State = value;
            return this;
        }

        public T? Build()
        {
            return entity;
        }

    }
}
