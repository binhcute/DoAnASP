using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnGiay.Areas.Admin.Models
{
    public class ColorModel
    {
        [Key]
        public int IdColor { get; set; }
        [Display(Name = "Tên màu")]
        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        public bool Status { get; set; }
        public ICollection<ShoeModel> Shoes { get; set; }
    }
}
