using Microsoft.AspNetCore.Mvc;
using RentalManagementSystem.Application.Abstractions.Services;
using RentalManagementSystem.Application.DTOs;

namespace RentalManagementSystem.Hosts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalRequestController : ControllerBase
    {
        private readonly IRentalRequestService _rentalRequestService;

        public RentalRequestController(IRentalRequestService rentalRequestService)
        {
            _rentalRequestService = rentalRequestService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRentalRequest([FromBody] CreateRentalRequestDto createRentalRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _rentalRequestService.CreateRentalRequest(createRentalRequestDto);
            if (!response.IsSuccessful)
            {
                return BadRequest(response.Message);
            }
            return CreatedAtAction(nameof(GetRentalRequestById),
                new { id = response.Data.Id },
                response.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentalRequest(Guid id)
        {
            var response = await _rentalRequestService.DeleteRentalRequest(id);
            if (!response.IsSuccessful)
            {
                return NotFound(response.Message);
            }
            return Ok(response.Message);    
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentalRequestById(Guid id)
        {
            var response = await _rentalRequestService.GetRentalRequestById(id);
            if (!response.IsSuccessful)
            {
                return NotFound(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRentalRequests()
        {
            var rentalRequests = await _rentalRequestService.GetAllRentalRequests();
            return Ok(rentalRequests);  
        }

        [HttpGet("User/{userId}")]
        public async Task<IActionResult> GetRentalRequestByUserId(Guid userId)
        {
            var response = await _rentalRequestService.GetRentalRequestsByUserId(userId);
            if (!response.IsSuccessful)
            {
                return NotFound(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRentalRequest(Guid id, [FromBody] UpdateRentalRequestDto updateRentalRequestDto)
        {
            if(id != updateRentalRequestDto.Id)
            {
                return BadRequest("Rental Request ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _rentalRequestService.UpdateRentalRequest(updateRentalRequestDto);
            if (!response.IsSuccessful)
            {
                return NotFound(response.Message);
            }
            return Ok(response.Data);
        }

        [HttpPost("{id}/Approve")]
        public async Task<IActionResult> ApproveRentalRequest(Guid id)
        {
            var response = await _rentalRequestService.ApproveRentalRequest(id);
            if (!response.IsSuccessful)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }

        [HttpPost("{id}/Reject")]
        public async Task<IActionResult> RejectRentalRequest(Guid id)
        {
            var response = await _rentalRequestService.RejectRentalRequest(id);
            if (!response.IsSuccessful)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);    
        }
    }
}
