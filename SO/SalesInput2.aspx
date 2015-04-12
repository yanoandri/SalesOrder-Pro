<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesInput.aspx.cs" Inherits="WebApplication1.Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="Scripts\jquery.js" type="text/javascript"></script>
    <script src="Scripts\jquery-ui.js" type="text/javascript"></script>
    <script src="Scripts\jquery-ui.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="Styles\jquery-ui.theme.css" />
    <link rel="stylesheet" href="Styles\jquery-ui.min.css" />
    <style>
        body
        {
            background-color: #E6E6E6;
            font-size: small;
            font-family: Lucida Sans Unicode;
        }
        h1
        {
            color: maroon;
            margin-left: 40px;
        }
        
        #main
        {
            background-color: White;
            width: 770px;
            margin-left: 200px;
            margin-top: 100px;
            padding: 25px;
            -webkit-border-radius: 20px;
            height: 557px;
        }
        
        .Center
        {
        }
        
        .Button
        {
            color: White;
            background-color: #1C5E55;
            font-family: Arial Black;
            margin: 15px;
        }
        
        .panel
        {
            border-color: Black;
            padding: 10px;
        }
        
        .GridView
        {
            margin: 15px;
        }
    </style>
    <%--<link rel="stylesheet" href="Styles\Site.css" />--%>
    <script type="text/javascript">
        $(function () {
            $("[id$=txtOrderDate]").datepicker({
                showOn: "button",
                buttonImageOnly: true,
                buttonImage: "images/Callender.png"
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server" class="form">
    <div id="main">
        <asp:Panel ID="Header" runat="server" Font-Bold="True" GroupingText="HEADER" Width="764px"
            Height="157px">
            <br />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label3" Font-Bold="False" runat="server" Text="SALES ORDER NO"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSalesOrderNo" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=" have to fill Sales No"
                            ForeColor="Green" ControlToValidate="txtSalesOrderNo">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Font-Bold="false" Text="SALES ORDER DATE"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOrderDate" runat="server" Width="120px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage=" have to fill Order Date"
                            ForeColor="Green" ControlToValidate="txtOrderDate">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Font-Bold="False" Text="CUSTOMER"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLCustomer" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ForeColor="Green" ControlToValidate="DDLCustomer"
                            InitialValue="Select One" ErrorMessage="Please select something" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Font-Bold="False" Text="ADDRESS"></asp:Label>
                    </td>
                    <td>
                        <textarea id="txtAddress" cols="20" rows="2" runat="server"></textarea>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage=" have to fill Address"
                            ForeColor="Green" ControlToValidate="txtAddress">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
        <asp:Panel ID="Detail" runat="server" Font-Bold="True" GroupingText="DETAIL" Width="760px"
            Height="389px">
            <br />
            <asp:Button ID="btnAddItem" runat="server" Text="ADD ITEM" CssClass="Button" CausesValidation="false"
                OnClick="btnAddItem_Click" />
            <br />
            <asp:GridView ID="GridInput" runat="server" CssClass="GridView" AutoGenerateColumns="false"
                BorderColor="Black" HeaderStyle-BackColor="#1C5E55" FooterStyle-BackColor="#1C5E55"
                OnRowDeleting="GridViewInput_RowDeleting" OnRowUpdating="GridViewInput_RowUpdating"
                OnRowCancelingEdit="GridViewInput_RowCancelingEdit" OnRowEditing="GridViewInput_RowEditing"
                ShowFooter="true" OnRowDataBound="GridViewInput_RowDataBound" ShowHeaderWhenEmpty="true"
                EmptyDataText="No Data Entry" Width="723px" AlternatingRowStyle-BackColor="White">
                <RowStyle BackColor="#E3EAEB" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <FooterStyle HorizontalAlign="Center" BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
               
                <Columns>
                    <asp:TemplateField HeaderText="NO" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center" BorderColor="Black" />
                        <ItemTemplate>
                            <asp:Label ID="lblRowID" runat="server" Text='<%# Eval("RowID") %>' EnableViewState="true"></asp:Label>
                            <asp:Label ID="lblItemID" runat="server" Text='<%# Eval("ItemID") %>' Visible="False"
                                EnableViewState="true"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ITEM NAME" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle BorderColor="Black" HorizontalAlign="Center" />
                        <EditItemTemplate>
                            <asp:TextBox ID="txtItemName" runat="server" Text='<%# Eval("ItemName") %>' EnableViewState="true"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblItemName" runat="server" Text='<%# Eval("ItemName") %>' EnableViewState="true"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="QTY" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center" BorderColor="Black" />
                        <EditItemTemplate>
                            <asp:TextBox ID="txtQty" runat="server" Text='<%# Eval("Quantity") %>' EnableViewState="true"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblQty" runat="server" Text='<%# Eval("Quantity") %>' EnableViewState="true"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PRICE" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle BorderColor="Black" HorizontalAlign="Center" />
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPrice" runat="server" Text='<%# Eval("Price") %>' EnableViewState="true"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price", "{0:N}") %>' EnableViewState="true"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <div style="text-align: right;">
                                <asp:Label ID="lbl1" runat="server" Text="TOTAL"></asp:Label>
                            </div>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TOTAL" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle BorderColor="Black" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("Total") %>' EnableViewState="true"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <div style="text-align: right;">
                                <asp:Label ID="lblGrandTotal" runat="server" Text="TOTAL"></asp:Label></div>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ACTION" HeaderStyle-HorizontalAlign="Center">
                        <ItemStyle HorizontalAlign="Center" BorderColor="Black" />
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" Text="EDIT" CommandName="Edit" CausesValidation="false" />
                            <asp:Button ID="btnDelete" runat="server" Text="DELETE" CommandName="Delete" CausesValidation="false" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Button ID="btnSave" runat="server" Text="SAVE" CommandName="Update" />
                            <asp:Button ID="btnCancel" runat="server" Text="CANCEL" CommandName="Cancel" CausesValidation="false" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <table align="center" border="0" cellpadding="4" cellspacing="3" style="width: 223px;
                height: 50px;">
                <tr>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="SAVE" OnClick="btnSave_Click" CssClass="Button"
                            Width="74px" />
                    </td>
                    <td>
                        <asp:Button ID="btnCancel" runat="server" Text="CANCEL" CssClass="Button" CausesValidation="false"
                            OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
