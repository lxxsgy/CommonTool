﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListCustom.aspx.cs" Inherits="WebDemo.ListCustom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <%-- Repater demo --%>
       <%-- <asp:Repeater ID="Repeater1" runat="server" >
          
            <ItemTemplate>
                <li>
                    <div class="postHeader">
                        <h3><%# Eval("PublishTime","{0:yyyy-MM-dd}") %></h3>
                        <h2>
                            <a href="#"><%# Eval("Title") %></a>
                        </h2>
                         </div>
                    <div class="postBody">
                        <p>
                            <%# Eval("Content") %>
                        </p>

                    </div>
                    <div class="postFooter">
                          <div>
                              发表于：
                              <span><%# Eval("PublishTime","{0:hh:mm:ss}") %></span>
                          </div>
                    </div>
                </li>
            </ItemTemplate> 
         <AlternatingItemTemplate>
             <li style="background-color:#eee;">
                  <div class="postHeader">
                        <h3><%# Eval("PublishTime","{0:yyyy-MM-dd}") %></h3>
                        <h2>
                            <a href="#"><%# Eval("Title") %></a>
                        </h2>
                         </div>
                    <div class="postBody">
                        <p>
                            <%# Eval("Content") %>
                        </p>

                    </div>
                    <div class="postFooter">
                          <div>
                              发表于：
                              <span><%# Eval("PublishTime","{0:hh:mm:ss}") %></span>
                          </div>
                    </div>
                </li>

             </li>
         </AlternatingItemTemplate>

        </asp:Repeater>--%>
          <%-- dataList Demo --%>
      <%--  <asp:DataList ID="DataList1" RepeatDirection="Vertical"  runat="server">
           
            <EditItemTemplate>
                <div class="postHeader">
                        <h3><%# Bind("PublishTime","{0:yyyy-MM-dd}") %></h3>
                        <h2>
                            <a href="#"><%# Bind("Title") %></a>
                        </h2>
                         </div>
                    <div class="postBody">
                        <p>
                            <%# Bind("Content") %>
                        </p>

                    </div>
                    <div class="postFooter">
                          <div>
                              发表于：
                              <span><%# Bind("PublishTime","{0:hh:mm:ss}") %></span>
                          </div>
                    </div>

            </EditItemTemplate>
       
                    
          
             

        
        </asp:DataList>--%>
        <%-- gridview Demo --%>
     <%--   <asp:GridView ID="GridcustomInfo" runat="server" AllowPaging="true"   Caption="数据表" HeaderStyle-BackColor="SpringGreen"  OnPageIndexChanging="GridcustomInfo_PageIndexChanging"   OnRowEditing="GridcustomInfo_RowEditing"  OnRowUpdating="GridcustomInfo_RowUpdating"  OnRowCancelingEdit="GridcustomInfo_RowCancelingEdit" OnRowDeleting="GridcustomInfo_RowDeleting" AutoGenerateDeleteButton="true"  AutoGenerateEditButton="true"> 
            <EditRowStyle BackColor="Red" />
             
        </asp:GridView>--%>
        <%-- DetailView demo --%>
       <%-- <asp:DetailsView ID="DetailsView1"  runat="server" Height="150px"     OnModeChanging="DetailsView1_ModeChanging"   AlternatingRowStyle-BackColor="Red"  AllowPaging="True"  AutoGenerateDeleteButton="True" AutoGenerateRows="False" AutoGenerateEditButton="True" AutoGenerateInsertButton="True" HorizontalAlign="Left" DataSourceID="SqlDataSource1" DefaultMode="Edit" ValidateRequestMode="Disabled">
