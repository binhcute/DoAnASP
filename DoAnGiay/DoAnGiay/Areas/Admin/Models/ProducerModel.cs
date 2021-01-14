using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnGiay.Areas.Admin.Models
{
    public class ProducerModel
    {
        [Key]
        public int IdPro { get; set; }
        [Display(Name = "Tên nhà sản xuất")]
        [StringLength(100, MinimumLength = 1)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public ICollection<ShoeModel> Shoes { get; set; }
    }
}
