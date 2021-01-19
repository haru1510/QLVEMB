using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CuoiKy
{
    public partial class ADThongKeVe : System.Web.UI.Page
    {
        VemayBayDataContext dc = new VemayBayDataContext();
        public void load_gwVeBan()
        {
            var q = from vb in dc.VEBANs
                    join lv in dc.LOAIVEs on vb.MaLoai equals lv.MaLoai
                    join nv in dc.NHANVIENs on vb.MaNhanVien equals nv.MaNhanVien
                    join kh in dc.KHACHHANGs on vb.CMND equals kh.CMND
                    join cb in dc.CHUYENBAYs on vb.MaChuyenBay equals cb.MaChuyenBay
                    join mb in dc.MAYBAYs on cb.MaMayBay equals mb.MaMayBay
                    select new
                    {
                        vb.id,
                        vb.SLVeBan,
                        vb.TongGia,
                        lv.TenLoai,
                        nv.TenNhanVien,
                        kh.TenKhachHang,
                        cb.MaChuyenBay,
                        cb.NgayDen,
                        cb.NgayDi,
                        cb.GhiChu,
                        cb.GioBay,
                        mb.TenMayBay
                    };
            gwVeBan.DataSource = q;
            gwVeBan.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int s1 = dc.VEBANs.Sum(x => x.SLVeBan);
                lbSLV.Text = s1.ToString();
                int s2 = dc.VEBANs.Sum(x => x.TongGia);
                lbTien.Text = s2.ToString("0,0") + " VNĐ";
            }
            catch (Exception)
            {
                lbTien.Text = "0,000 VNĐ";
                lbSLV.Text = "0";
            }
            if (!IsPostBack)
            {
                load_gwVeBan();
            }
        }
    }
}