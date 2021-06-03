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
using System.Net.Http;
using wpfLKMT.Models;

namespace wpfLKMT
{
    /// <summary>
    /// Interaction logic for qlNhanVien.xaml
    /// </summary>
    public partial class qlNhanVien : UserControl
    {
        private bool isClick = false;
        public qlNhanVien()
        {
            InitializeComponent();
            hienthi();
            loadChucVu();
        }

        private void BtnShowPassword_Click(object sender, RoutedEventArgs e)
        {
            if (isClick == false)
            {
                txtPassword.Visibility = Visibility.Visible;
                txtPassword.Text = passwordBox.Password.ToString();
                passwordBox.Visibility = Visibility.Hidden;
                isClick = true;
            }
            else
            {
                txtPassword.Visibility = Visibility.Hidden;
                passwordBox.Visibility = Visibility.Visible;
                isClick = false;
            }
        }
        private void hienthi()
        {
            List<CNhanVien> dsNhanVien = CXuLyNhanVien.getDanhSachNhanVien();
            if (dsNhanVien == null)
            {
                MessageBox.Show("Lỗi kết nối CSDL không thể load Danh sách nhân viên", "Thông báo");
            }
            else
            {
                dgDSNhanVien.ItemsSource = dsNhanVien;
            }
        }
        private void loadChucVu()
        {
            List<CChucVu> dsChuVu = CXuLyNhanVien.getDSChucVu();
            if (dsChuVu == null)
            {
                MessageBox.Show("Lỗi kết nối CSDL không thể load Danh sách chức vụ", "Thông báo");
            }
            else
            {
                cboChucVu.ItemsSource = dsChuVu;
            }
        }
        private void refresh()
        {
            txtDiaChi.Text = null;
            txtMaNV.Text = null;
            txtNamSinh.Text = null;
            txtPassword.Text = null;
            txtSDT.Text = null;
            txtTenNV.Text = null;
            txtUserName.Text = null;
            radNam.IsChecked = true;
            checkTrangThai.IsChecked = true;
            passwordBox.Password = null;
            cboChucVu.SelectedItem = null;
        }
        private void BtnXoaNV_Click(object sender, RoutedEventArgs e)
        {
            CNhanVien nvSelect = dgDSNhanVien.SelectedItem as CNhanVien;
            CNhanVien loginUser = UserLogin.getLoginUser();
            if (loginUser.ChucVu == "AD" && loginUser.ChucVu != nvSelect.ChucVu)
            {
                bool kq = CXuLyNhanVien.xoaNhanVien(nvSelect.MaNV);
                if (kq == true)
                {
                    MessageBox.Show("Xóa nhân viên thành công");
                    dgDSNhanVien.ItemsSource = CXuLyNhanVien.getDanhSachNhanVien();
                    refresh();
                }
                else
                    MessageBox.Show("Không thể xóa nhân viên này");
            }
            else
            {
                MessageBox.Show("Bạn không có quyền làm điều này");
            }
        }
        private bool checkExistUserName(string username)
        {
            List<CNhanVien> dsNV = CXuLyNhanVien.getDanhSachNhanVien();
            CNhanVien a = dsNV.Where(x => x.UserName == username).SingleOrDefault();
            if (a != null)
                return true;
            else return false;
        }
        private void BtnThemNV_Click(object sender, RoutedEventArgs e)
        {
            int num;
            if (txtMaNV.Text == "" || txtDiaChi.Text == "" || passwordBox.Password == "" || txtSDT.Text == "" || txtTenNV.Text == "" || txtUserName.Text == "" || txtNamSinh.Text == "" || cboChucVu.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin cho nhân viên!", "Thông báo");
            }
            else if (int.TryParse(txtNamSinh.Text, out num) == false)
            {
                MessageBox.Show("Năm sinh phải nhập số");
                txtNamSinh.Focus();
            }
            else
            {
                CNhanVien nv = new CNhanVien();
                CChucVu cv = cboChucVu.SelectedItem as CChucVu;
                nv.ChucVu1 = cv;
                nv.ChucVu = cv.MaCV;
                nv.TenNV = txtTenNV.Text;
                nv.MaNV = txtMaNV.Text;
                if (radNam.IsChecked == true)
                    nv.GioiTinh = true;
                else nv.GioiTinh = false;
                if (checkTrangThai.IsChecked == true)
                    nv.status = true;
                else nv.status = false;
                nv.NamSinh = int.Parse(txtNamSinh.Text);
                nv.Pass = txtPassword.Text;
                nv.UserName = txtUserName.Text;
                nv.DiaChi = txtDiaChi.Text;
                nv.SoDT = txtSDT.Text;
                if (checkExistUserName(nv.UserName))
                {
                    MessageBox.Show("Tên username này đã tồn tại!!", "Thông báo");
                }
                else
                {
                    bool kq = CXuLyNhanVien.themNhanVien(nv);
                    if (kq == true)
                    {
                        MessageBox.Show("Thêm nhân viên thành công");
                        dgDSNhanVien.ItemsSource = CXuLyNhanVien.getDanhSachNhanVien();
                        refresh();
                    }
                    else
                        MessageBox.Show("Thêm nhân viên thất bại");
                }
            }
        }
        private void BtnSuaNV_Click(object sender, RoutedEventArgs e)
        {
            int num;
            if (dgDSNhanVien.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!!", "Thông báo");
            }
            else
            {
                CNhanVien nvSelected = dgDSNhanVien.SelectedItem as CNhanVien;
                CNhanVien nvLogin = UserLogin.getLoginUser();
                if (nvSelected.ChucVu == nvLogin.ChucVu)
                    MessageBox.Show("Bạn không có quyền sửa tài khoản có cùng chức vụ!!", "Thông báo");
                else
                {
                    CNhanVien nv = new CNhanVien();
                    CChucVu cv = cboChucVu.SelectedItem as CChucVu;
                    nv.ChucVu1 = cv;
                    nv.ChucVu = cv.MaCV;
                    nv.TenNV = txtTenNV.Text;
                    nv.MaNV = nvSelected.MaNV;
                    if (radNam.IsChecked == true)
                        nv.GioiTinh = true;
                    else nv.GioiTinh = false;
                    if (checkTrangThai.IsChecked == true)
                        nv.status = true;
                    else nv.status = false;
                    nv.NamSinh = int.Parse(txtNamSinh.Text);
                    nv.Pass = txtPassword.Text;
                    nv.UserName = txtUserName.Text;
                    nv.DiaChi = txtDiaChi.Text;
                    nv.SoDT = txtSDT.Text;
                    if (txtMaNV.Text == "")
                    {
                        MessageBox.Show("Mã nhân viên không được để trống!!", "Thông báo");
                        txtMaNV.Focus();
                    }
                    else if (txtTenNV.Text == "")
                    {
                        MessageBox.Show("Tên nhân viên không được để trống!!", "Thông báo");
                        txtTenNV.Focus();
                    }
                    else if (txtDiaChi.Text == "")
                    {
                        MessageBox.Show("Địa chỉ khách hàng không được để trống!!", "Thông báo");
                        txtDiaChi.Focus();
                    }
                    else if (txtSDT.Text == "")
                    {
                        MessageBox.Show("Số điện thoại khách hàng không được để trống!!", "Thông báo");
                        txtSDT.Focus();
                    }
                    else if (cboChucVu.Text == "")
                    {
                        MessageBox.Show("Vui lòng chọn chức vụ cho nhân viên!!", "Thông báo");
                        cboChucVu.Focus();
                    }
                    else if (txtUserName.Text == "")
                    {
                        MessageBox.Show("Tên username không được để trống!!", "Thông báo");
                        txtUserName.Focus();
                    }
                    else if (passwordBox.Password == "")
                    {
                        MessageBox.Show("Mật khẩu nhân viên không được để trống!!", "Thông báo");
                        passwordBox.Focus();
                    }
                    else if (txtNamSinh.Text == "")
                    {
                        MessageBox.Show("Năm sinh nhân viên không được để trống!!", "Thông báo");
                        txtNamSinh.Focus();
                    }
                    else if (int.TryParse(txtNamSinh.Text, out num) == false)
                    {
                        MessageBox.Show("Năm sinh phải nhập số");
                        txtNamSinh.Focus();
                    }
                    else if (txtMaNV.Text != nvSelected.MaNV)
                    {
                        MessageBox.Show("Không được sửa mã nhân viên", "Thông báo");
                        txtMaNV.Text = nvSelected.MaNV;
                        return;
                    }
                    else if (checkExistUserName(nv.UserName) && nvSelected.UserName != txtUserName.Text)
                    {
                        MessageBox.Show("Tên username này đã tồn tại!!", "Thông báo");
                    }
                    else
                    {
                        bool kq = CXuLyNhanVien.suaNhanVien(nv);
                        if (kq == true)
                        {
                            MessageBox.Show("Sửa Nhân viên thành công");
                            refresh();
                            dgDSNhanVien.ItemsSource = CXuLyNhanVien.getDanhSachNhanVien();
                        }
                        else
                            MessageBox.Show("Sửa nhân viên thất bại");
                    }
                }
            }
        }

