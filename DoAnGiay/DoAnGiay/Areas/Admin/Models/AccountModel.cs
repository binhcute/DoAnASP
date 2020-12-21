using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnGiay.Areas.Admin.Models
{
    public class AccountModel
    {
        [Key]
        public int IdAccount { get; set; }

        [Required(ErrorMessage = "Nhập Đầy Đủ Thông Tin")]
        [StringLength(maximumLength: 200, ErrorMessage = "Độ dài không phù hợp", MinimumLength = 8)]
        [Display(Name = "Tên tài khoản")]
        public string AccountName { get; set; }

        [StringLength(maximumLength: 200, ErrorMessage = "Độ dài không phù hợp", MinimumLength = 8)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        public int IdRoles { get; set; }
        [ForeignKey("IdRoles")]
        public ICollection<AdminModel> Admins { get; set; }
        public ICollection<UserModel> Users { get; set; }

    }
}
