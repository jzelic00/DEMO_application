using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_Application.Entities
{
    public class SendMessageTo
    {
        public int ContactId { get; set; }
        public string Number { get; set; }
    }
}
