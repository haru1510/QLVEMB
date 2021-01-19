using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CuoiKy
{
    public partial class chuyenbayAD : System.Web.UI.Page
    {
        VemayBayDataContext dc = new VemayBayDataContext();

       
        public void loadtenmaybay()
        {
            var c = from tmb in dc.MAYBAYs
                    select tmb;
            drtenmaybay.DataSource = c;
            drtenmaybay.DataTextField = "TenMayBay";
            drtenmaybay.DataValueField = "MaMayBay";
            drtenmaybay.DataBind();
        }
        public void loaddiemxp()
        {
            var c = from nxp in dc.DIEMDAUs
                    select nxp;
            dropnoixuatphat.DataSource = c;
            dropnoixuatphat.DataTextField = "TenD";
            dropnoixuatphat.DataValueField = "MaDau";
            dropnoixuatphat.DataBind();
        }
        public void loadnoiden()
        {
            var c = from nxp in dc.DIEMCUOIs
                    select nxp;
            dropnoiden.DataSource = c;
            dropnoiden.DataTextField = "TenC";
            dropnoiden.DataValueField = "MaCuoi";
            dropnoiden.DataBind();
        }
        public void loaddatachuyenbay()
        {
            var q = from cb in dc.CHUYENBAYs 
                    join ddc in dc.DIEMDAUs on cb.MaDau equals ddc.MaDau
                    join ddd in dc.DIEMCUOIs on cb.MaCuoi equals ddd.MaCuoi
                    join mb in dc.MAYBAYs on cb.MaMayBay equals mb.MaMayBay
                    select new {
                        cb.MaChuyenBay,mb.TenMayBay,ddc.TenD, ddd.TenC, cb.NgayDi,cb.NgayDen,cb.GioBay,cb.GioDen,cb.GhiChu
                    };
            grv.DataSource = q;
            grv.DataBind();
        }
        protected string tdate1 { get; set; }
        protected string tdate2 { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loaddatachuyenbay();
                loadtenmaybay();
                loaddiemxp();
                loadnoiden();
            }
        }
        private void showMessage(string mess)
        {
            string strBuilder = "<script language='javascript'>alert('" + mess + "')</script>";
            Response.Write(strBuilder);
        }
        protected void btnthem_Click(object sender, EventArgs e)
        {
            if (dropnoiden.SelectedValue.ToString().Equals(dropnoixuatphat.SelectedValue.ToString())){
                showMessage("Nơi đến trùng với nơi xuất phát");
            }
            else
            {
                CHUYENBAY cb = new CHUYENBAY();
                cb.MaMayBay = Int32.Parse(drtenmaybay.SelectedValue);
                cb.MaDau = dropnoixuatphat.SelectedValue;
                cb.MaCuoi = dropnoiden.SelectedValue;
                cb.NgayDi = Request.Form["datepick1"];
                cb.NgayDen = Request.Form["datepick2"];
                cb.GioBay = txtgiobay.Text;
                cb.GioDen = txtgioden.Text;
                cb.GhiChu = txtghichu.Text;

                dc.CHUYENBAYs.InsertOnSubmit(cb);
                xoatrang();
                dc.SubmitChanges();
                Page.DataBind();
                loaddatachuyenbay();
                showMessage("Đã thêm thông tin máy bay");
            }
        }

        protected void grv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                drtenmaybay.Items.Clear();
                dropnoixuatphat.Items.Clear();
                dropnoiden.Items.Clear();
                txtmachuyenbay.Text = HttpUtility.HtmlDecode(grv.SelectedRow.Cells[1].Text).ToString();
                drtenmaybay.Items.Add(grv.SelectedRow.Cells[2].Text);
                dropnoixuatphat.Items.Add(HttpUtility.HtmlDecode(grv.SelectedRow.Cells[3].Text).ToString());
                dropnoiden.Items.Add(HttpUtility.HtmlDecode(grv.SelectedRow.Cells[4].Text).ToString()); 
                this.tdate1 = HttpUtility.HtmlDecode(grv.SelectedRow.Cells[5].Text).ToString();
                this.tdate2 = HttpUtility.HtmlDecode(grv.SelectedRow.Cells[6].Text).ToString();
                txtgiobay.Text = HttpUtility.HtmlDecode(grv.SelectedRow.Cells[7].Text).ToString();
                txtgioden.Text = HttpUtility.HtmlDecode(grv.SelectedRow.Cells[8].Text).ToString();
                txtghichu.Text = HttpUtility.HtmlDecode(grv.SelectedRow.Cells[9].Text).ToString();
            }
            catch (Exception)
            {
              
            }
        }
        public void xoatrang()
        {
            txtmachuyenbay.Text = "";
            this.tdate1 = "";
            this.tdate2 = "";
            txtgiobay.Text = "";
            txtgioden.Text = "";
            txtghichu.Text = "";
            txttim.Text = "";
            loadtenmaybay();
            loadnoiden();
            loaddiemxp();
        }
        protected void btnlt_Click(object sender, EventArgs e)
        {

            xoatrang();
            loaddatachuyenbay();
        }
        protected void btnxoa_Click(object sender, EventArgs e)
        {            var q = from x in dc.CHUYENBAYs
                    where x.MaChuyenBay == Int32.Parse(txtmachuyenbay.Text)
                    select x;
            foreach (var x in q)
            {
                dc.CHUYENBAYs.DeleteOnSubmit(x);
            }
            dc.SubmitChanges();
            loaddatachuyenbay();
            Page.DataBind();
            xoatrang();
        }

        protected void btncapnhat_Click(object sender, EventArgs e)
        {
            var q = from x in dc.CHUYENBAYs
                    where x.MaChuyenBay == Int32.Parse(txtmachuyenbay.Text)
                    select x;
            foreach (var us in q)
            {
                us.NgayDi = Request.Form["datepick1"];
                us.NgayDen = Request.Form["datepick2"];
                us.GioBay = txtgiobay.Text;
                us.GioDen = txtgioden.Text;
                us.GhiChu = txtghichu.Text;

                dc.SubmitChanges();
            }
           loaddatachuyenbay();
            Page.DataBind();
            showMessage("Đã cập nhật Thông tin chuyến bay");
        }

        protected void tbntim_Click(object sender, EventArgs e)
        {
            var q = from tim in dc.CHUYENBAYs
                    join dau in dc.DIEMDAUs on tim.MaDau equals dau.MaDau
                    join cuoi in dc.DIEMCUOIs on tim.MaCuoi equals cuoi.MaCuoi
                    join ten in dc.MAYBAYs on tim.MaMayBay equals ten.MaMayBay
                    where dau.TenD.EndsWith(txttim.Text)
                    || cuoi.TenC.EndsWith(txttim.Text)
                    || tim.NgayDi.EndsWith(txttim.Text)
                    ||tim.NgayDen.EndsWith(txttim.Text)
                    select new
                    {
                        tim.MaChuyenBay,
                        ten.TenMayBay,
                        dau.TenD,
                        cuoi.TenC,
                        tim.NgayDi,
                        tim.NgayDen,
                        tim.GioBay,
                        tim.GioDen,
                        tim.GhiChu
                    };

            grv.DataSource = q;
            grv.DataBind();        }
    }
}