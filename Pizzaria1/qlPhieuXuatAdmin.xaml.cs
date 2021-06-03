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
    /// Interaction logic for qlPhieuXuatAdmin.xaml
    /// </summary>
    public partial class qlPhieuXuatAdmin : UserControl
    {
        public qlPhieuXuatAdmin()
        {
            InitializeComponent();
            hienthi();
        }
        private void hienthi()
        {
            List<CPhieuXuat> dsPhieuXuat = CXuLyPhieuXuat.getDSPhieuXuat();
            dgDSPhieuXuat.ItemsSource = dsPhieuXuat;
        }

        private void BtnHuy_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Bạn có chắc chắn muốn hủy phiếu xuất này không?", "Xác nhận hủy phiếu xuất", MessageBoxButton.YesNo);
            if (Result == MessageBoxResult.Yes)
            {
                CPhieuXuat px = dgDSPhieuXuat.SelectedItem as CPhieuXuat;
                CHoaDon hd = CXuLyHoaDon.getHoaDonByMaPX(px.MaPX);
                if (hd != null)
                {
                    MessageBox.Show("Không thể hủy phiếu xuất này vì phiếu xuất này đã xuất hóa đơn!!", "Thông báo");
                }
                else if (px.status == false)
                {
                    MessageBox.Show("Phiếu xuất này đã bị hủy trước đó!! ", "Thông báo");
                }
                else
                {
                    px.status = false;
                    bool kq = CXuLyPhieuXuat.huyPhieuXuat(px);
                    if (kq == true)
                    {
                        MessageBox.Show("Hủy phiếu xuất thành công!!");
                    }
                    else MessageBox.Show("Hủy phiếu xuất thất bại!");
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<CPhieuXuat> dsPhieuXuat = CXuLyPhieuXuat.getDSPhieuXuat();
            List<CPhieuXuat> filter = new List<CPhieuXuat>();
            foreach (CPhieuXuat px in dsPhieuXuat)
            {
                px.MaPX.ToString().ToUpper();
                if (px.MaPX.ToString().ToUpper().Contains(txtSearch.Text.ToUpper()))
                {
                    filter.Add(px);
                }
            }
            dgDSPhieuXuat.ItemsSource = filter.ToList();
            if (txtSearch.Text == null)
                dgDSPhieuXuat.ItemsSource = CXuLyNhanVien.getDanhSachNhanVien();
        }

        private void DgDSPhieuXuat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CPhieuXuat a = dgDSPhieuXuat.SelectedItem as CPhieuXuat;
            if (a != null)
            {
                CPhieuXuat pxa = CXuLyPhieuXuat.getPhieuXuat(a.MaPX);
                txtSoPX.Text = a.MaPX.ToString();
                
                txtMaNV.Text = a.MaNV;
                txtMaKH.Text = a.MaKH;
                dpNgayXuat.SelectedDate = a.NgayXuat;
                dgChitiet.ItemsSource = CXuLyPhieuXuat.getDSChiTietPhieuXuat(pxa);
                double tongtien = (double)a.TongTien;
                txtThanhtien.Text = String.Format(new CultureInfo("vi-VN"), "{0:C}", tongtien);
            }
        }
    }
}
