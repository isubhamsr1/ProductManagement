using ProductManagement.API.Models;
using ProductManagement.API.Data;

namespace ProductManagement.API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppicationDbContext _context;
        public CategoryRepository(AppicationDbContext context)
        {
            _context = context;
        }
        public List<Category> GetAll()
        {
			try
			{
                var categories = _context.Categories.ToList();
                return categories;
			}
			catch (Exception)
			{

                throw new Exception();
            }
        }
    }
}
