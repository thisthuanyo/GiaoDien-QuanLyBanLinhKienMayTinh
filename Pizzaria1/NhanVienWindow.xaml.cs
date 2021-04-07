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
    /// Interaction logic for NhanVienWindow.xaml
    /// </summary>
    public partial class NhanVienWindow : Window
    {
        public Models.CNhanVien nv;
        public NhanVienWindow()
        {
            InitializeComponent();
        }
        public NhanVienWindow(Models.CNhanVien a)
        {
            InitializeComponent();
            nv = a;
            textNameUser.Text = nv.TenNV;
        }
        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new qlLinhKienNhanVien());
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new qlKhachHang());
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new qlPhieuXuat());
                    break;
                case 3:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new qlHoaDonNhanVien());
                    break;
                case 4:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new qlTaiKhoanNhanVien());
                    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }

        private void BtnQLTK_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDangXuat1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            LoginForm f = new LoginForm();
            f.Show();
        }
    }
}
