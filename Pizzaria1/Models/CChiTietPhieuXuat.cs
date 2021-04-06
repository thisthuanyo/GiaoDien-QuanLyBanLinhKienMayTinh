using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wpfLKMT.Models
{
    public class CChiTietPhieuXuat
    {
        public int MaPX { get; set; }

        public string MaLK { get; set; }

        public int? SoLuong { get; set; }

        public double? DonGia { get; set; }

        public virtual CLinhKien LinhKien { get; set; }

        public virtual CPhieuXuat PhieuXuat { get; set; }
    }
}