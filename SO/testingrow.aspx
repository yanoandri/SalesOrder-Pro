<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testingrow.aspx.cs" Inherits="SO.testingrow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <body>
        <form id="form1" runat="server">
            <div id="main">
                <asp:Panel ID="Panel1" runat="server">
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
                                        ClientIDMode="Static">
                                    </asp:TextBox>
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
                                    <asp:DropDownList ID="DDLCustomer" runat="server">
                                    </asp:DropDownList>
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
                <asp:Panel ID="Panel2" runat="server">
                    <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click" CausesValidation="false" />
                    <asp:GridView ID="Gridview1" runat="server" ShowFooter="true" AutoGenerateColumns="false">
                        <columns>
                        <asp:BoundField DataField="RowNumber" HeaderText="NO" />
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
                        </asp:TemplateField>
                    </columns>
                    </asp:GridView>
                </asp:Panel>
            </div>
        </form>
    </body>
</head>
</html>



