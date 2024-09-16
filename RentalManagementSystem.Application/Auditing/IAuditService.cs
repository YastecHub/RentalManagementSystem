namespace RentalManagementSystem.Application.Auditing
{
    public interface IAuditService
    {
        Task<List<AuditDto>> GetUserTrailsAsync(Guid userId);
    }
}