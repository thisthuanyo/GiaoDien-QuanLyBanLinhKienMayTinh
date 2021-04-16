using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace wpfLKMT.Models
{
    class CXuLyHoaDon
    {
        private static HttpClient hc = new HttpClient();
        public static List<CHoaDon> getDSHoaDon()
        {
            try
            {
                string url = @"http://localhost:64275/api/hoadon";
                var kq = hc.GetAsync(url);
                kq.Wait();
                if (kq.Result.IsSuccessStatusCode == false) return null;
                var list = kq.Result.Content.ReadAsAsync<List<CHoaDon>>();
                list.Wait();
                return list.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static CHoaDon getHoaDon(int mahd)
        {
            try
            {
                string url = @"http://localhost:64275/api/hoadon/" + mahd;
                var kq = hc.GetAsync(url);
                kq.Wait();
                if (kq.Result.IsSuccessStatusCode == false) return null;
                var list = kq.Result.Content.ReadAsAsync<CHoaDon>();
                list.Wait();
                return list.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static CHoaDon getHoaDonByMaPX(int mapx)
        {
            try
            {
                string url = @"http://localhost:64275/api/hoadon?mapx=" + mapx;
                var kq = hc.GetAsync(url);
                kq.Wait();
                if (kq.Result.IsSuccessStatusCode == false) return null;
                var list = kq.Result.Content.ReadAsAsync<CHoaDon>();
                list.Wait();
                return list.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static IEnumerable<object> getDSChiTietHoaDon(CHoaDon hd)
        {
            CPhieuXuat px = CXuLyPhieuXuat.getPhieuXuat((int)hd.MaPX);
            return CXuLyPhieuXuat.getDSChiTietPhieuXuat(px);
        }
        public static bool themHoaDon(CHoaDon hd)
        {
            try
            {
                string url = @"http://localhost:64275/api/hoadon/";
                var kq = hc.PostAsJsonAsync(url, hd);
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
