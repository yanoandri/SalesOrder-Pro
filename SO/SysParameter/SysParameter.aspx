<%@ Page Title="System Parameter" Language="C#" MasterPageFile="~/MasterPages/Default.master"
    ValidateRequest="false" AutoEventWireup="true" CodeBehind="SysParameter.aspx.cs"
    Inherits="PSC.Web.UI.Admin.SysParameter.SysParameter" EnableEventValidation="false"%>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentTitle" ContentPlaceHolderID="ContentTitle" runat="server">
    <script type="text/javascript">
        function OnClientClickSave(sender, eventArgs) {
            if (isClickedTwice()) return false;
        }

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
    <h1 class="title">
        Preferences - System Parameter
    </h1>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentDefault" runat="server">
    <div class="frame_lv1">
        

        <div class="col span_12 alpha omega">
            <div class="table-cust-01">
                <asp:ValidationSummary ID="vsInput" runat="server" />
                <asp:PlaceHolder ID="phSysParameter" runat="server"></asp:PlaceHolder>
            </div>
            <div class="col span_12 text-align-center">
                <asp:Button ID="btnSave" type="submit" OnClick="btnSave_Click" runat="server" CssClass="button blue medium"
                    OnClientClicking="ClickSave" OnClientClicked="OnClientClickSave" Text="Save" />
                <asp:Button ID="btnCancel" type="Reset" SkinID="ASPButtonCancel" OnClick="btnCancel_Click" runat="server" Text="Cancel"  CssClass="button blue medium" />
            </div>
        </div>
    </div>
    <telerik:RadAjaxManager ID="ram" runat="server" DefaultLoadingPanelID="ralp">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSave">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pbSysParam" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnCancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pbSysParam" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralp" runat="server">
    </telerik:RadAjaxLoadingPanel>
</asp:Content>
