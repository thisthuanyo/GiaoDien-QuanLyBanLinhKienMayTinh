using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
namespace wpfLKMT.Models
{
    class CXuLiLinhKien
    {
        private static HttpClient hc = new HttpClient();
        public static List<CLinhKien> getDanhSachLinhKien()
        {
            try
            {
                string url = @"http://localhost:64275/api/linhkien";
                var kq = hc.GetAsync(url);
                kq.Wait();
                if (kq.Result.IsSuccessStatusCode == false) return null;
                var list = kq.Result.Content.ReadAsAsync <List<CLinhKien>> ();
                list.Wait();
                return list.Result;
            }
            catch (Exception)
            {
                return null; 
            }
        }

        public static bool themLinhKien(CLinhKien lk)
        {
            try
            {
                string url = @"http://localhost:64275/api/linhkien";
                var kq = hc.PostAsJsonAsync(url,lk);
                kq.Wait();
                return kq.Result.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool xoaLinhKien(string maLk)
        {
            try
            {
                string url = @"http://localhost:64275/api/linhkien?malk="+maLk;
                var kq = hc.DeleteAsync(url);
                kq.Wait();
                return kq.Result.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool suaLinhKien(CLinhKien lk)
        {
            try
            {
                string url = @"http://localhost:64275/api/linhkien";
                var kq = hc.PutAsJsonAsync(url, lk);
                kq.Wait();
                return kq.Result.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<CLinhKien> getLinhKien(string malk)
        {
            try
            {
                string url = @"http://localhost:64275/api/linhkien?malk=" + malk;
                var kq = hc.GetAsync(url);
                kq.Wait();

                if (kq.Result.IsSuccessStatusCode == false) return null;
                var list = kq.Result.Content.ReadAsAsync<List<CLinhKien>>();
                list.Wait();
                return list.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
