﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CuoiKy
{
    public partial class DoiMatKhau : System.Web.UI.Page
    {
        VemayBayDataContext dc = new VemayBayDataContext();
        public void showMessage(string mess)
        {
            string strBuilder = "<script language='javascript'>alert('" + mess + "')</script>";
            Response.Write(strBuilder);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtTenDN.Text = Session["username"].ToString();
        }

        protected void btnDangNhap_Click(object sender, EventArgs e)
        {
            var q = from nv in dc.NHANVIENs
                    where nv.TenDangNhap == Session["username"].ToString()
                    select nv;
            foreach(var nv in q)
            {
                if(txtRePass.Text != txtPassword.Text)
                {
                    showMessage("Mật khẩu nhập lại không khớp.");
                }
                else
                {
                    if (txtPassword.Text == nv.MatKhau)
                    {
                        showMessage("Bạn đã nhập mật khẩu cũ.");
                    }
                    else
                    {
                        nv.MatKhau = txtPassword.Text;
                        dc.SubmitChanges();
                        Response.Redirect("DangNhap.aspx");
                    }
                }
            }
        }
    }
}