﻿using System.ComponentModel.DataAnnotations;

namespace ProductManagement.API.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
