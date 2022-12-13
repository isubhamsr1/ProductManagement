using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ProductManagement.API.Controllers;
using ProductManagement.API.Models;
using ProductManagement.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Newtonsoft.Json;
using System.Globalization;

namespace ProductManagement.API
{
    [TestFixture]
    public class ProductControllerTest
    {
        private Mock<IProductRepository> _productRepository;
        private ProductController _productContoller;

        [SetUp]

        public void SetUp()
        {
            _productRepository = new Mock<IProductRepository>();
            _productContoller = new ProductController(_productRepository.Object);
        }

        [Test]
        public void GetAll_VerifyGetAll()
        {
            // Invoke a method in a controller
            _productContoller.Get();
            _productRepository.Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public void AddProduct_CheckModelState()
        {
            _productContoller.ModelState.AddModelError("test", "test");
            var result = _productContoller.Post(new Product());
            var values = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(result);
            var error = values["error"];
            var message = values["message"];
            Assert.IsInstanceOf<string>(result); // bacause we are returning a staring from controller
            Assert.AreEqual(true, error);
            Assert.AreEqual("All Fields are Required", message);

        }

        [Test]
        public void AddProduct_CheckDate()
        {
            var result = _productContoller.Post(new Product()
            {
                Id = 5,
                Name = "Old World Christmas",
                ShortDescription = "ORNAMENTS FOR CHRISTMAS TREE",
                Description = "Octopus on Ball Ornament. Made from mouth blown glass.",
                CategoryId = 3,
                Price = 2000,
                BidEndDate = new DateTime(2022, 11, 20)
            });
            var values = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(result);
            var error = values["error"];
            var message = values["message"];
            
            Assert.AreEqual(true, error);
            Assert.AreEqual("Bid Date Mustbe in Future", message);
        }

        [Test]
        public void AddProduct_CheckWithOutOneField()
        {
            var result = _productContoller.Post(new Product()
            {
                Id = 5,
                Name = "Old World Christmas",
                ShortDescription = "ORNAMENTS FOR CHRISTMAS TREE",
                Description = "Octopus on Ball Ornament. Made from mouth blown glass.",
                CategoryId = 3,
                Price = 2000
            });
            var values = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(result);
            var error = values["error"];
            var message = values["message"];

            Assert.AreEqual(true, error);
            Assert.AreEqual("All Fields are Required", message);
        }
    }
}
