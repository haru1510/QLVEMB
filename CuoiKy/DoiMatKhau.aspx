<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoiMatKhau.aspx.cs" Inherits="CuoiKy.DoiMatKhau" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đổi mật khẩu</title>
    <link rel="stylesheet" href="Style/styleDangNhap.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="box">
             <img class="logosize" src="image/logo.png" alt=""/>
             <h1 class="header">Change Password</h1>
             <asp:TextBox class="text" ID="txtTenDN" placeholder="Username" runat="server" required=""></asp:TextBox>
             <asp:TextBox class="text" TextMode="Password" placeholder="Password" ID="txtPassword" runat="server" required=""></asp:TextBox>
             <asp:TextBox class="text" TextMode="Password" placeholder="Confirm password" ID="txtRePass" runat="server" required=""></asp:TextBox>
             <asp:Button class="btn" ID="btnDangNhap" runat="server" Text="Change Password" OnClick="btnDangNhap_Click" />
         </div>
        </div>
    </form>
</body>
</html>
