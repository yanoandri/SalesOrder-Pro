<%@ Page Language="C#" MasterPageFile="~/SiteMaster/Default.master" AutoEventWireup="true"
    Inherits="PFSHelper.WebUI.UserLogList" Theme="skin" CodeBehind="UserLogList.aspx.cs" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentTitle" ContentPlaceHolderID="ContentTitle" runat="server">
    <h1 class="title">
        Security - Audit Trails
    </h1>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentDefault" runat="Server">
    <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
        <script type="text/javascript">
            function handleEnterEvent_datefrom(sender, args) {
                if (args.get_keyCode() == 13) {
                    $find("<%# btnSearch.ClientID %>").click();
                    __doPostBack('search', 'search_datefrom');

                }
            }
            function handleEnterEvent_dateto(sender, args) {
                if (args.get_keyCode() == 13) {
                    $find("<%# btnSearch.ClientID %>").click();
                    __doPostBack('search', 'search_dateto');

                }
            }

            function OnClientClicked(sender, eventArgs) {
                if (!confirm('Are you sure want to purge from database?')) {
                    eventArgs.preventDefault();
                }
            }

            function OnClientClicking(sender, args) {
                var callBackFunction = Function.createDelegate(sender, function (argument) {
                    if (argument) {
                        this.click();
                    }
                });
                var text = "Are you sure want to purge from database?";
                if (!confirm(text, callBackFunction, 300, 100, null, "Title")) {
                    args.set_cancel(true)
                };
            }
        </script>
    </telerik:RadCodeBlock>
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
                                <th width="23%">
                                </th>
                                <th width="12%">
                                </th>
                                <th width="48%">
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label ID="lblKeywords" runat="server">Keywords </asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="tbFilterKeywords" runat="server" CssClass="input-text" MaxLength="100"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblFilterUserName" runat="server"> User Name</asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <telerik:RadComboBox ID="cmbFilterUserName" runat="server" HighlightTemplatedItems="True"
                                        MarkFirstMatch="True" radcontrolsdir="~/RadControls/" Skin="Office2007" skinspath="~/RadControls/ComboBox/Skins"
                                        Sort="None" Width="150px">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblFilterLogDateFrom" runat="server">Log Date From </asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <telerik:RadDatePicker ID="calFilterLogDateFrom" runat="server" />
                                </td>
                                <td>
                                    <asp:Label ID="lblFilterMemberCode" runat="server"> Module</asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <telerik:RadComboBox ID="cmbFilterMemberCode" runat="server" HighlightTemplatedItems="True"
                                        MarkFirstMatch="True" radcontrolsdir="~/RadControls/" Skin="Office2007" skinspath="~/RadControls/ComboBox/Skins"
                                        Sort="None" Width="300px">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="To"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <telerik:RadDatePicker ID="calFilterLogDateTo" runat="server" />
                                </td>
                                <td>
                                </td>
                                <td style="text-align: left;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:CompareValidator ID="cvDate" runat="server" ControlToValidate="calFilterLogDateTo"
                                        ControlToCompare="calFilterLogDateFrom" Operator="GreaterThanEqual" ErrorMessage="Start Date cannot be greater than End Date" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="right" style="padding-right:15px;">
                                    <br />
                                    <telerik:RadButton ID="btnSearch" OnClick="btnSearch_Click" runat="server" SkinID="RadButtonSearch"
                                        Skin="" EnableAjaxSkinRendering="False">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnReset" runat="server" CausesValidation="False" OnClick="btnReset_Click"
                                        UseSubmitBehavior="False" SkinID="RadButtonReset" Skin="" EnableAjaxSkinRendering="False">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="block acc_target">
                <asp:Label ID="Label2" runat="server" ForeColor="Red">
                            Warning! All purged data will be deleted from database. Exporting to excel will
                            help you to maintain purged audit trail.
                </asp:Label>
                <br /><br />
                <telerik:RadButton Skin="" ID="btnExort" SkinID="RadButtonExportToExcel" runat="server"
                    OnClick="btnExport_Click" />
                <telerik:RadButton ID="btnPurge" SkinID="RadButtonPurge" runat="server" OnClientClicked="OnClientClicked"
                    Skin="" OnClick="btnPurge_Click">
                </telerik:RadButton>
                <div style="margin-bottom:5px;"></div>
                <telerik:RadGrid ID="rgridUserLogList" runat="server" OnItemDataBound="rgridUserLogList_ItemDataBound"
                    OnItemCommand="rgridUserLogList_ItemCommand" OnNeedDataSource="rgridUserLogList_NeedDataSource">
                    <MasterTableView DataKeyNames="UserLogID" CommandItemDisplay="None" CommandItemSettings-ShowAddNewRecordButton="false"
                        CommandItemSettings-ShowRefreshButton="false">
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="No" UniqueName="Number" ItemStyle-HorizontalAlign="Center"
                                HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="30px" ItemStyle-CssClass="NumberColomn">
                                <ItemTemplate>
                                    <asp:Label ID="lblrgridNumber" runat="server" Text='<%# (rgridUserLogList.PageSize*rgridUserLogList.CurrentPageIndex)+ Container.ItemIndex + 1 %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Visible="False" SortExpression="UserLogID" DataField="UserLogID"
                                HeaderStyle-HorizontalAlign="Center" HeaderText="User Log ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserLogID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UserLogID") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Visible="False" SortExpression="UserID" DataField="UserID"
                                HeaderStyle-HorizontalAlign="Center" HeaderText="User ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblUserID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UserID") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn SortExpression="UserName" DataField="UserName" HeaderText="User Name">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUserName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UserName") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn SortExpression="FullName" DataField="FullName" HeaderText="Full Name">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFullName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FullName") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn SortExpression="IpAddress" DataField="IpAddress" HeaderText="IP Address"
                                HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblIpAddress" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.IpAddress") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn SortExpression="LogDate" HeaderStyle-HorizontalAlign="Center"
                                DataField="LogDate" HeaderText="Log Date">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLogDate" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LogDate","{0:dd MMM yyyy}")== "01 Jan 1900" ?"-":DataBinder.Eval(Container.DataItem, "LogDate","{0:dd MMM yyyy, HH:mm:ss}") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn Visible="False" SortExpression="ModuleObjectMemberID"
                                DataField="ModuleObjectMemberID" HeaderText="Module Object Member ID" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblModuleObjectMemberID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ModuleObjectMemberID") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn SortExpression="ObjectName" DataField="ObjectName" HeaderText="Module">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMemberName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ObjectName") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn SortExpression="MemberName" DataField="MemberName" HeaderText="Activity">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblMemberDescr" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.MemberName") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn SortExpression="Status" DataField="Status" HeaderText="Success"
                                ItemStyle-HorizontalAlign="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblSuccessStatus" runat="server" Text='<%# Convert.ToInt16(DataBinder.Eval(Container, "DataItem.Status"))==1?"Yes":"No" %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn SortExpression="Description" DataField="Description"
                                HeaderText="Remark">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
        </fieldset>
    </div>
    
    <telerik:RadAjaxManager ID="ram" runat="server" DefaultLoadingPanelID="ralp">
        <ClientEvents />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgridUserLogList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgridUserLogList"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgridUserLogList"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnPurge">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgridUserLogList" LoadingPanelID="ralp"></telerik:AjaxUpdatedControl>
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralp" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <tr class="GridRow_Office2007">
                <td class="textfield" align="right">
                    <%# Container.ItemIndex + 1%>
                </td>
                <td align="center" class="textfield">
                    <%# DataBinder.Eval(Container.DataItem, "UserLogID")%>
                </td>
                <td align="center" class="textfield">
                    <%# DataBinder.Eval(Container.DataItem, "UserID")%>
                </td>
                <td class="textfield" align="center">
                    <%# DataBinder.Eval(Container.DataItem, "UserName")%>
                </td>
                <td class="textfield">
                    <%# DataBinder.Eval(Container.DataItem, "FullName")%>
                </td>
                <td class="textfield" align="center">
                    <%# DataBinder.Eval(Container.DataItem, "IpAddress")%>
                </td>
                <td class="textfield">
                    <%# DataBinder.Eval(Container.DataItem, "LogDate", "{0:dd MMM yyyy}") == "01 Jan 1900" ? "-" : DataBinder.Eval(Container.DataItem, "LogDate", "{0:dd MMM yyyy HH:mm:ss}")%>
                </td>
                <td class="textfield" align="center">
                    <%# DataBinder.Eval(Container.DataItem, "ModuleObjectMemberID")%>
                </td>
                <td class="textfield">
                    <%# DataBinder.Eval(Container.DataItem, "ObjectName")%>
                </td>
                <td class="textfield" align="right">
                    <%#DataBinder.Eval(Container.DataItem, "MemberName")%>
                </td>
                <td class="textfield" align="center">
                    <%# DataBinder.Eval(Container.DataItem, "Description")%>
                </td>
            </tr>
        </ItemTemplate>
        <HeaderTemplate>
            <h2>
                Audit Trail Report</h2>
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
                        User Log ID
                    </td>
                    <td class="GridHeader_Office2007">
                        User ID
                    </td>
                    <td class="GridHeader_Office2007">
                        Username
                    </td>
                    <td class="GridHeader_Office2007">
                        Full Name
                    </td>
                    <td class="GridHeader_Office2007">
                        IP Address
                    </td>
                    <td class="GridHeader_Office2007">
                        LogDate
                    </td>
                    <td class="GridHeader_Office2007">
                        Module Object Member ID
                    </td>
                    <td class="GridHeader_Office2007">
                        ObjectName
                    </td>
                    <td class="GridHeader_Office2007">
                        Member Name
                    </td>
                    <td class="GridHeader_Office2007">
                        Description
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
