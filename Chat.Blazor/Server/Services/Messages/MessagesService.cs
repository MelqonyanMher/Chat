using Chat.Blazor.Server.Data;
using Chat.Blazor.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Blazor.Server.Services.Messages
{
    public class MessagesService : IMessagesService
    {
        private ApplicationDbContext _dbContext;

        public MessagesService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Message>> GetMessages()
        {
            return _dbContext.Messages;
        }

        public async Task SaveMessage(Message message)
        {
            await _dbContext.Messages.AddAsync(message);
            await _dbContext.SaveChangesAsync();
        }
    }
}
