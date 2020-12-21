using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnGiay.Areas.Admin.Models
{
    public class OrderDetails
    {
        [Key]
        public int IdOrder { get; set; }
        [Key]
        public int IdShoe { get; set; }
        public int Count { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SumMoney{get;set;}
        public bool Status { get; set; }
        public virtual OrderModel Order { get; set; }
        public virtual ShoeModel Shoe { get; set; }
    }
}
