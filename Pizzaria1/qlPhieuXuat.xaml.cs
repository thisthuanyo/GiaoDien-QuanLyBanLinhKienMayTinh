using System;
using System.Collections.Generic;
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
            List<CLinhKien> ds = CXuLiLinhKien.getDanhSachLinhKien();
            if (ds == null) MessageBox.Show("Lỗi kết nối Server!!");
            else cmbMahang.ItemsSource = ds;
        }
        private void hienthi()
        {
            List<CPhieuXuat> dsPhieuXuat = CXuLyPhieuXuat.getDSPhieuXuat();
            dgDSPhieuXuat.ItemsSource = dsPhieuXuat;
            List<CKhachHang> dsKhachHang = CXuLyKhachHang.getDSKhachHang();
            cboMaKH.ItemsSource = dsKhachHang;
            CNhanVien nvLogin = UserLogin.getLoginUser();
            txtMaNV.Text = nvLogin.MaNV;
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
                                txtThanhtien.Text = CXuLyPhieuXuat.getThanhTienPhieuXuat(pxTemp).ToString();
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
                                txtThanhtien.Text = CXuLyPhieuXuat.getThanhTienPhieuXuat(pxTemp).ToString();
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
                            txtThanhtien.Text = CXuLyPhieuXuat.getThanhTienPhieuXuat(pxTemp).ToString();
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
            txtThanhtien.Text = CXuLyPhieuXuat.getThanhTienPhieuXuat(pxTemp).ToString();
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
                px.TongTien = double.Parse(txtThanhtien.Text);
                px.status = true;
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
                    hienthi();
                    pxTemp.ChiTietPhieuXuats.Clear();
                    dgChitiet.ItemsSource = CXuLyPhieuXuat.getDSChiTietPhieuXuat(pxTemp);
                    txtThanhtien.Text = CXuLyPhieuXuat.getThanhTienPhieuXuat(pxTemp).ToString();
                }
            }
        }
        private void BtnHuy_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Bạn có chắc chắn muốn hủy phiếu xuất này không?", "Xác nhận hủy phiếu xuất", MessageBoxButton.YesNo);
            if (Result == MessageBoxResult.Yes)
            {
                CPhieuXuat px = dgDSPhieuXuat.SelectedItem as CPhieuXuat;
                if(px.status == false)
                {
                    MessageBox.Show("Phiếu xuất này đã bị hủy!!", "Thông báo");
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
        private void DgDSPhieuXuat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CPhieuXuat a = dgDSPhieuXuat.SelectedItem as CPhieuXuat;
            if(a!=null)
            {
                CPhieuXuat pxa = CXuLyPhieuXuat.getPhieuXuat(a.MaPX);
                txtSoPX.Text = a.MaPX.ToString();
                txtMaNV.Text = a.MaNV;
                cboMaKH.Text = a.MaKH;
                dpNgayXuat.SelectedDate = a.NgayXuat;
                dgChitiet.ItemsSource = CXuLyPhieuXuat.getDSChiTietPhieuXuat(pxa);
                txtThanhtien.Text = a.TongTien.ToString();
            }
        }

        private void DgChitiet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<CPhieuXuat> dsPhieuXuat = CXuLyPhieuXuat.getDSPhieuXuat();
            List<CPhieuXuat> filter = new List<CPhieuXuat>();
            foreach (CPhieuXuat px in dsPhieuXuat)
            {
                px.MaPX.ToString().ToUpper();
                if (px.MaPX.ToString().Contains(txtSearch.Text.ToUpper()))
                {
                    filter.Add(px);
                }
            }
            dgDSPhieuXuat.ItemsSource = filter.ToList();
            if (txtSearch.Text == null)
                dgDSPhieuXuat.ItemsSource = CXuLyNhanVien.getDanhSachNhanVien();
        }
    }
}
