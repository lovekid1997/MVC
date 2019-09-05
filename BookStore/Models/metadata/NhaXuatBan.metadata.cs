using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BookStore.Models.metadata
{
    [MetadataTypeAttribute(typeof(NhaXuatBanMetadata))]
    public partial class NhaXuatBan
    {
        internal sealed class NhaXuatBanMetadata
        {
            public int MaNXB { get; set; }
            [Display(Name = "Tên Nhà xuất bản")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public string TenNXB { get; set; }
            [Display(Name = "Địa Chỉ")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public string DiaChi { get; set; }

            [Display(Name = "Số điện thoại")]
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho trường này.")]
            public string DienThoai { get; set; }
        }
    }
}