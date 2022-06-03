using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_Application.Repository.Interface
{
    public interface IRepositoryBase<T>
    {
        public Task AddNewAsync(T item);
        public Task SaveAsync();

    }
}
