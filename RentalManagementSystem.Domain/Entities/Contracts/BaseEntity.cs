namespace RentalManagementSystem.Domain.Entities.Contracts
{
    public abstract class BaseEntity : BaseEntity<Guid>
    {

        protected BaseEntity() => Id = Guid.NewGuid();
    }

    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; } = default!;
    }
}