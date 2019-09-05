using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BookStore.Models.metadata
{
    [MetadataTypeAttribute(typeof(TacGiaMetadata))]
    public partial class TacGia
    {
        internal sealed class TacGiaMetadata
        {
            public int MaTacGia { get; set; }
            public string TenTacGia { get; set; }
            public string DiaChi { get; set; }
            public string TieuSu { get; set; }
            public string DienThoai { get; set; }
        }
    }
}