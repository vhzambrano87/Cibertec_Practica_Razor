using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class EmailAddressData : BaseDataAccess<EmailAddress>
    {
        public EmailAddress GetEmailAddressById(int id)
        {
            using (var dbcontext = new WebContextDB())
            {
                return dbcontext.EmailAddresses.FirstOrDefault(u => u.EmailAddressID == id);
            }
        }

        public List<EmailAddress> GetEmailAddressByPersonId(int id)
        {
            using (var dbcontext = new WebContextDB())
            {
                return dbcontext.EmailAddresses.Where(u => u.BusinessEntityID == id).ToList();
            }
        }
    }
}
