using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K194060852_ThiCuoiKy
{
    public class PhongVienAnh:NhanVien
    {
        public int SoAnh { get; set; }
        public override double ThucLanh
        {
            get
            {
                return 8000000 + 200000 * SoAnh;
            }
            
        }
    }
}
