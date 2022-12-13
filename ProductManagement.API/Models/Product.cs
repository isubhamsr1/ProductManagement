using System.Xml.Linq;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        //public int UserId { get; set; }
        public long Price { get; set; }
        public DateTime BidEndDate { get; set; }
        public Category? Category { get; set; }
        //public User? User { get; set; }

    }
}
