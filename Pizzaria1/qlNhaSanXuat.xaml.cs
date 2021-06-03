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
    /// Interaction logic for qlNhaSanXuat.xaml
    /// </summary>
    public partial class qlNhaSanXuat : UserControl
    {
        public qlNhaSanXuat()
        {
            InitializeComponent();
            hienthi();
        }
        private void hienthi()
        {
            List<CNhaSX> dsNhaSX = CXuLyNhaSX.getDSNhaSanXuat();
            if (dsNhaSX == null)
            {
                MessageBox.Show("Lỗi kết nối CSDL");
            }
            else
            {
                dgNhaSanXuat.ItemsSource = dsNhaSX;
            }
        }
        private void BtnThemNSX_Click(object sender, RoutedEventArgs e)
        {
            CNhaSX a = dgNhaSanXuat.SelectedItem as CNhaSX;
            if(a==null)
            {
                MessageBox.Show("Vui lòng chọn nhà sản xuất muốn sửa");
            }
            else {

                if (txtMaNSX.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mã nhà sản xuất!");
                    txtMaNSX.Focus();
                }
                else if (txtTenNSX.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập tên nhà sản xuất!");
                    txtTenNSX.Focus();
                }
                else if (txtMaNSX.Text != a.MaNhaSX)
                {
                    MessageBox.Show("Không được sửa mã nhà sản xuất");
                    txtMaNSX.Text = a.MaNhaSX;
                }
                else
                {
                    CNhaSX nsx = new CNhaSX();
                    nsx.MaNhaSX = txtMaNSX.Text;
                    nsx.TenNhaSX = txtTenNSX.Text;
                    if (checkActive.IsChecked == true)
                        nsx.status = true;
                    else nsx.status = false;
                    bool kq = CXuLyNhaSX.themNhaSanXuat(nsx);
                    if (kq == true)
                    {
                        MessageBox.Show("Thêm nhà sản xuất thành công");
                        refresh();
                        dgNhaSanXuat.ItemsSource = CXuLyNhaSX.getDSNhaSanXuat();
                    }
                    else
                        MessageBox.Show("Thêm nhà sản xuất thất bại");
                }
            }
        }
        private void BtnXoa_Click(object sender, RoutedEventArgs e)
        {
            if(dgNhaSanXuat.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn nhà sản xuất muốn xóa!!");
            }
            else
            {
                CNhaSX nsxSelect = dgNhaSanXuat.SelectedItem as CNhaSX;
                bool kq = CXuLyNhaSX.xoaNhaSanXuat(nsxSelect.MaNhaSX);
                if (kq == true)
                {
                    MessageBox.Show("Xóa nhà sản xuất thành công");
                    refresh();
                    dgNhaSanXuat.ItemsSource = CXuLyNhaSX.getDSNhaSanXuat();
                }
                else
                    MessageBox.Show("Không thể xóa nhà sản xuất này!");
            }
        }
        private void DgNhaSanXuat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CNhaSX nhaSX = dgNhaSanXuat.SelectedItem as CNhaSX;
            if (nhaSX != null)
            {
                txtMaNSX.Text = nhaSX.MaNhaSX;
                txtTenNSX.Text = nhaSX.TenNhaSX;
                if (nhaSX.status == true)
                    checkActive.IsChecked = true;
                else checkActive.IsChecked = false;
            }
        }

        private void BtnSuaNSX_Click(object sender, RoutedEventArgs e)
        {
            CNhaSX nsxSelected = dgNhaSanXuat.SelectedItem as CNhaSX;
            if(nsxSelected == null)
            {
                MessageBox.Show("Vui lòng chọn nhà sản xuất cần sửa!!");
            }
            else
            {
                if (txtMaNSX.Text == "")
                {
                    MessageBox.Show("Mã nhà sản xuất không được để trống!!");
                    txtMaNSX.Focus();
                }
                else if (txtTenNSX.Text == "")
                {
                    MessageBox.Show("Tên nhà sản xuất không được để trống!!");
                    txtMaNSX.Focus();
                }
                else if (txtMaNSX.Text != nsxSelected.MaNhaSX)
                {
                    MessageBox.Show("Không được sửa mã nhà sản xuất", "Thông báo");
                    txtMaNSX.Text = nsxSelected.MaNhaSX;
                    return;
                }
                else
                {
                    CNhaSX nsx = new CNhaSX();
                    nsx.MaNhaSX = txtMaNSX.Text;
                    nsx.TenNhaSX = txtTenNSX.Text;
                    if (checkActive.IsChecked == true)
                        nsx.status = true;
                    else nsx.status = false;
                    bool kq = CXuLyNhaSX.suaNhaSanXuat(nsx);
                    if (kq == true)
                    {
                        MessageBox.Show("Sửa nhà sản xuất thành công");
                        refresh();
                        dgNhaSanXuat.ItemsSource = CXuLyNhaSX.getDSNhaSanXuat();
                    }
                    else
                        MessageBox.Show("Sửa nhà sản xuất thất bại");
                }
            }
        }
        private void TxtSearchNSX_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<CNhaSX> dsNhaSX = CXuLyNhaSX.getDSNhaSanXuat();
            List<CNhaSX> filter = new List<CNhaSX>();
            foreach (CNhaSX nsx in dsNhaSX)
            {
                if (nsx.MaNhaSX.ToUpper().Contains(txtSearchNSX.Text.ToUpper()))
                {
                    filter.Add(nsx);
                }
            }
            dgNhaSanXuat.ItemsSource = filter.ToList();
            if (txtSearchNSX.Text == null)
                dgNhaSanXuat.ItemsSource = CXuLyNhaSX.getDSNhaSanXuat();
        }
        private void refresh()
        {
            txtMaNSX.Text = null;
            txtSearchNSX.Text = null;
            txtTenNSX.Text = null;
        }
        private void BtnLamMoi_Click(object sender, RoutedEventArgs e)
        {
            refresh();
            dgNhaSanXuat.SelectedItem = null;
        }
    }
}
