using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, int, BaseDbContext>, IUserOperationClaimRepository
{
    public UserOperationClaimRepository(BaseDbContext context) : base(context) { }

    public async Task<IList<OperationClaim>> GetOperationClaimsByUserIdAsync(int userId)
    {
        var operationClaims = await Query()
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .Select(x => new OperationClaim { Id = x.OperationClaimId, Name = x.OperationClaim.Name })
            .ToListAsync();
        return operationClaims;
    }
}
