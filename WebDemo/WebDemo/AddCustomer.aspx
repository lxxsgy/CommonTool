<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCustomer.aspx.cs" Inherits="WebDemo.AddCustomer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>会员添加页面</title>
</head>
<body>
    <form id="form1" runat="server">
        
   <%-- <div>
        <table>
            <thead>
                <tr><td  colspan="2">添加会员</td></tr>
            </thead>
            <tbody>

                <tr>
                    <td>会员编号</td>
                    <td>
                        <asp:TextBox ID="txtNumber" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>会员姓名:</td>
                    <td>
                        <asp:TextBox ID="TxtFullName" runat="server"></asp:TextBox>
                    </td>
                     </tr>
               

                <tr>
                    <td>证件类型:</td>
                    <td>
                         <asp:DropDownList ID="ddlCertificateType" runat="server">
                        <asp:ListItem>身份证</asp:ListItem>
                         <asp:ListItem>军官证</asp:ListItem>
                         <asp:ListItem>护照</asp:ListItem>
                    </asp:DropDownList>
                    </td>
                  
                </tr>
                <tr>
                    <td>证件号码:</td> 
                    <td>
                    <asp:TextBox ID="txtIDNumner" runat="server"  MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>生日:</td>
                    <td>
                    <asp:TextBox ID="TextBirthDay" runat="server"></asp:TextBox> 格式：yyyy-mm-dd:如2012-12-1
                    </td>
                </tr>
                <tr>
                    <td>籍贯:</td>
                    <td>
                    <asp:TextBox ID="TxtNativePlace" runat="server"  MaxLength="20"></asp:TextBox> 
                    </td>
                </tr>
                  <tr>
                    <td>工作单位:</td>
                    <td>
                    <asp:TextBox ID="TxtworkUnit" runat="server"></asp:TextBox> 
                    </td>
                </tr>
            </tbody>
        </table>
      
    
    </div>--%>
        <table cellspacing="1"  cellPadding="3">
           <thead>
              <tr>
                  <td  colspan="2" align="center">添加房间</td>
              </tr>
           </thead>
            <tbody>
                <tr>
                    <td class="td_left">房间编号:</td>
                    <td>
                    <asp:TextBox ID="txtNumber" runat="server"  MaxLength="5"></asp:TextBox>

                    </td>
                </tr>
                  <tr>
                    <td class="td_left">价格:</td>
                      <td>
                    <asp:TextBox ID="TxtPrice" runat="server"  MaxLength="10"></asp:TextBox>
                      </td>
                </tr>
                 <tr>
                    <td class="td_left">房间分类:</td>
                     <td>
                     <asp:DropDownList ID="ddlRoomClass" runat="server">
                          <asp:ListItem>普通单人间</asp:ListItem>
                          <asp:ListItem>普通双人间</asp:ListItem>
                          <asp:ListItem>普通海景房</asp:ListItem>
                          <asp:ListItem>高级海景房</asp:ListItem>
                          <asp:ListItem>豪华海景房</asp:ListItem>
                          <asp:ListItem>豪华海景套房</asp:ListItem>
                     </asp:DropDownList>

                     </td>
                </tr>
                 <tr>
                    <td class="td_left">房间状态:</td>
                     <td>
                     <asp:DropDownList ID="ddlStatus" runat="server">
                          <asp:ListItem>正常</asp:ListItem>
                          <asp:ListItem>使用</asp:ListItem>
                          <asp:ListItem>清洁</asp:ListItem>
                          <asp:ListItem>预定</asp:ListItem>
                          <asp:ListItem>锁定</asp:ListItem>
                          <asp:ListItem>维修</asp:ListItem>
                     </asp:DropDownList>
                     </td>
                </tr>
                <tr>
                    <td  colspan="2" align="center">
                        <asp:Button ID="btnSave" runat="server" Text="保存"  OnClick="btn_Save_Click" />
                    </td>
                </tr>
                <tr>
                    <asp:Label ID="LabelMessage" runat="server"></asp:Label>  
                </tr>

            </tbody>

        </table>

    </form>
</body>
</html>
