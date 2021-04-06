using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace wpfLKMT.Models
{
    class CXuLyNhanVien
    {
        private static HttpClient hc = new HttpClient();
        public static CNhanVien checkLogin(string username, string password)
        {
            try
            {
                string url = "http://localhost:64275/api/nhanvien?username=" + username;
                var kq = hc.GetAsync(url);
                kq.Wait();
                if (kq.Result.IsSuccessStatusCode == false) return null;
                var nv = kq.Result.Content.ReadAsAsync<CNhanVien>();
                nv.Wait();
                if (nv.Result.Pass == password)
                    return nv.Result;
                else return null;
            } catch(Exception)
            {
                return null;
            }
        }

    }
}
