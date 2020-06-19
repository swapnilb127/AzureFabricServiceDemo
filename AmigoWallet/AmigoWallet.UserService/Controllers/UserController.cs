using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmigoWallet.UserService.Models;
using AmigoWallet.UserService.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AmigoWallet.UserService.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        UserRepository repObj;
        public UserController(UserDBContext context)
        {
            repObj = new UserRepository(context);
        }

        [HttpGet("{emailId}/{password}")]
        public int ValidateCredentials(string emailId, string password)
        {
            int status;
            try
            {
                status = repObj.ValidateCredentials(emailId, password);
            }
            catch
            {
                status = -99;
            }
            return status;
        }


        [HttpPost]
        public int RegisterUser([FromBody] UserDetails userDetails)
        {
            int status;
            try
            {
                status = repObj.RegisterUser(userDetails);
            }
            catch
            {
                status = -99;
            }
            return status;
        }


        [HttpGet("{emailId}")]
        public int ValidateUserId(string emailId)
        {
            int status;
            try
            {
                status = repObj.ValidateUserId(emailId);
            }
            catch(Exception ex)
            {
                status = -99;
            }
            return status;
        }


        [HttpPost]
        public int UpdatePassword([FromBody] UserDetails userDetails)
        {
            int status;
            try
            {
                status = repObj.UpdatePassword(userDetails);
            }
            catch
            {
                status = -99;
            }
            return status;
        }
    }
}
