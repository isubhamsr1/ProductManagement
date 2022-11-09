using ProductManagement.API.Models;

namespace ProductManagement.API.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
    }
}
