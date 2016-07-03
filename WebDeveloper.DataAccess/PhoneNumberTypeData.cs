using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class PhoneNumberTypeData : BaseDataAccess<PhoneNumberType>
    {
        public PhoneNumberType GetPhoneNumberTypeById(int id)
        {
            using (var dbcontext = new WebContextDB())
            {
                return dbcontext.PhoneNumberTypes.FirstOrDefault(u => u.PhoneNumberTypeID == id);
            }
        }
    }
}
