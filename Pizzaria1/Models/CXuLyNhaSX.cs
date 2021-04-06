using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
namespace wpfLKMT.Models
{
    class CXuLyNhaSX
    {
        private static HttpClient hc = new HttpClient();
        public static List<CNhaSX> getDSNhaSanXuat()
        {
            try
            {
                string url = @"http://localhost:64275/api/nhasanxuat";
                var kq = hc.GetAsync(url);
                kq.Wait();
                if (kq.Result.IsSuccessStatusCode == false) return null;
                var list = kq.Result.Content.ReadAsAsync<List<CNhaSX>>();
                list.Wait();
                return list.Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static bool themNhaSanXuat(CNhaSX nsx)
        {
            try
            {
                string url = @"http://localhost:64275/api/nhasanxuat";
                var kq = hc.PostAsJsonAsync(url, nsx);
                kq.Wait();
                return kq.Result.IsSuccessStatusCode;           
            } catch (Exception)
            {
                return false;
            }
        }
        public static bool xoaNhaSanXuat(string maNSX)
        {
            try
            {
                string url= @"http://localhost:64275/api/nhasanxuat/" + maNSX;
                var kq = hc.DeleteAsync(url);
                kq.Wait();
                return kq.Result.IsSuccessStatusCode;
            } catch(Exception)
            {
                return false;
            }
        }
        public static bool suaNhaSanXuat(CNhaSX nsx)
        {
            try
            {
                string url = @"http://localhost:64275/api/nhasanxuat";
                var kq = hc.PutAsJsonAsync(url, nsx);
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
