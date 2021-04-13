using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace wpfLKMT.Models
{
    class CXuLyPhieuXuat
    {
        private static HttpClient hc = new HttpClient();
        public static List<CPhieuXuat> getDSPhieuXuat()
        {
            try
            {
                string url = @"http://localhost:64275/api/phieuxuat";
                var kq = hc.GetAsync(url);
                kq.Wait();
                if (kq.Result.IsSuccessStatusCode == false) return null;
                var list = kq.Result.Content.ReadAsAsync<List<CPhieuXuat>>();
                list.Wait();
                return list.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static CPhieuXuat getPhieuXuat(string maPX)
        {
            try
            {
                string url = @"http://localhost:53137/api/hoadon/" + maPX;
                var kq = hc.GetAsync(url);
                kq.Wait();
                if (kq.Result.IsSuccessStatusCode == false) return null;
                var list = kq.Result.Content.ReadAsAsync<CPhieuXuat>();
                list.Wait();
                return list.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static IEnumerable<object> getDSChiTietPhieuXuat(CPhieuXuat px)
        {
            return px.ChiTietPhieuXuats.Select(x => new
            {
                DonGia = x.DonGia,
                MaLK = x.MaLK,
                TenLK = x.LinhKien.TenLK,
                MaLoai = x.LinhKien.MaLoai,
                SoLuong = x.SoLuong,
                thanhtien = x.SoLuong.Value * x.DonGia.Value
            }).ToList();
        }
        public static double getThanhTienPhieuXuat(CPhieuXuat px)
        {
            return px.ChiTietPhieuXuats.Sum(x => x.SoLuong.Value * x.DonGia.Value);
        }
        public static bool themPhieuXuat(CPhieuXuat px)
        {
            try
            {
                string url = @"http://localhost:53137/api/hoadon/";
                var kq = hc.PostAsJsonAsync(url, px);
                kq.Wait();
                return kq.Result.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
