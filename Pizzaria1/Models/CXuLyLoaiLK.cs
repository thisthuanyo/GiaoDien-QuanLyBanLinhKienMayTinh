using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace wpfLKMT.Models
{
    class CXuLyLoaiLK
    {
        private static HttpClient hc = new HttpClient();
        public static List<CLoaiLK> getDanhSachLoaiLK()
        {
            try
            {
                string url = @"http://localhost:64275/api/loailinhkien";
                var kq = hc.GetAsync(url);
                kq.Wait();
                if (kq.Result.IsSuccessStatusCode == false) return null;
                var list = kq.Result.Content.ReadAsAsync<List<CLoaiLK>>();
                list.Wait();
                return list.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static bool themLoaiLK(CLoaiLK llk)
        {
            try
            {
                string url = @"http://localhost:64275/api/loailinhkien";
                var kq = hc.PostAsJsonAsync(url, llk);
                kq.Wait();
                return kq.Result.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool xoaLoaiLinhKien(string maLoaiLK)
        {
            try
            {
                string url = @"http://localhost:64275/api/loailinhkien/" + maLoaiLK;
                var kq = hc.DeleteAsync(url);
                kq.Wait();
                return kq.Result.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool suaLoaiLinhKien(CLoaiLK llk)
        {
            try
            {
                string url = @"http://localhost:64275/api/loailinhkien";
                var kq = hc.PutAsJsonAsync(url, llk);
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
