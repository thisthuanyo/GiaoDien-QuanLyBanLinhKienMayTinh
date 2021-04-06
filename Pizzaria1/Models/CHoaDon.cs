using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wpfLKMT.Models
{
    public class CHoaDon
    {
        public int MaHD { get; set; }

        public string MaKH { get; set; }

        public string MaNV { get; set; }

        public DateTime? NgayLapHD { get; set; }

        public DateTime? NgayGiao { get; set; }

        public double? TongTien { get; set; }

        public bool? status { get; set; }

        public int? MaPX { get; set; }

        public virtual CKhachHang KhachHang { get; set; }

        public virtual CNhanVien NhanVien { get; set; }

        public virtual CPhieuXuat PhieuXuat { get; set; }
    }
}