        private void DgDSNhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CNhanVien nv = dgDSNhanVien.SelectedItem as CNhanVien;
            if (nv != null)
            {
                txtDiaChi.Text = nv.DiaChi;
                txtMaNV.Text = nv.MaNV;
                if (nv.status == true)
                    checkTrangThai.IsChecked = true;
                else checkTrangThai.IsChecked = false;
                passwordBox.Password = nv.Pass;
                txtPassword.Text = nv.Pass;
                if (nv.GioiTinh == true)
                    radNam.IsChecked = true;
                else radNu.IsChecked = true;
                txtSDT.Text = nv.SoDT;
                txtTenNV.Text = nv.TenNV;
                txtUserName.Text = nv.UserName;
                txtNamSinh.Text = nv.NamSinh.ToString();
                CChucVu cv = CXuLyNhanVien.findChucVu(nv.ChucVu);
                cboChucVu.IsEnabled = true;
                if (cv != null)
                {
                    cboChucVu.Text = cv.TenCV;
                }
                CNhanVien NVLogin = UserLogin.getLoginUser();
                if (NVLogin.MaNV == nv.MaNV)
                {
                    cboChucVu.IsEnabled = false;
                }
            }
        }
        private void TxtSearchNV_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<CNhanVien> dsNhanVien = CXuLyNhanVien.getDanhSachNhanVien();
            List<CNhanVien> filter = new List<CNhanVien>();
            foreach (CNhanVien nv in dsNhanVien)
            {
                if (nv.MaNV.ToUpper().Contains(txtSearchNV.Text.ToUpper()))
                {
                    filter.Add(nv);
                }
            }
            dgDSNhanVien.ItemsSource = filter.ToList();
            if (txtSearchNV.Text == null)
                dgDSNhanVien.ItemsSource = CXuLyNhanVien.getDanhSachNhanVien();
        }
        private void BtnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            refresh();
            dgDSNhanVien.SelectedItem = null;
        }
    }
}
