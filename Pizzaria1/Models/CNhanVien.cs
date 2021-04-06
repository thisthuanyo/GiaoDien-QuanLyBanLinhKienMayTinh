using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wpfLKMT.Models
{
    public class CNhanVien
    {
        public string MaNV { get; set; }

        public string TenNV { get; set; }

        public int NamSinh { get; set; }

        public bool? GioiTinh { get; set; }

        public string DiaChi { get; set; }

        public string SoDT { get; set; }

        public string UserName { get; set; }

        public string Pass { get; set; }

        public string ChucVu { get; set; }

        public bool? status { get; set; }

        public virtual CChucVu ChucVu1 { get; set; }

        public virtual ICollection<CHoaDon> HoaDons { get; set; }

        public virtual ICollection<CPhieuXuat> PhieuXuats { get; set; }
    }
}