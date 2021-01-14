using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnGiay.Areas.Admin.Models
{
    public class ShoeModel
    {
        [Key]
        public int IdShoe { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [StringLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string Img { get; set; }
        [Required]
        public int Price { get; set; }
        
        [ForeignKey("Size")]
        public int Sizes { get; set; }
        public virtual SizeModel Size { get; set; }
        [ForeignKey("Color")]
        public int Colors { get; set; }
        public virtual ColorModel Color { get; set; }
       
        [Display(Name = "Serial Number")]
        [Required]
        [StringLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string NumberSeri { get; set; }
        public bool Shoelate { get; set; }
        public bool Version { get; set; }

        [ForeignKey("Material")]
        public int Materials { get; set; }
        public virtual MaterialModel Material { get; set; }
        [ForeignKey("Sale")]
        public int Sales { get; set; }
        public virtual SaleModel Sale { get; set; }
        [ForeignKey("TypeShoe")]
        public int Type { get; set; }
        public virtual TypeShoeModel TypeShoe { get; set; }

        [ForeignKey("Producer")]
        public int Pro { get; set; }
        public virtual ProducerModel Producer { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }
        public ICollection<CommentModel> Comment { get; set; }
        public ICollection<OrderDetailsModel> orderDetails { get; set; }
    }
}
