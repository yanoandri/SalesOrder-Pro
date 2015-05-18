<%@ Page Language="C#" AutoEventWireup="true" Inherits="SO.Security_UserInput"
    MasterPageFile="~/SiteMaster/Default.master" Theme="skin" CodeBehind="UserInput.aspx.cs" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="ContentTitle" ContentPlaceHolderID="ContentTitle" runat="server">
    <h1 class="title">
        Security - User Input
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
    <asp:ValidationSummary ID="vsInput" runat="server" />
    <asp:ValidationSummary ID="vsRemark" runat="server" ValidationGroup="RejectionNote" />
    <div class="accordion_field">
        <div class="accordion_field">
            <fieldset class="acc_wrap">
                <div class="block acc_target">
                    <div id="trApprovalInformation" runat="server">
                        <h2 class="title">
                            Approval Information</h2>
                        <br />
                        <div>
                            <table style="width: 550px">
                                <tr>
                                    <td style="width: 150px;">
                                        Request By
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:Label ID="lblRequestBy" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px;">
                                        Request Date
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:Label ID="lblRequestDate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px;">
                                        Request Type
                                    </td>
                                    <td>
                                        :
                                    </td>
                                    <td>
                                        <asp:Label ID="lblRequestType" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="block acc_target">
                    <div>
                        <table>
                            <tr>
                                <td id="tdUserData" runat="server">
                                    <h2 class="title">
                                        User Information</h2>
                                    <br />
                                    <table style="width: 500px">
                                        <tr id="trRequiredFieldsLabel" runat="server">
                                            <td colspan="2">
                                                <span class="RequiredField" style="color: Red;">*) Required</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                User Name <span class="RequiredField" style="color: Red;">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtUserName" runat="server" CssClass="input-text" Width="200px"
                                                    MaxLength="30"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtUserName"
                                                    Display="Dynamic" ErrorMessage="User Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:Label ID="lblUsername" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="trAdDomain" runat="server" visible="false">
                                            <td>
                                                Domain Name
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="rblAdDomain" RepeatDirection="Horizontal" runat="server">
                                                </asp:RadioButtonList>
                                                <telerik:RadButton ID="btnVerifyAD" SkinID="RadButtonVerify" runat="server" Text="Verify"
                                                    CausesValidation="false" OnClick="btnVerifyAD_Click" Skin="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Full Name <span class="RequiredField" style="color: Red;">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtFullName" runat="server" CssClass="input-text" Width="200px"
                                                    MaxLength="200"></asp:TextBox>
                                                <asp:Label ID="lblFullName" runat="server"></asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFullName"
                                                    ErrorMessage="Full Name is required" Display="Dynamic" CssClass="Validation"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Branch Code <span class="RequiredField" style="color: Red;">*</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlBranchCode" runat="server">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblBranchCode" runat="server"></asp:Label>
                                                <asp:RequiredFieldValidator ID="rqBranchCode" runat="server" ControlToValidate="ddlBranchCode"
                                                    ErrorMessage="Branch code is required" Display="Dynamic" CssClass="Validation"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Email <span class="RequiredField" style="color: Red;">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmail" ForeColor="Blue" runat="server" CssClass="input-text"
                                                    Width="200px" MaxLength="200"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid Email Format"
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail"
                                                    Display="Dynamic"></asp:RegularExpressionValidator>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                                                    Display="Dynamic" ErrorMessage="Email is required"></asp:RequiredFieldValidator>
                                                <asp:Label ID="lblEmail" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Active Status
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="rbIsActive" runat="server" RepeatDirection="Horizontal"
                                                    CssClass="RadioButton" RepeatLayout="Flow">
                                                    <asp:ListItem Text="Active " Value="true" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Non Active" Value="false"></asp:ListItem>
                                                </asp:RadioButtonList>
                                                <asp:Label ID="lblActiveStatus" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Blocked Status
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="rbIsBlocked" runat="server" RepeatDirection="Horizontal"
                                                    CssClass="RadioButton" RepeatLayout="Flow">
                                                    <asp:ListItem Text="Blocked " Value="true"></asp:ListItem>
                                                    <asp:ListItem Text="Not Blocked" Value="false" Selected="True"></asp:ListItem>
                                                </asp:RadioButtonList>
                                                <asp:Label ID="lblBlockedStatus" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Start Login Time
                                            </td>
                                            <td>
                                                <telerik:RadTimePicker ID="calStartLoginTime" runat="server" DateInput-DateFormat="HH:mm"
                                                    TimeView-TimeFormat="HH:mm" />
                                                <asp:Label ID="lblStartLoginTime" runat="server" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="calStartLoginTime"
                                                    Display="Dynamic" ErrorMessage="Start login time is required" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                End Login Time
                                            </td>
                                            <td>
                                                <telerik:RadTimePicker ID="calEndLoginTime" runat="server" DateInput-DateFormat="HH:mm"
                                                    TimeView-TimeFormat="HH:mm" />
                                                <asp:Label ID="lblEndLoginTime" runat="server" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="calEndLoginTime"
                                                    Display="Dynamic" ErrorMessage="End login time is required" ForeColor="Red"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Login on Holiday
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="chkHolidayLogin" runat="server" Text="Allowed" />
                                                <asp:Label ID="lblHolidayLogin" runat="server" />
                                            </td>
                                        </tr>
                                        <tr id="trChangePassword" runat="server">
                                            <td colspan="2">
                                                <asp:CheckBox ID="cbChangePassword" runat="server" Text="Change Password" OnCheckedChanged="cbChangePassword_CheckedChanged"
                                                    AutoPostBack="true" />
                                            </td>
                                        </tr>
                                        <tr id="trPassword" runat="server">
                                            <td>
                                                Password <span class="RequiredField" style="color: Red;">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPassword" runat="server" CssClass="input-text" Width="200px"
                                                    MaxLength="50" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtPassword" runat="server" ControlToValidate="txtPassword"
                                                    Display="Dynamic" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:Label ID="lblPassword" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="trPasswordConfirm" runat="server">
                                            <td>
                                                Confirm Password <span class="RequiredField" style="color: Red;">*</span>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtPasswordConfirm" runat="server" CssClass="input-text" Width="200px"
                                                    MaxLength="50" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtPasswordConfirm" runat="server" CssClass="Validation"
                                                    ControlToValidate="txtPasswordConfirm" Display="Dynamic" ErrorMessage="Password is required"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="cvPasswordComfirm" runat="server" ErrorMessage="Incorrect confirm password"
                                                    ControlToValidate="txtPasswordConfirm" ControlToCompare="txtPassword" Operator="Equal"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr id="trLastAccess" runat="server">
                                            <td>
                                                Last Access
                                            </td>
                                            <td>
                                                <asp:Label ID="lblLastAccess" runat="server" Text="-" CssClass="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="text-align: left">
                                                <asp:CompareValidator ID="cvcalEndLoginTime" runat="server" ControlToValidate="calEndLoginTime"
                                                    ControlToCompare="calStartLoginTime" Operator="GreaterThanEqual" ErrorMessage="Start login time cannot be greater than End login time" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="tdUserGroupData" runat="server" colspan="2">
                                                <table style="width: 350px">
                                                    <tr id="trAddAuthGroup" runat="server">
                                                        <td style="width: 232px;">
                                                            Group<span class="RequiredField" style="color: Red;">*</span>
                                                        </td>
                                                        <td style="text-align: right;">
                                                            <asp:DropDownList ID="cmbAuthGroup" runat="server" CssClass="DropDownList">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="text-align: left;">
                                                            <telerik:RadButton ID="btnAddAuthGroup" Text="Add Group" SkinID="New" Skin="" OnClick="btnAddAuthGroup_Click"
                                                                runat="server" CausesValidation="False" EnableViewState="false" ToolTip="Add Group" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <telerik:RadGrid ID="rgridAuthGroup" SkinID="RadGridWithoutPaging" Skin="Telerik"
                                                                runat="server" OnItemCommand="rgridAuthGroup_ItemCommand" OnNeedDataSource="rgridAuthGroup_NeedDataSource">
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
                                                                        <telerik:GridTemplateColumn HeaderText="Delete" UniqueName="Delete">
                                                                            <HeaderStyle Width="30px" HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="btnDelete" runat="server" SkinID="Delete" CommandName="Delete"
                                                                                    OnClientClick="javascript:return confirm('Are you sure want to delete?')" />
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
                                </td>
                                <td id="tdNewUserData" runat="server">
                                    <h2 class="title">
                                        New User Information</h2>
                                    <br />
                                    <table style="width: 500px">
                                        <tr id="trNewUserName" runat="server">
                                            <td style="width: 150px;">
                                                User Name
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNewUsername" runat="server" />
                                            </td>
                                        </tr>
                                        <tr id="trNewFullName" runat="server">
                                            <td style="width: 150px;">
                                                Full Name
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNewFullName" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="trNewBranchCode" runat="server">
                                            <td style="width: 150px;">
                                                Branch
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNewBranchCode" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="trNewEmail" runat="server">
                                            <td style="width: 150px;">
                                                Email
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNewEmail" ForeColor="Blue" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px;">
                                                Active Status
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNewActiveStatus" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px;">
                                                Blocked Status
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNewBlockedStatus" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px;">
                                                Start Login Time
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNewStartLoginTime" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px;">
                                                End Login Time
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNewEndLoginTime" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 150px;">
                                                Login on holidays
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNewHolidayLogin" runat="server" />
                                            </td>
                                        </tr>
                                        <tr id="trNewChangePassword" runat="server">
                                            <td colspan="3">
                                                <asp:CheckBox ID="cbNewChangePassword" runat="server" Text="Change Password" OnCheckedChanged="cbChangePassword_CheckedChanged"
                                                    AutoPostBack="true" />
                                            </td>
                                        </tr>
                                        <tr id="trNewPassword" runat="server">
                                            <td style="width: 150px;">
                                                Password
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNewPassword" runat="server" CssClass="input-text" Width="200px"
                                                    MaxLength="50" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvtxtNewPassword" runat="server" ControlToValidate="txtNewPassword"
                                                    Display="Dynamic" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:Label ID="lblNewPassword" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="trNewPasswordConfirm" runat="server">
                                            <td style="width: 150px;">
                                                Confirm Password
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtNewPasswordConfirm" runat="server" CssClass="input-text" Width="200px"
                                                    MaxLength="50" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfrvtxtNewPasswordConfirm" runat="server" CssClass="Validation"
                                                    ControlToValidate="txtNewPasswordConfirm" Display="Dynamic" ErrorMessage="Required"
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Incorrect confirm password"
                                                    ControlToValidate="txtNewPasswordConfirm" ControlToCompare="txtNewPassword" Operator="Equal"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr id="trNewLastAccess" runat="server">
                                            <td style="width: 150px;">
                                                Last Access
                                            </td>
                                            <td>
                                                :
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNewLastAccess" runat="server" Text="-" CssClass="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr id="trChangePasswordNotification" runat="server">
                                            <td colspan="3">
                                                <asp:Label ID="lblChangePasswordNotification" runat="server" ForeColor="Red" Text="Password Change Request" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" style="text-align: left">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="tdNewUserGroupData" runat="server" colspan="3">
                                                <table style="width: 60%;">
                                                    <tr id="trNewAddAuthGroup" runat="server">
                                                        <td style="width: 40%;">
                                                            Group
                                                            <asp:Label ID="lblNewGroup" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                        <td style="text-align: right;">
                                                            &nbsp;
                                                        </td>
                                                        <td style="text-align: right;">
                                                            <telerik:RadButton ID="btnNewAddAuthGroup" Visible="false" Text="Add Group" SkinID="New"
                                                                Skin="" OnClick="btnAddAuthGroup_Click" runat="server" CausesValidation="False"
                                                                EnableViewState="false" ValidationGroup="AuthGroup">
                                                            </telerik:RadButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <telerik:RadGrid ID="rgridNewAuthGroup" SkinID="RadGridWithoutPaging" Skin="Telerik"
                                                                runat="server" OnItemCommand="rgridNewAuthGroup_ItemCommand" OnNeedDataSource="rgridNewAuthGroup_NeedDataSource">
                                                                <MasterTableView DataKeyNames="UserGroupID" CommandItemDisplay="None" CommandItemSettings-ShowAddNewRecordButton="false"
                                                                    CommandItemSettings-ShowRefreshButton="false">
                                                                    <Columns>
                                                                        <telerik:GridTemplateColumn HeaderText="No" UniqueName="NewNumber" ItemStyle-CssClass="NumberColomn">
                                                                            <HeaderStyle Width="50px" HorizontalAlign="Center" />
                                                                            <ItemStyle Width="50px" HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblNewNumber" runat="server" Text="<%# (rgridNewAuthGroup.PageSize*rgridNewAuthGroup.CurrentPageIndex)+ Container.ItemIndex + 1 %>">
                                                                                </asp:Label>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="ID" HeaderStyle-HorizontalAlign="Center"
                                                                            UniqueName="NewGroupID" Visible="False" SortExpression="GroupID" DataField="GroupID">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblNewGroupID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GroupID") %>'>
                                                                                </asp:Label>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Group Name" HeaderStyle-HorizontalAlign="Center"
                                                                            UniqueName="NewGroupName" SortExpression="GroupName">
                                                                            <ItemStyle HorizontalAlign="Left" Wrap="False" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblNewGroupName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.GroupName") %>'>
                                                                                </asp:Label>
                                                                            </ItemTemplate>
                                                                        </telerik:GridTemplateColumn>
                                                                        <telerik:GridTemplateColumn HeaderText="Delete" UniqueName="NewDelete">
                                                                            <HeaderStyle Width="30px" HorizontalAlign="Center" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <asp:ImageButton ID="btnNewDelete" runat="server" SkinID="Delete" CommandName="Delete"
                                                                                    OnClientClick="javascript:return confirm('Are you sure want to delete?')" />
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
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="block acc_target">
                    <div id="trRemarks" runat="server">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    Remark
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="100%" ValidationGroup="RejectionNote"></asp:TextBox><br />
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
                    Skin="" OnClientClicking="ClickSave" />
                <telerik:RadButton ID="btnCancel" EnableViewState="false" OnClick="btnCancel_Click"
                    runat="server" SkinID="RadButtonCancel" Skin="" CausesValidation="false" />
                <telerik:RadButton ID="btnApprove" runat="server" SkinID="RadButtonApprove" Skin=""
                    OnClick="btnApprove_Click" CausesValidation="false" Visible="false" OnClientClicking="ClickApprove" />
                <telerik:RadButton ID="btnReject" SkinID="RadButtonReject" Skin="" runat="server"
                    ValidationGroup="RejectionNote" OnClick="btnReject_Click" Visible="false" OnClientClicking="ClickReject" />
                <telerik:RadButton ID="btnBack" SkinID="RadButtonBack" Skin="" OnClick="btnCancel_Click"
                    Visible="false" runat="server" CausesValidation="False" />
            </div>
        </div>
    </div>
    <telerik:RadAjaxManager ID="ramUserInput" runat="server" DefaultLoadingPanelID="ralp">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnVerifyAD">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="txtFullName" />
                    <telerik:AjaxUpdatedControl ControlID="txtTitle" />
                    <telerik:AjaxUpdatedControl ControlID="txtEmail" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnAddAuthGroup">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgridAuthGroup" />
                </UpdatedControls>
            </telerik:AjaxSetting>
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
