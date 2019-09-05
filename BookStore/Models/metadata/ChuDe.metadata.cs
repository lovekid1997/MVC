using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BookStore.Models
{
    [MetadataTypeAttribute(typeof(ChuDeMetadata))]
    public partial class ChuDe
    {
        internal sealed class ChuDeMetadata
        {
            public int MaChuDe { get; set; }
            [Display(Name = "Tên chủ đề: ")]
            [Required(ErrorMessage = "{0} không được để trống!")]
            public string TenChuDe { get; set; }
        }
    }
}