<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Default.master" AutoEventWireup="true"
    CodeBehind="ConditionMatrixSetup.aspx.cs" Inherits="PSC.Web.UI.SysParameter.ConditionMatrixSetup"
    Theme="skin" %>

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
        $(document).ready(function () {
            $(".acc_button").trigger("click");
            $(".preventEnter").keydown(function (event) {
                if (event.keyCode == 13) {
                    event.preventDefault();
                    return false;
                }
            });
        });
    </script>
    <h1 class="title">
        Preference - Condition and Matrix Setup</h1>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentDefault" runat="server">
    <div class="accordion_field">
        <fieldset class="acc_wrap">
            <legend class="bar rockpool acc_button">
                <h2>
                    GENERAL CONDITION SETTING</h2>
                <i class="icon toggle-up-circle"></i></legend>
            <div class="block acc_target">
                <div class="table_blue noscroll">
                    <h3 class="caption">
                        Vulnerable Checking Criteria Matrix</h3>
                    <table class="table_vulnerable">
                        <colgroup>
                            <col width="5%" />
                            <col />
                        </colgroup>
                        <thead>
                            <tr>
                                <th>
                                    No
                                </th>
                                <th>
                                    Variable
                                </th>
                                <th>
                                    Value
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    1
                                </td>
                                <td>
                                    Age (1)
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox runat="server" ID="tbAge1From" NumberFormat-DecimalDigits="0"
                                        MinValue="0" autocomplete="off">
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="rfvAge1From" runat="server" ControlToValidate="tbAge1From"
                                        Display="Dynamic" ErrorMessage="Please fill Age" CssClass="Validation" ForeColor="Red"
                                        ValidationGroup="SaveMatrix"></asp:RequiredFieldValidator>
                                    To
                                    <telerik:RadNumericTextBox runat="server" ID="tbAge1To" NumberFormat-DecimalDigits="0"
                                        MinValue="0" autocomplete="off">
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="rfvAge1To" runat="server" ControlToValidate="tbAge1To"
                                        Display="Dynamic" ErrorMessage="Please fill Age" CssClass="Validation" ForeColor="Red"
                                        ValidationGroup="SaveMatrix"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    2
                                </td>
                                <td>
                                    Age (2)
                                </td>
                                <td>
                                    <telerik:RadNumericTextBox runat="server" ID="tbAge2From" NumberFormat-DecimalDigits="0"
                                        MinValue="0" autocomplete="off">
                                    </telerik:RadNumericTextBox>
                                    <asp:RequiredFieldValidator ID="rfvAge2From" runat="server" ControlToValidate="tbAge2From"
                                        Display="Dynamic" ErrorMessage="Please fill Age" CssClass="Validation" ForeColor="Red"
                                        ValidationGroup="SaveMatrix"></asp:RequiredFieldValidator>
                                    To
                                    <telerik:RadNumericTextBox runat="server" ID="tbAge2To" NumberFormat-DecimalDigits="0"
                                        MinValue="0" autocomplete="off">
                                    </telerik:RadNumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    3
                                </td>
                                <td>
                                    Education Background
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEducationBackground" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="block acc_target">
                <div class="table_blue noscroll">
                    <h3 class="caption">
                        Important Notes Matrix</h3>
                    <table class="table_important_notes">
                        <thead>
                            <tr>
                                <th>
                                    VC Yes With
                                </th>
                                <th>
                                    P1
                                </th>
                                <th>
                                    P2
                                </th>
                                <th>
                                    P3
                                </th>
                                <th>
                                    P4
                                </th>
                                <th>
                                    P5
                                </th>
                                <th>
                                    Mismatch
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label ID="lbImportantNotesMatrixParam1" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam1P1" runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam1P2" runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam1P3" runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam1P4" runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam1P5" runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam1Mismatch" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbImportantNotesMatrixParam2" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam2P1" runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam2P2" runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam2P3" runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam2P4" runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam2P5" runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam2Mismatch" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbImportantNotesMatrixParam3" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam3P1" runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam3P2" runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam3P3" runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam3P4" runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam3P5" runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam3MisMatch" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbImportantNotesMatrixParam4" runat="server" Text=""></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam4P1" runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam4P2" runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam4P3" runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam4P4" runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam4P5" runat="server" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbImportantNotesMatrixParam4Mismatch" runat="server" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div class="block acc_target" id="divProductRatingVsCustomerRisk" runat="server">
                <div class="table_blue noscroll">
                    <h3 class="caption">
                        Product Rating Vs Customer Risk Profile Rating</h3>
                    <table>
                        <thead>
                            <tr>
                                <th>
                                    Customer Rating
                                </th>
                                <th>
                                    Product to Buy without Exception
                                </th>
                                <th>
                                    Product to Buy with Exception
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label ID="lbRating1" runat="server" Text="C1"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbRating1WithoutExceptionP1" runat="server" Text="P1" />
                                    <asp:CheckBox ID="cbRating1WithoutExceptionP2" runat="server" Text="P2" />
                                    <asp:CheckBox ID="cbRating1WithoutExceptionP3" runat="server" Text="P3" />
                                    <asp:CheckBox ID="cbRating1WithoutExceptionP4" runat="server" Text="P4" />
                                    <asp:CheckBox ID="cbRating1WithoutExceptionP5" runat="server" Text="P5" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbRating1WithExceptionNotAllowed" runat="server" AutoPostBack="true"
                                        Text="Not Allowed" OnCheckedChanged="cbRating1WithExceptionNotAllowed_CheckedChanged" />
                                    <asp:CheckBox ID="cbRating1WithExceptionP1" runat="server" Text="P1" />
                                    <asp:CheckBox ID="cbRating1WithExceptionP2" runat="server" Text="P2" />
                                    <asp:CheckBox ID="cbRating1WithExceptionP3" runat="server" Text="P3" />
                                    <asp:CheckBox ID="cbRating1WithExceptionP4" runat="server" Text="P4" />
                                    <asp:CheckBox ID="cbRating1WithExceptionP5" runat="server" Text="P5" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbRating2" runat="server" Text="C2"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbRating2WithoutExceptionP1" runat="server" Text="P1" />
                                    <asp:CheckBox ID="cbRating2WithoutExceptionP2" runat="server" Text="P2" />
                                    <asp:CheckBox ID="cbRating2WithoutExceptionP3" runat="server" Text="P3" />
                                    <asp:CheckBox ID="cbRating2WithoutExceptionP4" runat="server" Text="P4" />
                                    <asp:CheckBox ID="cbRating2WithoutExceptionP5" runat="server" Text="P5" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbRating2WithExceptionNotAllowed" runat="server" AutoPostBack="true"
                                        Text="Not Allowed" OnCheckedChanged="cbRating2WithExceptionNotAllowed_CheckedChanged" />
                                    <asp:CheckBox ID="cbRating2WithExceptionP1" runat="server" Text="P1" />
                                    <asp:CheckBox ID="cbRating2WithExceptionP2" runat="server" Text="P2" />
                                    <asp:CheckBox ID="cbRating2WithExceptionP3" runat="server" Text="P3" />
                                    <asp:CheckBox ID="cbRating2WithExceptionP4" runat="server" Text="P4" />
                                    <asp:CheckBox ID="cbRating2WithExceptionP5" runat="server" Text="P5" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbRating3" runat="server" Text="C3"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbRating3WithoutExceptionP1" runat="server" Text="P1" />
                                    <asp:CheckBox ID="cbRating3WithoutExceptionP2" runat="server" Text="P2" />
                                    <asp:CheckBox ID="cbRating3WithoutExceptionP3" runat="server" Text="P3" />
                                    <asp:CheckBox ID="cbRating3WithoutExceptionP4" runat="server" Text="P4" />
                                    <asp:CheckBox ID="cbRating3WithoutExceptionP5" runat="server" Text="P5" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbRating3WithExceptionNotAllowed" runat="server" AutoPostBack="true"
                                        Text="Not Allowed" OnCheckedChanged="cbRating3WithExceptionNotAllowed_CheckedChanged" />
                                    <asp:CheckBox ID="cbRating3WithExceptionP1" runat="server" Text="P1" />
                                    <asp:CheckBox ID="cbRating3WithExceptionP2" runat="server" Text="P2" />
                                    <asp:CheckBox ID="cbRating3WithExceptionP3" runat="server" Text="P3" />
                                    <asp:CheckBox ID="cbRating3WithExceptionP4" runat="server" Text="P4" />
                                    <asp:CheckBox ID="cbRating3WithExceptionP5" runat="server" Text="P5" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbRating4" runat="server" Text="C4"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbRating4WithoutExceptionP1" runat="server" Text="P1" />
                                    <asp:CheckBox ID="cbRating4WithoutExceptionP2" runat="server" Text="P2" />
                                    <asp:CheckBox ID="cbRating4WithoutExceptionP3" runat="server" Text="P3" />
                                    <asp:CheckBox ID="cbRating4WithoutExceptionP4" runat="server" Text="P4" />
                                    <asp:CheckBox ID="cbRating4WithoutExceptionP5" runat="server" Text="P5" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbRating4WithExceptionNotAllowed" runat="server" AutoPostBack="true"
                                        Text="Not Allowed" OnCheckedChanged="cbRating4WithExceptionNotAllowed_CheckedChanged" />
                                    <asp:CheckBox ID="cbRating4WithExceptionP1" runat="server" Text="P1" />
                                    <asp:CheckBox ID="cbRating4WithExceptionP2" runat="server" Text="P2" />
                                    <asp:CheckBox ID="cbRating4WithExceptionP3" runat="server" Text="P3" />
                                    <asp:CheckBox ID="cbRating4WithExceptionP4" runat="server" Text="P4" />
                                    <asp:CheckBox ID="cbRating4WithExceptionP5" runat="server" Text="P5" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lbRating5" runat="server" Text="C5"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbRating5WithoutExceptionP1" runat="server" Text="P1" />
                                    <asp:CheckBox ID="cbRating5WithoutExceptionP2" runat="server" Text="P2" />
                                    <asp:CheckBox ID="cbRating5WithoutExceptionP3" runat="server" Text="P3" />
                                    <asp:CheckBox ID="cbRating5WithoutExceptionP4" runat="server" Text="P4" />
                                    <asp:CheckBox ID="cbRating5WithoutExceptionP5" runat="server" Text="P5" />
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbRating5WithExceptionNotAllowed" runat="server" AutoPostBack="true"
                                        Text="Not Allowed" OnCheckedChanged="cbRating5WithExceptionNotAllowed_CheckedChanged" />
                                    <asp:CheckBox ID="cbRating5WithExceptionP1" runat="server" Text="P1" />
                                    <asp:CheckBox ID="cbRating5WithExceptionP2" runat="server" Text="P2" />
                                    <asp:CheckBox ID="cbRating5WithExceptionP3" runat="server" Text="P3" />
                                    <asp:CheckBox ID="cbRating5WithExceptionP4" runat="server" Text="P4" />
                                    <asp:CheckBox ID="cbRating5WithExceptionP5" runat="server" Text="P5" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </fieldset>
        <fieldset class="acc_wrap">
            <legend class="bar rockpool acc_button">
                <h2>
                    EXCEPTION &amp; RISK MISMATCH MATRIX</h2>
                <i class="icon toggle-up-circle"></i></legend>
            <div class="block acc_target">
                <div class="table_blue noscroll">
                    <h3 class="caption">
                        Profile Mismatch Matrix</h3>
                    <asp:Panel ID="pnlProfileMismatchMatrix" runat="server">
                        <telerik:RadGrid ID="rgridProfileMismatchMatrixList" runat="server" OnNeedDataSource="rgridProfileMismatchMatrixList_NeedDataSource"
                            SkinID="RadGridProfileMismatchMatrixList" OnItemDataBound="rgridProfileMismatchMatrixList_ItemDataBound">
                            <MasterTableView DataKeyNames="AssetClassID">
                                <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Asset Class ID" UniqueName="AssetClassID"
                                        SortExpression="AssetClassID" Visible="false">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblAssetClassID" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AssetClassID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Asset Class" UniqueName="AssetClassName"
                                        SortExpression="AssetClassName">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblAssetClassName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AssetClassName") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Product Rating" UniqueName="ProductRatingScore"
                                        SortExpression="ProductRatingScore">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbProductRatingScore" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ProductRatingScore") %>'></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Value No (%)" UniqueName="ValueNoPercent"
                                        SortExpression="ValueNoPercent">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlOperatorNo" runat="server">
                                            </asp:DropDownList>
                                            <telerik:RadNumericTextBox runat="server" ID="tbValueNoPercent" NumberFormat-DecimalDigits="0"
                                                Text='<%# DataBinder.Eval(Container, "DataItem.ValueNoPercent") %>' MinValue="0"
                                                CssClass="preventEnter" autocomplete="off">
                                            </telerik:RadNumericTextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Value Yes (%)" UniqueName="ValueYesPercent"
                                        SortExpression="ValueYesPercent">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlOperatorYes" runat="server">
                                            </asp:DropDownList>
                                            <telerik:RadNumericTextBox runat="server" ID="tbValueYesPercent" NumberFormat-DecimalDigits="0"
                                                Text='<%# DataBinder.Eval(Container, "DataItem.ValueYesPercent") %>' MinValue="0"
                                                CssClass="preventEnter" autocomplete="off">
                                            </telerik:RadNumericTextBox>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </asp:Panel>
                </div>
            </div>
            <div class="block acc_target">
                <div class="table_green" runat="server" id="divExceptionRequiredMatrix">
                    <h3 class="caption">
                        Risk Mismatch Exception Required Matrix Logic</h3>
                    <telerik:RadButton SkinID="AddNewExceptionRequiredMatrix" ID="btnCreateNewExceptionRequiredMatrix"
                        runat="server" CommandName="Insert" OnClick="btnCreateNewExceptionRequiredMatrix_Click">
                    </telerik:RadButton>
                    <div style="margin-bottom: 2px;">
                    </div>
                    <telerik:RadGrid ID="rgridExceptionRequiredMatrixList" runat="server" OnNeedDataSource="rgridExceptionRequiredMatrixList_NeedDataSource"
                        OnItemCommand="rgridExceptionRequiredMatrixList_ItemCommand" OnItemDataBound="rgridExceptionRequiredMatrixList_ItemDataBound"
                        SkinID="RadGridProfileMismatchMatrixList">
                        <MasterTableView DataKeyNames="ExceptionRequiredMatrixID">
                            <Columns>
                                <telerik:GridTemplateColumn HeaderText="No." UniqueName="Number" ItemStyle-CssClass="NumberColomn">
                                    <HeaderStyle Width="30px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblrgridNumber" runat="server" Text='<%# (rgridExceptionRequiredMatrixList.PageSize*rgridExceptionRequiredMatrixList.CurrentPageIndex)+ Container.ItemIndex + 1 %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="IsVc" HeaderText="VC" SortExpression="IsVc">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsVc" runat="server" Text='<%# (bool)Eval("IsVc") == true ? "Yes" : "No"  %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlIsVc" runat="server">
                                            <asp:ListItem Value="true">Yes</asp:ListItem>
                                            <asp:ListItem Value="false">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="IsRiskMismatch" HeaderText="Risk Mismatch"
                                    SortExpression="IsRiskMismatch">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblIsRiskMismatch" runat="server" Text='<%# (bool)Eval("IsRiskMismatch") == true ? "Yes" : "No"  %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlIsRiskMismatch" runat="server">
                                            <asp:ListItem Value="true">Yes</asp:ListItem>
                                            <asp:ListItem Value="false">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn UniqueName="ExceptionRequireStatus" HeaderText="Exception Require Status"
                                    SortExpression="ExceptionRequireStatus">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblExceptionRequireStatus" runat="server" Text='<%# (bool)Eval("ExceptionRequireStatus") == true ? "Yes" : "No"   %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="ddlExceptionRequireStatus" runat="server">
                                            <asp:ListItem Value="true">Yes</asp:ListItem>
                                            <asp:ListItem Value="false">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Is Active" UniqueName="IsActive" HeaderStyle-HorizontalAlign="Center">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbIsActive" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(DataBinder.Eval(Container, "DataItem.IsActive")) %>' />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="cbIsActive" runat="server" Checked='<%#  Convert.ToBoolean(Convert.IsDBNull(DataBinder.Eval(Container, "DataItem.IsActive"))?false:DataBinder.Eval(Container, "DataItem.IsActive")) %>' />
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Action" UniqueName="Action">
                                    <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEdit" runat="server" SkinID="Edit" CommandName="Edit" />
                                        <asp:ImageButton ID="btnDelete" runat="server" SkinID="Delete" CommandName="Delete"
                                            OnClientClick="javascript:return confirm('Are you sure want to delete?')" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:ImageButton ID="btnSave" runat="server" SkinID="Save" OnClientClick="javascript:return confirm('Are you sure want to save this?')"
                                            CommandName='<%# Convert.ToInt32(Convert.IsDBNull(DataBinder.Eval(Container, "DataItem.ExceptionRequiredMatrixID"))?0:DataBinder.Eval(Container, "DataItem.ExceptionRequiredMatrixID")) == 0 ? "PerformInsert" : "Update" %>' />
                                        <asp:ImageButton ID="btnCancel" runat="server" SkinID="Cancel" CommandName="Cancel"
                                            CausesValidation="false" />
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </div>
            </div>
        </fieldset>
        <div class="block acc_target">
            <div class="table_green">
                <div class="col span_12 text-align-center" style="width: 100%">
                    <asp:Button ID="btnSave" type="submit" OnClick="btnSave_Click" runat="server" CssClass="button blue medium"
                        OnClientClicking="ClickSave" OnClientClicked="OnClientClickSave" Text="Save"
                        ValidationGroup="SaveMatrix" />
                    <asp:Button type="Reset" ID="btnCancel" OnClick="btnCancel_Click" runat="server"
                        Text="Cancel" CssClass="button blue medium" />
                </div>
            </div>
        </div>
    </div>
    <telerik:RadAjaxManager ID="ram" runat="server" DefaultLoadingPanelID="ralp">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="rgridProfileMismatchMatrixList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rgridProfileMismatchMatrixList" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="divProductRatingVsCustomerRisk">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="divProductRatingVsCustomerRisk" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="divExceptionRequiredMatrix">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="divExceptionRequiredMatrix" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="pnlProfileMismatchMatrix">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="pnlProfileMismatchMatrix" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralp" runat="server">
    </telerik:RadAjaxLoadingPanel>
    <style>
        select
        {
            color: Gray;
        }
        .bar
        {
            background-color: #a291a3;
        }
        .table_important_notes tr td:first-child, .table_vulnerable tr td:first-child
        {
            width: 170px;
        }
        .table_blue thead tr th
        {
            font-size: 12px;
        }
        .noscroll
        {
            overflow-x: hidden;
        }
        h3.caption
        {
            text-transform: capitalize !important;
        }
    </style>
</asp:Content>
