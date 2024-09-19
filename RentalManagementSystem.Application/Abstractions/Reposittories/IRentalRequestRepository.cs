using RentalManagementSystem.Entities;
namespace RentalManagementSystem.Application.Abstractions.Reposittories
{
    public interface IRentalRequestRepository
    {
        Task<RentalRequest> AddRentalRequest(RentalRequest request);

        Task<RentalRequest?> GetRentalRequestById(Guid retalrequestId);

        Task<IEnumerable<RentalRequest>> GetRentalRequestsByUserIdAsync(string userId);

        Task<IEnumerable<RentalRequest>> GetAllRentalRequests();

        Task UpdateRentalRequest(RentalRequest rentalRequest);

        Task DeleteRentalRequest(Guid rentalrequestId);

        Task<bool> RentalRequestExist(Guid rentalrequestId);
    }
}
