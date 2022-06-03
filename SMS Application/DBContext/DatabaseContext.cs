using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SMS_Application.Model;

namespace SMS_Application.DBContext
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Message> Message { get; set; }     
    }
}
