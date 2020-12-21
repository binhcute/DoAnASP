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
        
        [Range(1000, 10000000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Size { get; set; }

        [ForeignKey("Color")]
        public int Color { get; set; }
        public virtual ColorModel color { get; set; }

        [ForeignKey("TypeShoe")]
        public int IdType { get; set; }
        public virtual TypeShoeModel TypeShoe { get; set; }

        [ForeignKey("Producer")]
        public int IdPro { get; set; }
        public virtual ProducerModel Producer { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }
        public ICollection<CommentModel> Comment { get; set; }
    }
}
