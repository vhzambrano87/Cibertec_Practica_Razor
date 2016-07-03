using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDeveloper.Model.DTO
{
    public class PersonPhoneModelView
    {
        public int BusinessEntityID { get; set; }
        [StringLength(25)]
        public string PhoneNumber { get; set; }        
        public int PhoneNumberTypeID { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string PhoneNumberTypeDesc { get; set; }
    }
}
