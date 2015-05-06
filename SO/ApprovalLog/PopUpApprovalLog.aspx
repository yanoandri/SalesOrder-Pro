<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PopUpApprovalLog.aspx.cs"
    Inherits="SE.WebUI.PopUpApprovalLog" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Approval List Detail</title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
        <table width="100%;">
            <tr>
                <td>
                    <telerik:RadButton ID="btnExportToExcel" SkinID="ExportToExcel" runat="server" OnClick="btnExportToExcel_Click" />
                    <telerik:RadGrid ID="rgridList" runat="server" GridLines="None" SkinID="" OnNeedDataSource="rgridList_NeedDataSource" AllowPaging="true" PageSize="1">
                        <ClientSettings>
                            <Selecting AllowRowSelect="False"></Selecting>
                        </ClientSettings>
                        <MasterTableView DataKeyNames="ApprovalLogID" AutoGenerateColumns="false" CommandItemDisplay="None" >
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="No" UniqueName="Number" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="15px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblrgridNumber" runat="server" Text='<%# (rgridList.PageSize*rgridList.CurrentPageIndex)+ Container.ItemIndex + 1 %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn Visible="False" SortExpression="ApprovalLogID" DataField="ApprovalLogID"
                                    HeaderText="Approval Log ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApprovalLogID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ApprovalLogID") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn SortExpression="RefID" Visible="false" DataField="RefID"
                                    HeaderText="Ref ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRefID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RefID") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn Visible="False" SortExpression="ModuleObjectMemberID"
                                    DataField="ModuleObjectMemberID" HeaderText="Module Object Member ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblModuleObjectMemberID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ModuleObjectMemberID") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn Visible="False" SortExpression="ModuleObjectID" DataField="ModuleObjectID"
                                    HeaderText="Module Object ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblModuleObjectID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ModuleObjectID") %>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn Visible="False" SortExpression="ApprovalStatusID" DataField="ApprovalStatusID"
                                    HeaderText="Approval Status ID">
                                    <ItemTemplate>
                                        <asp:Label ID="lblApprovalStatusID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ApprovalStatusID") %>' />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn SortExpression="CreateDate" DataField="CreateDate" HeaderText="Request Date"
                                    HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreateDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreateDate","{0:dd MMM yyyy}")== "01 Jan 1900" ?"-":DataBinder.Eval(Container.DataItem, "CreateDate","{0:dd MMM yyyy HH:mm:ss}") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="150px"></HeaderStyle>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn SortExpression="CreateByUserID" DataField="CreateByUserID"
                                    HeaderText="Request By" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCreateByUserID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CreateByUserName") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="100px"></HeaderStyle>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn SortExpression="ObjectName" DataField="ObjectName" HeaderText="Data"
                                    HeaderStyle-Width="180px" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblObjectName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ObjectName") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn SortExpression="MemberName" DataField="MemberName" HeaderText="Request Type"
                                    HeaderStyle-Width="180px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMemberName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MemberName") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle Width="180px"></HeaderStyle>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn Visible="false" SortExpression="Detail" DataField="Detail"
                                    HeaderText="Detail">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDetail" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Detail") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn SortExpression="Remark" DataField="Remark" HeaderText="Remark">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRemark" runat="server" Text='<%# (string)DataBinder.Eval(Container, "DataItem.Remark")=="NONE"?"":DataBinder.Eval(Container, "DataItem.Remark") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <ExpandCollapseColumn Visible="False" Resizable="False">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn Visible="False">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <PagerStyle AlwaysVisible="True" Mode="NextPrevNumericAndAdvanced"></PagerStyle>
                        </MasterTableView>
                        <HeaderStyle HorizontalAlign="Center" />
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                        <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                </td>
            </tr>
        </table>
        <telerik:RadAjaxManager ID="ram" runat="server" DefaultLoadingPanelID="ralp">
            <AjaxSettings>
                <telerik:AjaxSetting AjaxControlID="rgridList">
                    <UpdatedControls>
                        <telerik:AjaxUpdatedControl ControlID="rgridList" />
                    </UpdatedControls>
                </telerik:AjaxSetting>
            </AjaxSettings>
        </telerik:RadAjaxManager>
        <telerik:RadAjaxLoadingPanel ID="ralp" runat="server">
        </telerik:RadAjaxLoadingPanel>
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <tr class="GridRow_Office2007">
                    <td align="center" class="textfield">
                        <%# Container.ItemIndex + 1%>
                        &nbsp;
                    </td>
                    <td class="textfield">
                        <%# string.Format("{0:dd MMM yyyy}", DataBinder.Eval(Container.DataItem, "CreateDate"))%>
                    </td>
                    <td class="textfield">
                        <%# DataBinder.Eval(Container.DataItem, "CreateByUserName")%>
                    </td>
                    <td class="textfield">
                        <%# DataBinder.Eval(Container.DataItem, "ObjectName") %>
                    </td>
                    <td class="textfield">
                        <%# DataBinder.Eval(Container.DataItem, "MemberName")%>
                    </td>
                    <td class="textfield">
                        <%# DataBinder.Eval(Container.DataItem, "Remark").Equals("NONE") ? "" : DataBinder.Eval(Container.DataItem, "Remark")%>
                    </td>
                </tr>
            </ItemTemplate>
            <HeaderTemplate>
                <h2>
                    Pending Customer Registration Report</h2>
                <label class="GridSubTitle_Office2007">
                    Generated Date :<%# string.Format("{0:dd MMM yyyy}", DateTime.Now) %></label><br />
                <label class="GridSubTitle_Office2007">
                    Generate By :<%# ((PFSHelper.BusinessLogicLayer.CustomPrincipal)System.Web.HttpContext.Current.User).User.UserName %></label><br />
                <table width="100%" class="MasterTable_Office2007" border="1">
                    <tr class="MasterTable_Office2007">
                        <td class="GridHeader_Office2007">
                            No.
                        </td>
                        <td class="GridHeader_Office2007">
                            Request Date
                        </td>
                        <td class="GridHeader_Office2007">
                            Request By
                        </td>
                        <td class="GridHeader_Office2007">
                            Data
                        </td>
                        <td class="GridHeader_Office2007">
                            Request Type
                        </td>
                        <td class="GridHeader_Office2007">
                            Remark
                        </td>
                    </tr>
            </HeaderTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Literal ID="litCss" runat="server">
	<style type="text/css">
	    .MasterTable_Office2007
	    {
	        border-collapse: separate !important;
	        color: #27413e;
	    }
	    
	    .MasterTable_Office2007 th
	    {
	        padding: 0 5px 0 4px;
	    }
	    .MasterTable_Office2007 td
	    {
	        padding: 0 4px;
	    }
	    .GridHeader_Office2007
	    {
	        font: bold 10px;
	        background: #d3dbe9 url('Img/GridHeaderBg.gif') repeat-x;
	        padding-left: 6px; /*more than items to compensate for item borders!*/
	        height: 19px;
	        color: #27413e;
	        border-bottom: solid 1px #9eb6ce;
	        text-align: center;
	    }
	    .GridHeader_Office2007 a
	    {
	        color: #27413e;
	        text-decoration: none;
	    }
	    .GridRow_Office2007
	    {
	        background: transparent;
	        height: 19px;
	    }
	    .GridRow_Office2007 td
	    {
	        border-right: solid 1px #d0d7e5;
	        border-bottom: solid 1px #d0d7e5;
	    }
	    .textfield
	    {
	        font-size: 11px;
	        color: #3d3d3d;
	        font-family: Arial;
	        mso-number-format: \@;
	    }
	</style>
        </asp:Literal>
    </div>
    </form>
</body>
</html>
