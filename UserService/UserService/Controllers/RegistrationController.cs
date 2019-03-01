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
    public class RegistrationController : ControllerBase
    {
        public string[] TestValues = {"tester@version1.com" };

       // POST api/values
       [HttpPost]
        public string Post(string firstname, string lastname, string email, string password)
        {
            Boolean inuse = false;
            foreach (string e in TestValues)
            {
                if (email == e)
                    inuse = true;
            }
            if (inuse == true)
                return "Sorry that email is taken";
            else
                return "You tried to register the following details for email: " + email;
        }
    }
}