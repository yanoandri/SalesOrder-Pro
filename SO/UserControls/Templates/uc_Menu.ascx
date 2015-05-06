<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_uc_Menu"
    CodeBehind="uc_Menu.ascx.cs" %>
<!-- menu start !-->
<div id="menu">
    <div id="smoothmenu1" class="ddsmoothmenu">
        <ul>
            <li class="dashboard"><a href="../Home/Home.aspx" class="menu-button">Dashboard</a>
            </li>
            <li class="dashboard"><a href="../Security/UserList.aspx" class="menu-button">User</a>
            </li>
            <li class="dashboard"><a href="../Security/GroupList.aspx" class="menu-button">Group</a>
            </li>
            <li class="dashboard"><a href="../Security/UserLogList.aspx" class="menu-button">Audit
                Trail</a> </li>
            <li class="dashboard"><a href="../SysParameter/SysParameter.aspx" class="menu-button">
                Parameter</a> </li>
            <li class="dashboard"><a href="../ApprovalLog/ApprovalLogList.aspx" class="menu-button">
                Approval</a> </li>
            <li class="dashboard"><a href="../Process/Upload.aspx" class="menu-button">Upload</a>
            </li>
            <li class="dashboard"><a href="../Process/CallCenter.aspx" class="menu-button">Call
                Center</a> </li>
            <li class="dashboard"><a href="../Report/SummaryReport.aspx" class="menu-button">Summary</a>
            </li>
            <li class="dashboard"><a href="../Report/DetailReport.aspx" class="menu-button">Detail</a>
            </li>
            <li class="dashboard"><a href="../ProductChecking/ProductChecking.aspx" class="menu-button">Product Checking</a>
            </li>
        </ul>
    </div>
