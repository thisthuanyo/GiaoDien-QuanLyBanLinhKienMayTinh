using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace wpfLKMT.Models
{
    class CXuLyKhachHang
    {
        private static HttpClient hc = new HttpClient();
        public static List<CKhachHang> getDSKhachHang()
        {
            try
            {
                string url = @"http://localhost:64275/api/khachhang";
                var kq = hc.GetAsync(url);
                kq.Wait();
                if (kq.Result.IsSuccessStatusCode == false) return null;
                var list = kq.Result.Content.ReadAsAsync<List<CKhachHang>>();
                list.Wait();
                return list.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static bool themKhachHang(CKhachHang kh)
        {
            try
            {
                string url = @"http://localhost:64275/api/khachhang";
                var kq = hc.PostAsJsonAsync(url, kh);
                kq.Wait();
                return kq.Result.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool xoaKhachHang(string makh)
        {
            try
            {
                string url = @"http://localhost:64275/api/khachhang/" + makh;
                var kq = hc.DeleteAsync(url);
                kq.Wait();
                return kq.Result.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool suaKhachHang(CKhachHang kh)
        {
            try
            {
                string url = @"http://localhost:64275/api/khachhang";
                var kq = hc.PutAsJsonAsync(url, kh);
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
