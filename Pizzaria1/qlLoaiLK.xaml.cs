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
    /// Interaction logic for qlLoaiLK.xaml
    /// </summary>
    public partial class qlLoaiLK : UserControl
    {
        public qlLoaiLK()
        {
            InitializeComponent();
            hienthi();
        }

        private void DgDanhSachLLK_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }
        private void hienthi()
        {
            List<CLoaiLK> dsLoaiLK = CXuLyLoaiLK.getDanhSachLoaiLK();
            dgDanhSachLLK.ItemsSource = dsLoaiLK;
        }

        private void DgDanhSachLLK_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CLoaiLK loaiLK = dgDanhSachLLK.SelectedItem as CLoaiLK;
            if (loaiLK != null)
            {
                txtMaLoai.Text = loaiLK.MaLoai;
                txtTenLoai.Text = loaiLK.TenLoai;
                if (loaiLK.status == true)
                    checkIsActive.IsChecked = true;
                else checkIsActive.IsChecked = false;
            }
        }

        private void BtnThemLLK_Click(object sender, RoutedEventArgs e)
        {
            CLoaiLK llk = new CLoaiLK();
            llk.MaLoai = txtMaLoai.Text;
            llk.TenLoai = txtTenLoai.Text;
            if (checkIsActive.IsChecked == true)
                llk.status = true;
            else llk.status = false;
            bool kq = CXuLyLoaiLK.themLoaiLK(llk);
            if (kq == true)
            {
                MessageBox.Show("Thêm loại linh kiện thành công");
                dgDanhSachLLK.ItemsSource = CXuLyLoaiLK.getDanhSachLoaiLK();
            }
            else
                MessageBox.Show("Thêm loại linh kiện thất bại");
        }

        private void BtnSuaLLK_Click(object sender, RoutedEventArgs e)
        {
            CLoaiLK llk = new CLoaiLK();
            llk.MaLoai = txtMaLoai.Text;
            llk.TenLoai = txtTenLoai.Text;
            if (checkIsActive.IsChecked == true)
                llk.status = true;
            else llk.status = false;
            bool kq = CXuLyLoaiLK.suaLoaiLinhKien(llk);
            if (kq == true)
            {
                MessageBox.Show("Sửa loại linh kiện thành công");
                dgDanhSachLLK.ItemsSource = CXuLyLoaiLK.getDanhSachLoaiLK();
            }
            else
                MessageBox.Show("Sửa loại linh kiện thất bại");
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            CLoaiLK llkSelected = dgDanhSachLLK.SelectedItem as CLoaiLK;
            bool kq = CXuLyLoaiLK.xoaLoaiLinhKien(llkSelected.MaLoai);
            if (kq == true)
            {
                MessageBox.Show("Xóa loại linh kiện thành công");
                dgDanhSachLLK.ItemsSource = CXuLyLoaiLK.getDanhSachLoaiLK();
            }
            else
                MessageBox.Show("Xóa loại linh kiện thất bại");
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            List<CLoaiLK> dsLoaiLK = CXuLyLoaiLK.getDanhSachLoaiLK();
            List<CLoaiLK> filter = new List<CLoaiLK>();
            foreach (CLoaiLK llk in dsLoaiLK)
            {
                llk.MaLoai.ToUpper();
                if (llk.MaLoai.Contains(txtSearch.Text.ToUpper()))
                {
                    filter.Add(llk);
                }
            }
            dgDanhSachLLK.ItemsSource = filter.ToList();
        }
    }
}
