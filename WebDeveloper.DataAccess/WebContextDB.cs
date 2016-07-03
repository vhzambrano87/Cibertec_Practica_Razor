using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class WebContextDB:DbContext
    {
        public WebContextDB() : base("name=WebDeveloperConnectionString")
        {
           
        }

        public DbSet<BusinessEntity> BusinessEntitys { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }
        public DbSet<PersonPhone> PersonPhones { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Person>().HasRequired(p => p.BusinessEntity);
            modelBuilder.Entity<Person>().HasRequired(p => p.Password);

            //modelBuilder.Entity<EmailAddress>().HasRequired(p=>p.Person);
        }
    }
}
