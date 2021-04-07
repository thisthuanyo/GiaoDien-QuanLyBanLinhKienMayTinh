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
        }

        private void BtnShowPassword_Click(object sender, RoutedEventArgs e)
        {
            if(isClick == false)
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
            dgDSNhanVien.ItemsSource = dsNhanVien;
        }

        private void BtnXoaNV_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnThemNV_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSuaNV_Click(object sender, RoutedEventArgs e)
        {

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
                if (nv.GioiTinh == true)
                    radNam.IsChecked = true;
                else radNu.IsChecked = true;
                txtSDT.Text = nv.SoDT;
                txtTenNV.Text = nv.TenNV;
                txtUserName.Text = nv.UserName;
                cboChucVu.Text = nv.ChucVu;
                txtNamSinh.Text = nv.NamSinh.ToString();
                    
            }
        }
    }
}
