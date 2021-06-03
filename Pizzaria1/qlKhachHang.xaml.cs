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
    /// Interaction logic for qlKhachHang.xaml
    /// </summary>
    public partial class qlKhachHang : UserControl
    {
        public qlKhachHang()
        {
            InitializeComponent();
            hienthi();
        }
        private void refresh()
        {
            txtDiaChi.Text = null;
            txtNamSinh.Text = null;
            txtSDT.Text = null;
            radNam.IsChecked = true;
            checkTrangThai.IsChecked = true;
            txtNaKH.Text = null;
            txtTenKH.Text = null;
            txtSearch.Text = null;
        }
        private void hienthi()
        {
            List<CKhachHang> dsKhachHang = CXuLyKhachHang.getDSKhachHang();
            dgDSKhachHang.ItemsSource = dsKhachHang;
        }
        private void BtnThemKH_Click(object sender, RoutedEventArgs e)
        {
            int num;
            if (txtNaKH.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "" || txtTenKH.Text == "" || txtNamSinh.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin cho khách hàng!", "Thông báo");
            }
            else if (int.TryParse(txtNamSinh.Text, out num) == false)
            {
                MessageBox.Show("Năm sinh phải nhập số");
                txtNamSinh.Focus();
            }
            else
            {
                CKhachHang kh = new CKhachHang();
                kh.DiaChi = txtDiaChi.Text;
                kh.MaKH = txtNaKH.Text;
                kh.NamSinh = int.Parse(txtNamSinh.Text);
                if (radNam.IsChecked == true)
                    kh.GioiTinh = true;
                else kh.GioiTinh = false;
                if (checkTrangThai.IsChecked == true)
                    kh.status = true;
                else kh.status = false;
                kh.SoDT = txtSDT.Text;
                kh.TenKh = txtTenKH.Text;
                bool kq = CXuLyKhachHang.themKhachHang(kh);
                if (kq == true)
                {
                    MessageBox.Show("Thêm khách hàng thành công");
                    dgDSKhachHang.ItemsSource = CXuLyKhachHang.getDSKhachHang();
                    refresh();
                }
                else
                    MessageBox.Show("Thêm khách hàng thất bại");
            }
        }
        private void BtnSuaKH_Click(object sender, RoutedEventArgs e)
        {
            int num;
            CKhachHang kha = dgDSKhachHang.SelectedItem as CKhachHang;
            if (kha == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa!!", "Thông báo");
            }
            else
            {
                CKhachHang kh = new CKhachHang();
                if (radNam.IsChecked == true)
                    kh.GioiTinh = true;
                else kh.GioiTinh = false;
                if (checkTrangThai.IsChecked == true)
                    kh.status = true;
                else kh.status = false;
                kh.MaKH = txtNaKH.Text;
                if (txtNaKH.Text == "")
                {
                    MessageBox.Show("Mã khách hàng không được để trống!!", "Thông báo");
                    txtNaKH.Focus();
                }
                else if (txtTenKH.Text == "")
                {
                    MessageBox.Show("Tên khách hàng không được để trống!!", "Thông báo");
                    txtTenKH.Focus();
                }
                else if (txtSDT.Text == "")
                {
                    MessageBox.Show("Số điện thoại khách hàng không được để trống!!", "Thông báo");
                    txtSDT.Focus();
                }
                else if (txtDiaChi.Text == "")
                {
                    MessageBox.Show("Địa chỉ khách hàng không được để trống!!", "Thông báo");
                    txtDiaChi.Focus();
                }
                else if (txtNamSinh.Text == "")
                {
                    MessageBox.Show("Năm sinh khách hàng không được để trống!!", "Thông báo");
                    txtNamSinh.Focus();
                }
                else if (int.TryParse(txtNamSinh.Text, out num) == false)
                {
                    MessageBox.Show("Năm sinh phải nhập số");
                    txtNamSinh.Focus();
                }
                else if(txtNaKH.Text != kha.MaKH)
                {
                    MessageBox.Show("Không được sửa mã khách hàng");
                    txtNaKH.Text = kha.MaKH;
                }
                else
                {
                    kh.TenKh = txtTenKH.Text;
                    kh.NamSinh = int.Parse(txtNamSinh.Text);
                    kh.SoDT = txtSDT.Text;
                    kh.DiaChi = txtDiaChi.Text;
                    bool kq = CXuLyKhachHang.suaKhachHang(kh);
                    if (kq == true)
                    {
                        MessageBox.Show("Sửa khách hàng thành công");
                        refresh();
                        dgDSKhachHang.ItemsSource = CXuLyKhachHang.getDSKhachHang();
                    }
                    else
                        MessageBox.Show("Sửa khách hàng thất bại");
                }
            }
        }
        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            CKhachHang nvSelect = dgDSKhachHang.SelectedItem as CKhachHang;
            if (nvSelect != null)
            {
                bool kq = CXuLyKhachHang.xoaKhachHang(nvSelect.MaKH);
                if (kq == true)
                {
                    MessageBox.Show("Xóa khách hàng thành công");
                    dgDSKhachHang.ItemsSource = CXuLyKhachHang.getDSKhachHang();
                    refresh();
                }
                else
                    MessageBox.Show("Không thể xóa khách hàng này!!","Thông báo");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng muốn xóa!!","Thông báo");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<CKhachHang> dsKhachHang = CXuLyKhachHang.getDSKhachHang();
            List<CKhachHang> filter = new List<CKhachHang>();
            foreach (CKhachHang kh in dsKhachHang)
            {
                if (kh.MaKH.ToUpper().Contains(txtSearch.Text.ToUpper()))
                {
                    filter.Add(kh);
                }
            }
            dgDSKhachHang.ItemsSource = filter.ToList();
            if (txtSearch.Text == null)
                dgDSKhachHang.ItemsSource = CXuLyKhachHang.getDSKhachHang();
        }

        private void DgDSKhachHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CKhachHang a = dgDSKhachHang.SelectedItem as CKhachHang;
            if (a != null)
            {
                txtDiaChi.Text = a.DiaChi;
                txtNaKH.Text = a.MaKH;
                txtNamSinh.Text = a.NamSinh.ToString();
                txtSDT.Text = a.SoDT;
                txtTenKH.Text = a.TenKh;
                if (a.GioiTinh == true)
                    radNam.IsChecked = true;
                else radNu.IsChecked = true;
                if (a.status == true)
                {
                    checkTrangThai.IsChecked = true;
                }
                else checkTrangThai.IsChecked = false;
            }
        }
        private void BtnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            refresh();
        }
    }
}
