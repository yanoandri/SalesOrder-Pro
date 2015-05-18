<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster/Default.master" AutoEventWireup="true"
    CodeBehind="UserDetail.aspx.cs" Inherits="SO.UserDetail" Theme="skin" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentTitle" ContentPlaceHolderID="ContentTitle" runat="server">
    <h1 class="title">
        Security - User Detail</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentDefault" runat="server">
    <div class="accordion_field">
        <div class="accordion_field">
            <fieldset class="acc_wrap">
                <div class="block acc_target">
                    <table style="width:450px;" border="0" cellspacing="0" class="trClass" cellpadding="1">
                        <tr>
                            <td style="width: 150px;">
                                <span>Active Status</span>
                            </td>
                            <td style="width: 10px;">
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblActiveStatus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px;">
                                <span>Blocked Status</span>
                            </td>
                            <td style="width: 10px;">
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblBlockedStatus" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px;">
                                <span>User Name</span>
                            </td>
                            <td style="width: 10px;">
                                :
                            </td>
                            <td style="width: 210px;">
                                <asp:Label ID="lblUsername" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px;">
                                <span>Full Name</span>
                            </td>
                            <td style="width: 10px;">
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblFullName" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px;">
                                <span>Branch</span>
                            </td>
                            <td style="width: 10px;">
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblBranchCode" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px;">
                                <span>Title/Position</span>
                            </td>
                            <td style="width: 10px;">
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblTitle" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px;">
                                <span>Email</span>
                            </td>
                            <td style="width: 10px;">
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblEmail" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px;">
                                Start Login Time
                            </td>
                            <td style="width: 10px;">
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblStartLoginTime" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px;">
                                End Login Time
                            </td>
                            <td style="width: 10px;">
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblEndLoginTime" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px;">
                                Login on holidays
                            </td>
                            <td style="width: 10px;">
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblHolidayLogin" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px;">
                                <span>Last Access</span>
                            </td>
                            <td style="width: 10px;">
                                :
                            </td>
                            <td>
                                <asp:Label ID="lblLastAccess" runat="server" Text="-" CssClass="Label"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="width: 420px;" class="block acc_target">
                    <telerik:RadGrid ID="rgridAuthGroup" runat="server" SkinID="RadGridWithoutPaging"
                        OnNeedDataSource="rgridAuthGroup_NeedDataSource">
                        <MasterTableView DataKeyNames="UserGroupID" CommandItemDisplay="None" CommandItemSettings-ShowAddNewRecordButton="false"
                            CommandItemSettings-ShowRefreshButton="false">
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="No" UniqueName="Number" ItemStyle-CssClass="NumberColomn">
                                    <HeaderStyle Width="50px" HorizontalAlign="Center" />
                                    <ItemStyle Width="50px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblrgridNumber" runat="server" Text="<%# (rgridAuthGroup.PageSize*rgridAuthGroup.CurrentPageIndex)+ Container.ItemIndex + 1 %>">
                                        </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="ID" UniqueName="GroupID" Visible="False"
                                    SortExpression="GroupID" DataField="GroupID" HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGroupID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GroupID") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Group Name" HeaderStyle-HorizontalAlign="Center"
                                    UniqueName="GroupName" SortExpression="GroupName">
                                    <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblGroupName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GroupName") %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </fieldset>
            <div style="width: 100%; text-align: center;">
                <br />
                <telerik:RadButton ID="btnBack" SkinID="RadButtonBack" Skin="" OnClick="btnCancel_Click"
                    runat="server" CausesValidation="False" />
            </div>
        </div>
    </div>
    <telerik:RadAjaxManager ID="ramUserInput" runat="server" DefaultLoadingPanelID="ralp">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgridAuthGroup">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgridAuthGroup" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralp" runat="server">
    </telerik:RadAjaxLoadingPanel>
</asp:Content>
