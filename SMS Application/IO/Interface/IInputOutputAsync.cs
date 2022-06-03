using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_Application.IO.Interface
{
    public interface IInputOutputAsync
    {
        public Task WriteAsync(FileStream fs, string _message);
    }
}
