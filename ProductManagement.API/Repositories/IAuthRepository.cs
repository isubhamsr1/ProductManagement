using ProductManagement.API.Models;

namespace ProductManagement.API.Repositories
{
    public interface IAuthRepository
    {
        bool Login(User user);
        bool Signup(User user);
    }
}
