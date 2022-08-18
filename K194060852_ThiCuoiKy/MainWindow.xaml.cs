using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace K194060852_ThiCuoiKy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<NhanVien> listNV = new List<NhanVien>();
        string fileName = "dulieu.xml";
        public MainWindow()
        {
            InitializeComponent();
            radNam.IsChecked = true;
            radPhongVienThuongTru.IsChecked = true;
            txtMaNV.Focus();
            dtpNgayVaoLam.SelectedDate = DateTime.Now;
            //if (File.Exists(fileName) == false) return;
            //XmlSerializer serializer = new XmlSerializer(typeof(List<NhanVien>));
            //FileStream fs = new FileStream(fileName, FileMode.Open);
            //listNV = (List<NhanVien>)serializer.Deserialize(fs);
            //if (listNV != null)
            //    foreach (NhanVien nv in listNV)
            //        listNV.Add(nv);
            lvDanhSachNhanVien.ItemsSource = listNV;
            lvDanhSachNhanVien.Items.Refresh();
        }
        private void GanDuLieuMacDinh()
        {
            txtMaNV.Clear();
            txtTen.Clear();
            txtDienThoai.Clear();
            txtThayDoi.Clear();
            dtpNgayVaoLam.SelectedDate = DateTime.Now;
            txtMaNV.Focus();
            radNam.IsChecked = true;
            
            radPhongVienThuongTru.IsChecked = true;
            
        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            GanDuLieuMacDinh();
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (txtMaNV.Text == "" || txtDienThoai.Text == "" || txtTen.Text == ""  || dtpNgayVaoLam.Text == "")
            {
                MessageBox.Show("Có lỗi!");
            }
            else
            {
                

                NhanVien nv = null;
                if (radPhongVienThuongTru.IsChecked == true)
                {
                    
                    
                    nv = new PhongVienThuongTru();
                    nv.MaNV = txtMaNV.Text;
                    nv.HoTen = txtTen.Text;
                    nv.SoDienThoai = txtDienThoai.Text;
                    nv.NgayVaoLam = Convert.ToDateTime(dtpNgayVaoLam.SelectedDate);
                    nv.GioiTinh = radNam.IsChecked == true ? "Nam" : "Nữ";
                    
                    listNV.Add(nv); 
                    //XmlSerializer serializer = new XmlSerializer(typeof(List<NhanVien>));
                    //TextWriter writer = new StreamWriter(fileName);
                    //serializer.Serialize(writer, listNV);
                    //writer.Close();
                    lvDanhSachNhanVien.ItemsSource = listNV;
                    lvDanhSachNhanVien.Items.Refresh();
                    //listNV[lvDanhSachNhanVien.SelectedItem] = nv;
                }
                else if(radPhongVienAnh.IsChecked == true)
                {
                    if (txtThayDoi.Text == "")
                    { MessageBox.Show("Có lỗi!"); }
                    else
                    {
                        //int vitri = lvDanhSachNhanVien.SelectedIndex;
                        
                        nv = new PhongVienAnh();
                        nv.MaNV = txtMaNV.Text;
                        nv.HoTen = txtTen.Text;
                        nv.SoDienThoai = txtDienThoai.Text;
                        nv.NgayVaoLam = Convert.ToDateTime(dtpNgayVaoLam.SelectedDate);
                        nv.GioiTinh = radNam.IsChecked == true ? "Nam" : "Nữ";
                        (nv as PhongVienAnh).SoAnh = Convert.ToInt32(txtThayDoi.Text);
                        listNV.Add(nv); //listNV[vitri] = nv;
                        //XmlSerializer serializer = new XmlSerializer(typeof(List<NhanVien>));
                        //TextWriter writer = new StreamWriter(fileName);
                        //serializer.Serialize(writer, listNV);
                        //writer.Close();
                        lvDanhSachNhanVien.ItemsSource = listNV;
                        lvDanhSachNhanVien.Items.Refresh();
                    }
                    
                }
                else
                {
                    if (txtThayDoi.Text == "")
                    { MessageBox.Show("Có lỗi!"); }
                    else
                    {
                        //int vitri = lvDanhSachNhanVien.SelectedIndex;
                        
                        nv = new BienTapVien();
                        nv.MaNV = txtMaNV.Text;
                        nv.HoTen = txtTen.Text;
                        nv.SoDienThoai = txtDienThoai.Text;
                        nv.NgayVaoLam = Convert.ToDateTime(dtpNgayVaoLam.SelectedDate);
                        nv.GioiTinh = radNam.IsChecked == true ? "Nam" : "Nữ";
                        (nv as BienTapVien).SoGioLamThem = Convert.ToInt32(txtThayDoi.Text);
                        listNV.Add(nv);
                        //listNV[vitri] = nv;
                        //XmlSerializer serializer = new XmlSerializer(typeof(List<NhanVien>));
                        //TextWriter writer = new StreamWriter(fileName);
                        //serializer.Serialize(writer, listNV);
                        //writer.Close();
                        lvDanhSachNhanVien.ItemsSource = listNV;
                        lvDanhSachNhanVien.Items.Refresh();
                    }
                    
                }
                
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            int vt = lvDanhSachNhanVien.SelectedIndex;
            if (vt == -1)
            {
                MessageBox.Show("Bạn chưa chọn gì để xóa!");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Bạn muốn xóa nhân viên này ?", "Xác nhận thoát", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
                return;
            listNV.RemoveAt(vt);

            //XmlSerializer serializer = new XmlSerializer(typeof(List<NhanVien>));
            //TextWriter writer = new StreamWriter(fileName);
            //serializer.Serialize(writer, listNV);
            //writer.Close();

            lvDanhSachNhanVien.ItemsSource = listNV;
            lvDanhSachNhanVien.Items.Refresh();
            lvDanhSachNhanVien.SelectedIndex = vt;

            if (lvDanhSachNhanVien.Items.Count == 0)
            {
                GanDuLieuMacDinh();
            }
        }

        private void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if (txtMaNV.Text == "" || txtDienThoai.Text == "" || txtTen.Text == "" || dtpNgayVaoLam.Text == "")
            {
                MessageBox.Show("Có lỗi!");
            }
            else
            {
                int vitri = lvDanhSachNhanVien.SelectedIndex;
                if (vitri == -1)
                    return;
                NhanVien nv = null;
                if (radPhongVienThuongTru.IsChecked == true)
                {
                    nv = new PhongVienThuongTru();


                }
                else if (radPhongVienAnh.IsChecked == true)
                {
                    if (txtThayDoi.Text == "")
                    {
                        MessageBox.Show("Lỗi rồi bạn êii!");
                    }
                    else
                    {
                        nv = new PhongVienAnh();
                        (nv as PhongVienAnh).SoAnh = Convert.ToInt32(txtThayDoi.Text);
                    }
                    
                }
                else
                {
                    if (txtThayDoi.Text == "")
                    {
                        MessageBox.Show("Lỗi rồi bạn êii!");
                    }
                    else
                    {
                        nv = new BienTapVien();
                        (nv as BienTapVien).SoGioLamThem = Convert.ToInt32(txtThayDoi.Text);
                    }
                }
                nv.MaNV = txtMaNV.Text;
                nv.HoTen = txtTen.Text;
                nv.SoDienThoai = txtDienThoai.Text;
                nv.NgayVaoLam = Convert.ToDateTime(dtpNgayVaoLam.SelectedDate);
                nv.GioiTinh = radNam.IsChecked == true ? "Nam" : "Nữ";
                listNV[vitri] = nv;


                //XmlSerializer serializer = new XmlSerializer(typeof(List<NhanVien>));
                //TextWriter writer = new StreamWriter(fileName);
                //serializer.Serialize(writer, listNV);
                //writer.Close();

                lvDanhSachNhanVien.ItemsSource = listNV;
                lvDanhSachNhanVien.Items.Refresh();
                lvDanhSachNhanVien.SelectedIndex = vitri;
            }
        }
        private void btnSapXep_Click(object sender, RoutedEventArgs e)
        {
            listNV.Sort(new NhanVien.SapXep());
            //GhiDuLieu(); //ko cần thiết phải sắp xếp trong dữ liệu luôn
            lvDanhSachNhanVien.ItemsSource = listNV;
            lvDanhSachNhanVien.Items.Refresh();
        }

        private void btnThongKe_Click(object sender, RoutedEventArgs e)
        {
            int tongPhongVienThuongTru = 0, tongPhongVienAnh = 0, tongBienTapVien = 0;
            double tongLuongPhongVienThuongTru = 0, tongLuongPhongVienAnh = 0, tongLuongBienTapVien = 0;
            foreach (NhanVien p in listNV)
            {
                if (p is PhongVienThuongTru)
                {
                    tongPhongVienThuongTru++;

                    tongLuongPhongVienThuongTru += ((PhongVienThuongTru)p).ThucLanh;
                }
                else if (p is PhongVienAnh)
                {
                    tongPhongVienAnh++;
                    tongLuongPhongVienAnh += ((PhongVienAnh)p).ThucLanh;
                }
                else
                {
                    tongBienTapVien++;
                    tongLuongBienTapVien += ((BienTapVien)p).ThucLanh;
                }

            }
            MessageBox.Show("Có " + tongPhongVienThuongTru + " PV thường trú" + "\n" + "Có " + tongPhongVienAnh + " PV ảnh"+"\n"+"Có "+ tongBienTapVien + "BTV"
                    + "\n" + "Tổng lương các PV thường trú: " + tongLuongPhongVienThuongTru.ToString("#,##0 đ")
                    + "\n" + "Tổng lương các PV ảnh: " + tongLuongPhongVienAnh.ToString("#,##0 đ")
            + "\n" + "Tổng lương các BTV: " + tongLuongBienTapVien.ToString("#,##0 đ"));
            
        }

        private void lvDanhSachNhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvDanhSachNhanVien.SelectedIndex == -1)
                return;
            NhanVien data = lvDanhSachNhanVien.Items[lvDanhSachNhanVien.SelectedIndex] as NhanVien;


            if (lvDanhSachNhanVien.Items[lvDanhSachNhanVien.SelectedIndex] is PhongVienThuongTru)
            {

                radPhongVienThuongTru.IsChecked = true;


                


            }
            else if (lvDanhSachNhanVien.Items[lvDanhSachNhanVien.SelectedIndex] is PhongVienAnh)
            {
                radPhongVienAnh.IsChecked = true;

                txtThayDoi.Text = (data as PhongVienAnh).SoAnh.ToString();
            }
            else
            {
                radBTV.IsChecked = true;

                txtThayDoi.Text = (data as BienTapVien).SoGioLamThem.ToString();

            }
            txtMaNV.Text = data.MaNV;
            txtTen.Text = data.HoTen;
            txtDienThoai.Text = data.SoDienThoai;
            if (data.GioiTinh == "Nam")
            {
                radNam.IsChecked = true;
            }
            else if (data.GioiTinh == "Nữ")
            {
                radNu.IsChecked = true;
            }
            dtpNgayVaoLam.SelectedDate = data.NgayVaoLam;
        }

        private void radPhongVienThuongTru_Checked(object sender, RoutedEventArgs e)
        {
            lblThayDoi.Opacity = 0; 
            txtThayDoi.Opacity = 0;
            lblThayDoi.Content = "";
            txtThayDoi.IsEnabled = false;
        }

        private void radPhongVienAnh_Checked(object sender, RoutedEventArgs e)
        {
            txtThayDoi.IsEnabled = true;
            lblThayDoi.Opacity = 1;
            txtThayDoi.Opacity = 1;
            lblThayDoi.Content = "Số ảnh: ";
        }

        private void radBTV_Checked(object sender, RoutedEventArgs e)
        {
            txtThayDoi.IsEnabled = true;
            lblThayDoi.Opacity = 1;
            txtThayDoi.Opacity = 1;
            lblThayDoi.Content = "Số giờ làm thêm: ";
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn muốn đóng chương trình?", "Xác nhận thoát", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.No || result == MessageBoxResult.Cancel)
            {
                e.Cancel = true;

            }
        }
    }
}
