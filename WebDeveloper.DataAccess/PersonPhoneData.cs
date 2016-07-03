using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class PersonPhoneData : BaseDataAccess<PersonPhone>
    {
        public PersonPhone GetPersonPhoneById(int PhoneNumberTypeID, string PhoneNumber, int BusinessEntityID)
        {
            using (var dbcontext = new WebContextDB())
            {
                return dbcontext.PersonPhones.FirstOrDefault(u => u.PhoneNumberTypeID == PhoneNumberTypeID && u.PhoneNumber == PhoneNumber && u.BusinessEntityID == BusinessEntityID);
            }
        }
        public List<PersonPhone> GetPersonPhoneByPersonId(int id)
        {
            using (var dbcontext = new WebContextDB())
            {
                return dbcontext.PersonPhones.Where(u=>u.BusinessEntityID == id).ToList();
            }
        }
    }
}
