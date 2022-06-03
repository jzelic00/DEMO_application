using AutoMapper;
using SMS_Application.DBContext;
using SMS_Application.DTO_s;
using SMS_Application.Entities;
using SMS_Application.Model;
using SMS_Application.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_Application.Repository
{
    public class MessageRepository : IMessageRepositoryAsync
    {
        private readonly DatabaseContext _db;
        private readonly IMapper _mapper;
        public MessageRepository(DatabaseContext db,
            IMapper mapper)
        {
            _db = db;
             _mapper=mapper;
        }

        public async Task AddNewAsync(SendMessageTo contact)
        {
            Message _newContact = _mapper.Map<Message>(contact);

            _newContact.DateAndTimeOfSending = DateTime.Now;
            _newContact.Folder = "DEMO_"+contact.Number+".txt";

            await _db.AddAsync(_newContact);
        }
        
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
