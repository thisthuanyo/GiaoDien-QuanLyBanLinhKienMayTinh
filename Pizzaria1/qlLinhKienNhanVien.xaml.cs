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
    /// Interaction logic for qlLinhKienNhanVien.xaml
    /// </summary>
    public partial class qlLinhKienNhanVien : UserControl
    {
        private List<CLinhKien> temp_lk = new List<CLinhKien>();
        public qlLinhKienNhanVien()
        {
            InitializeComponent();
            HienThi();
        }
        private void HienThi()
        {
            List<CLinhKien> lst = new List<CLinhKien>();
            foreach (var item in CXuLiLinhKien.getDanhSachLinhKien())
            {
                if (item.status == true)
                {
                    lst.Add(item);
                }
            }
            setNull();
            dgDanhSachLK.ItemsSource = lst;
            temp_lk = lst;
            cmbMaLoai.ItemsSource = CXuLyLoaiLK.getDanhSachLoaiLK();
            cmbHSX.ItemsSource = CXuLyNhaSX.getDSNhaSanXuat();
        }
        private void setNull()
        {
            txtGiaBan.Text = "";
            txtMaLinhKien.Text = "";
            txtTenLinhKien.Text = "";
        }

        private void txtTimKiemMaLK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {

                string malk = txtTimKiemMaLK.Text.ToUpper();

                List<CLinhKien> lk = new List<CLinhKien>();
                foreach (var item in temp_lk)
                {
                    string ma = item.MaLK.ToUpper();
                    if (ma == malk)
                    {
                        lk.Add(item);
                    }
                }

                if (lk.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy ");
                    return;
                }

                dgDanhSachLK.ItemsSource = lk;
                return;
            }
        }
        private void txtTimKiemMaLK_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                if (txtTimKiemMaLK.Text == "")
                {
                    HienThi();
                }
            }
        }

        private void dgDanhSachLK_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgDanhSachLK.SelectedItem == null) return;
            CLinhKien lk = dgDanhSachLK.SelectedItem as CLinhKien;
            txtMaLinhKien.Text = lk.MaLK;
            txtTenLinhKien.Text = lk.TenLK;
            txtGiaBan.Text = lk.GiaBan.ToString();
            cmbMaLoai.Text = lk.MaLoai.ToString();
            cmbHSX.Text = lk.MaNSX.ToString();
            if (lk.status == true)
            {
                checkActive.IsChecked = true;
            }
            else checkActive.IsChecked = false;
        }
    }
}
