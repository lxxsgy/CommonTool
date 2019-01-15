<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncodeAndDecode.aspx.cs" Inherits="WebApplication2.Encode_Decode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
          <Table ID="Table1" runat="server" Width="390" CellPadding="5" border="1">
           <tr>
               <td width="80">原文内容：</td>
               <td>
                   <asp:TextBox ID="txtSource" runat="server" Height="80" Width="300" TextMode="MultiLine"></asp:TextBox>
                   <asp:TextBox ID="txtEncodeKey" runat="server"></asp:TextBox>(秘钥)
               </td>
           </tr>
           <tr>
               <td>解密结果:</td>

              <td>
                   <asp:TextBox ID="txtDecode" runat="server" Height="80" Width="300" TextMode="MultiLine"></asp:TextBox>
              </td>
           </tr>
          </Table>

          <div>
          <asp:Button  ID="btnEncode" runat="server" Text="加密" OnClick="btnEncode_Click"/>
         <asp:Button  ID="btnDecode" runat="server" Text="解密" OnClick="btnDecode_Click"/>
          </div>
    </form>
   
</body>
</html>
