using SMS_Application.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_Application.Services.Interface
{
    public interface IFileHandler
    {
        public Task CreateFile(MessageDTO MessageDTO);
    }
}
