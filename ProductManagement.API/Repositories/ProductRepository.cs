using Microsoft.EntityFrameworkCore;
using ProductManagement.API.Data;
using ProductManagement.API.Models;

namespace ProductManagement.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppicationDbContext _context;
        public ProductRepository(AppicationDbContext context)
        {
            _context = context;
        }
        public bool AddProduct(Product product)
        {
            try
            {
                if(product != null)
                {
                    _context.Products.Add(product);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public bool CheckDate(DateTime date)
        {
            try
            {
                DateTime today = DateTime.Now;
                if(date > today)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                var product = _context.Products.Where(p => p.Id == id).FirstOrDefault();
                if (product != null)
                {
                    _context.Entry(product).State = EntityState.Deleted;
                    _context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public List<Product> GetAll()
        {
            try
            {
                var products = _context.Products.ToList();
                return products;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public List<Product> GetById(int id)
        {
            try
            {
                var product = _context.Products.Where(p => p.Id == id).ToList();
                return product;
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                var productId = product.Id;
                var data = _context.Products.Where(p => p.Id == productId).FirstOrDefault();
                if(data != null)
                {
                    data.Name = product.Name;
                    data.Price = product.Price;
                    data.CategoryId = product.CategoryId;
                    data.ShortDescription = product.ShortDescription;
                    data.Description = product.Description;
                    data.BidEndDate = product.BidEndDate;

                    _context.Entry(data).State = EntityState.Modified;
                    _context.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}
