using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wpfLKMT.Models
{
    public class CPhieuXuat
    {
        public int MaPX { get; set; }

        public string MaKH { get; set; }

        public string MaNV { get; set; }

        public DateTime? NgayXuat { get; set; }

        public double? TongTien { get; set; }

        public bool? status { get; set; }

        public virtual ICollection<CChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }

        public virtual ICollection<CHoaDon> HoaDons { get; set; }

        public virtual CKhachHang KhachHang { get; set; }

        public virtual CNhanVien NhanVien { get; set; }
    }
}