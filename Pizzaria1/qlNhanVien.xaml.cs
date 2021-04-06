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
  
    }
}
