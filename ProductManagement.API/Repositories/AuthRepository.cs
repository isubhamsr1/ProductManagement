using ProductManagement.API.Data;
using ProductManagement.API.Models;

namespace ProductManagement.API.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppicationDbContext _context;
        private readonly IGenarateToken _genarateToken;
        public AuthRepository(AppicationDbContext context, IGenarateToken genarateToken)
        {
            _context = context;
            _genarateToken = genarateToken;
        }
        public bool Login(User user)
        {
            try
            {
                var userDetails = _context.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();

                if(userDetails != null)
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

                throw;
            }
        }

        public bool Signup(User user)
        {
            try
            {
                    var userDetails = _context.Users.Where(u => u.UserName == user.UserName).FirstOrDefault();
                    if (userDetails == null)
                    {
                        _context.Users.Add(user);
                    _context.SaveChanges();
                        return true;
                    }
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
