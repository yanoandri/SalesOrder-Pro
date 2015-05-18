<%@ Page Language="C#" MasterPageFile="~/SiteMaster/Default.master" AutoEventWireup="true"
    Theme="skin" Inherits="SE_WebUI_ApprovalLogList" CodeBehind="ApprovalLogList.aspx.cs" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentTitle" ContentPlaceHolderID="ContentTitle" runat="server">
    <h1 class="title">
        Security - Approval Log List
    </h1>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentDefault" runat="Server">
    <script type="text/javascript">

        function OnClientClickApproveAll(button, args) {
            var bIsConfirm = (window.confirm('Are you sure want to approve all request?'));
            button.set_autoPostBack(bIsConfirm);
        }

        function OnClientClickRejectAll(sender, eventArgs) {
            var bIsConfirm = (confirm('Are you sure want to reject all request?'));
            sender.set_autoPostBack(bIsConfirm);
        }

    </script>
    <div class="accordion_field">
        <fieldset class="acc_wrap">
            <div class="block acc_target">
                <div class="table_filter">
                    <table>
                        <thead>
                            <tr>
                                <th width="17%" class="filter">
                                    Filter
                                </th>
                                <th width="30%">
                                </th>
                                <th width="19%">
                                </th>
                                <th width="34%">
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label ID="lblKeywords" runat="server">Keywords</asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="tbFilterKeywords" runat="server" Width="130px" MaxLength="100"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblFilterApprovalStatusCode" runat="server"> Approval Status</asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <telerik:RadComboBox ID="cmbFilterApprovalStatusCode" runat="server" HighlightTemplatedItems="True"
                                        MarkFirstMatch="True" radcontrolsdir="~/RadControls/" Skin="Office2007" skinspath="~/RadControls/ComboBox/Skins"
                                        Sort="None" Width="130px">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFilterMemberCode" runat="server"> Data</asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <telerik:RadComboBox ID="cmbFilterObjectCode" runat="server" HighlightTemplatedItems="True"
                                        MarkFirstMatch="True" radcontrolsdir="~/RadControls/" Skin="Office2007" skinspath="~/RadControls/ComboBox/Skins"
                                        Sort="None" Width="205px" AutoPostBack="true" OnSelectedIndexChanged="cmbFilterObjectMember_SelectedIndexChanged">
                                    </telerik:RadComboBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblRequestType" runat="server" Visible="false"> Request Type</asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <telerik:RadComboBox ID="cmbFilterObjectMember" runat="server" HighlightTemplatedItems="True"
                                        Visible="false" MarkFirstMatch="True" radcontrolsdir="~/RadControls/" Skin="Office2007"
                                        skinspath="~/RadControls/ComboBox/Skins" Sort="None" Width="130px">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="right" style="padding-right: 15px;">
                                    <telerik:RadButton ID="btnSearch" OnClick="btnSearch_Click" runat="server" SkinID="RadButtonSearch"
                                        Skin="" EnableAjaxSkinRendering="False" />
                                    <telerik:RadButton ID="btnReset" runat="server" CausesValidation="False" OnClick="btnReset_Click"
                                        UseSubmitBehavior="False" SkinID="RadButtonReset" Skin="" EnableAjaxSkinRendering="False" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="block acc_target">
                <telerik:RadButton ID="btnApproved" runat="server" SkinID="ApproveAll" OnClientClicked="OnClientClickApproveAll"
                    Visible="false" OnClick="btnApprove_Click" />
                <telerik:RadButton ID="btnReject" SkinID="RejectAll" runat="server" OnClientClicked="OnClientClickRejectAll"
                    Visible="false" OnClick="btnReject_Click" />
                <telerik:RadButton ID="btnExportToExcel" runat="server" SkinID="RadButtonExportToExcel"
                    OnClick="OnExportToExcel" Skin="" EnableAjaxSkinRendering="False" />
                <div style="margin-bottom: 5px;">
                </div>
                <telerik:RadGrid ID="rgridApprovalLogList" runat="server" GridLines="None" OnItemDataBound="rgridApprovalLogList_ItemDataBound"
                    OnItemCommand="rgridApprovalLogList_ItemCommand" OnNeedDataSource="rgridApprovalLogList_NeedDataSource"
                    AllowMultiRowSelection="True">
                    <ClientSettings>
                        <Selecting AllowRowSelect="True"></Selecting>
                    </ClientSettings>
                    <MasterTableView DataKeyNames="ApprovalLogID" CommandItemDisplay="Top" EditMode="EditForms">
                        <CommandItemSettings ExportToPdfText="Export to PDF" ShowAddNewRecordButton="False"
                            ShowRefreshButton="False"></CommandItemSettings>
                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column">
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridClientSelectColumn Reorderable="False" UniqueName="ClientSelectColumn"
                                Visible="false">
                                <HeaderStyle Width="30px"></HeaderStyle>
                            </telerik:GridClientSelectColumn>
                            <telerik:GridTemplateColumn HeaderText="No" UniqueName="Number" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="15px" ItemStyle-CssClass="NumberColomn">
                                <ItemTemplate>
                                    <asp:Label ID="lblrgridNumber" runat="server" Text='<%# (rgridApprovalLogList.PageSize*rgridApprovalLogList.CurrentPageIndex)+ Container.ItemIndex + 1 %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="15px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Visible="False" SortExpression="ApprovalLogID" DataField="ApprovalLogID"
                                HeaderText="Approval Log ID" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblApprovalLogID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ApprovalLogID") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn SortExpression="RefID" Visible="false" DataField="RefID"
                                HeaderText="Ref ID" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblRefID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.RefID") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Visible="False" SortExpression="ModuleObjectMemberID"
                                DataField="ModuleObjectMemberID" HeaderText="Module Object Member ID" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblModuleObjectMemberID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ModuleObjectMemberID") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Visible="False" SortExpression="ModuleObjectID" DataField="ModuleObjectID"
                                HeaderText="Module Object ID" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblModuleObjectID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ModuleObjectID") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Visible="False" SortExpression="ApprovalStatusID" DataField="ApprovalStatusID"
                                HeaderText="Approval Status ID" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblApprovalStatusID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ApprovalStatusID") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn SortExpression="CreateDate" DataField="CreateDate" HeaderText="Request Date"
                                HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lblCreateDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CreateDate","{0:dd MMM yyyy}")== "01 Jan 1900" ?"-":DataBinder.Eval(Container.DataItem, "CreateDate","{0:dd MMM yyyy HH:mm:ss}") %>'
                                        CommandName="VIEW DETAIL" Font-Underline="true" ForeColor="Green" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="150px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn SortExpression="UpdateDate" DataField="UpdateDate" HeaderText="Approval Date"
                                HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdateDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UpdateDate","{0:dd MMM yyyy}")== "01 Jan 1900" ?"-":DataBinder.Eval(Container.DataItem, "UpdateDate","{0:dd MMM yyyy HH:mm:ss}") %>'
                                        ForeColor="Green" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="150px"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn SortExpression="CreateByUserID" DataField="CreateByUserID"
                                HeaderText="Request By" HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblCreateByUserID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CreateByUserName") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn SortExpression="UpdateByUserName" DataField="UpdateByUserName"
                                HeaderText="Approval By" HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblUpdateByUsername" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UpdateByUserName") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn SortExpression="ObjectName" DataField="ObjectName" HeaderText="Data"
                                HeaderStyle-Width="145px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblObjectName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ObjectName") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn SortExpression="MemberName" DataField="MemberName" HeaderText="Request Type"
                                HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblMemberName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MemberName") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Visible="false" SortExpression="Detail" DataField="Detail"
                                HeaderText="Detail" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblDetail" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Detail") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn SortExpression="Remark" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Left" DataField="Remark" HeaderText="Remark">
                                <ItemTemplate>
                                    <asp:Label ID="lblRemark" runat="server" Text='<%# (string)DataBinder.Eval(Container, "DataItem.Remark")=="NONE"?"-":DataBinder.Eval(Container, "DataItem.Remark") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn SortExpression="ApprovalStatusName" DataField="ApprovalStatusName"
                                HeaderStyle-HorizontalAlign="Center" HeaderText="Status" HeaderStyle-Width="80px"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblApprovalStatusName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ApprovalStatusName") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="EditColumn" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="80px" HeaderText="Action">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnApprovalAction" runat="server" Text='<%# Convert.ToString(DataBinder.Eval(Container, "DataItem.ApprovalStatusCode")).ToUpper() == "PENDING"?"APPROVAL":"" %>'
                                        CommandName="Approval" Font-Bold="true" Font-Underline="true" ForeColor="red"></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <CommandItemTemplate>
                            <telerik:RadToolBar ID="RadTBUser" runat="server" SkinID="Approval" />
                        </CommandItemTemplate>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                    </MasterTableView>
                    <FilterMenu EnableImageSprites="False">
                    </FilterMenu>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                    </HeaderContextMenu>
                </telerik:RadGrid>
            </div>
        </fieldset>
    </div>
    <telerik:RadAjaxManager ID="ram" runat="server" DefaultLoadingPanelID="ralp">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnApprove" />
                    <telerik:AjaxUpdatedControl ControlID="rgridApprovalLogList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnApprove">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgridApprovalLogList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnReject">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgridApprovalLogList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgridApprovalLogList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="btnApprove" />
                    <telerik:AjaxUpdatedControl ControlID="rgridApprovalLogList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="cmbFilterObjectCode">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="lblRequestType" />
                    <telerik:AjaxUpdatedControl ControlID="cmbFilterObjectMember" />
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
                </td>
                <td class="textfield">
                    <%# DataBinder.Eval(Container.DataItem, "CreateDate", "{0:dd MMM yyyy}") == "01 Jan 1900" ? "-" : DataBinder.Eval(Container.DataItem, "CreateDate", "{0:dd MMM yyyy}")%>
                </td>
                <td class="textfield">
                    <%# DataBinder.Eval(Container.DataItem, "UpdateDate", "{0:dd MMM yyyy}") == "01 Jan 1900" ? "-" : DataBinder.Eval(Container.DataItem, "UpdateDate", "{0:dd MMM yyyy}")%>
                </td>
                <td class="textfield">
                    <%# DataBinder.Eval(Container.DataItem, "CreateByUserName")%>
                </td>
                <%--<td align="center" class="textfield">
                    <%# DataBinder.Eval(Container.DataItem, "CycleName")%>
                </td>--%>
                <td class="textfield">
                    <%# DataBinder.Eval(Container.DataItem, "UpdateByUserName")%>
                </td>
                <td class="textfield">
                    <%# DataBinder.Eval(Container.DataItem, "ObjectName")%>
                </td>
                <td class="textfield">
                    <%# DataBinder.Eval(Container.DataItem, "MemberName")%>
                </td>
                <td class="textfield">
                    <%# DataBinder.Eval(Container.DataItem, "Remark") == "NONE" ? string.Empty : DataBinder.Eval(Container.DataItem, "Remark")%>
                </td>
                <td class="textfield">
                    <%# DataBinder.Eval(Container.DataItem, "ApprovalStatusName") %>
                </td>
            </tr>
        </ItemTemplate>
        <HeaderTemplate>
            <h2>
                Approval Log Report</h2>
            <label class="GridSubTitle_Office2007">
                Generated Date :
                <%# string.Format("{0:dd MMM yyyy}", DateTime.Now) %></label><br />
            <label class="GridSubTitle_Office2007">
                Generate By :
                <%# ((PFSHelper.BusinessLogicLayer.CustomPrincipal)System.Web.HttpContext.Current.User).User.UserName %></label><br />
            <table width="100%" class="MasterTable_Office2007" border="1" cellpadding="0" cellspacing="0">
                <tr class="MasterTable_Office2007">
                    <td class="GridHeader_Office2007">
                        No.
                    </td>
                    <td class="GridHeader_Office2007">
                        Request Date
                    </td>
                    <td class="GridHeader_Office2007">
                        Approval Date
                    </td>
                    <td class="GridHeader_Office2007">
                        Request By
                    </td>
                    <%--<td class="GridHeader_Office2007">
                        Cycle
                    </td>--%>
                    <td class="GridHeader_Office2007">
                        Approved By
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
                    <td class="GridHeader_Office2007">
                        Status
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
</asp:Content>
