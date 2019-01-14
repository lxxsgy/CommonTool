<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebApplication2.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>demo</title>
   
</head>
<body>
   
   <%-- <form id="form1" runat="server">
   <asp:FileUpload ID="FileUpload1" runat="server"  Width="300px" />
    <asp:Button ID="btnupload" runat="server" Text="开始上传"  OnClick="btnupload_Click"/>

    <asp:Label ID="lmsg"  runat="server" style=""></asp:Label><br />

    <asp:Label ID="lpathinfo" runat="server"></asp:Label>
  </form>--%>
    

  <form id="form2" runat="server">
  <asp:FileUpload ID="FileUpload1" runat="server" />
  <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="上传文件" />
  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
  <Columns>
  <asp:HyperLinkField DataNavigateUrlFields="FileId" DataTextField="Title" DataNavigateUrlFormatString="~/download.aspx?FileId={0}"/>  
  </Columns>
  </asp:GridView>
  </form>
   
</body>
</html>
