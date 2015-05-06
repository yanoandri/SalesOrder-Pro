<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="UserControls_Security_ChangePassword" Codebehind="ChangePassword.ascx.cs" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<div class="Title">
    :: Change Password
</div>
<fieldset>
    <legend>Changing Your Password</legend>
    <fieldset>
        <legend>Old Password</legend>
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr class="Label">
                <td style="width: 120px">
                    Old Password<span class="RequiredField">*</span>
                </td>
                <td style="width: 5px">
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtOldPassword" runat="server" CssClass="textbox" Width="200px"
                        MaxLength="50" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtOldPassword"
                        Display="Dynamic" ErrorMessage="Required" ValidationGroup="ChangePassword" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>New Password</legend>
        <table width="100%" cellpadding="0" cellspacing="0" border="0" class="Label">
            <tr id="trPassword" runat="server" class="Label">
                <td style="width: 120px">
                    New Password<span class="RequiredField">*</span>
                </td>
                <td style="width: 5px">
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtNewPassword" runat="server" CssClass="textbox" Width="200px"
                        MaxLength="50" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNewPassword"
                        Display="Dynamic" ErrorMessage="Required" ValidationGroup="ChangePassword" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr id="trPasswordConfirm" runat="server" valign="top" class="Label">
                <td>
                    Confirm New Password<span class="RequiredField">*</span>
                </td>
                <td>
                    :
                </td>
                <td>
                    <asp:TextBox ID="txtNewPasswordConfirm" runat="server" CssClass="textbox" Width="200px"
                        MaxLength="50" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" CssClass="Validation"
                        ControlToValidate="txtNewPasswordConfirm" Display="Dynamic" ErrorMessage="Required"
                        ValidationGroup="ChangePassword" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvPasswordComfirm" runat="server" ErrorMessage="Incorrect confirm password"
                        ControlToValidate="txtNewPasswordConfirm" ControlToCompare="txtNewPassword" Operator="Equal"
                        ValidationGroup="ChangePassword"></asp:CompareValidator>
                </td>
            </tr>
        </table>
    </fieldset>
    <div style="padding-top: 10px;">
        <asp:Button ID="btnSave" runat="server" CssClass="Button" Text="Save" CausesValidation="True"
            EnableViewState="false" OnClick="btnSave_Click" ValidationGroup="ChangePassword">
        </asp:Button></div>
</fieldset>
<telerik:RadAjaxManager ID="ramChangePassword" runat="server" DefaultLoadingPanelID="ralp">
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="ralp" runat="server">
</telerik:RadAjaxLoadingPanel>
