<%@ Page Language="C#" AutoEventWireup="true" Inherits="Security_GroupList" MasterPageFile="~/SiteMaster/Default.master"
    Theme="skin" CodeBehind="GroupList.aspx.cs" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentTitle" ContentPlaceHolderID="ContentTitle" runat="server">
    <h1 class="title">
        Security - Group List
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
                                    <asp:Label ID="lblKeywords" runat="server" EnableViewState="false" CssClass="Label">Keywords</asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtFilterKeywords" runat="server" MaxLength="100" CssClass="TextBox"
                                        OnTextChanged="btnFilterSearch_Click">
                                    </asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" EnableViewState="false" CssClass="Label">Active Status</asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="DropDownList">
                                        <asp:ListItem Value="-1" Selected="True">All</asp:ListItem>
                                        <asp:ListItem Value="true">Active</asp:ListItem>
                                        <asp:ListItem Value="false">Non Active</asp:ListItem>
                                    </asp:DropDownList>
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
                                    <br />
                                    <telerik:RadButton ID="btnFilterSearch" OnClick="btnFilterSearch_Click" runat="server"
                                        CssClass="ButtonSearch" SkinID="RadButtonSearch" Skin="" CausesValidation="false">
                                    </telerik:RadButton>
                                    <telerik:RadButton ID="btnReset" runat="server" CssClass="ButtonReset" CausesValidation="False"
                                        OnClick="btnReset_Click" UseSubmitBehavior="False" SkinID="RadButtonReset" Skin="">
                                    </telerik:RadButton>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="block acc_target">
                
                <telerik:RadButton ID="btnExportToExcel" SkinID="RadButtonExportToExcel" Skin=""
                    runat="server" OnClick="btnExportToExcel_Click">
                </telerik:RadButton>
                <telerik:RadButton SkinID="RadButtonCreateNewGroup" Skin="" Text="Create New Group"
                    ID="btnCreateNewGroup" runat="server" CommandName="Insert" ToolTip="Create New Group"
                    OnClick="btnCreateNewGroup_Click">
                </telerik:RadButton>
                <div style="margin-bottom:5px;"></div>
                <telerik:RadGrid ID="rgridGroupList" runat="server" Skin="Telerik" OnNeedDataSource="rgridGroupList_NeedDataSource"
                    OnItemCommand="rgridGroupList_ItemCommand" OnItemDataBound="rgridGroupList_ItemDataBound">
                    <MasterTableView DataKeyNames="GroupID" CommandItemDisplay="Top">
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="No." UniqueName="Number" ItemStyle-CssClass="NumberColomn">
                                <HeaderStyle Width="30px" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:Label ID="lblrgridNumber" runat="server" Text='<%# (rgridGroupList.PageSize*rgridGroupList.CurrentPageIndex)+ Container.ItemIndex + 1 %>'></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn" HeaderText="ID" Visible="False"
                                SortExpression="GroupID" DataField="GroupID" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblGroupID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GroupID") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn1" HeaderText="Group Name"
                                SortExpression="GroupName">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label ID="lblGroupName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GroupName") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGroupName" runat="server" MaxLength="50" Width="200px" Text='<%# DataBinder.Eval(Container, "DataItem.GroupName") %>'
                                        ForeColor="Black"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Group name is required"
                                        ControlToValidate="txtGroupName" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn2" HeaderText="Description"
                                SortExpression="GroupDescr">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <asp:Label ID="lblGroupDescr" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GroupDescr") %>'>
                                    </asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtGroupDescr" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GroupDescr") %>'
                                        ForeColor="Black" Width="300px" MaxLength="300"></asp:TextBox>
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Is Active" UniqueName="IsActive" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbIsActive" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(DataBinder.Eval(Container, "DataItem.IsActive")) %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="cbIsActive" runat="server" Checked='<%#  Convert.ToBoolean(Convert.IsDBNull(DataBinder.Eval(Container, "DataItem.IsActive"))?false:DataBinder.Eval(Container, "DataItem.IsActive")) %>' />
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn4" HeaderText="Member" HeaderStyle-HorizontalAlign="Center"
                                SortExpression="TotalUser">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbMember" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TotalUser") %>'
                                        CommandName="Member" Font-Bold="true" Font-Underline="true" ForeColor="blue" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderStyle-Width="100px" UniqueName="TemplateColumn3"
                                HeaderText="Access Right">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnAccessRight" runat="server" CommandName="AccessRight" ImageUrl="~/App_Themes/Default/images/icons/ico_access_right.png" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderStyle-HorizontalAlign="Center" HeaderText="Need Approval"
                                Visible="false" UniqueName="IsNeedApproval">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbIsNeedApproval" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(DataBinder.Eval(Container, "DataItem.IsNeedApproval")) %>' />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="cbIsNeedApproval" runat="server" Checked='<%# Convert.ToBoolean(Convert.IsDBNull(DataBinder.Eval(Container, "DataItem.IsNeedApproval"))?false:true) %>' />
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Action" UniqueName="Action">
                                <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEdit" runat="server" SkinID="Edit" CommandName="Edit" />
                                    <asp:ImageButton ID="btnDelete" runat="server" SkinID="Delete" CommandName="Delete"
                                        OnClientClick="javascript:return confirm('Are you sure want to delete?')" />
                                    <asp:Label ID="lblNeedApproval" runat="server" Text='Need Approval' Visible='<%# Convert.ToBoolean(DataBinder.Eval(Container, "DataItem.IsNeedApproval")) %>'
                                        ForeColor="Red"></asp:Label>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:ImageButton ID="btnSave" runat="server" SkinID="Save" OnClientClick="if(!confirm('Are you sure want to save this?')) return false;"
                                        CommandName='<%# Convert.ToInt32(Convert.IsDBNull(DataBinder.Eval(Container, "DataItem.GroupID"))?0:DataBinder.Eval(Container, "DataItem.GroupID")) == 0 ? "PerformInsert" : "Update" %>' />
                                    <asp:ImageButton ID="btnCancel" runat="server" SkinID="Cancel" CommandName="Cancel"
                                        CausesValidation="false" />
                                </EditItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                        <CommandItemTemplate>
                            <telerik:RadToolBar ID="RadTBGroup" runat="server" SkinID="NewAndExport" Width="100%" />
                        </CommandItemTemplate>
                        <ExpandCollapseColumn Resizable="False" Visible="False">
                            <HeaderStyle Width="20px" />
                        </ExpandCollapseColumn>
                        <RowIndicatorColumn Visible="False">
                            <HeaderStyle Width="20px" />
                        </RowIndicatorColumn>
                    </MasterTableView>
                </telerik:RadGrid>
            </div>
            <div style="text-align: center;">
                <asp:ValidationSummary ID="vsInput" runat="server" />
            </div>
        </fieldset>
    </div>
    <telerik:RadAjaxManager ID="ramGroupList" runat="server" DefaultLoadingPanelID="ralp">
        <ClientEvents OnRequestStart="onRequestStart" />
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="RadTBGroup">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgridGroupList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnFilterSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgridGroupList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="rgridGroupList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgridGroupList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnReset">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgridGroupList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <%--<telerik:AjaxSetting
    AjaxControlID="ram"> <UpdatedControls> <telerik:AjaxUpdatedControl ControlID="rgridGroupList"
    /> </UpdatedControls> </telerik:AjaxSetting>--%>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralp" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <script type="text/javascript">        function onRequestStart(sender, args) {
            if (args.get_eventTarget().indexOf("RadTBGroup")
    >= 0) { args.set_enableAjax(false); }
        } </script>
    <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <tr class="GridRow_Office2007">
                <td align="center" class="textfield">
                    <%# Container.ItemIndex + 1%>
                </td>
                <td class="textfield">
                    <%# DataBinder.Eval(Container.DataItem,
    "GroupName") %>
                </td>
                <td class="textfield">
                    <%# DataBinder.Eval(Container.DataItem,
    "GroupDescr")%>
                </td>
                <td class="textfield">
                    <%# Convert.ToBoolean(DataBinder.Eval(Container.DataItem,
    "IsActive"))?"Active":"Not Active" %>
                </td>
                <td class="textfield">
                    <%# DataBinder.Eval(Container.DataItem,
    "TotalUser")%>
                </td>
            </tr>
        </ItemTemplate>
        <HeaderTemplate>
            <h2>
                Group List Report</h2>
            <label class="GridSubTitle_Office2007">
                Generated Date :<%# string.Format("{0:dd MMM yyyy}", DateTime.Now) %></label><br />
            <label class="GridSubTitle_Office2007">
                Generated By :<%# ((PFSHelper.BusinessLogicLayer.CustomPrincipal)System.Web.HttpContext.Current.User).User.UserName
                %></label><br />
            <table width="100%" class="MasterTable_Office2007" border="1">
                <tr class="MasterTable_Office2007">
                    <td class="GridHeader_Office2007">
                        No.
                    </td>
                    <td class="GridHeader_Office2007">
                        Group Name
                    </td>
                    <td class="GridHeader_Office2007">
                        Description
                    </td>
                    <td class="GridHeader_Office2007">
                        Active Status
                    </td>
                    <td class="GridHeader_Office2007">
                        Member Number
                    </td>
                </tr>
        </HeaderTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Literal ID="litCss" runat="server"> <style type="text/css">
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
                                                     padding-left: 6px; /*more than items to compensate
    for item borders!*/
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
                                             </style> </asp:Literal>
</asp:Content>
