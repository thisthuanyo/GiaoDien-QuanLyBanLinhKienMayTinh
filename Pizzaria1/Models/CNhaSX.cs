using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wpfLKMT.Models
{
    public class CNhaSX
    {
        public string MaNhaSX { get; set; }

        public string TenNhaSX { get; set; }

        public bool? status { get; set; }

        public virtual ICollection<CLinhKien> LinhKiens { get; set; }
    }
}