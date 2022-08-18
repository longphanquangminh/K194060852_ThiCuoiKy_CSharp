using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K194060852_ThiCuoiKy
{
    public class PhongVienThuongTru:NhanVien
    {
        public override double ThucLanh
        {
            get
            {
                if ((DateTime.Now.Day - NgayVaoLam.Day) / 365 >= 7)
                {
                    return 12000000 + (12000000 * 0.3);
                }
                else if ((DateTime.Now.Day - NgayVaoLam.Day) / 365 >= 5)
                {
                    return 12000000 + (12000000 * 0.2);
                }
                else if ((DateTime.Now.Day - NgayVaoLam.Day) / 365 >= 3)
                {
                    return 12000000 + (12000000 * 0.15);
                }
                else
                {
                    return 12000000;
                }
            }
        }
    }
}
