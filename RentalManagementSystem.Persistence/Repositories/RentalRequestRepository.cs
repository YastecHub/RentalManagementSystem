using Microsoft.EntityFrameworkCore;
using RentalManagementSystem.Application.Abstractions.Reposittories;
using RentalManagementSystem.Entities;
using RentalManagementSystem.Persistence.Context;

namespace RentalManagementSystem.Persistence.Repositories
{
    public class RentalRequestRepository : IRentalRequestRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public RentalRequestRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<RentalRequest> AddRentalRequest(RentalRequest request)
        {
            await _applicationDbContext.RentalRequests.AddAsync(request);
            await _applicationDbContext.SaveChangesAsync();
            return request;
        }

        public async Task DeleteRentalRequest(Guid rentalrequestid)
        {
            var rentalRequest = await _applicationDbContext.RentalRequests.FindAsync(rentalrequestid);
            if (rentalRequest != null)
            {
                _applicationDbContext.RentalRequests.Remove(rentalRequest);
                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<RentalRequest>> GetAllRentalRequests()
        {
            return await _applicationDbContext.RentalRequests
                .Include(r => r.User)
                .Include(r => r.Product)
                .ToListAsync();
        }

        public async Task<RentalRequest?> GetRentalRequestById(Guid retalrequestId)
        {
            return await _applicationDbContext.RentalRequests
                .Include(r => r.User)
                .Include(r => r.Product)
                .FirstOrDefaultAsync(r => r.Id == retalrequestId);
        }

        public async Task<IEnumerable<RentalRequest>> GetRentalRequestsByUserIdAsync(string userId)
        {
           return await _applicationDbContext.RentalRequests
                 .Include(r => r.User)
                 .Include(r => r.Product)
                 .Where(r => r.UserId == userId)
                 .ToListAsync();
        }

        public async Task<bool> RentalRequestExist(Guid rentalRequestId)
        {
            return await _applicationDbContext.RentalRequests.AnyAsync(r => r.Id == rentalRequestId);
        }

        public async Task UpdateRentalRequest(RentalRequest rentalRequest)
        {
           _applicationDbContext.RentalRequests.Update(rentalRequest);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
