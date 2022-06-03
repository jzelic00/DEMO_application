using Microsoft.EntityFrameworkCore;
using SMS_Application.DBContext;
using SMS_Application.Model;
using SMS_Application.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_Application.Repository
{
    public class ContactRepository : IContactRepositoryAsync
    {
        private readonly DatabaseContext _db;
        public ContactRepository(DatabaseContext db)
        {
            _db = db;
        }
        public async Task AddNewAsync(Contact NewContact)
        {
            await _db.AddAsync(NewContact);
        }
        public IQueryable<Contact> GetAllContacts()
        {
            return  _db.Contact.AsNoTracking().AsQueryable();
        }
        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