<AlternatingRowStyle BackColor="Red"></AlternatingRowStyle>
            <Fields>
                <asp:BoundField DataField="RecordID" HeaderText="RecordID" SortExpression="RecordID" />
                <asp:BoundField DataField="DataID" HeaderText="DataID" SortExpression="DataID" />
                <asp:BoundField DataField="BATCH_INFO" HeaderText="BATCH_INFO" SortExpression="BATCH_INFO" />
                <asp:BoundField DataField="IMAGE_FILE_NAME" HeaderText="IMAGE_FILE_NAME" SortExpression="IMAGE_FILE_NAME" />
                <asp:TemplateField HeaderText="AGENT_COMPANY_NAME" SortExpression="AGENT_COMPANY_NAME">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1"   TextMode="MultiLine" runat="server" Text='<%# Bind("AGENT_COMPANY_NAME") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <InsertItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("AGENT_COMPANY_NAME") %>'></asp:TextBox>
                    </InsertItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("AGENT_COMPANY_NAME") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="AGENT_FAX" HeaderText="AGENT_FAX" SortExpression="AGENT_FAX" />
                <asp:BoundField DataField="AGENT_PERSON_NAME" HeaderText="AGENT_PERSON_NAME" SortExpression="AGENT_PERSON_NAME" />
                <asp:BoundField DataField="AGENT_PHONE" HeaderText="AGENT_PHONE" SortExpression="AGENT_PHONE" />
                <asp:BoundField DataField="AGENT_STATE" HeaderText="AGENT_STATE" SortExpression="AGENT_STATE" />
                <asp:BoundField DataField="AGENT_ZIP" HeaderText="AGENT_ZIP" SortExpression="AGENT_ZIP" />
                <asp:BoundField DataField="CANCEL_DATE" HeaderText="CANCEL_DATE" SortExpression="CANCEL_DATE" />
                <asp:BoundField DataField="CANCEL_PREMIUM_DUE" HeaderText="CANCEL_PREMIUM_DUE" SortExpression="CANCEL_PREMIUM_DUE" />
                <asp:BoundField DataField="CANCEL_PREMIUM_DUE_DATE" HeaderText="CANCEL_PREMIUM_DUE_DATE" SortExpression="CANCEL_PREMIUM_DUE_DATE" />
                <asp:BoundField DataField="CANCEL_REASON" HeaderText="CANCEL_REASON" SortExpression="CANCEL_REASON" />
                <asp:BoundField DataField="CARRIER_NAME" HeaderText="CARRIER_NAME" SortExpression="CARRIER_NAME" />
                <asp:BoundField DataField="CHANGE_EFFECTIVE_DATE" HeaderText="CHANGE_EFFECTIVE_DATE" SortExpression="CHANGE_EFFECTIVE_DATE" />
                <asp:BoundField DataField="COINSURANCE_PERCENT" HeaderText="COINSURANCE_PERCENT" SortExpression="COINSURANCE_PERCENT" />
                <asp:BoundField DataField="CONTINUOUS_TO_CANCEL" HeaderText="CONTINUOUS_TO_CANCEL" SortExpression="CONTINUOUS_TO_CANCEL" />
                <asp:BoundField DataField="DEDUCTIBLE" HeaderText="DEDUCTIBLE" SortExpression="DEDUCTIBLE" />
                <asp:BoundField DataField="DOCUMENT_DATE" HeaderText="DOCUMENT_DATE" SortExpression="DOCUMENT_DATE" />
                <asp:BoundField DataField="DOCUMENT_ID" HeaderText="DOCUMENT_ID" SortExpression="DOCUMENT_ID" />
                <asp:BoundField DataField="EFFECTIVE_DATE" HeaderText="EFFECTIVE_DATE" SortExpression="EFFECTIVE_DATE" />
                <asp:BoundField DataField="EXPIRE_DATE" HeaderText="EXPIRE_DATE" SortExpression="EXPIRE_DATE" />
                <asp:BoundField DataField="INSURANCE_AMOUNT" HeaderText="INSURANCE_AMOUNT" SortExpression="INSURANCE_AMOUNT" />
                <asp:BoundField DataField="INSURANCE_ID" HeaderText="INSURANCE_ID" SortExpression="INSURANCE_ID" />
                <asp:BoundField DataField="INSURED_LOCATION_NUMBER" HeaderText="INSURED_LOCATION_NUMBER" SortExpression="INSURED_LOCATION_NUMBER" />
                <asp:BoundField DataField="INSURED_LOCATION_OR_VEH_NUMBER" HeaderText="INSURED_LOCATION_OR_VEH_NUMBER" SortExpression="INSURED_LOCATION_OR_VEH_NUMBER" />
                <asp:BoundField DataField="INSURED_MAIL_ADDRESS1" HeaderText="INSURED_MAIL_ADDRESS1" SortExpression="INSURED_MAIL_ADDRESS1" />
                <asp:BoundField DataField="INSURED_MAIL_ADDRESS2" HeaderText="INSURED_MAIL_ADDRESS2" SortExpression="INSURED_MAIL_ADDRESS2" />
                <asp:BoundField DataField="INSURED_MAIL_CITY" HeaderText="INSURED_MAIL_CITY" SortExpression="INSURED_MAIL_CITY" />
                <asp:BoundField DataField="INSURED_MAIL_STATE" HeaderText="INSURED_MAIL_STATE" SortExpression="INSURED_MAIL_STATE" />
                <asp:BoundField DataField="INSURED_MAIL_ZIP" HeaderText="INSURED_MAIL_ZIP" SortExpression="INSURED_MAIL_ZIP" />
                <asp:BoundField DataField="INSURED_NAME" HeaderText="INSURED_NAME" SortExpression="INSURED_NAME" />
                <asp:BoundField DataField="LOAN_NUMBER" HeaderText="LOAN_NUMBER" SortExpression="LOAN_NUMBER" />
                <asp:BoundField DataField="LOSS_PAYEE_ADDRESS1" HeaderText="LOSS_PAYEE_ADDRESS1" SortExpression="LOSS_PAYEE_ADDRESS1" />
                <asp:BoundField DataField="LOSS_PAYEE_ADDRESS2" HeaderText="LOSS_PAYEE_ADDRESS2" SortExpression="LOSS_PAYEE_ADDRESS2" />
                <asp:BoundField DataField="LOSS_PAYEE_CITY" HeaderText="LOSS_PAYEE_CITY" SortExpression="LOSS_PAYEE_CITY" />
                <asp:BoundField DataField="LOSS_PAYEE_NAME" HeaderText="LOSS_PAYEE_NAME" SortExpression="LOSS_PAYEE_NAME" />
                <asp:BoundField DataField="LOSS_PAYEE_STATE" HeaderText="LOSS_PAYEE_STATE" SortExpression="LOSS_PAYEE_STATE" />
                <asp:BoundField DataField="LOSS_PAYEE_ZIP" HeaderText="LOSS_PAYEE_ZIP" SortExpression="LOSS_PAYEE_ZIP" />
                <asp:BoundField DataField="POLICY_NUMBER" HeaderText="POLICY_NUMBER" SortExpression="POLICY_NUMBER" />
                <asp:BoundField DataField="PREMIUM_AMOUNT" HeaderText="PREMIUM_AMOUNT" SortExpression="PREMIUM_AMOUNT" />
                <asp:BoundField DataField="NUMOFUNITS" HeaderText="NUMOFUNITS" SortExpression="NUMOFUNITS" />
                <asp:BoundField DataField="REALESTATE_ADDRESS1" HeaderText="REALESTATE_ADDRESS1" SortExpression="REALESTATE_ADDRESS1" />
                <asp:BoundField DataField="REALESTATE_ADDRESS2" HeaderText="REALESTATE_ADDRESS2" SortExpression="REALESTATE_ADDRESS2" />
                <asp:BoundField DataField="REALESTATE_CITY" HeaderText="REALESTATE_CITY" SortExpression="REALESTATE_CITY" />
                <asp:BoundField DataField="REALESTATE_STATE" HeaderText="REALESTATE_STATE" SortExpression="REALESTATE_STATE" />
                <asp:BoundField DataField="REALESTATE_ZIP" HeaderText="REALESTATE_ZIP" SortExpression="REALESTATE_ZIP" />
                <asp:BoundField DataField="REINSTATE_DATE" HeaderText="REINSTATE_DATE" SortExpression="REINSTATE_DATE" />
                <asp:BoundField DataField="REINSTATE_WITHOUT_LAPSE" HeaderText="REINSTATE_WITHOUT_LAPSE" SortExpression="REINSTATE_WITHOUT_LAPSE" />
                <asp:BoundField DataField="TERM" HeaderText="TERM" SortExpression="TERM" />
                <asp:BoundField DataField="WHO_PAYS_PREMIUM" HeaderText="WHO_PAYS_PREMIUM" SortExpression="WHO_PAYS_PREMIUM" />
                <asp:BoundField DataField="WINDHAILDED" HeaderText="WINDHAILDED" SortExpression="WINDHAILDED" />
                <asp:BoundField DataField="AGENT_ADDRESS" HeaderText="AGENT_ADDRESS" SortExpression="AGENT_ADDRESS" />
                <asp:BoundField DataField="AGENT_CITY" HeaderText="AGENT_CITY" SortExpression="AGENT_CITY" />
                <asp:BoundField DataField="DOCUMENT_SIGNED" HeaderText="DOCUMENT_SIGNED" SortExpression="DOCUMENT_SIGNED" />
                <asp:BoundField DataField="RANGE_ADDRESS" HeaderText="RANGE_ADDRESS" SortExpression="RANGE_ADDRESS" />
                <asp:BoundField DataField="POLICY_10DAYNONPAYNOTICE" HeaderText="POLICY_10DAYNONPAYNOTICE" SortExpression="POLICY_10DAYNONPAYNOTICE" />
                <asp:BoundField DataField="POLICY_30DAYCANCELNOTICE" HeaderText="POLICY_30DAYCANCELNOTICE" SortExpression="POLICY_30DAYCANCELNOTICE" />
                <asp:BoundField DataField="POLICY_CONTTOCANC" HeaderText="POLICY_CONTTOCANC" SortExpression="POLICY_CONTTOCANC" />
                <asp:BoundField DataField="POLICY_CUTTHROUGHENDORSE" HeaderText="POLICY_CUTTHROUGHENDORSE" SortExpression="POLICY_CUTTHROUGHENDORSE" />
                <asp:BoundField DataField="POLICY_DISCLOSUREFORMREC" HeaderText="POLICY_DISCLOSUREFORMREC" SortExpression="POLICY_DISCLOSUREFORMREC" />
                <asp:BoundField DataField="POLICY_INSPAYSPREMIUM" HeaderText="POLICY_INSPAYSPREMIUM" SortExpression="POLICY_INSPAYSPREMIUM" />
                <asp:BoundField DataField="POLICY_MOLDINCLUDE" HeaderText="POLICY_MOLDINCLUDE" SortExpression="POLICY_MOLDINCLUDE" />
                <asp:BoundField DataField="POLICY_RISKPURCHASINGGROUP" HeaderText="POLICY_RISKPURCHASINGGROUP" SortExpression="POLICY_RISKPURCHASINGGROUP" />
                <asp:BoundField DataField="POLICY_TENANTPROVIDED" HeaderText="POLICY_TENANTPROVIDED" SortExpression="POLICY_TENANTPROVIDED" />
                <asp:BoundField DataField="POLICY_TERRORINCLUDE" HeaderText="POLICY_TERRORINCLUDE" SortExpression="POLICY_TERRORINCLUDE" />
                <asp:BoundField DataField="NOTES" HeaderText="NOTES" SortExpression="NOTES" />
                <asp:BoundField DataField="ADDTNL_INSURED_NAME" HeaderText="ADDTNL_INSURED_NAME" SortExpression="ADDTNL_INSURED_NAME" />
                <asp:BoundField DataField="ADDTNL_INSURED_ADDRESS1" HeaderText="ADDTNL_INSURED_ADDRESS1" SortExpression="ADDTNL_INSURED_ADDRESS1" />
                <asp:BoundField DataField="ADDTNL_INSURED_CITY" HeaderText="ADDTNL_INSURED_CITY" SortExpression="ADDTNL_INSURED_CITY" />
                <asp:BoundField DataField="ADDTNL_INSURED_STATE" HeaderText="ADDTNL_INSURED_STATE" SortExpression="ADDTNL_INSURED_STATE" />
                <asp:BoundField DataField="ADDTNL_INSURED_ZIP" HeaderText="ADDTNL_INSURED_ZIP" SortExpression="ADDTNL_INSURED_ZIP" />
                <asp:BoundField DataField="DEL_INTEREST_AI" HeaderText="DEL_INTEREST_AI" SortExpression="DEL_INTEREST_AI" />
                <asp:BoundField DataField="HAZARD_PROPERTY" HeaderText="HAZARD_PROPERTY" SortExpression="HAZARD_PROPERTY" />
                <asp:BoundField DataField="HAZARD_DEDUCTIBLE" HeaderText="HAZARD_DEDUCTIBLE" SortExpression="HAZARD_DEDUCTIBLE" />
                <asp:BoundField DataField="HAZARD_WINDHAILDED" HeaderText="HAZARD_WINDHAILDED" SortExpression="HAZARD_WINDHAILDED" />
                <asp:BoundField DataField="HAZARD_COINSURANCE" HeaderText="HAZARD_COINSURANCE" SortExpression="HAZARD_COINSURANCE" />
                <asp:BoundField DataField="HAZARD_ACV" HeaderText="HAZARD_ACV" SortExpression="HAZARD_ACV" />
                <asp:BoundField DataField="HAZARD_AGREEDAMNTVAL" HeaderText="HAZARD_AGREEDAMNTVAL" SortExpression="HAZARD_AGREEDAMNTVAL" />
                <asp:BoundField DataField="HAZARD_ALLRISK" HeaderText="HAZARD_ALLRISK" SortExpression="HAZARD_ALLRISK" />
                <asp:BoundField DataField="HAZARD_BLANKETPOLLIMIT" HeaderText="HAZARD_BLANKETPOLLIMIT" SortExpression="HAZARD_BLANKETPOLLIMIT" />
                <asp:BoundField DataField="HAZARD_MULTILAYER" HeaderText="HAZARD_MULTILAYER" SortExpression="HAZARD_MULTILAYER" />
                <asp:BoundField DataField="HAZARD_RC" HeaderText="HAZARD_RC" SortExpression="HAZARD_RC" />
                <asp:BoundField DataField="HAZARD_WAIVEROFSUBJ" HeaderText="HAZARD_WAIVEROFSUBJ" SortExpression="HAZARD_WAIVEROFSUBJ" />
                <asp:BoundField DataField="HAZARD_WINDEXCLUDED" HeaderText="HAZARD_WINDEXCLUDED" SortExpression="HAZARD_WINDEXCLUDED" />
                <asp:BoundField DataField="LIABILITY_LIABILITY1" HeaderText="LIABILITY_LIABILITY1" SortExpression="LIABILITY_LIABILITY1" />
                <asp:BoundField DataField="LIABILITY_LIABILITY2" HeaderText="LIABILITY_LIABILITY2" SortExpression="LIABILITY_LIABILITY2" />
                <asp:BoundField DataField="LIABILITY_LIABILITY3" HeaderText="LIABILITY_LIABILITY3" SortExpression="LIABILITY_LIABILITY3" />
                <asp:BoundField DataField="LIABILITY_DLGENADDLIM" HeaderText="LIABILITY_DLGENADDLIM" SortExpression="LIABILITY_DLGENADDLIM" />
                <asp:BoundField DataField="BUSNSINCOME_AMOUNT" HeaderText="BUSNSINCOME_AMOUNT" SortExpression="BUSNSINCOME_AMOUNT" />
                <asp:BoundField DataField="BUSNSINCOME_EXTRAEXPENSE" HeaderText="BUSNSINCOME_EXTRAEXPENSE" SortExpression="BUSNSINCOME_EXTRAEXPENSE" />
                <asp:BoundField DataField="BUSNSINCOME_COINSURANCE" HeaderText="BUSNSINCOME_COINSURANCE" SortExpression="BUSNSINCOME_COINSURANCE" />
                <asp:BoundField DataField="BUSNSINCOME_6MOINDEMNITY" HeaderText="BUSNSINCOME_6MOINDEMNITY" SortExpression="BUSNSINCOME_6MOINDEMNITY" />
                <asp:BoundField DataField="BUSNSINCOME_12MOINDEMNITY" HeaderText="BUSNSINCOME_12MOINDEMNITY" SortExpression="BUSNSINCOME_12MOINDEMNITY" />
                <asp:BoundField DataField="BUSNSINCOME_18MOINDEMNITY" HeaderText="BUSNSINCOME_18MOINDEMNITY" SortExpression="BUSNSINCOME_18MOINDEMNITY" />
                <asp:BoundField DataField="BUSNSINCOME_24MOINDEMNITY" HeaderText="BUSNSINCOME_24MOINDEMNITY" SortExpression="BUSNSINCOME_24MOINDEMNITY" />
                <asp:BoundField DataField="BUSNSINCOME_ACTUALLOSSSUST" HeaderText="BUSNSINCOME_ACTUALLOSSSUST" SortExpression="BUSNSINCOME_ACTUALLOSSSUST" />
                <asp:BoundField DataField="BUILDINGORD_PROPUNDMG" HeaderText="BUILDINGORD_PROPUNDMG" SortExpression="BUILDINGORD_PROPUNDMG" />
                <asp:BoundField DataField="BUILDINGORD_DEMOCOST" HeaderText="BUILDINGORD_DEMOCOST" SortExpression="BUILDINGORD_DEMOCOST" />
                <asp:BoundField DataField="BUILDINGORD_INCRCOST" HeaderText="BUILDINGORD_INCRCOST" SortExpression="BUILDINGORD_INCRCOST" />
                <asp:BoundField DataField="BUILDINGORD_DEMOLITION" HeaderText="BUILDINGORD_DEMOLITION" SortExpression="BUILDINGORD_DEMOLITION" />
                <asp:BoundField DataField="BUILDINGORD_INCREASECONSTRCOST" HeaderText="BUILDINGORD_INCREASECONSTRCOST" SortExpression="BUILDINGORD_INCREASECONSTRCOST" />
                <asp:BoundField DataField="BOILERMACH_PROPERTY" HeaderText="BOILERMACH_PROPERTY" SortExpression="BOILERMACH_PROPERTY" />
                <asp:BoundField DataField="BOILERMACH_DEDUCTIBLE" HeaderText="BOILERMACH_DEDUCTIBLE" SortExpression="BOILERMACH_DEDUCTIBLE" />
                <asp:BoundField DataField="BOILERMACH_COINSURANCE" HeaderText="BOILERMACH_COINSURANCE" SortExpression="BOILERMACH_COINSURANCE" />
                <asp:BoundField DataField="TERRORISM_PROPERTY" HeaderText="TERRORISM_PROPERTY" SortExpression="TERRORISM_PROPERTY" />
                <asp:BoundField DataField="TERRORISM_DEDUCTIBLE" HeaderText="TERRORISM_DEDUCTIBLE" SortExpression="TERRORISM_DEDUCTIBLE" />
                <asp:BoundField DataField="TERRORISM_COINSURANCE" HeaderText="TERRORISM_COINSURANCE" SortExpression="TERRORISM_COINSURANCE" />
                <asp:BoundField DataField="EARTHQUAKE_PROPERTY" HeaderText="EARTHQUAKE_PROPERTY" SortExpression="EARTHQUAKE_PROPERTY" />
                <asp:BoundField DataField="EARTHQUAKE_DEDUCTIBLE" HeaderText="EARTHQUAKE_DEDUCTIBLE" SortExpression="EARTHQUAKE_DEDUCTIBLE" />
                <asp:BoundField DataField="EARTHQUAKE_COINSURANCE" HeaderText="EARTHQUAKE_COINSURANCE" SortExpression="EARTHQUAKE_COINSURANCE" />
                <asp:BoundField DataField="WIND_PROPERTY" HeaderText="WIND_PROPERTY" SortExpression="WIND_PROPERTY" />
                <asp:BoundField DataField="WIND_DEDUCTIBLE" HeaderText="WIND_DEDUCTIBLE" SortExpression="WIND_DEDUCTIBLE" />
                <asp:BoundField DataField="WIND_COINSURANCE" HeaderText="WIND_COINSURANCE" SortExpression="WIND_COINSURANCE" />
                <asp:BoundField DataField="FLOOD_PROPERTY" HeaderText="FLOOD_PROPERTY" SortExpression="FLOOD_PROPERTY" />
                <asp:BoundField DataField="FLOOD_DEDUCTIBLE" HeaderText="FLOOD_DEDUCTIBLE" SortExpression="FLOOD_DEDUCTIBLE" />
                <asp:BoundField DataField="FLOOD_COINSURANCE" HeaderText="FLOOD_COINSURANCE" SortExpression="FLOOD_COINSURANCE" />
                <asp:BoundField DataField="WORKERSCOMP_WORKERS1" HeaderText="WORKERSCOMP_WORKERS1" SortExpression="WORKERSCOMP_WORKERS1" />
                <asp:BoundField DataField="WORKERSCOMP_WORKERS2" HeaderText="WORKERSCOMP_WORKERS2" SortExpression="WORKERSCOMP_WORKERS2" />
                <asp:BoundField DataField="WORKERSCOMP_WORKERS3" HeaderText="WORKERSCOMP_WORKERS3" SortExpression="WORKERSCOMP_WORKERS3" />
                <asp:BoundField DataField="WORKERSCOMP_STATLIMIT" HeaderText="WORKERSCOMP_STATLIMIT" SortExpression="WORKERSCOMP_STATLIMIT" />
                <asp:BoundField DataField="EXCESS_LIABILITY1" HeaderText="EXCESS_LIABILITY1" SortExpression="EXCESS_LIABILITY1" />
                <asp:BoundField DataField="EXCESS_LIABILITY2" HeaderText="EXCESS_LIABILITY2" SortExpression="EXCESS_LIABILITY2" />
                <asp:BoundField DataField="EXCESS_LIABILITY3" HeaderText="EXCESS_LIABILITY3" SortExpression="EXCESS_LIABILITY3" />
                <asp:BoundField DataField="EXCESS_MULTILAYER" HeaderText="EXCESS_MULTILAYER" SortExpression="EXCESS_MULTILAYER" />
                <asp:BoundField DataField="SINKHOLE_PROPERTY" HeaderText="SINKHOLE_PROPERTY" SortExpression="SINKHOLE_PROPERTY" />
                <asp:BoundField DataField="SINKHOLE_DEDUCTIBLE" HeaderText="SINKHOLE_DEDUCTIBLE" SortExpression="SINKHOLE_DEDUCTIBLE" />
                <asp:BoundField DataField="SINKHOLE_COINSURANCE" HeaderText="SINKHOLE_COINSURANCE" SortExpression="SINKHOLE_COINSURANCE" />
                <asp:BoundField DataField="PROFLIAB_LIABILITY1" HeaderText="PROFLIAB_LIABILITY1" SortExpression="PROFLIAB_LIABILITY1" />
                <asp:BoundField DataField="PROFLIAB_LIABILITY2" HeaderText="PROFLIAB_LIABILITY2" SortExpression="PROFLIAB_LIABILITY2" />
                <asp:BoundField DataField="PROFLIAB_LIABILITY3" HeaderText="PROFLIAB_LIABILITY3" SortExpression="PROFLIAB_LIABILITY3" />
                <asp:BoundField DataField="POLLUTION_LIABILITY1" HeaderText="POLLUTION_LIABILITY1" SortExpression="POLLUTION_LIABILITY1" />
                <asp:BoundField DataField="POLLUTION_LIABILITY2" HeaderText="POLLUTION_LIABILITY2" SortExpression="POLLUTION_LIABILITY2" />
                <asp:BoundField DataField="POLLUTION_LIABILITY3" HeaderText="POLLUTION_LIABILITY3" SortExpression="POLLUTION_LIABILITY3" />
                <asp:BoundField DataField="CONTENTS_PROPERTY" HeaderText="CONTENTS_PROPERTY" SortExpression="CONTENTS_PROPERTY" />
                <asp:BoundField DataField="CONTENTS_DEDUCTIBLE" HeaderText="CONTENTS_DEDUCTIBLE" SortExpression="CONTENTS_DEDUCTIBLE" />
                <asp:BoundField DataField="CONTENTS_COINSURANCE" HeaderText="CONTENTS_COINSURANCE" SortExpression="CONTENTS_COINSURANCE" />
                <asp:BoundField DataField="INSURANCE_ID_BOILERMACH" HeaderText="INSURANCE_ID_BOILERMACH" SortExpression="INSURANCE_ID_BOILERMACH" />
                <asp:BoundField DataField="INSURANCE_ID_BUILDINGORD" HeaderText="INSURANCE_ID_BUILDINGORD" SortExpression="INSURANCE_ID_BUILDINGORD" />
                <asp:BoundField DataField="INSURANCE_ID_BUSNSINCOME" HeaderText="INSURANCE_ID_BUSNSINCOME" SortExpression="INSURANCE_ID_BUSNSINCOME" />
                <asp:BoundField DataField="INSURANCE_ID_CONTENTS" HeaderText="INSURANCE_ID_CONTENTS" SortExpression="INSURANCE_ID_CONTENTS" />
                <asp:BoundField DataField="INSURANCE_ID_EARTHQUAKE" HeaderText="INSURANCE_ID_EARTHQUAKE" SortExpression="INSURANCE_ID_EARTHQUAKE" />
                <asp:BoundField DataField="INSURANCE_ID_EXCESS" HeaderText="INSURANCE_ID_EXCESS" SortExpression="INSURANCE_ID_EXCESS" />
                <asp:BoundField DataField="INSURANCE_ID_FLOOD" HeaderText="INSURANCE_ID_FLOOD" SortExpression="INSURANCE_ID_FLOOD" />
                <asp:BoundField DataField="INSURANCE_ID_HAZARD" HeaderText="INSURANCE_ID_HAZARD" SortExpression="INSURANCE_ID_HAZARD" />
                <asp:BoundField DataField="INSURANCE_ID_LIABILITY" HeaderText="INSURANCE_ID_LIABILITY" SortExpression="INSURANCE_ID_LIABILITY" />
                <asp:BoundField DataField="INSURANCE_ID_TERRORISM" HeaderText="INSURANCE_ID_TERRORISM" SortExpression="INSURANCE_ID_TERRORISM" />
                <asp:BoundField DataField="INSURANCE_ID_WIND" HeaderText="INSURANCE_ID_WIND" SortExpression="INSURANCE_ID_WIND" />
                <asp:BoundField DataField="INSURANCE_ID_WORKERSCOMP" HeaderText="INSURANCE_ID_WORKERSCOMP" SortExpression="INSURANCE_ID_WORKERSCOMP" />
                <asp:BoundField DataField="PAYEE_NAME" HeaderText="PAYEE_NAME" SortExpression="PAYEE_NAME" />
                <asp:BoundField DataField="PAYEE_ADDRESS1" HeaderText="PAYEE_ADDRESS1" SortExpression="PAYEE_ADDRESS1" />
                <asp:BoundField DataField="PAYEE_CITY" HeaderText="PAYEE_CITY" SortExpression="PAYEE_CITY" />
                <asp:BoundField DataField="PAYEE_STATE" HeaderText="PAYEE_STATE" SortExpression="PAYEE_STATE" />
                <asp:BoundField DataField="PAYEE_ZIP" HeaderText="PAYEE_ZIP" SortExpression="PAYEE_ZIP" />
                <asp:BoundField DataField="AMOUNT_DUE" HeaderText="AMOUNT_DUE" SortExpression="AMOUNT_DUE" />
                <asp:BoundField DataField="PAYMENT_DUE_OR_CHECK_DATE" HeaderText="PAYMENT_DUE_OR_CHECK_DATE" SortExpression="PAYMENT_DUE_OR_CHECK_DATE" />
                <asp:BoundField DataField="POLICY_TYPE" HeaderText="POLICY_TYPE" SortExpression="POLICY_TYPE" />
                <asp:BoundField DataField="EntryFlag" HeaderText="EntryFlag" SortExpression="EntryFlag" />
                <asp:BoundField DataField="WorkID" HeaderText="WorkID" SortExpression="WorkID" />
                <asp:BoundField DataField="InserTime" HeaderText="InserTime" SortExpression="InserTime" />
                <asp:BoundField DataField="REPLACEMENTVALUE" HeaderText="REPLACEMENTVALUE" SortExpression="REPLACEMENTVALUE" />
                <asp:BoundField DataField="REPLACEMENTCOST" HeaderText="REPLACEMENTCOST" SortExpression="REPLACEMENTCOST" />
                <asp:BoundField DataField="FLOODREPLACEMENTVALUE" HeaderText="FLOODREPLACEMENTVALUE" SortExpression="FLOODREPLACEMENTVALUE" />
                <asp:BoundField DataField="FLOODREPLACEMENTCOST" HeaderText="FLOODREPLACEMENTCOST" SortExpression="FLOODREPLACEMENTCOST" />
                <asp:BoundField DataField="NFIP_FLOOD_ZONE" HeaderText="NFIP_FLOOD_ZONE" SortExpression="NFIP_FLOOD_ZONE" />
                <asp:BoundField DataField="GRANDFATHERED_FLOOD_ZONE_CHARACTERISTIC" HeaderText="GRANDFATHERED_FLOOD_ZONE_CHARACTERISTIC" SortExpression="GRANDFATHERED_FLOOD_ZONE_CHARACTERISTIC" />
                <asp:BoundField DataField="UNITOWNER" HeaderText="UNITOWNER" SortExpression="UNITOWNER" />
                <asp:BoundField DataField="LIEN_HOLDER_NAME" HeaderText="LIEN_HOLDER_NAME" SortExpression="LIEN_HOLDER_NAME" />
                <asp:BoundField DataField="LIEN_HOLDER_ADDRESS1" HeaderText="LIEN_HOLDER_ADDRESS1" SortExpression="LIEN_HOLDER_ADDRESS1" />
                <asp:BoundField DataField="LIEN_HOLDER_CITY" HeaderText="LIEN_HOLDER_CITY" SortExpression="LIEN_HOLDER_CITY" />
                <asp:BoundField DataField="LIEN_HOLDER_STATE" HeaderText="LIEN_HOLDER_STATE" SortExpression="LIEN_HOLDER_STATE" />
                <asp:BoundField DataField="LIEN_HOLDER_ZIP" HeaderText="LIEN_HOLDER_ZIP" SortExpression="LIEN_HOLDER_ZIP" />
                <asp:BoundField DataField="DEL_INTEREST_LH" HeaderText="DEL_INTEREST_LH" SortExpression="DEL_INTEREST_LH" />
                <asp:BoundField DataField="OTHER_COLL_SERIAL_NUMBER" HeaderText="OTHER_COLL_SERIAL_NUMBER" SortExpression="OTHER_COLL_SERIAL_NUMBER" />
                <asp:BoundField DataField="OTHER_COLL_YEAR" HeaderText="OTHER_COLL_YEAR" SortExpression="OTHER_COLL_YEAR" />
                <asp:BoundField DataField="OTHER_COLL_MAKE" HeaderText="OTHER_COLL_MAKE" SortExpression="OTHER_COLL_MAKE" />
                <asp:BoundField DataField="OTHER_COLL_MODEL" HeaderText="OTHER_COLL_MODEL" SortExpression="OTHER_COLL_MODEL" />
                <asp:BoundField DataField="OTHER_COLL_ZIP" HeaderText="OTHER_COLL_ZIP" SortExpression="OTHER_COLL_ZIP" />
                <asp:BoundField DataField="FLDCONTENTS_PROPERTY" HeaderText="FLDCONTENTS_PROPERTY" SortExpression="FLDCONTENTS_PROPERTY" />
                <asp:BoundField DataField="FLDCONTENTS_DEDUCTIBLE" HeaderText="FLDCONTENTS_DEDUCTIBLE" SortExpression="FLDCONTENTS_DEDUCTIBLE" />
                <asp:BoundField DataField="FLDCONTENTS_COINSURANCE" HeaderText="FLDCONTENTS_COINSURANCE" SortExpression="FLDCONTENTS_COINSURANCE" />
                <asp:BoundField DataField="FLDCONTENTSREPLACEMENTVALUE" HeaderText="FLDCONTENTSREPLACEMENTVALUE" SortExpression="FLDCONTENTSREPLACEMENTVALUE" />
                <asp:BoundField DataField="FLDCONTENTSREPLACEMENTCOST" HeaderText="FLDCONTENTSREPLACEMENTCOST" SortExpression="FLDCONTENTSREPLACEMENTCOST" />
                <asp:BoundField DataField="NFIP_FLDCONTENTS_ZONE" HeaderText="NFIP_FLDCONTENTS_ZONE" SortExpression="NFIP_FLDCONTENTS_ZONE" />
                <asp:BoundField DataField="STIC" HeaderText="STIC" SortExpression="STIC" />
            </Fields>
 

            

          

        </asp:DetailsView>--%>
        <%-- FormView --%>
        <asp:FormView ID="FormView1" runat="server" AllowPaging="false"  OnModeChanging="FormView1_ModeChanging" >

           
            <ItemTemplate>

                <div>
                    <h3><%# Eval("PublishTime") %></h3>
                </div>
                <div>
                    <p><%# Eval("Content") %></p>
                </div>
                 <asp:LinkButton   runat="server" ID="EditButton"   CausesValidation="false" CommandName="edit" Text="编辑">

                </asp:LinkButton>
            </ItemTemplate>
            <EditItemTemplate>
            <div>
                    <h3><%# Eval("PublishTime") %></h3>
                </div>
                <div>
                   <textarea><%# Eval("Content") %></textarea>
                </div>
                 <asp:LinkButton   runat="server" ID="UpdateButton"   CausesValidation="false" CommandName="update" Text="更新">

                </asp:LinkButton>
            </EditItemTemplate>
        </asp:FormView>


       <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:userConnectionString %>" SelectCommand="SELECT * FROM [his_tblData1]"></asp:SqlDataSource>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>--%>
        <asp:TreeView ID="TreeView1" runat="server"></asp:TreeView>

    </form>
    <script>
      
       



    </script>
</body>
</html>