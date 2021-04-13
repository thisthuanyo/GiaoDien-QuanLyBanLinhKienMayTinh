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
    /// Interaction logic for qlLinhKien.xaml
    /// </summary>
    public partial class qlLinhKien : UserControl
    {
        private List<CLinhKien> temp_lk = new List<CLinhKien>();


        public qlLinhKien()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            HienThi();
        }
        private string randomMaLK()
        {
            Random r = new Random();
            CLoaiLK llk = cmbMaLoai.SelectedItem as CLoaiLK;
            string malk = llk.MaLoai + r.Next(0000, 9999);
            List<CLinhKien> dsLinhKien = CXuLiLinhKien.getDanhSachLinhKien();

            foreach (CLinhKien a in dsLinhKien)
            {
                if(a.MaLK == malk)
                {
                    malk = llk.MaLoai + r.Next(0000, 9999);
                }
            }
            return malk;
        }
        private void HienThi()
        {
            List<CLinhKien> lst = CXuLiLinhKien.getDanhSachLinhKien();
            setNull();
            dgDanhSachLK.ItemsSource = lst;
            temp_lk = lst;
            List<CLoaiLK> dsLLKFilter = new List<CLoaiLK>();
            List<CLoaiLK> dsLoaiLK = CXuLyLoaiLK.getDanhSachLoaiLK();
            foreach(CLoaiLK llk in dsLoaiLK)
            {
                if (llk.status == true)
                    dsLLKFilter.Add(llk);
            }
            cmbMaLoai.ItemsSource = dsLLKFilter;
            List<CNhaSX> dsNhaSXFilter = new List<CNhaSX>();
            List<CNhaSX> dsNhaSX = CXuLyNhaSX.getDSNhaSanXuat();
            foreach (CNhaSX nsx in dsNhaSX)
            {
                if (nsx.status == true)
                    dsNhaSXFilter.Add(nsx);
            }
            cmbHSX.ItemsSource = dsNhaSXFilter;
        }
        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            if (KiemTra() == false) return;
            CLinhKien lk = new CLinhKien();
            lk.MaLK = randomMaLK();
            lk.TenLK = txtTenLinhKien.Text;
            lk.LoaiLK = cmbMaLoai.SelectedItem as CLoaiLK;
            lk.NhaSX = cmbHSX.SelectedItem as CNhaSX;
            lk.MaLoai = lk.LoaiLK.MaLoai;
            lk.MaNSX = lk.NhaSX.MaNhaSX;
            lk.GiaBan = double.Parse(txtGiaBan.Text);
            if (checkActive.IsChecked == true)
                lk.status = true;
            else lk.status = false;
            bool kq = CXuLiLinhKien.themLinhKien(lk);
            if (kq == true)
            {
                MessageBox.Show("Thêm thành công");
                HienThi();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }

        }
        public bool KiemTra()
        {
            
            if (txtTenLinhKien.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên linh kiện");
                txtTenLinhKien.Focus();
                return false;
            }
            if (cmbMaLoai.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng nhập chọn loại linh kiện");
                cmbMaLoai.Focus();
                return false;
            }
            if (cmbHSX.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn nhà sản xuất");
                cmbHSX.Focus();
                return false;
            }
            if (txtGiaBan.Text == "")
            {
                MessageBox.Show("Vui lòng nhập giá bán");
                txtGiaBan.Focus();
                return false;
            }
            else
            {
                double num;
                if (double.TryParse(txtGiaBan.Text, out num) == false)
                {
                    MessageBox.Show("Giá bán là một số");
                    txtGiaBan.Focus();
                    return false;
                }
            }
            return true;
        }
        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            if (dgDanhSachLK.SelectedItem == null) return;
            string malk = dgDanhSachLK.SelectedValue.ToString();
            bool kq = CXuLiLinhKien.xoaLinhKien(malk);
            if (kq == false)
            {
                MessageBox.Show("Xóa thất bại");
            }
            else
            {
                MessageBox.Show("Xóa thành công");
            }
            HienThi();
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
            if(lk.status == true)
            {
                checkActive.IsChecked = true;
            }
            else checkActive.IsChecked = false;
        }
        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (dgDanhSachLK.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa");
                return;
            }
            if (KiemTra() == false) return;
            CLinhKien lk = dgDanhSachLK.SelectedItem as CLinhKien;
            lk.TenLK = txtTenLinhKien.Text;
            lk.NhaSX = cmbHSX.SelectedItem as CNhaSX;
            lk.LoaiLK = cmbMaLoai.SelectedItem as CLoaiLK;
            lk.MaLoai = lk.LoaiLK.MaLoai;
            lk.MaNSX = lk.NhaSX.MaNhaSX;
            if (checkActive.IsChecked == true)
                lk.status = true;
            else lk.status = false;
            lk.GiaBan = lk.GiaBan;
            bool kq = CXuLiLinhKien.suaLinhKien(lk);
            if (kq == true)
                MessageBox.Show("Sửa thành công !!!");
            else
                MessageBox.Show("Sửa thất bại !!!");

            HienThi();
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
    }
}
