using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnGiay.Areas.Admin.Models
{
    public class TypeShoeModel
    {
        [Key]
        public int IdType { get; set; }
        [Display(Name = "Tên loại giày")]
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public ICollection<ShoeModel> Shoes { get; set; }
    }
}
