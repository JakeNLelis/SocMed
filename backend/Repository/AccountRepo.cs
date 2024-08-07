using backend.Helpers;
using backend.Interfaces;
using backend.Models;

namespace backend.Repository;

public class AccountRepo : IAccountRepo
{
    public async Task<List<Relationship>> GetAllFollowersAsync(QueryUser query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Relationship>> GetAllFollowingsAsync(QueryUser query)
    {
        throw new NotImplementedException();
    }

    public async Task<List<AppUser>> QueryAllUsersAsync(QueryUser query)
    {
        throw new NotImplementedException();
    }
}