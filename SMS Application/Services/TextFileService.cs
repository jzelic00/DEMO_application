using SMS_Application.DTO_s;
using SMS_Application.Entities;
using SMS_Application.IO.Interface;
using SMS_Application.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Application.Services
{
    public class TextFileService: IFileHandler
    {
        private readonly IInputOutputAsync _inputOutput;
        readonly string FileName = @"./Sms";

        public TextFileService(IInputOutputAsync inputOutput)
        {
            _inputOutput = inputOutput;
        }
       
        public async Task CreateFile(MessageDTO MessageDTO)
        {
            foreach (SendMessageTo contact in MessageDTO.Contacts)
            {
                using (FileStream fs = File.Create(FileName+"/DEMO_"+contact.Number+".txt"))
                {
                   await _inputOutput.WriteAsync(fs, MessageDTO.Message);
                }
            }
        }
    }
}
