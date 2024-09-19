using RentalManagementSystem.Application.Abstractions.Reposittories;
using RentalManagementSystem.Application.Abstractions.Services;
using RentalManagementSystem.Application.DTOs;
using RentalManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalManagementSystem.Application.Services
{
    public class RentalRequestService : IRentalRequestService
    {
        private readonly IRentalRequestRepository _rentalRequestRepository;

        public RentalRequestService(IRentalRequestRepository rentalRequestRepository)
        {
            _rentalRequestRepository = rentalRequestRepository;
        }
        public async Task<ResponseModel<RentalRequestDto>> CreateRentalRequest(CreateRentalRequestDto createRentalRequest)
        {
            try
            {
                var rentalRequest = new RentalRequest
                {
                    UserId = createRentalRequest.UserId,
                    ProductId = Guid.Parse(createRentalRequest.ProductId),
                    RentalPeriod = createRentalRequest.RentalPeriod,
                    RentalStartDate = createRentalRequest.RentalStartDate,
                    RentalEndDate = createRentalRequest.RentalEndDate,
                    Status = createRentalRequest.Status
                };
                var createdRequest = await _rentalRequestRepository.AddRentalRequest(rentalRequest);

                if (createdRequest == null)
                {
                    return new ResponseModel<RentalRequestDto>
                    {
                        IsSuccessful = false,
                        StatusCode = 400,
                        Message = "Failed to create rental request",
                    };
                }

                var rentalRequestDto = new RentalRequestDto
                {
                    Id = createdRequest.Id,
                    UserId = createdRequest.UserId,
                    ProductId = createdRequest.ProductId.ToString(),
                    RentalPeriod = createdRequest.RentalPeriod,
                    RentalStartDate = createdRequest.RentalStartDate,
                    RentalEndDate = createdRequest.RentalEndDate,
                    Status = createdRequest.Status
                };

                return new ResponseModel<RentalRequestDto>
                {
                    IsSuccessful = true,
                    StatusCode = 200,
                    Message = "Rental request Created successfully",
                    Data = rentalRequestDto
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<RentalRequestDto>
                {
                    IsSuccessful = true,
                    StatusCode = 200,
                    Message = $"Error occurred while creating rental request: {ex.Message}"
                };
            }

        }

        public async Task<ResponseModel> DeleteRentalRequest(Guid rentalRequestId)
        {
            try
            {
                var rentalRequest = await _rentalRequestRepository.GetRentalRequestById(rentalRequestId);

                if (rentalRequest == null)
                {
                    return new ResponseModel
                    {
                        IsSuccessful = false,
                        StatusCode = 400,
                        Message = "Rental Request not found"
                    };
                }
                await _rentalRequestRepository.DeleteRentalRequest(rentalRequestId);

                return new ResponseModel
                {
                    IsSuccessful = true,
                    StatusCode = 200,
                    Message = $"Rental request with Id {rentalRequestId} deleted successfully"
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel
                {
                    IsSuccessful = false,
                    StatusCode = 500,
                    Message = $"Error occurred while deleting rental request: {ex.Message}"
                };
            }
        }

        public async Task<ResponseModel<IEnumerable<RentalRequestDto>>> GetAllRentalRequests()
        {
            try
            {
                var rentalRequests = await _rentalRequestRepository.GetAllRentalRequests();

                var rentalRequestDtos = rentalRequests.Select(request => new RentalRequestDto
                {
                    Id = request.Id,
                    UserId = request.UserId,
                    ProductId = request.ProductId.ToString(),
                    RentalPeriod = request.RentalPeriod,
                    RentalStartDate = request.RentalStartDate,
                    RentalEndDate = request.RentalEndDate,
                    Status = request.Status,
                });

                return new ResponseModel<IEnumerable<RentalRequestDto>>
                {
                    IsSuccessful = true,
                    StatusCode = 200,
                    Message = "All rental requests returned successfully",
                    Data = rentalRequestDtos
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<IEnumerable<RentalRequestDto>>
                {
                    IsSuccessful = false,
                    StatusCode = 500,
                    Message = $"Error occurred while retrieving all rental requests: {ex.Message}"
                };
            }
            
        }

        public async Task<ResponseModel<RentalRequestDto>> GetRentalRequestById(Guid rentalRequestId)
        {
            try
            {
                var rentalRequest = await _rentalRequestRepository.GetRentalRequestById(rentalRequestId);

                if (rentalRequest == null)
                {
                    return new ResponseModel<RentalRequestDto>
                    {
                        IsSuccessful = false,
                        StatusCode = 400,
                        Message = "Rental Request not found"
                    };
                }

                var rentalRequestDto = new RentalRequestDto
                {
                    Id = rentalRequest.Id,
                    UserId = rentalRequest.UserId,
                    ProductId = rentalRequest.ProductId.ToString(),
                    RentalPeriod = rentalRequest.RentalPeriod,
                    RentalStartDate = rentalRequest.RentalStartDate,
                    RentalEndDate = rentalRequest.RentalEndDate,
                    Status = rentalRequest.Status
                };

                return new ResponseModel<RentalRequestDto>
                {
                    IsSuccessful = true,
                    StatusCode = 200,
                    Message = "Rental Request retrieved successfully",
                    Data = rentalRequestDto
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<RentalRequestDto>
                {
                    IsSuccessful = true,
                    StatusCode = 400,
                    Message = $"Error occurred while retrieving rental request: {ex.Message}"
                };
            }
        }

        public async Task<ResponseModel<IEnumerable<RentalRequestDto>>> GetRentalRequestsByUserId(string userId)
        {
            try
            {
                var rentalRequests = await _rentalRequestRepository.GetRentalRequestsByUserIdAsync(userId);

                var rentalRequestDtos = rentalRequests.Select(request => new RentalRequestDto
                {
                    Id = request.Id,
                    UserId = request.UserId,
                    ProductId = request.ProductId.ToString(),
                    RentalPeriod = request.RentalPeriod,
                    RentalStartDate = request.RentalStartDate,
                    RentalEndDate = request.RentalEndDate,
                    Status = request.Status

                }).ToList();

                return new ResponseModel<IEnumerable<RentalRequestDto>>
                {
                    IsSuccessful = true,
                    StatusCode = 200,
                    Message = "Rental Request Retrieved successfully",
                    Data = rentalRequestDtos
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<IEnumerable<RentalRequestDto>>
                {
                    IsSuccessful = false,
                    StatusCode = 500,
                    Message = $"Error occurred while retrieving rental requests: {ex.Message}"
                };
            }

        }

        public async Task<ResponseModel<RentalRequestDto>> UpdateRentalRequest(UpdateRentalRequestDto updateRentalRequest)
        {
            try
            {
                var existingRequest = await _rentalRequestRepository.GetRentalRequestById(updateRentalRequest.Id);

                if (existingRequest != null)
                {
                    return new ResponseModel<RentalRequestDto>
                    {
                        IsSuccessful = false,
                        StatusCode = 400,
                        Message = "Rental Request not found"
                    };
                }

                existingRequest.UserId = updateRentalRequest.UserId;
                existingRequest.ProductId = Guid.Parse(updateRentalRequest.ProductId);
                existingRequest.RentalPeriod = updateRentalRequest.RentalPeriod;
                existingRequest.RentalStartDate = updateRentalRequest.RentalStartDate;
                existingRequest.RentalEndDate = updateRentalRequest.RentalEndDate;
                existingRequest.Status = updateRentalRequest.Status;

                await _rentalRequestRepository.UpdateRentalRequest(existingRequest);

                var retalRequestDto = new RentalRequestDto
                {
                    Id = existingRequest.Id,
                    UserId = existingRequest.UserId,
                    ProductId = existingRequest.ProductId.ToString(),
                    RentalPeriod = existingRequest.RentalPeriod,
                    RentalEndDate = existingRequest.RentalEndDate,
                    RentalStartDate = existingRequest.RentalStartDate,
                    Status = existingRequest.Status,
                };

                return new ResponseModel<RentalRequestDto>
                {
                    IsSuccessful = true,
                    StatusCode = 200,
                    Message = "Rental Request Updated successfully",
                    Data = retalRequestDto
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel<RentalRequestDto>
                {
                    IsSuccessful = true,
                    StatusCode = 400,
                    Message = $"Error occurred while updating rental request: {ex.Message}"
                };
            }

        }
    }
}
