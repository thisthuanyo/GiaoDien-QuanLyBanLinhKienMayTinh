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
    /// Interaction logic for qlPhieuXuat.xaml
    /// </summary>
    public partial class qlPhieuXuat : UserControl
    {
        private CPhieuXuat pxTemp = new CPhieuXuat
        {
            MaPX = 0,
            NgayXuat = DateTime.Now,
            MaKH = "",
            MaNV = "",
            status = true,
            TongTien = 0,
            ChiTietPhieuXuats = new List<CChiTietPhieuXuat>()
        };
        public qlPhieuXuat()
        {
            InitializeComponent();
            hienthi();
            List<CLinhKien> ds = CXuLiLinhKien.getDanhSachLinhKien();
            if (ds == null) MessageBox.Show("Lỗi kết nối Server!!");
            else cmbMahang.ItemsSource = ds;
        }
        private void hienthi()
        {
            List<CPhieuXuat> dsPhieuXuat = CXuLyPhieuXuat.getDSPhieuXuat();      
            dgDSPhieuXuat.ItemsSource = dsPhieuXuat;
        }

        private void BtnChon_Click(object sender, RoutedEventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(txtSoluong.Text, out n);
            var item = cmbMahang.SelectedItem;
            if (item == null)
                MessageBox.Show("Vui lòng chọn linh kiện!");
            else if (txtSoluong.Text == "")
                MessageBox.Show("Vui lòng nhập số lượng!");
            else if (isNumeric == false)
            {
                MessageBox.Show("Số lượng phải là số!");
            }
            else
            {
                CChiTietPhieuXuat ct = new CChiTietPhieuXuat();
                CLinhKien lk = cmbMahang.SelectedItem as CLinhKien;
                if (lk == null) return;
                else
                {
                    bool flag = false;
                    foreach (CChiTietPhieuXuat t in pxTemp.ChiTietPhieuXuats)
                    {
                        if (t.MaLK == lk.MaLK)
                        {
                            flag = true;
                            int s = int.Parse(txtSoluong.Text) + (int)t.SoLuong;
                            if (s == 0)
                            {
                                pxTemp.ChiTietPhieuXuats.Remove(t);
                                dgChitiet.ItemsSource = CXuLyPhieuXuat.getDSChiTietPhieuXuat(pxTemp);
                                txtThanhtien.Text = CXuLyPhieuXuat.getThanhTienPhieuXuat(pxTemp).ToString();
                                break;
                            }
                            else if (s < 0)
                            {
                                MessageBox.Show("Số lượng không hợp lệ!!");
                                break;
                            }
                            else
                            {
                                t.SoLuong = s;
                                dgChitiet.ItemsSource = CXuLyPhieuXuat.getDSChiTietPhieuXuat(pxTemp);
                                txtThanhtien.Text = CXuLyPhieuXuat.getThanhTienPhieuXuat(pxTemp).ToString();
                                break;
                            }
                        }
                    }
                    if (flag == false)
                    {
                        if (int.Parse(txtSoluong.Text) <= 0)
                            MessageBox.Show("Số lượng không hợp lệ!!");
                        else
                        {
                            ct.LinhKien = lk;
                            ct.MaLK = lk.MaLK;
                            ct.SoLuong = int.Parse(txtSoluong.Text);
                            ct.DonGia = lk.GiaBan;
                            pxTemp.ChiTietPhieuXuats.Add(ct);
                            dgChitiet.ItemsSource = CXuLyPhieuXuat.getDSChiTietPhieuXuat(pxTemp);
                            txtThanhtien.Text = CXuLyPhieuXuat.getThanhTienPhieuXuat(pxTemp).ToString();
                        }
                    }
                }
            }
        }
    }
}
