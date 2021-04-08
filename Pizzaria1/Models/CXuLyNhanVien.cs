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
                {
                    return nv.Result;
                }
                else return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static List<CChucVu> getDSChucVu()
        {
            try
            {
                string url = @"http://localhost:64275/api/chucvu";
                var kq = hc.GetAsync(url);
                kq.Wait();
                if (kq.Result.IsSuccessStatusCode == false)
                    return null;
                var listCV = kq.Result.Content.ReadAsAsync<List<CChucVu>>();
                listCV.Wait();
                return listCV.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static List<CNhanVien> getDanhSachNhanVien()
        {
            try
            {
                string url = @"http://localhost:64275/api/nhanvien";
                var kq = hc.GetAsync(url);
                kq.Wait();
                if (kq.Result.IsSuccessStatusCode == false) return null;
                var list = kq.Result.Content.ReadAsAsync<List<CNhanVien>>();
                list.Wait();
                return list.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static bool themNhanVien(CNhanVien nv)
        {
            try
            {
                string url = @"http://localhost:64275/api/nhanvien";
                var kq = hc.PostAsJsonAsync(url, nv);
                kq.Wait();
                return kq.Result.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool xoaNhanVien(string maNhanVien)
        {
            try
            {
                string url = @"http://localhost:64275/api/nhanvien/" + maNhanVien;
                var kq = hc.DeleteAsync(url);
                kq.Wait();
                return kq.Result.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool suaNhanVien(CNhanVien nv)
        {
            try
            {
                string url = @"http://localhost:64275/api/nhanvien";
                var kq = hc.PutAsJsonAsync(url, nv);
                kq.Wait();
                return kq.Result.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static CChucVu findChucVu(string macv)
        {
            try
            {
                string url = @"http://localhost:64275/api/chucvu/" + macv;
                var kq = hc.GetAsync(url);
                kq.Wait();
                if (kq.Result.IsSuccessStatusCode == false) return null;
                var a = kq.Result.Content.ReadAsAsync<CChucVu>();
                return a.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
