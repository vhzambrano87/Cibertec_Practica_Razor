using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDeveloper.Model.DTO
{
    public class PasswordModelView
    {
        public int BusinessEntityID { get; set; }

        [Required]
        [StringLength(128)]
        public string PasswordHash { get; set; }

        [StringLength(10)]
        public string PasswordSalt { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
