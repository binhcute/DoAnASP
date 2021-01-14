using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnGiay.Areas.Admin.Models
{
    public class AdminModel
    {
        [Key]
        public int IdAdmin { get; set; }

        [Required(ErrorMessage = "Không Được Bỏ Trống")]
        [StringLength(maximumLength: 50, ErrorMessage = "Vui lòng nhập đúng tên", MinimumLength = 8)]
        [Display(Name = "Họ Và Tên")]
        public string FullName { get; set; }

        

        [Required(ErrorMessage = "Không Được Bỏ Trống")]
        [StringLength(maximumLength: 300, ErrorMessage = "Nhập một địa chỉ phù hợp", MinimumLength = 8)]
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Không Được Bỏ Trống")]
        [Display(Name = "Số Điện Thoại")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(maximumLength: 10, ErrorMessage = "Độ dài không phù hợp", MinimumLength = 10)]
        public string Phone { get; set; }
        [ForeignKey("Account")]
        public string IdAccount { get; set; }
        
        public virtual AccountModel Account { get; set; }
    }
}
