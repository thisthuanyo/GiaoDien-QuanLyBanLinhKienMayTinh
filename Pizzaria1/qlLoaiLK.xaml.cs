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
            if (txtMaLoai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã loại linh kiện!");
                txtMaLoai.Focus();
            }
            else if (txtTenLoai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên loại linh kiện!");
                txtTenLoai.Focus();
            }
            else
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
                    refresh();
                }
                else
                    MessageBox.Show("Thêm loại linh kiện thất bại");
            }
               
        }

        private void BtnSuaLLK_Click(object sender, RoutedEventArgs e)
        {
            CLoaiLK a = dgDanhSachLLK.SelectedItem as CLoaiLK;
            if(a==null)
            {
                MessageBox.Show("Vui lòng chọn loại linh kiện muốn sửa");
            }
            else
            {
                if (txtMaLoai.Text == "")
                {
                    MessageBox.Show("Mã loại linh kiện không được để trống!!");
                    txtMaLoai.Focus();
                }
                else if (txtTenLoai.Text == "")
                {
                    MessageBox.Show("Tên loại linh kiện không được để trống!!");
                    txtTenLoai.Focus();
                }
                else if (txtMaLoai.Text != a.MaLoai)
                {
                    MessageBox.Show("Không được sửa mã loại linh kiện");
                    txtMaLoai.Text = a.MaLoai;
                }
                else
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
                        refresh();
                        dgDanhSachLLK.ItemsSource = CXuLyLoaiLK.getDanhSachLoaiLK();
                    }
                    else
                        MessageBox.Show("Sửa loại linh kiện thất bại");
                }
            }
           
        }

        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (dgDanhSachLLK.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn loại linh kiện muốn xóa");
            }
            else
            {
                CLoaiLK llkSelected = dgDanhSachLLK.SelectedItem as CLoaiLK;
                bool kq = CXuLyLoaiLK.xoaLoaiLinhKien(llkSelected.MaLoai);
                if (kq == true)
                {
                    MessageBox.Show("Xóa loại linh kiện thành công");
                    refresh();
                    dgDanhSachLLK.ItemsSource = CXuLyLoaiLK.getDanhSachLoaiLK();
                }
                else
                    MessageBox.Show("Thông thể xóa loại linh kiện này!");
            }
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<CLoaiLK> dsLoaiLK = CXuLyLoaiLK.getDanhSachLoaiLK();
            List<CLoaiLK> filter = new List<CLoaiLK>();
            foreach (CLoaiLK llk in dsLoaiLK)
            {
                if (llk.MaLoai.ToUpper().Contains(txtSearch.Text.ToUpper()))
                {
                    filter.Add(llk);
                }
            }
            dgDanhSachLLK.ItemsSource = filter.ToList();
            if (txtSearch.Text == null)
                dgDanhSachLLK.ItemsSource = CXuLyLoaiLK.getDanhSachLoaiLK();
        }
        private void refresh()
        {
            txtMaLoai.Text = null;
            txtTenLoai.Text = null;
            txtSearch.Text = null;
            checkIsActive.IsChecked = false;
        }
        private void BtnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            refresh();
            dgDanhSachLLK.SelectedItem = null;
        }
    }
}
