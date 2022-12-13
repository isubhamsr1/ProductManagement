using Microsoft.EntityFrameworkCore;

namespace ProductManagement.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; } = false;
        //public List<string> Roles { get; set; } = new List<string>();
    }
}