</div>
<!-- menu end !-->
<%--<table>
    <tr>
        <td id="tdDashboardMain" runat="server" style="width: 105px">
            <telerik:RadMenu ID="rmDashboardMain" runat="server" EnableEmbeddedSkins="False"
                EnableViewState="false" Width="100%">
                <Items>
                    <telerik:RadMenuItem runat="server" ImageUrl="../App_Themes/Default/images/button-menu/dashboard.gif"
                        NavigateUrl="../Home/Home.aspx" HoveredImageUrl="../App_Themes/Default/images/button-menu/dashboard-hover.gif">
                    </telerik:RadMenuItem>
                </Items>
            </telerik:RadMenu>
        </td>
        <td id="tdPreferences" runat="server" style="width: 105px">
            <telerik:RadMenu ID="rmPreferences" runat="server" EnableEmbeddedSkins="False" EnableViewState="false"
                Width="100%">
                <Items>
                    <telerik:RadMenuItem runat="server" ImageUrl="../App_Themes/Default/images/button-menu/preferences.gif"
                        HoveredImageUrl="../App_Themes/Default/images/button-menu/preferences-hover.gif">
                        <Items>
                            <telerik:RadMenuItem ID="rmSystemParameters" runat="server" Text="System Parameter"
                                NavigateUrl="../SysParameter/SysParameter.aspx" />
                        </Items>
                    </telerik:RadMenuItem>
                </Items>
            </telerik:RadMenu>
        </td>
        <td id="tdSecurity" runat="server" style="width: 105px">
            <telerik:RadMenu ID="rmSecurity" runat="server" EnableEmbeddedSkins="False" EnableViewState="false"
                Width="100%">
                <Items>
                    <telerik:RadMenuItem runat="server" ImageUrl="../App_Themes/Default/images/button-menu/security.gif"
                        HoveredImageUrl="../App_Themes/Default/images/button-menu/security-hover.gif">
                        <Items>
                            <telerik:RadMenuItem ID="rmUser" runat="server" Text="User" NavigateUrl="../Security/UserList.aspx" />
                            <telerik:RadMenuItem ID="rmGroup" runat="server" Text="Group" NavigateUrl="../Security/GroupList.aspx" />
                            <telerik:RadMenuItem ID="rmAuditTrail" runat="server" Text="Audit Trail" NavigateUrl="../Security/UserLogList.aspx" />
                        </Items>
                    </telerik:RadMenuItem>
                </Items>
            </telerik:RadMenu>
        </td>
        <td id="tdCustomer" runat="server" style="width: 105px">
            <telerik:RadMenu ID="rmCustomer" runat="server" EnableEmbeddedSkins="False" EnableViewState="false"
                Width="100%">
                <Items>
                    <telerik:RadMenuItem runat="server" ImageUrl="../App_Themes/Default/images/button-menu/customer.gif"
                        HoveredImageUrl="../App_Themes/Default/images/button-menu/customer-hover.gif">
                        <Items>
                            <telerik:RadMenuItem id="rmCustomerMaintenance" runat="server" Text="Customer Maintenance"
                                NavigateUrl="../Customer/Maintenance.aspx" />
                            <telerik:RadMenuItem id="rmCustomerRegistration" runat="server" Text="Customer Registration"
                                NavigateUrl='../Customer/Registration.aspx?' />
                            <telerik:RadMenuItem id="rmCustomerReRegistration" runat="server" Text="Customer Re-Registration"
                                NavigateUrl="../Customer/ReRegistration.aspx" />
                            <telerik:RadMenuItem id="rmCustomerInquiry" runat="server" Text="Customer Inquiry"
                                NavigateUrl="../Customer/Inquiry.aspx" />
                            <telerik:RadMenuItem id="rmNewToBankRegistration" runat="server" Text="New To Bank Registration"
                                NavigateUrl="../Customer/NewToBankRegistrationList.aspx" />
                            <telerik:RadMenuItem id="rmAdhocStatementRequest" runat="server" Text="Adhoc Statement Request"
                                NavigateUrl="../Customer/AdhocStatementRequest.aspx" />
                        </Items>
                    </telerik:RadMenuItem>
                </Items>
            </telerik:RadMenu>
        </td>
        <td id="tdStatementPreparation" runat="server" style="width: 160px">
            <telerik:RadMenu ID="rmStatementPreparation" runat="server" EnableEmbeddedSkins="False"
                EnableViewState="false" Width="100%">
                <Items>
                    <telerik:RadMenuItem runat="server" ImageUrl="../App_Themes/Default/images/button-menu/statement.gif"
                        HoveredImageUrl="../App_Themes/Default/images/button-menu/statement-hover.gif">
                        <Items>
                            <telerik:RadMenuItem ID="rmCustomMessage" runat="server" Text="Custom Message" NavigateUrl="../CustomMessage/CustomMessageList.aspx" />
                            <telerik:RadMenuItem ID="rmEmailBodyTemplate" runat="server" Text="Email Body Template"
                                NavigateUrl="../EmailBodyTemplate/EmailBodyTemplateList.aspx" />
                            <telerik:RadMenuItem ID="rmInsertion" runat="server" Text="Insertion" NavigateUrl="../Insertion/InsertionList.aspx" />
                            <telerik:RadMenuItem ID="rmUploadFile" runat="server" Text="Upload File" NavigateUrl="../UploadFile/UploadFileList.aspx" />
                            <telerik:RadMenuItem ID="rmPaperInsertion" runat="server" Text="Paper Insertion"
                                NavigateUrl="../PaperInsertion/PaperInsertionInput.aspx" />
                            <telerik:RadMenuItem ID="rmUploadSuppressionList" runat="server" Text="Upload Suppression List"
                                NavigateUrl="../UploadSuppressionList/UploadSuppressionList.aspx" />
                            <telerik:RadMenuItem ID="rmCourierAssignment" runat="server" Text="Courier Assignment"
                                NavigateUrl="../CourierAssignment/CourierAssignmentList.aspx" />
                        </Items>
                    </telerik:RadMenuItem>
                </Items>
            </telerik:RadMenu>
        </td>
        <td id="tdApproval" runat="server" style="width: 105px">
            <telerik:RadMenu ID="rmApproval" runat="server" EnableEmbeddedSkins="False" EnableViewState="false"
                Width="100%">
                <Items>
                    <telerik:RadMenuItem runat="server" ImageUrl="../App_Themes/Default/images/button-menu/approval.gif"
                        HoveredImageUrl="../App_Themes/Default/images/button-menu/approval-hover.gif">
                        <Items>
                            <telerik:RadMenuItem runat="server" Text="Approval Log" NavigateUrl="../ApprovalLog/ApprovalLogList.aspx">
                            </telerik:RadMenuItem>
                        </Items>
                    </telerik:RadMenuItem>
                </Items>
            </telerik:RadMenu>
        </td>
        <td id="tdReport" runat="server" style="width: 105px">
            <telerik:RadMenu ID="rmReport" runat="server" EnableEmbeddedSkins="False" EnableViewState="false"
                Width="100%">
                <Items>
                    <telerik:RadMenuItem runat="server" ImageUrl="../App_Themes/Default/images/button-menu/report.gif"
                        HoveredImageUrl="../App_Themes/Default/images/button-menu/report-hover.gif">
                        <Items>
                            <telerik:RadMenuItem ID="rmServiceLogReport" runat="server" Text="Service Log Report"
                                NavigateUrl="../Report/ServiceLogReport.aspx" />
                            <telerik:RadMenuItem ID="rmImportReport" runat="server" Text="Import Report" NavigateUrl="../Report/ImportReport.aspx" />
                            <telerik:RadMenuItem ID="rmStatementProgressReport" runat="server" Text="Statement Progress Report"
                                NavigateUrl="../Report/BillingStatementProgressReport.aspx" />
                            <telerik:RadMenuItem ID="rmEmailDeliveryReport" runat="server" Text="Email Delivery Report"
                                NavigateUrl="../Report/EmailDelivery.aspx" />
                            <telerik:RadMenuItem ID="rmPaperStatementReport" runat="server" Text="Paper Statement Report"
                                NavigateUrl="../Report/PaperStatement.aspx" />
                            <telerik:RadMenuItem ID="rmEStatementReport" runat="server" Text="eStatement Report"
                                NavigateUrl="../Report/eStatement.aspx" />
                            <telerik:RadMenuItem ID="rmReconcileReport" runat="server" Text="Reconcile Report"
                                NavigateUrl="">
                                <Items>
                                    <telerik:RadMenuItem ID="rmReconcileConsolidatedReport" runat="server" Text="Consolidated"
                                        NavigateUrl="" />
                                    <telerik:RadMenuItem ID="rmReconcileBillingReport" runat="server" Text="Billing"
                                        NavigateUrl="../Report/BillingReconcileReport.aspx" />
                                </Items>
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem ID="rmCustomerActivityReport" runat="server" Text="Customer Activity Report"
                                NavigateUrl="">
                                <Items>
                                    <telerik:RadMenuItem ID="rmCustomerActivityConsolidatedReport" runat="server" Text="Consolidated"
                                        NavigateUrl="" />
                                    <telerik:RadMenuItem ID="rmCustomerActivityBillingReport" runat="server" Text="Billing"
                                        NavigateUrl="../Report/BillingCustomerActivityReport.aspx" />
                                </Items>
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem ID="rmCustomerStatusReport" runat="server" Text="Customer Status Report"
                                NavigateUrl="">
                                <Items>
                                    <telerik:RadMenuItem ID="rmCustomerStatusConsolidatedReport" runat="server" Text="Consolidated"
                                        NavigateUrl="" />
                                    <telerik:RadMenuItem ID="rmCustomerStatusBillingReport" runat="server" Text="Billing"
                                        NavigateUrl="../Report/CustomerStatus.aspx" />
                                </Items>
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem ID="rmStatementInquiryReport" runat="server" Text="Statement Inquiry"
                                NavigateUrl="">
                                <Items>
                                    <telerik:RadMenuItem ID="rmStatementInquiryConsolidatedReport" runat="server" Text="Consolidated"
                                        NavigateUrl="" />
                                    <telerik:RadMenuItem ID="rmStatementInquiryBillingReport" runat="server" Text="Billing"
                                        NavigateUrl="../Report/BillingStatementInquiryReport.aspx" />
                                </Items>
                            </telerik:RadMenuItem>
                            <telerik:RadMenuItem ID="rmDownloadNewRegistrationReport" runat="server" Text="Registration Report"
                                NavigateUrl="../Report/DownloadNewRegistrationReport.aspx" />
                            <telerik:RadMenuItem ID="rmCancellationRegistrationReport" runat="server" Text="Cancellation Report"
                                NavigateUrl="../Report/DownloadCancellationReport.aspx" />
                        </Items>
                    </telerik:RadMenuItem>
                </Items>
            </telerik:RadMenu>
        </td>
    </tr>
</table>--%>
