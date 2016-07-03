using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDeveloper.Model.DTO
{
    public class EmailAddressModelView
    {
        public int BusinessEntityID { get; set; }

        public int EmailAddressID { get; set; }

        [Column("EmailAddress")]
        [StringLength(50)]
        public string EmailAddress1 { get; set; }

        public DateTime ModifiedDate { get; set; }

        public Guid rowguid { get; set; }
    }
}
