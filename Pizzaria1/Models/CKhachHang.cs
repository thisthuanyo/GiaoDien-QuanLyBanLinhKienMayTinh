using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wpfLKMT.Models
{
    public class CKhachHang
    {
        public string MaKH { get; set; }

        public string TenKh { get; set; }

        public bool GioiTinh { get; set; }

        public int NamSinh { get; set; }

        public string DiaChi { get; set; }

        public string SoDT { get; set; }

        public bool? status { get; set; }

        public virtual ICollection<CHoaDon> HoaDons { get; set; }

        public virtual ICollection<CPhieuXuat> PhieuXuats { get; set; }
    }
}