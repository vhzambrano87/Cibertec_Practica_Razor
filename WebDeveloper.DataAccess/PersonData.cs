using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class PersonData:BaseDataAccess<Person>
    {
        public Person GetPersonById(int id)
        {
            using (var dbcontext = new WebContextDB())
            {
                return dbcontext.Persons.FirstOrDefault(u => u.BusinessEntityID == id);
            }
        }
    }
}
