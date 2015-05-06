<%@ Page Language="C#" AutoEventWireup="true" Inherits="Security_ChangePass" MasterPageFile="~/MasterPages/Default.master" Theme="Default" Codebehind="ChangePass.aspx.cs" %>
<%@ Register Src="../UserControls/Security/ChangePassword.ascx" TagName="ChangePassword" TagPrefix="uc1" %>

<asp:Content ContentPlaceHolderID="ContentDefault" runat="server">
      <uc1:ChangePassword ID="ChangePassword1" runat="server" />
</asp:Content>
