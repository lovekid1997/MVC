using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BookStore.Models.metadata
{
    public partial class KhachHang
    {
        [MetadataTypeAttribute(typeof(KhachHangMetadata))]
        internal sealed class KhachHangMetadata
        {
            public int MaKH { get; set; }

            [Display(Name = "Họ tên")]
            [Required(ErrorMessage = "{0} không được để trống!")]
            [StringLength(25,ErrorMessage ="Không quá 25 ký tự")]
            public string HoTen { get; set; }

            [Display(Name = "Tài khoản")]
            [Required(ErrorMessage = "{0} không được để trống!")]

            [BookStore.Models.TrungTK.TrungTKs(ErrorMessage = "Birth Date can not be greater than current date")]
            public string TaiKhoan { get; set; }

            [Display(Name = "Mật khẩu")]
            [Required(ErrorMessage = "{0} không được để trống!")]
            public string MatKhau { get; set; }

            [Display(Name = "Email")]
            [Required(ErrorMessage = "{0} không được để trống!")]
            public string Email { get; set; }

            [Display(Name = "Địa chỉ")]
            [Required(ErrorMessage = "{0} không được để trống!")]
            public string DiaChi { get; set; }

            [Display(Name = "Điện thoại")]
            [Required(ErrorMessage = "{0} không được để trống!")]
            [Phone(ErrorMessage ="Xin hãy nhập số điện thoại!")]
            [MaxLength(11,ErrorMessage ="Không quá 11 số!")]
           
            public string DienThoai { get; set; }

            [Display(Name = "Giới tính")]
            [Required(ErrorMessage = "{0} không được để trống!")]
            [StringLength(3, ErrorMessage = "Chỉ điền nam hoặc nữ")]
            public string GioiTinh { get; set; }

            [Display(Name = "Ngày sinh")]
            [Required(ErrorMessage = "{0} không được để trống!")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
            [BookStore.Models.UserCustomValidation.ValidBirthDate(ErrorMessage = "Birth Date can not be greater than current date")]
            public Nullable<System.DateTime> NgaySinh { get; set; }
        }
    }
}