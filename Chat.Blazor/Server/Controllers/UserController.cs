using Chat.Blazor.Server.Models;
using Chat.Blazor.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Blazor.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController:Controller
    {
        private readonly IUsersService _service;

        public UserController(IUsersService service)
        {
            _service = service;
        }

        [HttpGet("user")]
        public async Task<IEnumerable<ApplicationUser>> GetUsers()
        {
           return await _service.GetUsers();
        }
    }
}
