using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, int, BaseDbContext>, IRefreshTokenRepository
{
    public RefreshTokenRepository(BaseDbContext context) : base(context) { }

    public async Task<List<RefreshToken>> GetOldRefreshTokensAsync(int userId, int refreshTokenTTL)
    {
        List<RefreshToken> tokens = await Query()
            .AsNoTracking()
            .Where(x =>
                x.UserId == userId &&
                x.Revoked == null &&
                x.Expires >= DateTime.UtcNow &&
                x.CreatedDate.AddDays(refreshTokenTTL) <= DateTime.UtcNow
            ).ToListAsync();
        return tokens;
    }
}
