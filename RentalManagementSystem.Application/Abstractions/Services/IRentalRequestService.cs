using RentalManagementSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagementSystem.Application.Abstractions.Services
{
    public interface IRentalRequestService
    {
        Task<ResponseModel<RentalRequestDto>> CreateRentalRequest(CreateRentalRequestDto createRentalRequest);

        Task<ResponseModel<RentalRequestDto>> UpdateRentalRequest(UpdateRentalRequestDto updateRentalRequest);

        Task<ResponseModel<RentalRequestDto>> GetRentalRequestById(Guid rentalRequestId);

        Task<ResponseModel<IEnumerable<RentalRequestDto>>> GetRentalRequestsByUserId(string userId);

        Task<ResponseModel<IEnumerable<RentalRequestDto>>> GetAllRentalRequests();

        Task<ResponseModel> DeleteRentalRequest(Guid rentalRequestId);
    }
}
