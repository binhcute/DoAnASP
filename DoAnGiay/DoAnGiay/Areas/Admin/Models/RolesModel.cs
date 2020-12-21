using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnGiay.Areas.Admin.Models
{
    public class RolesModel
    {
        [Key]
        public int IdRoles { get; set; }
        [Required]
        [Display(Name = "Name Roles")]
        public string Name { get; set; }
        public ICollection<AccountModel> Accounts { get; set; }
    }
}
