using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using wpfLKMT.Models;

namespace wpfLKMT
{
    /// <summary>
    /// Interaction logic for qlHoaDon.xaml
    /// </summary>
    public partial class qlHoaDon : UserControl
    {
        public qlHoaDon()
        {
            InitializeComponent();
            hienthi();
        }
        private void hienthi()
        {
            List<CHoaDon> dshd = CXuLyHoaDon.getDSHoaDon();
            dgDSHoadon.ItemsSource = dshd;
        }

        private void DgDSHoadon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CHoaDon hd = dgDSHoadon.SelectedItem as CHoaDon;
            if(hd != null)
            {
                txtMaKH.Text = hd.MaKH;
                txtMaNVXuat.Text = hd.MaNV;
                txtMaPX.Text = hd.MaPX.ToString();
                txtMaHD.Text = hd.MaHD.ToString();
                dpNgayGiao.SelectedDate = hd.NgayGiao;
                dpNgayLapHD.SelectedDate = hd.NgayLapHD;
                double tongtien = (double)hd.TongTien;
                txtTongTien.Text = String.Format(new CultureInfo("vi-VN"), "{0:C}", tongtien);
                dgChitiet.ItemsSource = CXuLyHoaDon.getDSChiTietHoaDon(hd);
            }
        }
    }
}
