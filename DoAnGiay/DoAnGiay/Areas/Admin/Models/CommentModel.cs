using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnGiay.Areas.Admin.Models
{
    public class CommentModel
    {
        [Key]
        public int IdComment { get; set; }
        [Required]
        [StringLength(maximumLength: 300, ErrorMessage = "Độ không phù hợp!", MinimumLength = 16)]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Content")]
        public string Content { get; set; }
        public int IdShoe { get; set; }
        [ForeignKey("IdShoe")]
        public virtual ShoeModel Shoe { get; set; }
    }
}
