<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SOInput.aspx.cs" Inherits="SO.Grid" %>

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
                                <asp:DropDownList ID="DDLCustomer" runat="server" DataSourceID="SqlDataSource1" DataTextField="CUSTOMER_NAME" DataValueField="CUSTOMER_NAME">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SOConnectionString %>" SelectCommand="SELECT [CUSTOMER_NAME] FROM [COM_CUSTOMER]"></asp:SqlDataSource>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage=" Pilih Salah Satu"
                                    ForeColor="Green" ControlToValidate="DDLCustomer">
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
            <asp:Panel ID="List" GroupingText="List" runat="server" Style="margin-left: 67px; border: solid;" Height="709px" Width="824px">
                &nbsp&nbsp<asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" Text="ADD ITEM" />
                <asp:GridView ID="Gridview1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />
                        <asp:TemplateField HeaderText="Header 1">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Header 2">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Header 3">
                            <ItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" />
                            <FooterTemplate>
                                <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row"  />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <%--<asp:GridView ID="GridInput" runat="server" AutoGenerateColumns="False" BorderWidth="1px"
                BorderColor="Black" OnRowCancelingEdit="GridInput_RowCancelingEdit" OnRowEditing="GridInput_RowEditing"
                OnRowDataBound="GridInput_RowDataBound" OnRowUpdating="GridInput_RowUpdating"
                OnRowCommand="GridInput_RowCommand" CellPadding="4"
                Width="939px" ForeColor="#333333" ShowFooter="True" EmptyDataText="Tidak ada data" AllowPaging="True" AllowSorting="True">
                <RowStyle HorizontalAlign="Center" />
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle HorizontalAlign="Center" BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <Columns>
                    <asp:TemplateField HeaderText="NO" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblNo" runat="server" Text='<%#Bind("SALES_SO_LITEM_ID") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ITEM NAME" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblitem" runat="server" Text='<%#Bind("ITEM_NAME") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtItem" runat="server" Text='<%#Bind("ITEM_NAME") %>' MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtItem" runat="server" Text="Isi ya..." ToolTip="Enter Item"
                                ControlToValidate="txtItem"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revtxtItem" runat="server" Text="Enter Item"
                                ToolTip="Enter Item " ControlToValidate="txtItem" ValidationExpression="^[a-zA-Z'.\s]{1,40}$"></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="QTY" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblqty" runat="server" Text='<%#Bind("QUANTITY") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtQty" runat="server" Text='<%#Bind("QUANTITY") %>' MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtQty" runat="server" Text="Isi ya..." ToolTip="Enter qty"
                                ControlToValidate="txtQty"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revtxtQty" runat="server" Text="Enter number"
                                ToolTip="Enter number " ControlToValidate="txtQty" ValidationExpression="^[0-9]"></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PRICE" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblprice" runat="server" Text='<%#Bind("PRICE") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtprice" runat="server" Text='<%#Bind("PRICE") %>' MaxLength="50"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtprice" runat="server" Text="Isi ya..." ToolTip="Enter Price"
                                ControlToValidate="txtprice"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revtxtprice" runat="server" Text="Enter number"
                                ToolTip="Enter Price " ControlToValidate="txtprice" ValidationExpression="^[0-9]"></asp:RegularExpressionValidator>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblTotal" runat="server" Text="TOTAL"></asp:Label>
                        </FooterTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TOTAL" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblTotal" runat="server" Text='<%#Bind("TOTAL") %>' EnableViewState="true"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <div style="text-align: center">
                                <asp:Label ID="lblGrandTotal" runat="server"></asp:Label></div>
                        </FooterTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ACTION" ShowHeader="False">
                        <EditItemTemplate>
                            <asp:Button ID="btnUpdate" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                            &nbsp;<asp:Button ID="btnCancel" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" CommandArgument='<%# Eval("SALES_SO_LITEM_ID") %>' />
                            <asp:Button ID="btnDelete" runat="server" CausesValidation="False" CommandName="DeleteRow" Text="Delete" CommandArgument='<%# Eval("SALES_SO_LITEM_ID") %>'
                                OnClientClick="return confirm('Are you sure?')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>--%>
                <asp:SqlDataSource ID="SqlDataItem" runat="server" ConnectionString="<%$ ConnectionStrings:SOConnectionString %>" SelectCommand="SELECT [SALES_SO_LITEM_ID], [SALES_SO_ID], [ITEM_NAME], [QUANTITY], [PRICE], (QUANTITY * PRICE) as TOTAL FROM [SALES_SO_LITEM]"></asp:SqlDataSource>
                <br />
                <br />
            </asp:Panel>
            <table align="center" border="0" style="width: 199px">
                <tr>
                    <td>
                        <asp:Button ID="btnsave" runat="server" Text="Save" Width="104px" />
                    </td>
                    <td>
                        <asp:Button ID="btncancel" runat="server" CausesValidation="false" Text="Cancel" Width="104px" OnClick="btncancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</asp:Content>
