using SMS_Application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_Application.Repository.Interface
{
    public interface IContactRepositoryAsync:IRepositoryBase<Contact>
    {
        IQueryable<Contact> GetAllContacts();
    }
}
