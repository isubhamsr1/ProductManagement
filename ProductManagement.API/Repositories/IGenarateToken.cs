using ProductManagement.API.Models;

namespace ProductManagement.API.Repositories
{
    public interface IGenarateToken
    {
        Task<string> GetTokenAsync(User user);
    }
}
