using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnGiay.Areas.Admin.Models
{
    public class SaleModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public int PriceSale { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        
       
        public ICollection<ShoeModel> Shoes { get; set; }
    }
}
