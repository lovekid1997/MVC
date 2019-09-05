using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BookStore.Models
{
    [MetadataTypeAttribute(typeof (SAchMetadata))]
    public partial class SAch
    {
        internal sealed class SAchMetadata
        {
            [Display(Name = "Mã Sách")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]// Kiem tra rong
            public int MaSach { get; set; }
            [StringLength(50, ErrorMessage = "Không quá 50 ký tự")]
            [Display(Name = "Tên Sách")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]// Kiem tra rong
            [MinLength(5,ErrorMessage ="ít nhất 5 ký tự!")]
            public string TenSach { get; set; }
            [Display(Name = "Giá Sách")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            //[Range(Convert.ToDecimal(10000),Convert.ToDecimal(500000),ErrorMessage = "{0} phải từ {1} đến {2}")]
            //[Range([10000],[500000],ErrorMessage = "{0} phải từ {1} đến {2}")]
            [Range(5000, 500000, ErrorMessage = "{0} phải từ {1} đến {2}")]
            public Nullable<decimal> GiaBan { get; set; }

            //[Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]// Kiem tra rong
            [Display(Name = "Mô Tả Sách")]
            [MinLength(10,ErrorMessage ="Phải hơn 10 ký tự!")]
            public string MoTa { get; set; }
            [Display(Name = "Ảnh Bìa Sách")]
            public string AnhBia { get; set; }
            [Display(Name = "Ngày cập nhật Sách")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
           
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public Nullable<System.DateTime> NgayCapNhat { get; set; }
            [Display(Name = "Sô lượng tồn Sách")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            [Range(10, 100, ErrorMessage = "{0} phải từ {1} đến {2}")]
            public Nullable<int> SoLuongTon { get; set; }
            [Display(Name = "Nhà Xuất Bản")]

            public Nullable<int> MaNXB { get; set; }
            [Display(Name = "Chủ đề")]

            public Nullable<int> MaChuDe { get; set; }
            [Display(Name = "Sách mới")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            [Range(0, 1, ErrorMessage = "Sách mới là 1, ngược lại là 0")]

            //[StringLength(1,ErrorMessage ="Không quá 1 ký tự")]
            public Nullable<int> Moi { get; set; }
        }
    }
}