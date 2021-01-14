using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnGiay.Areas.Admin.Models
{
    public class OrderDetailsModel
    {
        [Key]
        public int Id { get; set; }
        public int IdOrder { get; set; }
        [ForeignKey("Shoe")]
        public int Shoes { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SumMoney{get;set;}
        public bool Status { get; set; }
        public virtual OrderModel Order { get; set; }
        public virtual ShoeModel Shoe { get; set; }
    }
}
