using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductManagement.API.Models;
using ProductManagement.API.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private IDictionary<string, dynamic> response = new Dictionary<string, dynamic>();
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public string Get()
        {
            try
            {
                var data = _productRepository.GetAll();
                if (data.Count > 0)
                {
                    response.Add("error", false);
                    response.Add("message", "Products are fetch");
                    response.Add("data", data);

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "There is no Products");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
            }
            catch (Exception ex)
            {

                response.Add("error", true);
                response.Add("message", ex.Message);

                string jsonResponse = JsonConvert.SerializeObject(response);

                return jsonResponse;
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            try
            {
                var data = _productRepository.GetById(id);
                if (data.Count > 0)
                {
                    response.Add("error", false);
                    response.Add("message", "Product are fetch");
                    response.Add("data", data);

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "There is no Product");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
            }
            catch (Exception ex)
            {

                response.Add("error", true);
                response.Add("message", ex.Message);

                string jsonResponse = JsonConvert.SerializeObject(response);

                return jsonResponse;
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public string Post([FromBody] Product value)
        {
            try
            {
                DateTime bidDate = value.BidEndDate;
                var checkDate = _productRepository.CheckDate(bidDate);

                if (checkDate)
                {
                    var product = _productRepository.AddProduct(value);
                    if (product)
                    {
                        response.Add("error", false);
                        response.Add("message", "Product Added");

                        string jsonResponse = JsonConvert.SerializeObject(response);

                        return jsonResponse;
                    }
                    else
                    {
                        response.Add("error", true);
                        response.Add("message", "Some Thing Went Wrong");

                        string jsonResponse = JsonConvert.SerializeObject(response);

                        return jsonResponse;
                    }
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "Bid Date Mustbe in Future");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }

                
            }
            catch (Exception ex)
            {

                response.Add("error", true);
                response.Add("message", ex.Message);

                string jsonResponse = JsonConvert.SerializeObject(response);

                return jsonResponse;
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public string Put([FromBody] Product value)
        {
            try
            {
                DateTime bidDate = value.BidEndDate;
                var checkDate = _productRepository.CheckDate(bidDate);

                if (checkDate)
                {
                    var product = _productRepository.UpdateProduct(value);
                    if (product)
                    {
                        response.Add("error", false);
                        response.Add("message", "Product Updated");

                        string jsonResponse = JsonConvert.SerializeObject(response);

                        return jsonResponse;
                    }
                    else
                    {
                        response.Add("error", true);
                        response.Add("message", "Some Thing Went Wrong, Product is not Updated");

                        string jsonResponse = JsonConvert.SerializeObject(response);

                        return jsonResponse;
                    }
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "Bid Date Mustbe in Future");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }


            }
            catch (Exception ex)
            {

                response.Add("error", true);
                response.Add("message", ex.Message);

                string jsonResponse = JsonConvert.SerializeObject(response);

                return jsonResponse;
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            try
            {
                var data = _productRepository.DeleteProduct(id);
                if (data)
                {
                    response.Add("error", false);
                    response.Add("message", "Product Deleted");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "Some Thing Went Wrong, Product is not Deleted");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
            }
            catch (Exception ex)
            {

                response.Add("error", true);
                response.Add("message", ex.Message);

                string jsonResponse = JsonConvert.SerializeObject(response);

                return jsonResponse;
            }
        }
    }
}
