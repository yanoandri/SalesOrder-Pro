<%@ Page Language="C#" AutoEventWireup="true" Inherits="Security_UserList" MasterPageFile="~/MasterPages/Default.master"
    CodeBehind="UserList.aspx.cs" Theme="skin" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentTitle" ContentPlaceHolderID="ContentTitle" runat="server">
    <h1 class="title">
        Security - User List
    </h1>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentDefault" runat="server">
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
                                    <asp:Label ID="lblKeywords" runat="server" EnableViewState="false">Keywords</asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtFilterKeywords"  runat="server" CssClass="input-text"
                                        MaxLength="200" OnTextChanged="btnFilterSearch_Click" AutoPostBack="true"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" EnableViewState="false">Active Status</asp:Label></dt>
                                </td>
                                <td style="text-align: left;">
                                    <asp:DropDownList ID="ddlStatus" runat="server">
                                        <asp:ListItem Value="-1" Selected="True">All</asp:ListItem>
                                        <asp:ListItem Value="true">Active</asp:ListItem>
                                        <asp:ListItem Value="false">Non Active</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblGroup" runat="server" EnableViewState="false">Groups</asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:DropDownList ID="ddlGroup" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
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
                                <td align="right" style="padding-right:15px;">
                               
                                    <telerik:RadButton ID="btnFilterSearch" OnClick="btnFilterSearch_Click" runat="server"
                                        Skin="" EnableAjaxSkinRendering="False" SkinID="RadButtonSearch" />
                                    <telerik:RadButton ID="btnReset" runat="server" CausesValidation="False" OnClick="btnReset_Click"
                                        Skin="" UseSubmitBehavior="False" SkinID="RadButtonReset" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="block acc_target">
                <telerik:RadButton ID="btnExportToExcel" runat="server" OnClick="btnExportToExcel_Click"
                    Skin="" SkinID="RadButtonExportToExcel" />
                <telerik:RadButton ID="btnCreateNewUser" runat="server" PostBackUrl="~/Security/UserInput.aspx?UserID=-1"
                    Skin="" SkinID="RadButtonCreateNewUser" />
                <div style="margin-bottom:5px;"></div>
                <telerik:RadGrid ID="rgridUserList" runat="server" GridLines="None" OnNeedDataSource="rgridUserList_NeedDataSource"
                    OnItemCommand="rgridUserList_ItemCommand" Skin="Telerik" OnItemDataBound="rgridUserList_ItemDataBound">
                    <ClientSettings>
                        <Selecting AllowRowSelect="True"></Selecting>
                    </ClientSettings>
                    <MasterTableView DataKeyNames="UserID" CommandItemDisplay="Top">
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="No." UniqueName="Number" ItemStyle-CssClass="NumberColomn">
                                <HeaderStyle Width="30px" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblGridNumber" runat="server" Text='<%# (rgridUserList.PageSize*rgridUserList.CurrentPageIndex)+ Container.ItemIndex + 1 %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="User Name" UniqueName="UserName" SortExpression="UserName">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:HyperLink ID="hlUserName" Font-Underline="true" runat="server"><%# DataBinder.Eval(Container, "DataItem.UserName") %></asp:HyperLink>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Full Name" UniqueName="FullName" SortExpression="FullName">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label ID="lblFullName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FullName") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Email" UniqueName="Email" SortExpression="Email">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail" SkinID="EmailColor" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Email") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="User Group" UniqueName="UserGroupItem" SortExpression="UserGroupItem">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label ID="lblUserGroup" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.UserGroupItem") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Is Active" UniqueName="IsActive" SortExpression="IsActive"
                                HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbIsActive" runat="server" Enabled="false" Checked='<%# DataBinder.Eval(Container, "DataItem.IsActive") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Created By" UniqueName="CreatedBy" SortExpression="CreatedBy"
                                HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblCreatedBy" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CreatedByName") %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Last Access" UniqueName="LastAccess" SortExpression="LastAccess"
                                HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblLastAccess" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LastAccess","{0:dd-MM-yyyy hh:mm tt}") %>' />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Need Approval" Visible="false" UniqueName="IsNeedApproval"
                                HeaderStyle-HorizontalAlign="Center" SortExpression="IsNeedApproval">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbIsNeedApproval" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.IsNeedApproval") %>'>
                                    </asp:CheckBox>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Action" UniqueName="Action">
                                <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEdit" runat="server" SkinID="Edit" CommandName="Edit" Visible='<%# !(bool)DataBinder.Eval(Container, "DataItem.IsNeedApproval") %>' />
                                    <asp:ImageButton ID="btnDelete" runat="server" SkinID="Delete" CommandName="Delete"
                                        Visible='<%# !(bool)DataBinder.Eval(Container, "DataItem.IsNeedApproval") %>'
                                        OnClientClick="javascript:return confirm('Are you sure want to delete?')" />
                                    <asp:Label ID="lblNeedApproval" runat="server" Text='Need Approval' Visible='<%# DataBinder.Eval(Container, "DataItem.IsNeedApproval") %>'
                                        ForeColor="Red"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <CommandItemTemplate>
                            <telerik:RadToolBar ID="RadTBUser" runat="server" SkinID="NewAndExport" />
                        </CommandItemTemplate>
                        <ExpandCollapseColumn Visible="False" Resizable="False">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                        <EditFormSettings>
                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                            </EditColumn>
                        </EditFormSettings>
                        <PagerStyle AlwaysVisible="True" Mode="NextPrevNumericAndAdvanced"></PagerStyle>
                    </MasterTableView>
                    <HeaderStyle HorizontalAlign="Center" />
                    <FilterMenu EnableImageSprites="False">
                    </FilterMenu>
                    <HeaderContextMenu CssClass="GridContextMenu GridContextMenu_Default">
                    </HeaderContextMenu>
                </telerik:RadGrid>
            </div>
        </fieldset>
    </div>
    <telerik:RadAjaxManager ID="ramUserList" runat="server" DefaultLoadingPanelID="ralp">
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadTBUser">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgridUserList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnFilterSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgridUserList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgridUserList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgridUserList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralp" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <script type="text/javascript">
        function onRequestStart(sender, args) {
            if (args.get_eventTarget().indexOf("RadTBUser") >= 0) {
                args.set_enableAjax(false);
            }
        }
    </script>
    <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <tr class="GridRow_Office2007">
                <td align="center" class="textfield">
                    <%# Container.ItemIndex + 1%>
                    &nbsp;
                </td>
                <td class="textfield">
                    <%# DataBinder.Eval(Container.DataItem, "UserName")%>
                </td>
                <td class="textfield">
                    <%# DataBinder.Eval(Container.DataItem, "FullName")%>
                </td>
                <td class="textfield">
                    <%# DataBinder.Eval(Container.DataItem, "Email")%>
                </td>
                <td class="textfield">
                    <%# DataBinder.Eval(Container.DataItem, "UserGroupItem")%>
                </td>
                <td class="textfield">
                    <%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem, "IsActive"))?"Active":"Not Active" %>
                </td>
                <td class="textfield">
                    <%# DataBinder.Eval(Container.DataItem, "CreatedByName")%>
                </td>
                <td class="textfield">
                    <%# DataBinder.Eval(Container.DataItem, "LastAccess", "{0:dd-MM-yyyy hh:mm tt}")%>
                </td>
            </tr>
        </ItemTemplate>
        <HeaderTemplate>
            <h2>
                User List Report</h2>
            <label class="GridSubTitle_Office2007">
                Generated Date :<%# string.Format("{0:dd MMM yyyy}", DateTime.Now) %></label><br />
            <label class="GridSubTitle_Office2007">
                Generated By :<%# ((PFSHelper.BusinessLogicLayer.CustomPrincipal)System.Web.HttpContext.Current.User).User.UserName %></label><br />
            <table width="100%" class="MasterTable_Office2007" border="1">
                <tr class="MasterTable_Office2007">
                    <td class="GridHeader_Office2007">
                        No.
                    </td>
                    <td class="GridHeader_Office2007">
                        User Name
                    </td>
                    <td class="GridHeader_Office2007">
                        Full Name
                    </td>
                    <td class="GridHeader_Office2007">
                        Email
                    </td>
                    <td class="GridHeader_Office2007">
                        Group
                    </td>
                    <td class="GridHeader_Office2007">
                        Active Status
                    </td>
                    <td class="GridHeader_Office2007">
                        Created By
                    </td>
                    <td class="GridHeader_Office2007">
                        Last Access
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
