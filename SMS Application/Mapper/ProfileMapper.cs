using AutoMapper;
using SMS_Application.Entities;
using SMS_Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_Application.Mapper
{
    public class ProfileMapper:Profile
    {
        public ProfileMapper()
        {           
            CreateMap<Message, SendMessageTo>();
            CreateMap<SendMessageTo, Message>();
        }
    }
}
