<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SOInput.aspx.cs" MasterPageFile="~/Site.Master" Inherits="SO.SOInput2" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script type="text/javascript">
        $(function () {
            $('.txtCalendarCss').datepicker({
                dateFormat: "yy-mm-dd",
                showOn: "button",
                buttonImage: "Images/calender.png",
                buttonImageOnly: true
            });
        });
    </script>
    <form id="form1">
        <div id="main">
            <asp:Panel ID="Header" Font-Bold="True" runat="server" GroupingText="HEADER" Style="margin-left: 66px; margin-right: 61px; border: solid;">
                <div>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="SALES ORDER NO" Font-Bold="False"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtsales" runat="server" Width="161px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" Wajib Diisi"
                                    ForeColor="Green" ControlToValidate="txtsales">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="SALES ORDER DATE" Font-Bold="False"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtdate" CssClass="txtCalendarCss" runat="server" Width="162px"
                                    ClientIDMode="Static"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage=" Wajib Diisi"
                                    ForeColor="Green" ControlToValidate="txtdate">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="CUSTOMER" Font-Bold="False"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DDLCustomer" runat="server" DataSourceID="SqlDataSource1" AppendDataBoundItems="true" DataTextField="CUSTOMER_NAME" DataValueField="COM_CUSTOMER_ID">
                                    <asp:ListItem Text="--Select One--" Value="" />
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SOConnectionString %>" SelectCommand="SELECT * FROM [COM_CUSTOMER]"></asp:SqlDataSource>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage=" Pilih Salah Satu"
                                    ForeColor="Green" ControlToValidate="DDLCustomer" InitialValue="0">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="ADDRESS" Font-Bold="False"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtaddres" runat="server" Width="174px" Height="50"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage=" Wajib Diisi"
                                    ForeColor="Green" ControlToValidate="txtaddres">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <br />
            <asp:Panel ID="List" GroupingText="List" runat="server" Style="border-style: solid; border-color: inherit; border-width: medium; margin-left: 67px; margin-right: 0px;" Height="444px" Width="827px">
                &nbsp&nbsp<asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" Text="ADD ITEM" CausesValidation="false" />
                <br />
                <br />
                <asp:GridView ID="GridInput" runat="server" AutoGenerateColumns="False" BorderWidth="1px"
                    BorderColor="Black" OnRowCancelingEdit="GridInput_RowCancelingEdit" OnRowEditing="GridInput_RowEditing"
                    OnRowDataBound="GridInput_RowDataBound" OnRowUpdating="GridInput_RowUpdating" OnRowCommand="GridInput_RowCommand" OnRowDeleting="GridInput_RowDeleting"
                    CellPadding="4"
                    Width="678px" ForeColor="#333333" ShowFooter="True" EmptyDataText="Please Add an Item" AllowPaging="True" AllowSorting="True" Height="5px" HorizontalAlign="Center" PageSize="5">
                    <RowStyle BackColor="#E3EAEB" />
                    <AlternatingRowStyle BackColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="NO">
                            <ItemTemplate>
                                <asp:Label ID="lblUrut" runat="server" Text='<%#Bind("NO_URUT") %>'></asp:Label>
                                <asp:Label ID="lblNo" runat="server" Text='<%#Bind("SALES_SO_LITEM_ID") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="ITEM NAME">
                            <ItemTemplate>
                                <asp:Label ID="lblitem" runat="server" Text='<%#Bind("ITEM_NAME") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtItem" runat="server" MaxLength="50" Text='<%#Bind("ITEM_NAME") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtItem" runat="server" ControlToValidate="txtItem" Text="Please fill..." ToolTip="Enter Item"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtItem" runat="server" ControlToValidate="txtItem" Text="Enter Item" ToolTip="Enter Item " ValidationExpression="^[a-zA-Z'.\s]{1,40}$"></asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="QUANTITY">
                            <ItemTemplate>
                                <asp:Label ID="lblqty" runat="server" Text='<%#Bind("QUANTITY") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtQty" runat="server" MaxLength="50" Text='<%#Bind("QUANTITY") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtQty" runat="server" ControlToValidate="txtQty" Text="Isi ya..." ToolTip="Enter qty"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtQty" runat="server" ControlToValidate="txtQty" Text="Please fill..." ToolTip="Enter number " ValidationExpression="^[0-9]"></asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="PRICE">
                            <ItemTemplate>
                                <asp:Label ID="lblprice" runat="server" Text='<%#Bind("PRICE") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtprice" runat="server" MaxLength="50" Text='<%#Bind("PRICE") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtprice" runat="server" ControlToValidate="txtprice" Text="Please fil...." ToolTip="Enter Price"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revtxtprice" runat="server" ControlToValidate="txtprice" Text="Enter number" ToolTip="Enter Price " ValidationExpression="^[0-9]"></asp:RegularExpressionValidator>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lblTotal" runat="server" Text="TOTAL"></asp:Label>
                            </FooterTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="TOTAL">
                            <ItemTemplate>
                                <asp:Label ID="lblTotal" runat="server" EnableViewState="true" Text=""></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <div style="text-align: center">
                                    <asp:Label ID="lblGrandTotal" runat="server"></asp:Label>
                                </div>
                            </FooterTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ACTION" ShowHeader="False">
                            <EditItemTemplate>
                                <asp:Button ID="btnUpdate" runat="server" CausesValidation="False" CommandName="Update" Text="Update" />
                                &nbsp;<asp:Button ID="btnCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" CausesValidation="False" CommandArgument='<%# Eval("SALES_SO_LITEM_ID") %>' CommandName="Edit" Text="Edit" />
                                <asp:Button ID="btnDelete" runat="server" CausesValidation="False" CommandArgument='<%# Eval("NO_URUT") %>' CommandName="DeleteRow" OnClientClick="return confirm('Are you sure?')" Text="Delete" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle HorizontalAlign="Center" />
                </asp:GridView>
                <br />
                <br />
            </asp:Panel>
            <table style="vertical-align: middle; text-align: center;">
                <tr>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click" CssClass="Button"
                            Width="74px" />
                    </td>
                    <td>
                        <asp:Button ID="btnCancelOrder" runat="server" Text="CANCEL" CssClass="Button" CausesValidation="false"
                            OnClick="btnCancelOrder_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>

