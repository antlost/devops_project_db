using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Model;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        //test variables
        Registration TestUser = new Registration { FirstName = "Conor", LastName = "Oneill", Email = "test@version1.com", Password = "test123" };



        //// GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // POST api/Authentication
        [HttpPost]
        public object Post(string email, string password)
        {
            if (TestUser.Email == email && TestUser.Password == password)
            {
                return this.Ok("success: all ok!!");
            }
            else
            {
                return this.Unauthorized();
            }
        }
    }
}