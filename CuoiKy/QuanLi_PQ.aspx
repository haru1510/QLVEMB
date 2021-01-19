﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuanLi_PQ.aspx.cs" Inherits="CuoiKy.QuanLi_PQ" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chọn trang</title>
    <link rel="stylesheet" href="Style/stylePQ.css" />
    <link href='https://fonts.googleapis.com/css?family=Quicksand' rel='stylesheet' />
</head>
<body>
    <form id="form1" runat="server">
        <div class="multi-button">
            <asp:Button CssClass="button" ID="btnQuanLi" runat="server" Text="Trang quản lí" OnClick="btnQuanLi_Click" style="left: 0px; top: 0px" />
            <asp:Button CssClass="button" ID="btnNhanVien" runat="server" Text="Trang nhân viên" OnClick="btnNhanVien_Click" style="left: 0px; top: 0px" />
        </div>
    </form>
</body>
</html>
