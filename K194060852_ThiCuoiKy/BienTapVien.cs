using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K194060852_ThiCuoiKy
{
    public class BienTapVien:NhanVien
    {
        public int SoGioLamThem { get; set; }
        public override double ThucLanh
        {
            get
            {
                return 12000000 + (160000 * SoGioLamThem);
            }
        }
    }
}
