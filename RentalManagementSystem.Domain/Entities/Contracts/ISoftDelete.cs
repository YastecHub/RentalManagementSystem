namespace RentalManagementSystem.Domain.Entities.Contracts
{
    public interface ISoftDelete
    {
        DateTime? DeletedOn { get; set; }
        Guid? DeletedBy { get; set; }
        bool IsDeleted { get; set; }
    }
}