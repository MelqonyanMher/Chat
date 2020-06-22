using Chat.Blazor.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Blazor.Server.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<ApplicationUser>> GetUsers();
    }
}
