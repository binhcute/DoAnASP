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
        public string Title { get; set; }
        public string Content { get; set; }
        public int IdShoe { get; set; }
        [ForeignKey("IdShoe")]
        public virtual ShoeModel Shoe { get; set; }
    }
}
