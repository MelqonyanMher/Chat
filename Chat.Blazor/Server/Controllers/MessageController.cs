using Chat.Blazor.Server.Models;
using Chat.Blazor.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class MessageController : Controller
    {
        private readonly IMessagesService _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public MessageController(IMessagesService service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        [HttpGet("messages")]
        public async Task<IEnumerable<Message>> GetMessages()
        {
            return await _service.GetMessages();
        }

        [HttpPost("message")]
        public async Task SaveMessage(Message message)
        {
            if (ModelState.IsValid)
            {
                var sender =  _userManager.Users.First(u=>u.UserName == message.UserName);
                message.UserId = sender.Id;
                await _service.SaveMessage(message);
            }
        }
    }
}
