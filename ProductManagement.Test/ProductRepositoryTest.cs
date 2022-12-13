using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductManagement.API.Models;
using Microsoft.EntityFrameworkCore;
using ProductManagement.API.Data;
using ProductManagement.API.Repositories;

namespace ProductManagement.API
{
    [TestFixture]
    public class ProductRepositoryTest
    {
        private Product product_ONE;
        private Product product_TWO;

        public ProductRepositoryTest()
        {
            product_ONE = new Product() 
            { 
                Id = 5,
                Name = "Old World Christmas",
                ShortDescription = "ORNAMENTS FOR CHRISTMAS TREE",
                Description = "Octopus on Ball Ornament. Made from mouth blown glass.",
                CategoryId = 3,
                Price = 2000,
                BidEndDate = new DateTime(2022, 12, 12)
            };

            product_TWO = new Product()
            {
                Id = 11,
                Name = "Old World Christmas",
                ShortDescription = "ORNAMENTS FOR CHRISTMAS TREE",
                Description = "Octopus on Ball Ornament. Made from mouth blown glass.",
                CategoryId = 1,
                Price = 2000,
                BidEndDate = new DateTime(2022, 12, 12)
            };
        }

        [Test]
        [Order(1)]
        public void AddProduct_Product_ONE_CheckTheValuesFromDatabase()
        {
            //arrange
            var option = new DbContextOptionsBuilder<AppicationDbContext>()
                                .UseInMemoryDatabase(databaseName: "temp_ProductManagement")
                                .Options;

            //act
            using (var context = new AppicationDbContext(option))
            {
                var repository = new ProductRepository(context);
                repository.AddProduct(product_ONE);
            }

            //assert
            using (var context = new AppicationDbContext(option))
            {
                var productFromDatabase = context.Products.FirstOrDefault(p => p.Id == 11);
                Assert.AreEqual(product_TWO.CategoryId, productFromDatabase.CategoryId);
                Assert.AreEqual(product_TWO.Id, productFromDatabase.Id);
                Assert.AreEqual(product_TWO.BidEndDate, productFromDatabase.BidEndDate);
            }
        }

    }
}
