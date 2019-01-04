<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false" CodeBehind="UpdateProcessDemo.aspx.cs" Inherits="WebDemo.UpdateProcessDemo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   <%-- <style>
        .RatingStar{
            width:20px;
            height:55px;
            margin:0px;
            padding:0px;
            cursor:pointer;
            display:block;
            background-repeat:repeat;
        }
        .filledStar{
            background-image:url(Images/FilledStar.png);
        }
        .emptyStar{
             background-image:url(Images/FilledStar.png);
        }
        .savedRatingStar{
 background-image:url(Images/FilledStar.png);
        }
    </style>--%>
</head>
<body>
    <form id="form1" runat="server">
        <%-- 异步显示所选日期 --%>
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <asp:UpdateProgress ID="UpdateProgress1"  runat="server">
           <ProgressTemplate>
               <span>正在处理。。。</span>
           </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" DayNameFormat="Shortest" Font-Size="8pt"  OnSelectionChanged="Calendar1_SelectionChanged"
                            >
            <SelectedDayStyle  BackColor="#009999" Font-Bold="true" ForeColor="#CCFF99"/>
            <WeekendDayStyle  BackColor="#CCCCFF"/>   

        </asp:Calendar>
         <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger  ControlID="Calendar1" EventName="SelectionChanged"/>
            </Triggers>
           
        </asp:UpdatePanel>  



            
    </div>   --%>
        <%-- Timer --%>
       <%-- <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <ContentTemplate>

               <asp:Label ID="timeCount" runat="server"></asp:Label>
           </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger  ControlID="Timer1" EventName="Tick"/>
            </Triggers>
        </asp:UpdatePanel>
        <asp:Timer ID="Timer1" runat="server"  Interval="1000" OnTick="Timer1_Tick"></asp:Timer>--%>
  
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <%--     <ajaxToolkit:Accordion ID="Accordion1"  AutoSize="None" SelectedIndex="0" FadeTransitions="true" FramesPerSecond="60" runat="server">
        <Panes>
         <ajaxToolkit:AccordionPane runat="server" >
               <Header>
                   <h3> LCD  养生之道，液晶显示器清洁技巧</h3>
               </Header>
             <Content>
                 <p>LCD  养生之道，液晶显示器清洁技巧</p>
                  <p>LCD  养生之道，液晶显示器清洁技巧</p>
             </Content>
            
         </ajaxToolkit:AccordionPane>
            <ajaxToolkit:AccordionPane runat="server">
             
                   <Header>
                   <h3> LED  养生之道，液晶显示器清洁技巧</h3>
               </Header>
             <Content>
                 <p>LED  养生之道，液晶显示器清洁技巧</p>
                  <p>LED  养生之道，液晶显示器清洁技巧</p>
             </Content>
         </ajaxToolkit:AccordionPane>
        </Panes>
    </ajaxToolkit:Accordion>--%>
  <%--      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="PanelHeader1" runat="server">
                 <h2><span>
                     <asp:ImageButton ID="ImageButton1" runat="server"  AlternateText="collapse" />IT技术杂谈</span></h2>
                </asp:Panel>
                <asp:Panel ID="PanelContent1" runat="server">
                    <ul>
                        <li>
                            <a href="#">
                                <span>硬件知识</span>
                            </a>
                        </li>
                         <li>
                            <a href="#">
                                <span>路由交换</span>
                            </a>
                        </li>
                         <li>
                            <a href="#">
                                <span>windows</span>
                            </a>
                        </li>
                         <li>
                            <a href="#">
                                <span>安全防护</span>
                            </a>
                        </li>

                    </ul>
                </asp:Panel>
                <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" 
             SuppressPostBack="true"  Collapsed="false"    TargetControlID="PanelContent1"  ExpandControlID="PanelHeader1"  CollapseControlID="PanelHeader1"
            />
                 <asp:Panel ID="PanelHeader2" runat="server">
                 <h2><span>
                     <asp:ImageButton ID="ImageButton2" runat="server"  AlternateText="collapse" />IT技术杂谈</span></h2>
                </asp:Panel>
                <asp:Panel ID="PanelContent2" runat="server">
                    <ul>
                        <li>
                            <a href="#">
                                <span>硬件知识</span>
                            </a>
                        </li>
                         <li>
                            <a href="#">
                                <span>路由交换</span>
                            </a>
                        </li>
                         <li>
                            <a href="#">
                                <span>windows</span>
                            </a>
                        </li>
                         <li>
                            <a href="#">
                                <span>安全防护</span>
                            </a>
                        </li>

                    </ul>
                </asp:Panel>
                <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server" 
             SuppressPostBack="true"  Collapsed="false"    TargetControlID="PanelContent2"  ExpandControlID="PanelHeader2"  CollapseControlID="PanelHeader2"
            />
            </ContentTemplate>
        </asp:UpdatePanel>--%>
        <%-- Rating 评分 --%>
      <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="Label1" runat="server" Text="请评分!"></asp:Label>
                <asp:Label ID="Label2" runat="server"  ForeColor="Red"></asp:Label>
                
                 <ajaxToolkit:Rating ID="Rating2" runat="server" CurrentRating="2" MaxRating="6" 
                     StarCssClass="RatingStar"
                     WaitingStarCssClass="savedRatingStar"
                     FilledStarCssClass="filledStar"
                     EmptyStarCssClass="emptyStar"
                     OnChanged="Rating1_Changed"
                     AutoPostBack="false">
               
                      </ajaxToolkit:Rating>
                 <ajaxToolkit:Rating ID="Rating1" WaitingStarCssClass="RatingStar" EmptyStarCssClass ="emptyStar"  FilledStarCssClass="filledStar" StarCssClass="RatingStar" runat="server" CurrentRating="2" RatingAlign="Vertical">
                </ajaxToolkit:Rating>
                 </ContentTemplate>
        </asp:UpdatePanel>--%>

     <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <asp:DropDownList  id="DropDownList1" runat="server"  Width="10%"></asp:DropDownList>
            <asp:DropDownList id="DropDownList2" runat="server"  Width="10%"
                 AutoPostBack="true" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"
                ></asp:DropDownList>
                <ajaxToolkit:CascadingDropDown ID="CascadingDropDown1" runat="server"
                     Category="project"
                     PromptText="请选择文章分类"
                     ServicePath="CascadingDropDownServcie.asmx"
                     ServiceMethod="GetDropDownContents"
                    TargetControlID="DropDownList1"/>
                    
                <ajaxToolkit:CascadingDropDown ID="CascadingDropDown2" runat="server" 
                     Category="detail" 
                      PromptText="请选择文章分类"
                         ServiceMethod="GetDropDownContents"
                     ServicePath="CascadingDropDownServcie.asmx"
                    TargetControlID="DropDownList2"
                    
                    />

            </ContentTemplate>

           

        </asp:UpdatePanel>--%>

      <%--              <table>
            <tr>
                <td>Make</td>
                <td><asp:DropDownList ID="DropDownList1" runat="server" Width="170" /></td>
            </tr>
            <tr>
                <td>Color</td>
                <td><asp:DropDownList ID="DropDownList2" runat="server" Width="170" 
                        AutoPostBack="True" onselectedindexchanged="DropDownList3_SelectedIndexChanged"
                    /></td>
            </tr>
        </table>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server"  UpdateMode ="Conditional" RenderMode ="Inline" >
    <ContentTemplate >
       <asp:Label ID="Label1" runat="server" Text="没有服务器响应数据(结果将显示在这里)"></asp:Label>
    </ContentTemplate>
    <Triggers >
    <asp:AsyncPostBackTrigger ControlID ="DropDownList2" EventName ="SelectedIndexChanged" />
    </Triggers>
    </asp:UpdatePanel>
          <ajaxToolkit:CascadingDropDown ID="CascadingDropDown1" runat="server" TargetControlID ="DropDownList1"
     Category ="projecct" PromptText ="please select a make" LoadingText ="[loading categories...]"
      ServicePath ="~/CarsService.asmx" ServiceMethod ="GetDropDownContents">
     
    </ajaxToolkit:CascadingDropDown>
   
    <ajaxToolkit:CascadingDropDown ID="CascadingDropDown3" runat="server" TargetControlID ="DropDownList2"
    Category="detail" PromptText="Please select a color" LoadingText="[Loading colors...]"
    ServicePath="~/CarsService.asmx" ServiceMethod="GetDropDownContents"
    ParentControlID="DropDownList1">
    </ajaxToolkit:CascadingDropDown>--%>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:TextBox ID="myTextBox" runat="server"  MaxLength="100" Width="390px"></asp:TextBox>
                <input  type="submit" id="su" value="越搜越开心"/>
                  <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
             TargetControlID="myTextBox" 
             CompletionSetCount="10"  
               MinimumPrefixLength="1"
             ServiceMethod="GetCompleteList"
             ServicePath="~/WebService1.asmx">

        </ajaxToolkit:AutoCompleteExtender>
            </ContentTemplate>
             
        </asp:UpdatePanel>
        
        

            </form>
 
</body>
</html>
