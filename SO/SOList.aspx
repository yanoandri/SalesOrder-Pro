<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SOList.aspx.cs" MasterPageFile="~/Site.Master" Inherits="SO.SOList" %>

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
    <form id="formSearch">
        <div id="main" class="Center">
            <asp:Panel ID="Header" runat="server" Font-Bold="True" GroupingText="HEADER" Style="margin-left: 12px"
                Width="890px" BorderStyle="Solid">
                <br />
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="KEYWORDS" Font-Bold="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtkey" runat="server" Width="194px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="ORDER DATE" Font-Bold="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCalendar" CssClass="txtCalendarCss" runat="server" Width="162px"
                                ClientIDMode="Static"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td align="right">
                            <asp:Button ID="btnsearch" runat="server" Text="SEARCH" CssClass="Button" OnClick="btnsearch_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <br />
            <br />
            <asp:Panel ID="Detail" runat="server" Font-Bold="True" GroupingText="DETAIL" Style="margin-left: 12px"
                Width="890px" BorderStyle="Solid">
                &nbsp&nbsp<asp:Button ID="btnAdd" runat="server" Text="ADD SO" OnClick="Button3_Click" />
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="SALES_SO_ID" OnRowDeleting="GridView1_RowDeleting"
                    OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="NO" SortExpression="SALES_SO_ID">
                            <EditItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("SALES_SO_ID") %>'></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("SALES_SO_ID") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#009933" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SALES ORDER NO" SortExpression="SO_NO">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("SO_NO") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("SO_NO") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#009933" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ORDER DATE" SortExpression="ORDER_DATE">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ORDER_DATE") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("ORDER_DATE") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#009933" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CUSTOMER" SortExpression="COM_CUSTOMER_ID">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("CUSTOMER_NAME") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("CUSTOMER_NAME") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#009933" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ADDRESS" SortExpression="ADDRESS">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ADDRESS") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("ADDRESS") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#009933" />
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" CommandArgument='<%# Eval("SALES_SO_ID") %>' />
                                <asp:Button ID="btnDelete" runat="server" CausesValidation="true" CommandName="Delete" Text="Delete" CommandArgument='<%# Eval("SALES_SO_ID") %>'
                                    OnClientClick="return confirm('Are you sure?')" />
                            </ItemTemplate>
                            <HeaderStyle BackColor="#009933" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </div>
    </form>
</asp:Content>
