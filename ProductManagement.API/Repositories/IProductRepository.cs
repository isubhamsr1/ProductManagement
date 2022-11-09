using ProductManagement.API.Models;

namespace ProductManagement.API.Repositories
{
    public interface IProductRepository
    {
        bool AddProduct(Product product);
        List<Product> GetAll();
        List<Product> GetById(int id);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
        bool CheckDate(DateTime date);
    }
}
