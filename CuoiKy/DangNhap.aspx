<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="CuoiKy.DangNhap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập</title>
    <link rel="stylesheet" href="Style/styleDangNhap.css"/>
</head>
<body>
    <form id="form1" runat="server">
         <div class="box">
             <img class="logosize" src="image/logo.png" alt=""/>
             <h1 class="header">Login</h1>
             <asp:TextBox class="text" ID="txtTenDN" placeholder="Username" runat="server" required=""></asp:TextBox>
             <asp:TextBox class="text" TextMode="Password" placeholder="Password" ID="txtPassword" runat="server" required=""></asp:TextBox>
             <asp:Button class="btn" ID="btnDangNhap" runat="server" Text="Login" OnClick="btnDangNhap_Click" />
         </div>
    </form>
</body>
</html>
