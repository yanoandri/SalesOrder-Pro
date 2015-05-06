<%@ Page Language="C#" AutoEventWireup="true" Inherits="PSC.Web.UI.Login" MasterPageFile="~/MasterPages/Login.master"
    CodeBehind="Login.aspx.cs" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentDefault" runat="server">
    <script type="text/javascript">
        function ShowProgress() {
            setTimeout(function () {
                var modal = $('<div />');
                modal.addClass("modal");
                $('body').append(modal);
                var loading = $(".loading");
                loading.show();
                var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
                var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
                loading.css({ top: top, left: left });
            }, 200);
        }

    </script>
    <style type="text/css">
        input[type="radio"]
        {
            margin-left: 4px;
        }
        
        .login-box .single table td
        {
            padding: 5px;
        }
    </style>
    <div class="span_12">
        <div class="login-box">
            <div class="single">
                <asp:MultiView ID="viewLogin" runat="server">
                    <asp:View ID="vLogin" runat="server">
                        <h2>
                            PSC - Login</h2>
                        <span>Please enter your ANZ network (Windows)<br />
                            Username and Password to log in</span>
                        <table id="tblLogin" runat="server">
                            <tr id="trDomian" runat="server">
                                <td style="font-size:14px; padding:0; padding-left:5px;">
                                   Domain Name
                                </td>
                            </tr>
                            <tr id="trActiveDirectory" runat="server">
                                <td>
                                    <asp:PlaceHolder ID="phDomainName" runat="server"></asp:PlaceHolder>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="block">
                                        <i class="icon sprites-user"></i>
                                        <asp:TextBox ID="txtUserName" Style="vertical-align: middle !important;" placeholder="Username"
                                            runat="server" MaxLength="100" TabIndex="1" CssClass="input-text"></asp:TextBox>
                                    </label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="block">
                                        <i class="icon sprites-key"></i>
                                        <asp:TextBox ID="txtPassword" runat="server" MaxLength="100" TabIndex="2" CssClass="input-text"
                                            placeholder="Password" TextMode="Password"></asp:TextBox>
                                    </label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="#" style="display: none">Forget Password</a>
                                    <asp:Button ID="btnLogin" Text="Login" runat="server" OnClientClick="ShowProgress();"
                                        OnClick="btnLogin_Click" CausesValidation="False" ToolTip="Click to login" TabIndex="3"
                                        Font-Size="18px" type="submit" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="vChangePassword" runat="server">
                        <table>
                            <tr>
                                <td>
                                    <label class="block">
                                        Your password has been expired or first time login, please input your new password</label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="block">
                                        <i class="icon sprites-key"></i>
                                        <asp:TextBox ID="txtNewPassword" runat="server" MaxLength="100" TabIndex="1" CssClass="input-text"
                                            placeholder="Password" TextMode="Password" />
                                    </label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="block">
                                        <i class="icon sprites-key"></i>
                                        <asp:TextBox ID="txtCfrmNewPassword" runat="server" MaxLength="100" TextMode="Password"
                                            TabIndex="2" CssClass="input-text" placeholder="Confirm Password" name="password" />
                                    </label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="btnChangePassword" Text="Submit" runat="server" OnClick="btnChangePassword_Click"
                                        CssClass="button blue large" CausesValidation="False" ToolTip="Click to submit"
                                        TabIndex="3" Font-Size="18px" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </div>
        </div>
    </div>
    <div class="loading" align="center">
        <img src="../App_Themes/images/icons/loading.gif" alt="" />
    </div>
    <telerik:RadAjaxManager ID="ramLogin" runat="server" DefaultLoadingPanelID="ralp">
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralp" runat="server">
    </telerik:RadAjaxLoadingPanel>
</asp:Content>
