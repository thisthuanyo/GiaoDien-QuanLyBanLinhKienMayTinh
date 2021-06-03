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
    /// Interaction logic for qlPhieuXuat.xaml
    /// </summary>
    public partial class qlPhieuXuat : UserControl
    {
        private CPhieuXuat pxTemp = new CPhieuXuat
        {
            MaPX = 0,
            NgayXuat = DateTime.Now,
            MaKH = "",
            MaNV = "",
            status = true,
            TongTien = 0,
            ChiTietPhieuXuats = new List<CChiTietPhieuXuat>()
        };
        public qlPhieuXuat()
        {
            InitializeComponent();
            hienthi();
        }
        private void hienthi()
        {
            List<CPhieuXuat> dsPhieuXuat = CXuLyPhieuXuat.getDSPhieuXuat();
            dgDSPhieuXuat.ItemsSource = dsPhieuXuat;
            List<CKhachHang> dsKhachHang = CXuLyKhachHang.getDSKhachHang();
            cboMaKH.ItemsSource = dsKhachHang;
            CNhanVien nvLogin = UserLogin.getLoginUser();
            txtMaNV.Text = nvLogin.MaNV;

            List<CLinhKien> ds = CXuLiLinhKien.getDanhSachLinhKien();
            List<CLinhKien> dsFilter = new List<CLinhKien>();
            if (ds == null) MessageBox.Show("Lỗi kết nối Server!!");
            else
            {
                foreach(CLinhKien lk in ds)
                {
                    if(lk.status == true)
                    {
                        dsFilter.Add(lk);
                    }
                }
                if(dsFilter!= null)
                {
                    cmbMahang.ItemsSource = dsFilter;
                }
            }
        }
        
        private void BtnChon_Click(object sender, RoutedEventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(txtSoluong.Text, out n);
            var item = cmbMahang.SelectedItem;
            if (item == null)
                MessageBox.Show("Vui lòng chọn linh kiện!");
            else if (txtSoluong.Text == "")
                MessageBox.Show("Vui lòng nhập số lượng!");
            else if (isNumeric == false)
            {
                MessageBox.Show("Số lượng phải là số!");
            }
            else
            {
                CChiTietPhieuXuat ct = new CChiTietPhieuXuat();
                CLinhKien lk = cmbMahang.SelectedItem as CLinhKien;
                if (lk == null) return;
                else
                {
                    bool flag = false;
                    foreach (CChiTietPhieuXuat t in pxTemp.ChiTietPhieuXuats)
                    {
                        if (t.MaLK == lk.MaLK)
                        {
                            flag = true;
                            int s = int.Parse(txtSoluong.Text) + (int)t.SoLuong;
                            if (s == 0)
                            {
                                pxTemp.ChiTietPhieuXuats.Remove(t);
                                dgChitiet.ItemsSource = CXuLyPhieuXuat.getDSChiTietPhieuXuat(pxTemp);
                                double tongtien = CXuLyPhieuXuat.getThanhTienPhieuXuat(pxTemp);
                                txtThanhtien.Text = String.Format(new CultureInfo("vi-VN"), "{0:C}", tongtien);


                                break;
                            }
                            else if (s < 0)
                            {
                                MessageBox.Show("Số lượng không hợp lệ!!");
                                break;
                            }
                            else
                            {
                                t.SoLuong = s;
                                dgChitiet.ItemsSource = CXuLyPhieuXuat.getDSChiTietPhieuXuat(pxTemp);
                                double tongtien = CXuLyPhieuXuat.getThanhTienPhieuXuat(pxTemp);
                                txtThanhtien.Text = String.Format(new CultureInfo("vi-VN"), "{0:C}", tongtien);
                                break;
                            }
                        }
                    }
                    if (flag == false)
                    {
                        if (int.Parse(txtSoluong.Text) <= 0)
                            MessageBox.Show("Số lượng không hợp lệ!!");
                        else
                        {
                            ct.LinhKien = lk;
                            ct.MaLK = lk.MaLK;
                            ct.SoLuong = int.Parse(txtSoluong.Text);
                            ct.DonGia = lk.GiaBan;
                            pxTemp.ChiTietPhieuXuats.Add(ct);
                            dgChitiet.ItemsSource = CXuLyPhieuXuat.getDSChiTietPhieuXuat(pxTemp);
                            double tongtien = CXuLyPhieuXuat.getThanhTienPhieuXuat(pxTemp);
                            txtThanhtien.Text = String.Format(new CultureInfo("vi-VN"), "{0:C}", tongtien);
                        }
                    }
                }
            }
        }
        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (dgChitiet.SelectedItem == null) return;
            string malk = dgChitiet.SelectedValue.ToString();
            foreach (CChiTietPhieuXuat t in pxTemp.ChiTietPhieuXuats)
            {
                if (t.MaLK == malk)
                {
                    pxTemp.ChiTietPhieuXuats.Remove(t);
                    break;
                }
            }
            dgChitiet.ItemsSource = CXuLyPhieuXuat.getDSChiTietPhieuXuat(pxTemp);
            double tongtien = CXuLyPhieuXuat.getThanhTienPhieuXuat(pxTemp);
            txtThanhtien.Text = String.Format(new CultureInfo("vi-VN"), "{0:C}", tongtien);
        }

        private void BtnTaoPX_Click(object sender, RoutedEventArgs e)
        {
            if (dpNgayXuat.SelectedDate == null)
            {
                MessageBox.Show("Chọn ngày lập phiếu xuất!!");
                dpNgayXuat.Focus();
            }
            else if (cboMaKH.Text == "")
            {
                MessageBox.Show("Nhập mã khách hàng!!");
                cboMaKH.Focus();
            }
            else if (pxTemp.ChiTietPhieuXuats.Count == 0)
            {
                MessageBox.Show("Chưa chọn linh kiện nào để lập phiếu xuất!!");
            }
            else
            {
                CPhieuXuat px = new CPhieuXuat();
                px.NgayXuat = dpNgayXuat.SelectedDate;
                px.MaKH = cboMaKH.Text;
                px.MaNV = txtMaNV.Text;
                px.TongTien = CXuLyPhieuXuat.getThanhTienPhieuXuat(pxTemp);
                px.status = true;
                px.HoaDons = null;
                px.ChiTietPhieuXuats = pxTemp.ChiTietPhieuXuats.Select(x => new CChiTietPhieuXuat
                {
                    MaPX = px.MaPX,
                    MaLK = x.MaLK,
                    DonGia = x.DonGia,
                    SoLuong = x.SoLuong
                }).ToList();
                bool ok = CXuLyPhieuXuat.themPhieuXuat(px);
                if (ok == false) MessageBox.Show("Không thêm được phiếu xuất!!");
                else
                {
                    MessageBox.Show("Thêm phiếu xuất thành công!!");
                    refresh();
                    List<CPhieuXuat> dsPhieuXuat = CXuLyPhieuXuat.getDSPhieuXuat();
                    dgDSPhieuXuat.ItemsSource = dsPhieuXuat;
                    pxTemp.ChiTietPhieuXuats.Clear();
                    dgChitiet.ItemsSource = CXuLyPhieuXuat.getDSChiTietPhieuXuat(pxTemp);
                    double tongtien = CXuLyPhieuXuat.getThanhTienPhieuXuat(pxTemp);
                    txtThanhtien.Text = String.Format(new CultureInfo("vi-VN"), "{0:C}", tongtien);
                }
            }
        }
        private void BtnHuy_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Bạn có chắc chắn muốn hủy phiếu xuất này không?", "Xác nhận hủy phiếu xuất", MessageBoxButton.YesNo);
            if (Result == MessageBoxResult.Yes)
            {
                CPhieuXuat px = dgDSPhieuXuat.SelectedItem as CPhieuXuat;
                CHoaDon hd = CXuLyHoaDon.getHoaDonByMaPX(px.MaPX);
                if(hd != null)
                {
                    MessageBox.Show("Không thể hủy phiếu xuất này vì phiếu xuất này đã xuất hóa đơn!!", "Thông báo");
                }
                else if (px.status == false)
                {
                    MessageBox.Show("Phiếu xuất này đã bị hủy trước đó!! ","Thông báo");
                }
                else
                {
                    px.status = false;
                    bool kq = CXuLyPhieuXuat.huyPhieuXuat(px);
                    if (kq == true)
                    {
                        MessageBox.Show("Hủy phiếu xuất thành công!!");
                        refresh();
                        dgChitiet.ItemsSource = CXuLyPhieuXuat.getDSChiTietPhieuXuat(pxTemp);
                        double tongtien = CXuLyPhieuXuat.getThanhTienPhieuXuat(pxTemp);
                        txtThanhtien.Text = String.Format(new CultureInfo("vi-VN"), "{0:C}", tongtien);
                    }
                    else MessageBox.Show("Hủy phiếu xuất thất bại!");
                }
            }
        }
        private void DgDSPhieuXuat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CPhieuXuat a = dgDSPhieuXuat.SelectedItem as CPhieuXuat;
            if (a != null)
            {
                CPhieuXuat pxa = CXuLyPhieuXuat.getPhieuXuat(a.MaPX);
                txtSoPX.Text = a.MaPX.ToString();
                txtMaNV.Text = a.MaNV;
                cboMaKH.Text = a.MaKH;
                dpNgayXuat.SelectedDate = a.NgayXuat;
                dgChitiet.ItemsSource = CXuLyPhieuXuat.getDSChiTietPhieuXuat(pxa);
                double tongtien = (double)a.TongTien;
                txtThanhtien.Text = String.Format(new CultureInfo("vi-VN"), "{0:C}", tongtien);
                btnLapHD.IsEnabled = true;
            }
            else btnLapHD.IsEnabled = false;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<CPhieuXuat> dsPhieuXuat = CXuLyPhieuXuat.getDSPhieuXuat();
            List<CPhieuXuat> filter = new List<CPhieuXuat>();
            foreach (CPhieuXuat px in dsPhieuXuat)
            {
                if (px.MaPX.ToString().ToUpper().Contains(txtSearch.Text.ToUpper()))
                {
                    filter.Add(px);
                }
            }
            dgDSPhieuXuat.ItemsSource = filter.ToList();
            if (txtSearch.Text == null)
                dgDSPhieuXuat.ItemsSource = CXuLyNhanVien.getDanhSachNhanVien();
        }

        private void BtnLapHD_Click(object sender, RoutedEventArgs e)
        {
            CPhieuXuat pxSelected = dgDSPhieuXuat.SelectedItem as CPhieuXuat;
            if(pxSelected.status == false)
            {
                MessageBox.Show("Phiếu xuất này đã bị hủy, không thể tạo hóa đơn cho phiếu xuất này!!", "Thông báo");
            }
            else if (pxSelected != null)
            {
                CHoaDon hd = new CHoaDon()
                {
                    MaKH = pxSelected.MaKH,
                    MaNV = pxSelected.MaNV,
                    NgayGiao = pxSelected.NgayXuat,
                    NgayLapHD = DateTime.Now,
                    status = pxSelected.status,
                    TongTien = pxSelected.TongTien,
                    MaPX = pxSelected.MaPX,
                };
                bool kq = CXuLyHoaDon.themHoaDon(hd);
                if (kq == false) MessageBox.Show("Không lập được hóa đơn!!");
                else
                {
                    MessageBox.Show("Lập hóa đơn thành công!!");
                    btnLapHD.IsEnabled = false;
                    refresh();
                }
            }

        }
        private void refresh()
        {
            txtSoluong.Text = null;
            txtSoPX.Text = null;
            txtThanhtien.Text = null;
            dpNgayXuat.SelectedDate = null;
            cmbMahang.SelectedItem = null;
            cboMaKH.SelectedItem = null;
        }
        private void DgChitiet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
