using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wpfLKMT.Models
{
    public class CChucVu
    {
        public string MaCV { get; set; }

        public string TenCV { get; set; }

        public bool? status { get; set; }

        public virtual ICollection<CNhanVien> NhanViens { get; set; }
    }
}