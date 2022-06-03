using SMS_Application.Entities;
using SMS_Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_Application.Services.Interface
{
    public interface IService
    {
        public Task AddNewContactAsync(Contact newContact);
        public Task AddNewMessageAsync(IList<SendMessageTo> newMessage);
        public IQueryable<Contact> GetAllContacts();
    }
}
