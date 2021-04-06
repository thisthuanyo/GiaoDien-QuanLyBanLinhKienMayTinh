using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wpfLKMT.Models
{
    public class CLinhKien
    {
        public string MaLK { get; set; }

        public string MaLoai { get; set; }

        public string MaNSX { get; set; }

        public string TenLK { get; set; }

        public double? GiaBan { get; set; }

        public bool? status { get; set; }

        public virtual ICollection<CChiTietPhieuXuat> ChiTietPhieuXuats { get; set; }

        public virtual CLoaiLK LoaiLK { get; set; }

        public virtual CNhanVien NhaSX { get; set; }
    }
}