<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteCustom.aspx.cs" Inherits="WebDemo.DeleteCustom" %>

<%@ Register src="WebUserControl1.ascx" tagname="WebUserControl1" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <uc1:WebUserControl1 ID="WebUserControl11" runat="server" />
    </form>
  
</body>
</html>
