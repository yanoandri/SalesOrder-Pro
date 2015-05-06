<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Default.master" AutoEventWireup="true" CodeBehind="ChangeUserInfo.aspx.cs" Inherits="PSC.Web.UI.ChangeUserInfo" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentTitle" ContentPlaceHolderID="ContentTitle" runat="server">
    <div class="title left">
        <div class="icon left">
            <img id="imgTitleIcon" runat="server" src="../App_Themes/Default/images/background/security-title.jpg" alt="" />
        </div>
        <div class="text left">
            <h1 id="divTitle" runat="server">Security User Info
            </h1>
        </div>
        <br clear="all" />
    </div>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentDefault" runat="server">
    <asp:ValidationSummary ID="vsInput" runat="server" />
    <asp:ValidationSummary ID="vsRemark" runat="server" ValidationGroup="RejectionNote" />
    <script type="text/javascript">
        function ClickSave(sender, args) {
            var callBackFunction = Function.createDelegate(sender, function (argument) {
                if (argument) {
                    this.click();
                }
            });
            var text = "Are you sure want to save this";
            if (!confirm(text, callBackFunction, 300, 100, null, "Title")) {
                args.set_cancel(true)
            };
        }
    </script>
    <div class="frame_lv1">
        <div class="title">
            <h3>User Input
            </h3>
        </div>
        <div style="margin-top: -11px;">
        </div>
        <div class="form-table">
            <table width="100%" style="margin: 5px 0px 5px 0px;" cellpadding="0" cellspacing="0">
                <tr>
                    <td id="tdUserData" runat="server" style="width: 50%; padding-right: 5px;">
                        <div class="body-content-left left">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="frame_lv2-title">User Information
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frame_lv2-content">
                                        <table width="100%" border="0" cellspacing="0" class="trClass" cellpadding="1">
                                            <tr id="trRequiredFieldsLabel" runat="server">
                                                <td class="frame_lv2-leftcolumn">
                                                    <span class="RequiredField">*) Required</span>
                                                </td>
                                                <td class="frame_lv2-rightcolumn" colspan="2"></td>
                                            </tr>
                                            <tr class="Label">
                                                <td width="150px" class="frame_lv2-leftcolumn">
                                                    <span>Active Status</span>
                                                </td>
                                                <td class="frame_lv2-rightcolumn" colspan="2">
                                                    <asp:Label ID="lblActiveStatus" runat="server" SkinID="LabelData"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="Label">
                                                <td width="150px" class="frame_lv2-leftcolumn">
                                                    <span>Blocked Status</span>
                                                </td>
                                                <td class="frame_lv2-rightcolumn" colspan="2">
                                                    <asp:Label ID="lblBlockedStatus" runat="server" SkinID="LabelData"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="Label">
                                                <td class="frame_lv2-leftcolumn">
                                                    <span>User Name</span>
                                                </td>
                                                <td class="frame_lv2-rightcolumn" style="width: 210px;">
                                                    <asp:Label ID="lblUsername" runat="server" SkinID="LabelData"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="Label">
                                                <td class="frame_lv2-leftcolumn">
                                                    <span>Full Name <span class="RequiredField">*</span></span>
                                                </td>
                                                <td class="frame_lv2-rightcolumn">
                                                    <asp:TextBox ID="txtFullName" runat="server" CssClass="textbox" Width="200px" MaxLength="200"></asp:TextBox>
                                                    <asp:Label ID="lblFullName" runat="server" SkinID="LabelData"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtFullName"
                                                        ErrorMessage="Full Name is required" Display="Dynamic" CssClass="Validation" ForeColor="Red"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr class="Label">
                                                <td class="frame_lv2-leftcolumn">
                                                    <span>Title/Position</span>
                                                </td>
                                                <td class="frame_lv2-rightcolumn" colspan="2">
                                                    <asp:TextBox ID="txtTitle" runat="server" CssClass="textbox" Width="200px" MaxLength="50"></asp:TextBox>
                                                    <asp:Label ID="lblTitle" runat="server" SkinID="LabelData"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr class="Label">
                                                <td class="frame_lv2-leftcolumn">
                                                    <span>Email <span class="RequiredField">*</span></span>
                                                </td>
                                                <td class="frame_lv2-rightcolumn">
                                                    <asp:TextBox ID="txtEmail" ForeColor="Blue" runat="server" CssClass="textbox" Width="200px"
                                                        MaxLength="200"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email Format"
                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail"
                                                        Display="Dynamic" ForeColor="Red"></asp:RegularExpressionValidator>
                                                    <asp:Label ID="lblEmail" runat="server" SkinID="LabelData"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                                                        Display="Dynamic" ErrorMessage="Email is required"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr class="Label">
                                                <td class="frame_lv2-leftcolumn">Start Login Time
                                                </td>
                                                <td class="frame_lv2-rightcolumn">
                                                    <asp:Label ID="lblStartLoginTime" runat="server" SkinID="LabelData" />
                                                </td>
                                            </tr>
                                            <tr class="Label">
                                                <td class="frame_lv2-leftcolumn">End Login Time
                                                </td>
                                                <td class="frame_lv2-rightcolumn">
                                                    <asp:Label ID="lblEndLoginTime" runat="server" SkinID="LabelData" />
                                                </td>
                                            </tr>
                                            <tr class="Label">
                                                <td class="frame_lv2-leftcolumn">Login on holidays
                                                </td>
                                                <td class="frame_lv2-rightcolumn" colspan="2">
                                                    <asp:Label ID="lblHolidayLogin" runat="server" SkinID="LabelData" />
                                                </td>
                                            </tr>
                                            <tr id="trChangePassword" runat="server" class="Label">
                                                <td class="frame_lv2-leftcolumn"></td>
                                                <td id="tdChangePassword" class="frame_lv2-rightcolumn">
                                                    <asp:CheckBox ID="cbChangePassword" runat="server" Text="Change Password" OnCheckedChanged="cbChangePassword_CheckedChanged"
                                                        AutoPostBack="true" />
                                                </td>
                                            </tr>
                                            <tr id="trPassword" runat="server" class="Label">
                                                <td class="frame_lv2-leftcolumn">
                                                    <span>Password<span class="RequiredField">*</span></span>
                                                </td>
                                                <td class="frame_lv2-rightcolumn">
                                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox" Width="200px" MaxLength="50"
                                                        TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvtxtPassword" runat="server" ControlToValidate="txtPassword"
                                                        Display="Dynamic" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
                                                    <asp:Label ID="lblPassword" runat="server" SkinID="LabelData"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="trPasswordConfirm" runat="server" class="Label">
                                                <td class="frame_lv2-leftcolumn">
                                                    <span>Confirm Password<span class="RequiredField">*</span></span>
                                                </td>
                                                <td class="frame_lv2-rightcolumn">
                                                    <asp:TextBox ID="txtPasswordConfirm" runat="server" CssClass="textbox" Width="200px"
                                                        MaxLength="50" TextMode="Password"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvtxtPasswordConfirm" runat="server" CssClass="Validation"
                                                        ControlToValidate="txtPasswordConfirm" Display="Dynamic" ForeColor="Red" ErrorMessage="Password is required"></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="cvPasswordComfirm" runat="server" ErrorMessage="Incorrect confirm password"
                                                        ControlToValidate="txtPasswordConfirm" ControlToCompare="txtPassword" Operator="Equal"></asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr id="trLastAccess" runat="server" class="Label">
                                                <td class="frame_lv2-leftcolumn">
                                                    <span>Last Access</span>
                                                </td>
                                                <td class="frame_lv2-rightcolumn">
                                                    <asp:Label ID="lblLastAccess" runat="server" Text="-" CssClass="Label" SkinID="LabelData"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
            <table id="Table1" width="100%" runat="server" style="margin: 5px 0px 5px 0px;" cellpadding="0"
                cellspacing="0">
                <tr>
                    <td id="tdUserGroupData" runat="server" style="width: 50%; padding-right: 5px;">
                        <div class="body-content-left left">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="frame_lv2-title">Group Access
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frame_lv2-content">
                                        <table style="width: 96%;">
                                            <tr>
                                                <td>
                                                    <table id="Table6" width="100%" border="0">
                                                        <tr id="trAddAuthGroup" runat="server" class="Label">
                                                            <td style="width: 50px;" class="Label">
                                                                <span>Group</span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <telerik:RadGrid ID="rgridAuthGroup" runat="server" SkinID="GridInput">
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
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div class="footer-top" style="text-align: center">
            <telerik:RadButton ID="btnSave" OnClick="btnSave_Click" runat="server" SkinID="RadButtonSave" OnClientClicking="ClickSave" />
            <telerik:RadButton ID="btnCancel" EnableViewState="false" OnClick="btnCancel_Click"
                runat="server" SkinID="RadButtonCancel" CausesValidation="false" />
        </div>
    </div>
    <telerik:RadAjaxManager ID="ramUserInput" runat="server" DefaultLoadingPanelID="ralp">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgridAuthGroup">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgridAuthGroup" />
                    <telerik:AjaxUpdatedControl ControlID="cmbAuthGroup" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralp" runat="server">
    </telerik:RadAjaxLoadingPanel>
</asp:Content>
