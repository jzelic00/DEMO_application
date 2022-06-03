using SMS_Application.Entities;
using SMS_Application.Model;
using SMS_Application.Repository.Interface;
using SMS_Application.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_Application.Services
{
    public class Service : IService
    {
        private readonly IContactRepositoryAsync _contactRepository;
        private readonly IMessageRepositoryAsync _messageRepository;

        public Service(IMessageRepositoryAsync messageRepository
                       , IContactRepositoryAsync contactRepository)
        {
           
            _messageRepository = messageRepository;
            _contactRepository = contactRepository;
        }
      
        public async Task AddNewContactAsync(Contact newContact)
        {
            await _contactRepository.AddNewAsync(newContact);

            await _contactRepository.SaveAsync();
        }

        public async Task AddNewMessageAsync(IList<SendMessageTo> allContacts)
        {
            foreach (SendMessageTo contact in allContacts)
            {
                await _messageRepository.AddNewAsync(contact);

                await _messageRepository.SaveAsync();
            }    
        }

        public IQueryable<Contact> GetAllContacts()
        {
            return _contactRepository.GetAllContacts();
        }
    }
}
