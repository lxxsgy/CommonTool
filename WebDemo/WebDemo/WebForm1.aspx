<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebDemo.WebForm1"   %>


<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
         
</head>
<body>
    主机名：   
    <asp:Label ID="lblHostName" runat="server" Text="Label"></asp:Label>
    IP：   
    <asp:Label ID="lblIP" runat="server" Text="Label"></asp:Label>
    URL：   
    <asp:Label ID="lblURL" runat="server" Text="Label"></asp:Label>
 
   <%-- <form id="form1" runat="server">
   
        <div>
            <asp:TreeView ID="TreeView1" runat="server" imageSet="News" NodeIndent="10">
              <ParentNodeStyle  Font-Bold="False"/>
               <HoverNodeStyle  Font-Underline="true"/>

                <Nodes>
                    <asp:TreeNode  Text="新闻"  NavigateUrl="#">
                       <asp:TreeNode  Text="国内"  NavigateUrl="#">

                    </asp:TreeNode>
                     <asp:TreeNode  Text="国际"  NavigateUrl="#">

                    </asp:TreeNode>
                    </asp:TreeNode>
                    
                     <asp:TreeNode  Text="互联网"  NavigateUrl="#">
                            <asp:TreeNode  Text="搜索引擎"></asp:TreeNode>
                            <asp:TreeNode  Text="电子商务"></asp:TreeNode>
                            <asp:TreeNode  Text="网络游戏"></asp:TreeNode>
                    </asp:TreeNode>
                    
                </Nodes>

            </asp:TreeView>
        </div>
    </form>
     <%=DateTime.Now.ToString() %>
    <script>
        setTimeout(function () {
            location.href = location.href;
        }, 1000);
    </script>--%>
  <%--  <form id="form1" action="WebForm1.aspx" method="post">

        <div>
            <input type="text"  name="username" />
             <input type="password"  name="pwd" />
           <input  type="submit" value="提交"/>
        </div>
        <div>
           
        </div>
    </form>--%>
    
</body>
</html>
