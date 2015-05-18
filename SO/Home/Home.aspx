<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster/Dashbord.Master" AutoEventWireup="true"
    CodeBehind="Home.aspx.cs" Inherits="SO.Home" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Charting" TagPrefix="telerik" %>
<asp:Content ID="Home" ContentPlaceHolderID="ContentDefault" runat="server">
    <telerik:RadCodeBlock ID="rcb" runat="server">
        <script language="javascript" type="text/javascript">
            try {
                var oParent = window.parent;

                if (oParent != null) {
                    oParent.bIsLogin = true;
                    oParent = null;
                }
            }
            catch (ex) {
            }
        </script>
    </telerik:RadCodeBlock>
    <style type="text/css">       
    .rockpool {
	margin:0px;
	height:25px;
	background-color: #a291a3;
	*zoom: 1;
	 }
	 
	 .blue
	 {
	    background-color: #007dba;
        *zoom: 1;
      }
    </style>
    <div class="span_4">
        <div class="dashboard_menu">
            <h1>
                MENU</h1>
            <div class="block menu_wrap">
                <div id="dashboard_menu" class="clean li-block">
                    <ol>
                        <li runat="server" id="mnuSecurity"><a href="#">Security</a>
                            <ol>
                                <li runat="server" id="mnuUser" visible="false"><a href="../Security/UserList.aspx">
                                    User</a></li>
                                <li runat="server" id="mnuGroup" visible="false"><a href="../Security/GroupList.aspx">
                                    Group</a></li>
                                <li runat="server" id="mnuAuditTrails" visible="false"><a href="../Security/UserLogList.aspx">
                                    Audit Trails</a></li>
                            </ol>
                        </li>
                        <li runat="server" id="mnuPreferences"><a href="#">Preferences</a>
                            <ol>
                                <li runat="server" id="mnuParameter" visible="false"><a href="../SysParameter/SysParameter.aspx">
                                    Parameter</a></li>
                                <li runat="server" id="mnuConditionAndMatrix" visible="false"><a href="../SysParameter/ConditionMatrixSetup.aspx">
                                    Condition And Matrix Setup</a></li>
                            </ol>
                        </li>
                        <li runat="server" id="mnuMaster"><a href="#">Master</a>
                            <ol>
                                <li runat="server" id="mnuExceptionForm" visible="false"><a href="../ExceptionForm/ExceptionFormList.aspx">
                                    Exception Form</a></li>
                                <li runat="server" id="mnuProduct" visible="false"><a href="../Product/ProductList.aspx">
                                    Product</a></li>
                            </ol>
                        </li>
                        <li runat="server" id="mnuParentApproval"><a href="">Approval</a>
                            <ol>
                                <li runat="server" id="mnuApprovalLog" visible="false"><a href="../ApprovalLog/ApprovalLogList.aspx">
                                    Approval Log</a></li>
                            </ol>
                        </li>
                        <li runat="server" id="mnuTransaction"><a href="#">Transaction</a>
                            <ol>
                                <li runat="server" id="mnuManualUpload" visible="false"><a href="../Manual Upload/ManualUploadList.aspx">
                                    Manual Upload</a></li>
                                <li runat="server" id="mnuProductChecking" visible="false"><a href="../ProductChecking/ProductCheck.aspx">
                                    Product Checking</a></li>
                                <li runat="server" id="mnuProductOffering" visible="false"><a href="../ProductOffering/ProductOffer.aspx">
                                    Product Offering</a></li>
                            </ol>
                        </li>
                        <li runat="server" id="mnuReporting"><a href="#">Reporting</a>
                            <ol>
                                <li runat="server" id="mnuSubReporting"><a href="../Report/Reporting.aspx">
                                    Reporting</a></li>
                            </ol>
                        </li>
                    </ol>
                </div>
            </div>
            <asp:LoginStatus ID="lsLogout" runat="server" CssClass="button blue medium" OnLoggingOut="lsLogout_OnLoggingOut" />
        </div>
    </div>
    <div class="span_8">
        <div class="block bar blue">
            <h1>
                WELCOME</h1>
        </div>
    </div>
    <div class="push">
    </div>
</asp:Content>
