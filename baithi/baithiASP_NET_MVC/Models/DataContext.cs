using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ContactsWeb.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Contacts") { }

        public DbSet<Contact> Contacts { get; set; }

    }
}