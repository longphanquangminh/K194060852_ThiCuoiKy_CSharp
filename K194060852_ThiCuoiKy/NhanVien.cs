using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K194060852_ThiCuoiKy
{
    
    [Serializable]
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgayVaoLam { get; set; }
        
        public bool ToMau1
        {
            get
            {
                
                if ((DateTime.Now.Day - NgayVaoLam.Day)/365>=3)
                    return true;
                else
                    return false;

            }
        }
        public bool ToMau2
        {
            get
            {
                
                if ((DateTime.Now.Day - NgayVaoLam.Day) / 365 >= 5)
                    return true;
                else
                    return false;

            }
        }
        public bool ToMau3
        {
            get
            {
                if((DateTime.Now.Day - NgayVaoLam.Day) / 365 >= 7)
                    return true;
                else
                    return false;
                
            }
        }
        public NhanVien(string manv, string hoten, string gioitinh, string sodienthoai, DateTime ngayvaolam)//, string loaiNV)
        {
            this.MaNV = manv;
            this.HoTen = hoten;
            this.GioiTinh = gioitinh;
            this.SoDienThoai = sodienthoai;
            this.NgayVaoLam = ngayvaolam;
            //this.LoaiNV = loaiNV;

        }
        public NhanVien() { }
        public virtual double ThucLanh
        {
            get;
        }
        public class SapXep : IComparer<NhanVien>
        {
            public int Compare(NhanVien x, NhanVien y)
            {
                if (x.NgayVaoLam.CompareTo(y.NgayVaoLam) != 0)
                {
                    return x.NgayVaoLam.CompareTo(y.NgayVaoLam);
                }
                else
                {
                    return x.HoTen.CompareTo(y.HoTen);
                }
            }
        }
    }
}
