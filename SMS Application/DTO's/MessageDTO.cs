using SMS_Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_Application.DTO_s
{
    public class MessageDTO
    {
        public IList<SendMessageTo> Contacts { get; set; }
        public string Message { get; set; }
    }
}
