using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P10.Server.DB;
using P10.Shared;

namespace P10.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public static List<User> Users = new List<User>
        {};

        private readonly UserProvider U_provider;
        public UserController(UserProvider provider)
        {
            this.U_provider = provider;
        }
        [HttpPost]
        [Route("AddNewUserToDB")]
        public async Task<User> AddNewUserToDB(User newUser)
        {
            await this.U_provider.AddUser(newUser);
            return newUser;
        }
        [HttpGet]
        [Route("GetAllUsersFromDB")]
        public List<User> GetAllUsersFromDB()
            => this.U_provider.GetAllUsers();
        
        [HttpGet("getUserById/{id}")]
        public List<User> getUserByCategory(int id)
            => this.U_provider.GetAllClothesById(id);

        [HttpPost("Compare")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> CompareUser(User u)
        {
            if(this.U_provider.Compare(u) == false)
                return BadRequest() ;
            return u ;
        }

        // [HttpDelete]
        // [Route("RemoveUserFromDB")]//-->[]
        // public List<User> RemoveUsers(int[] ids)
        //     => this.U_provider.RemoveUsers(ids);


        // [HttpPut]
        // [Route("UpdateUserNameFromDB")]//-->Params
        // // [HttpPut("UpdateUserName/{id}/{name}")]
        // public User UpdateUserName(int id,string newname)
        // {
        //     var User = Users.Where(arg => arg.id == id).FirstOrDefault();
        //     User.p_name = newname;
        //     return User;
        // }

    //     [HttpPut]
    //     [Route("UpdateUserFromDB")]
    //     public User UpdateUser(User newUser)
    //     {
    //         var idx = Users.IndexOf(newUser) + 1;
    //         Users[idx] = newUser;
    //         return Users[idx];
    //     }
    }
}