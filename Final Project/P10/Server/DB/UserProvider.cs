using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using P10.Server.Controllers;
using P10.Shared;

namespace P10.Server.DB
{
    public class UserProvider
    {
        //*********************Yek object az class UserDBContext
        private readonly UserDBContext U_context;
        private readonly ILogger U_logger;
        public UserProvider(UserDBContext context, ILoggerFactory loggerFactory)
        {
            this.U_context = context;
            this.U_logger = loggerFactory.CreateLogger("UserProvider");
        }
        public async Task AddUser(User User)
        {
            var LastUser = this.U_context.Users.ToArray().LastOrDefault();
            var newID = 0;
            if(!(LastUser is null))
                newID = LastUser.id + 1;
            User.id = newID;

            await U_context.Users.AddAsync(User);
            await U_context.SaveChangesAsync();
        }
        public List<User> GetAllClothesById(int id)
            => this.U_context.Users.Where(u => u.id == id).ToList();
        public List<User> GetAllUsers()
            => this.U_context.Users.ToList();
        public List<User> RemoveUsers(int[] ids)
            => this.U_context.Users.Where(arg => ids.Contains(arg.id)).ToList();
        
        public bool Compare(User u)
        {
            foreach(User s in this.U_context.Users)
            {
                if(u.User_name ==u.User_name & u.Password == u.Password)
                {
                    return true ;
                }
            }
            return false ;
        }
        // public User UpdateUser(User newUser)
        // {
        //     var idx = this.U_context.Users.IndexOf(newUser) + 1;
        //     this.U_context.Users[idx] = newUser;
        //     return this.U_context.Users[idx];
        // }
    }
}