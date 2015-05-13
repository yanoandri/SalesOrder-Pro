<%@ Page Language="C#" AutoEventWireup="true" Inherits="Security_AccessRight" MasterPageFile="~/SiteMaster/Default.master"
    CodeBehind="AccessRight.aspx.cs" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentTitle" ContentPlaceHolderID="ContentTitle" runat="server">
    <h1 class="title" id="divSubtitle" runat="server">
    </h1>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentDefault" runat="server">
    <script language="javascript" type="text/javascript">
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

        function ClickApprove(sender, args) {
            var callBackFunction = Function.createDelegate(sender, function (argument) {
                if (argument) {
                    this.click();
                }
            });
            var text = "Are you sure want to approve this";
            if (!confirm(text, callBackFunction, 300, 100, null, "Title")) {
                args.set_cancel(true)
            };
        }

        function ClickReject(sender, args) {
            var callBackFunction = Function.createDelegate(sender, function (argument) {
                if (argument) {
                    this.click();
                }
            });
            var text = "Are you sure want to reject this";
            if (!confirm(text, callBackFunction, 300, 100, null, "Title")) {
                args.set_cancel(true)
            };
        }
    </script>
    <div class="accordion_field">
        <fieldset class="acc_wrap">
            <div class="block acc_target">
                <div id="trApprovalInformation" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                <h2 class="title">
                                    <strong>Request Information</strong></h2>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="150%" border="0" cellspacing="0" cellpadding="1" class="trClass">
                                    <tr class="Label">
                                        <td width="150px">
                                            Request By
                                        </td>
                                        <td style="width: 10px;">
                                            :
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRequestBy" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="Label">
                                        <td width="150px">
                                            Request Date
                                        </td>
                                        <td style="width: 10px;">
                                            :
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRequestDate" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="Label">
                                        <td width="150px">
                                            Request Type
                                        </td>
                                        <td style="width: 10px;">
                                            :
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRequestType" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:ValidationSummary ID="vsInput" runat="server" />
                                <asp:Label ID="lblErrorMessage" runat="server" EnableViewState="false" Font-Bold="true"
                                    ForeColor="Red" Font-Size="12px" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div>
                    <table id="Table2" width="100%">
                        <tr>
                            <td id="tdGroupData" runat="server" style="width: 50%; padding-right: 5px;">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <h2 class="title">
                                                <strong>Group Information</strong></h2>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frame_lv2-content">
                                            <table width="100%" border="0" cellspacing="0" class="trClass" cellpadding="1">
                                                <tr id="trActiveStatus" runat="server" class="Label">
                                                    <td style="width: 150px;">
                                                        <span>Active Status</span>
                                                    </td>
                                                    <td style="width: 10px;">
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblActiveStatus" runat="server" CssClass="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="Label">
                                                    <td style="width: 150px;">
                                                        <span>Group Name</span>
                                                    </td>
                                                    <td style="width: 10px;">
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList CssClass="DropDownList" ID="cmbGroupName" runat="server" OnSelectedIndexChanged="cmbGroupName_SelectedIndexChanged"
                                                            AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:Label ID="lblGroupName" runat="server" CssClass="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="Label">
                                                    <td style="width: 150px;">
                                                        <span>Description</span>
                                                    </td>
                                                    <td style="width: 10px;">
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblGroupDescr" runat="server" CssClass="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td id="tdNewGroupData" runat="server">
                                <table>
                                    <tr>
                                        <td>
                                            <h2 class="title">
                                                <strong>New Group Information</strong></h2>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table border="0" class="trClass" cellspacing="0" cellpadding="1">
                                                <tr id="trNewActiveStatus" runat="server">
                                                    <td style="width: 150px;">
                                                        <span>Active Status</span>
                                                    </td>
                                                    <td style="width: 10px;">
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNewActiveStatus" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="Label">
                                                    <td style="width: 150px;">
                                                        <span>Group Name</span>
                                                    </td>
                                                    <td style="width: 10px;">
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNewGroupName" runat="server" CssClass="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="Label">
                                                    <td style="width: 150px;">
                                                        <span>Description</span>
                                                    </td>
                                                    <td style="width: 10px;">
                                                        :
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNewGroupDescr" runat="server" CssClass="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="block acc_target">
                <div id="tdAccessRight" runat="server">
                    <div class="col span_12 alpha omega">
                        <div class="table-cust-01">
                            <table id="Table1" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <asp:Literal ID="ltrBody" runat="server"></asp:Literal><br />
                                <asp:Label ID="lblBody" runat="server"></asp:Label>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
            <div class="block acc_target">
                <div id="trRemarks" runat="server" class="body-content-full">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="frame_lv2-title">
                                Remark <span class="RequiredField">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="80%" ValidationGroup="RejectionNote"></asp:TextBox><br />
                                <asp:RequiredFieldValidator ID="rfvRemarks" runat="server" ControlToValidate="txtRemarks"
                                    Display="Dynamic" ErrorMessage="Required for rejection note" ValidationGroup="RejectionNote"
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </fieldset>
        <div style="width: 100%; text-align: center;">
            <br />
            <telerik:RadButton ID="btnSave" OnClick="btnSave_Click" runat="server" SkinID="RadButtonSave"
                OnClientClicking="ClickSave" Skin="" EnableAjaxSkinRendering="False">
            </telerik:RadButton>
            <telerik:RadButton ID="btnCancel" OnClick="btnCancel_Click" runat="server" SkinID="RadButtonCancel"
                Skin="" EnableAjaxSkinRendering="False">
            </telerik:RadButton>
            <telerik:RadButton ID="btnApprove" runat="server" CommandName="Approve" SkinID="RadButtonApprove"
                OnClick="btnApprove_Click" Visible="False" OnClientClicking="ClickApprove" Skin=""
                EnableAjaxSkinRendering="False">
            </telerik:RadButton>
            <telerik:RadButton ID="btnReject" SkinID="RadButtonReject" runat="server" ValidationGroup="RejectionNote"
                OnClick="btnReject_Click" Visible="False" OnClientClicking="ClickReject" Skin=""
                EnableAjaxSkinRendering="False">
            </telerik:RadButton>
            <telerik:RadButton ID="btnBack" SkinID="RadButtonBack" OnClick="btnCancel_Click"
                runat="server" CausesValidation="False" Skin="" EnableAjaxSkinRendering="False">
            </telerik:RadButton>
        </div>
    </div>
    <telerik:RadAjaxManager ID="ramAccessRight" runat="server" DefaultLoadingPanelID="ralp"
        RequestQueueSize="1">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnSave">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="tblMain" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnCancel">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="tblMain" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnApprove">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="tblMain" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnReject">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="tblMain" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnBack">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="tblMain" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralp" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadCodeBlock runat="server" ID="rcb1">
        <script language="JavaScript" type="text/javascript">
            //-------------------------------------------------------------	
            //this function used fot the cmb lines 
            //it clear the form to avoid new query inserted in the next view.
            function ChangeNumOfLines() {
                with (window.document.forms[0]) {
                    var SelectedIndex = cmbLines.selectedIndex;
                    reset();
                    cmbLines.selectedIndex = SelectedIndex;
                    submit();
                }
            }
            //-------------------------------------------------------------
            function formReset() {

            }

            function set_group_access() {
                with (window.document.forms[0]) {
                    hSubmit.value = "1";
                    submit();
                }
            }

            function GetModuleID(sMemberValue) {
                var arrMemberValue = sMemberValue.split("*");
                if (arrMemberValue.length > 0)
                    return arrMemberValue[0];
                else
                    return 0;
            }

            function GetObjectID(sMemberValue) {
                var arrMemberValue = sMemberValue.split("*");
                if (arrMemberValue.length > 0)
                    return arrMemberValue[1];
                else
                    return 0;
            }

            function IsAllMemberOfModuleSelected(iModuleID) {
                var bAllMemberSelected = true;
                with (window.document.forms[0]) {
                    for (var i = 0; i < chkMember.length; i++) {
                        if (GetModuleID(chkMember[i].value) == iModuleID) {
                            if (chkMember[i].checked == false) {
                                bAllMemberSelected = false;
                                break;
                            }
                        }
                    }
                }
                return bAllMemberSelected;
            }

            function IsAllMemberOfObjectSelected(iObjectID, iEndPos) {
                var bAllMemberSelected = true;
                with (window.document.forms[0]) {
                    for (var i = 0; i <= iEndPos; i++) {
                        if (GetObjectID(chkMember[i].value) == iObjectID) {
                            if (chkMember[i].checked == false) {
                                bAllMemberSelected = false;
                                break;
                            }
                        }
                    }
                }
                return bAllMemberSelected;
            }

            function chkAllMemberByModule_Change(iModuleID) {
                var sTempObjectID = "";
                var bBreakLooping = false;
                with (window.document.forms[0]) {
                    for (var i = 0; i < chkMember.length; i++) {
                        if (GetModuleID(chkMember[i].value) == iModuleID) {
                            bBreakLooping = true;
                            chkMember[i].checked = elements["chkAllMemberByModule" + iModuleID].checked;
                            if (i < chkMember.length - 1) {
                                if (GetObjectID(chkMember[i].value) != GetObjectID(chkMember[i + 1].value)) {
                                    elements["chkAllMemberByObject" + GetObjectID(chkMember[i].value)].checked = IsAllMemberOfObjectSelected(GetObjectID(chkMember[i].value), i);
                                }
                            }
                            else {
                                if (i == chkMember.length - 1) {
                                    elements["chkAllMemberByObject" + GetObjectID(chkMember[i].value)].checked = IsAllMemberOfObjectSelected(GetObjectID(chkMember[i].value), i);
                                }
                            }
                        }
                        else {
                            if (bBreakLooping == true) {
                                bBreakLooping = false;
                                break;
                            }
                        }
                    }
                }
                return true;
            }

            function chkAllMemberByObject_Change(sObjectValue) {
                var bBreakLooping = false;
                var iModuleID = "";
                with (window.document.forms[0]) {
                    for (var i = 0; i < chkMember.length; i++) {
                        if (GetObjectID(chkMember[i].value) == GetObjectID(sObjectValue)) {
                            bBreakLooping = true;
                            chkMember[i].checked = elements["chkAllMemberByObject" + GetObjectID(sObjectValue)].checked;
                            if (iModuleID == "") {
                                iModuleID = GetModuleID(chkMember[i].value);
                            }
                        }
                        else {
                            if (bBreakLooping == true) {
                                break;
                            }
                        }
                    }
                    if (iModuleID != "") {
                        elements["chkAllMemberByModule" + iModuleID].checked = IsAllMemberOfModuleSelected(iModuleID);
                    }
                }
            }

            function chkMember_Change(sSelectedMember) {
                with (window.document.forms[0]) {
                    elements["chkAllMemberByObject" + GetObjectID(sSelectedMember)].checked = IsAllMemberOfObjectSelected(GetObjectID(sSelectedMember), chkMember.length - 1);
                    elements["chkAllMemberByModule" + GetModuleID(sSelectedMember)].checked = IsAllMemberOfModuleSelected(GetModuleID(sSelectedMember));
                }
            }

            function CheckObjectAccess() {
                with (window.document.forms[0]) {
                    var iObjectID = "";
                    var iModuleID = "";
                    var sMemberValue, arrMemberValue;
                    var bMemberSelectAll = true;
                    var bObjectSelectAll = true;

                    for (var i = 0; i < chkMember.length; i++) {
                        sMemberValue = chkMember[i].value;
                        arrMemberValue = sMemberValue.split("*");

                        if (iModuleID != arrMemberValue[0]) {
                            iModuleID = arrMemberValue[0];
                            bObjectSelectAll = true;
                        }

                        if (iObjectID != arrMemberValue[1]) {
                            iObjectID = arrMemberValue[1];
                            bMemberSelectAll = true;
                        }
                        if (chkMember[i].checked == false) {
                            if (bMemberSelectAll == true) {
                                bMemberSelectAll = false;
                            }
                            if (bObjectSelectAll == true) {
                                bObjectSelectAll = false;
                            }
                        }
                        elements["chkAllMemberByObject" + iObjectID].checked = bMemberSelectAll;
                        elements["chkAllMemberByModule" + iModuleID].checked = bObjectSelectAll;
                    }
                }
            }
        </script>
    </telerik:RadCodeBlock>
    </asp:Content>

