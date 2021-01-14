using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnGiay.Areas.Admin.Models
{
    public class UserModel
    {
        [Key]
        public int IdUser { get; set; }

        [Required(ErrorMessage = "Không Được Bỏ Trống")]
        [StringLength(maximumLength: 50, ErrorMessage = "Độ dài từ 8 ký tự trở lên", MinimumLength = 8)]
        [Display(Name = "Họ Và Tên")]
        public string FullName { get; set; }

        [EmailAddress(ErrorMessage = "Vui Lòng Nhập Vào 1 E-Mail Hợp Lệ")]
        [StringLength(maximumLength: 300, MinimumLength = 8)]
        [Display(Name = "E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Không Được Bỏ Trống")]
        [StringLength(maximumLength: 300, ErrorMessage = "Mật Khẩu Dài Hơn 8 Ký Tự", MinimumLength = 8)]
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
        public ICollection<OrderModel> Orders { get; set; }
    }
}
