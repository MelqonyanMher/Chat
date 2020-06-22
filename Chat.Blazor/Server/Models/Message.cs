using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Blazor.Server.Models
{
    public class Message
    {
        public Guid MessageId { get; set; }
        [Required]
        public String UserName { get; set; }
        [Required]
        public String Text { get; set; }
        public DateTime Date { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser Sender { get; set; }
    }
}
