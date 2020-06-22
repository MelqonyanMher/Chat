using Chat.Blazor.Server.Data;
using Chat.Blazor.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Blazor.Server.Services.Users
{
    public class UsersService : IUsersService
    {
        private ApplicationDbContext _dbContext;

        public UsersService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsers()
        {
            return _dbContext.Users;
        }
    }
}
