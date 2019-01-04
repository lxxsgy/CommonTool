<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="WebDemo.WebUserControl1" %>
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Services>
         <asp:ServiceReference   Path="~/EditCustom.aspx"/>
        </Services>
    </asp:ScriptManagerProxy>
    
<div class="title">
    Member Center | 会员中心
</div>
<a href="#">
    UserName:
     <asp:TextBox ID="TbUserName" runat="server"></asp:TextBox>
     <br />
     PassWord:
      <asp:TextBox ID="TbPassWord" runat="server"></asp:TextBox>
     <br />
    <asp:Button ID="Button1" runat="server" Text="登录"  OnClick="Button1_Click" />
</a>
