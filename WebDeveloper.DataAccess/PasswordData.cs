using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class PasswordData : BaseDataAccess<Password>
    {
        public Password GetPasswordById(int id)
        {
            using (var dbcontext = new WebContextDB())
            {
                return dbcontext.Passwords.FirstOrDefault(u => u.BusinessEntityID == id);
            }
        }
    }
}
