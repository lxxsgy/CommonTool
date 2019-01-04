
<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Login.aspx.cs" Inherits="WebDemo.Login" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Access-Control-Allow-Origin" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="">
        用户名：
        <asp:TextBox ID="TextBoxUsername" runat="server" name="username"></asp:TextBox>
    </div>
        <div class="">
              密 码：
            <asp:TextBox ID="TextBoxpwd" runat="server" CssClass ="input" TextMode="Password"></asp:TextBox>
    </div>
       <div>
           验证码:
            <asp:TextBox ID="CheckCode" runat="server"></asp:TextBox>
           <img  style="border:1px solid black" title="看不清，双击图片换一张。"  src="checkimage.aspx" ondblclick="this.src='checkimage.aspx?flag='+Math.random()"/>(区分大小写)
       </div>
        <div class="">
            <asp:Button ID="Button1" runat="server" Text="登录" OnClick="btn_Click" />

    </div>
    </form>
</body>
</html>
