using Microsoft.AspNetCore.Mvc;
using ProductManagement.API.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using ProductManagement.API.Repositories;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IDictionary<string, dynamic> response = new Dictionary<string, dynamic>();
        private readonly IAuthRepository _authRepository;
        private readonly IGenarateToken _genarateToken;

        public AuthController(IAuthRepository authRepository, IGenarateToken genarateToken)
        {
            _authRepository = authRepository;
            _genarateToken = genarateToken;
        }

        // GET: api/<AuthController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("Signin")]
        public async Task<string> Signin([FromBody] User user)
        {
            if(user != null)
            {
                var auth = _authRepository.Login(user);
                if (auth)
                {
                    string token = await _genarateToken.GetTokenAsync(user);
                    response.Add("error", false);
                    response.Add("message", "Sign ip Successfull");
                    response.Add("token", token);

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "Invalid Username or Password");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
            }
            else
            {
                response.Add("error", true);
                response.Add("message", "All Fields are required");

                string jsonResponse = JsonConvert.SerializeObject(response);

                return jsonResponse;
            }
        }

        // POST api/<AuthController>
        [HttpPost]
        public string Post([FromBody] User user)
        {
            try
            {
                if(user != null)
                {
                    var auth = _authRepository.Signup(user);
                    if (auth)
                    {
                        response.Add("error", false);
                        response.Add("message", "Sign up Successfull");

                        string jsonResponse = JsonConvert.SerializeObject(response);

                        return jsonResponse;
                    }
                    else
                    {
                        response.Add("error", true);
                        response.Add("message", "This Username Allready Exist");

                        string jsonResponse = JsonConvert.SerializeObject(response);

                        return jsonResponse;
                    }
                }
                else
                {
                    response.Add("error", true);
                    response.Add("message", "All field Require");

                    string jsonResponse = JsonConvert.SerializeObject(response);

                    return jsonResponse;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<AuthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
