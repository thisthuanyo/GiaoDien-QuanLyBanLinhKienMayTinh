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
    /// Interaction logic for qlTaiKhoanNhanVien.xaml
    /// </summary>
    public partial class qlTaiKhoanNhanVien : UserControl
    {
        public qlTaiKhoanNhanVien()
        {
            InitializeComponent();
            hienthi();
        }
        private void hienthi()
        {
            CNhanVien nvLogin = UserLogin.getLoginUser();
            txtUserName.Text = nvLogin.UserName;
            txtSDT.Text = nvLogin.SoDT;
            txtDiaChi.Text = nvLogin.DiaChi;
            txtTenNV.Text = nvLogin.TenNV;
            txtMaNV.Text = nvLogin.MaNV;
        }
        private bool checkExistUserName(string username)
        {
            List<CNhanVien> dsNV = CXuLyNhanVien.getDanhSachNhanVien();
            CNhanVien a = dsNV.Where(x => x.UserName == username).SingleOrDefault();
            if (a != null)
                return true;
            else return false;
        }
        private void BtnCapNhat_Click(object sender, RoutedEventArgs e)
        {
            CNhanVien nvLogin = UserLogin.getLoginUser();
            nvLogin.SoDT = txtSDT.Text;
            nvLogin.DiaChi = txtDiaChi.Text;
            nvLogin.TenNV = txtTenNV.Text;
            bool flag1 = true;
            bool flag2 = true;
            if (checkExistUserName(txtUserName.Text) && txtUserName.Text != nvLogin.UserName)
            {
                MessageBox.Show("Tên username này đã tồn tại!!", "Thông báo");
                flag1 = false;
            }
            else
            {
                nvLogin.UserName = txtUserName.Text;
            }
            if (checkResetPassword.IsChecked == true)
            {
                if (txtPassword.Password != txtConfirmPassWord.Password)
                {
                    MessageBox.Show("Mật khẩu không khớp!!", "Thông báo");
                    flag2 = false;
                }
                else
                {
                    flag2 = true;
                    nvLogin.Pass = txtPassword.Password;
                }
            }
            if (flag1 == true && flag2 == true)
            {
                bool kq = CXuLyNhanVien.suaNhanVien(nvLogin);
                if (kq == true)
                {
                    MessageBox.Show("Cập nhật thông tin cá nhân thành công");
                    checkResetPassword.IsChecked = false;
                    txtPassword.Password = null;
                    txtConfirmPassWord.Password = null;
                }
                else
                    MessageBox.Show("Cập nhật thông tin cá nhân thất bại");
            }
        }
    }
}
