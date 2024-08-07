using backend.Helpers;
using backend.Models;

namespace backend.Interfaces;

public interface IAccountRepo
{
    public Task<List<AppUser>> QueryAllUsersAsync(QueryUser query);
    public Task<List<Relationship>> GetAllFollowersAsync(QueryUser query);
    public Task<List<Relationship>> GetAllFollowingsAsync(QueryUser query);
}