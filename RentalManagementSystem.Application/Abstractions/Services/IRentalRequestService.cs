using RentalManagementSystem.Application.DTOs;

namespace RentalManagementSystem.Application.Abstractions.Services
{
    public interface IRentalRequestService
    {
        Task<ResponseModel<RentalRequestDto>> CreateRentalRequest(CreateRentalRequestDto createRentalRequest);

        Task<ResponseModel<RentalRequestDto>> UpdateRentalRequest(UpdateRentalRequestDto updateRentalRequest);

        Task<ResponseModel<RentalRequestDto>> GetRentalRequestById(Guid rentalRequestId);

        Task<ResponseModel<IEnumerable<RentalRequestDto>>> GetRentalRequestsByUserId(Guid userId);

        Task<ResponseModel<IEnumerable<RentalRequestDto>>> GetAllRentalRequests();

        Task<ResponseModel> DeleteRentalRequest(Guid rentalRequestId);

        Task<ResponseModel<RentalRequestDto>> ApproveRentalRequest(Guid rentalRequestId);

        Task<ResponseModel<RentalRequestDto>> RejectRentalRequest(Guid rentalRequestId);
    }
}
