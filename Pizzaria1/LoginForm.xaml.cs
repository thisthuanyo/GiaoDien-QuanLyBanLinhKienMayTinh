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
using System.Windows.Shapes;

namespace wpfLKMT
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    /// 
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Models.CNhanVien a = Models.CXuLyNhanVien.checkLogin(txtTaiKhoan.Text, txtMatKhau.Password);
            if (a != null)
            {
                if(a.ChucVu.Equals("AD"))
                {
                    MainWindow f = new MainWindow(a);
                    this.Hide();
                    f.Show();
                }
                else if(a.ChucVu.Equals("NV"))
                {
                    NhanVienWindow f = new NhanVienWindow(a);
                    this.Hide();
                    f.Show();
                }
            }      
            else MessageBox.Show("Sai thông tin đăng nhập ");
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void GridLogin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
