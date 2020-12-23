using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnGiay.Areas.Admin.Models
{
    public class MaterialModel
    {
        [Key]
        public int IdMaterial { get; set; }
        [Required]
        [Display(Name = "Tên chất liệu ")]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ShoeModel> Shoes { get; set; }
        
    }
}
