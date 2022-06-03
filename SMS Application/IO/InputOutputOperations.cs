using SMS_Application.IO.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Application.IO
{
    public class InputOutputOperations : IInputOutputAsync
    {
        public async Task WriteAsync(FileStream fs,string _message)
        {
            Byte[] message = new UTF8Encoding(true).GetBytes(_message);
            await fs.WriteAsync(message, 0, message.Length);
        }
    }
}
