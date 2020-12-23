using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnGiay.Areas.Admin.Models
{
    public class SizeModel
    {
        [Key]
        public int IdSize { get; set; }
        [Range(35, 49)]
        public string NumSize { get; set; }
        public ICollection<ShoeModel> Shoes { get; set; }
    }
}
