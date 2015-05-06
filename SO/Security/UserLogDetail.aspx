<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPages/Default.master"
    Theme="skin" Inherits="Security_UserLogDetail" ValidateRequest="false" CodeBehind="UserLogDetail.aspx.cs" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentTitle" ContentPlaceHolderID="ContentTitle" runat="server">
    <h1 class="title">
        Security - Audit Trail Detail</h1>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentDefault" runat="Server">
    <fieldset class="fieldset-grey">
        <asp:TextBox ID="tbUserLogDetail" runat="server" Width="99%" Height="315px" TextMode="MultiLine"
            ViewStateMode="Disabled" EnableViewState="false"></asp:TextBox>
        <table width="100%" style="margin: 5px 0px 5px 0px;" cellpadding="0" cellspacing="0">
            <tr>
                <td id="tdAuditLogData" runat="server" style="width: 50%; padding-right: 5px; vertical-align: top;"
                    visible="false">
                    <div class="body-content-left left">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="frame_lv2-title">
                                    <asp:Literal ID="lblLastHeaderCode" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="frame_lv2-content">
                                    <asp:PlaceHolder ID="phLastSysParameter" runat="server"></asp:PlaceHolder>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td id="tdNewAuditLogData" runat="server" style="width: 50%; vertical-align: top;">
                    <div class="body-content-left left">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="frame_lv2-title">
                                    <asp:Literal ID="lblHeaderCode" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td class="frame_lv2-content">
                                    <asp:PlaceHolder ID="phSysParameter" runat="server"></asp:PlaceHolder>
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
                <td id="tdGridData" runat="server" style="width: 50%; padding-right: 5px; vertical-align: top;"
                    visible="false">
                    <div class="body-content-left left">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="frame_lv2-title">
                                </td>
                            </tr>
                            <tr>
                                <td class="frame_lv2-content">
                                    <asp:PlaceHolder ID="litLastGrid" runat="server"></asp:PlaceHolder>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td id="tdNewGridData" runat="server" style="width: 50%; vertical-align: top;">
                    <div class="body-content-left left">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="frame_lv2-title">
                                </td>
                            </tr>
                            <tr>
                                <td class="frame_lv2-content">
                                    <asp:PlaceHolder ID="litGrid" runat="server"></asp:PlaceHolder>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </fieldset>
    <br />
    <div class="col span_12 text-align-center">
        <telerik:RadButton ID="btnBack" SkinID="RadButtonBack" OnClick="btnBack_Click" runat="server"
            CausesValidation="False" Skin="">
        </telerik:RadButton>
    </div>
</asp:Content>
