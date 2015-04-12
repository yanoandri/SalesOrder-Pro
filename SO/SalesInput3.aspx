<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesInput.aspx.cs" Inherits="asp_3.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="css/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>
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
            width: 949px;
            margin-left: 200px;
            margin-top: 100px;
            padding: 25px;
            -webkit-border-radius: 20px;
            height: 575px;
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
    <script type="text/javascript">
        $(function () {

            $('.txtCalendarCss').datepicker({
                dateFormat: "yy-mm-dd",
                showOn: "button",
                buttonImage: "image/calender.png",
                buttonImageOnly: true
            });

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="main">
        <asp:Panel ID="Header" Font-Bold="True" runat="server" GroupingText="HEADER">
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
        <br />
        <br />
        <asp:Panel ID="Detail" runat="server" Font-Bold="True" GroupingText="DETAIL" Width="949px"
            Height="388px">
            <asp:Button ID="btnadd" runat="server" Text="ADD ITEM" CssClass="Button" CausesValidation="false"
                OnClick="btnadd_Click" />
            <br />
            <br />
            <asp:GridView ID="GridInput" runat="server" AutoGenerateColumns="False" BorderWidth="1px"
                BorderColor="Black" OnRowCancelingEdit="GridView1_RowCanceling" OnRowEditing="GridView1_RowEditing"
                OnRowDataBound="GridView1_RowDataBound1" OnRowUpdating="GridView1_RowUpdating"
                OnRowCommand="GridView1_RowCommand" CellPadding="4" EnableModelValidation="True"
                Width="939px" ForeColor="#333333" ShowFooter="true" EmptyDataText="Tidak ada data">
                <RowStyle HorizontalAlign="Center" />
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle HorizontalAlign="Center" BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <Columns>
                    <asp:TemplateField HeaderText="NO" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblNo" runat="server" Text='<%#Container.DataItemIndex +1 %>'></asp:Label>
                        </ItemTemplate>
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
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TOTAL" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblTotal" runat="server" Text='<%#Bind("Total") %>' EnableViewState="true"></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <div style="text-align: center">
                                <asp:Label ID="lblGrandTotal" runat="server"></asp:Label></div>
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Action</HeaderTemplate>
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" CommandArgument='<%# Eval("SALES_SO_ITEM_ID") %>' />
                            <asp:Button ID="btnDelete" runat="server" CommandName="DeleteRow" Text="Delete" CommandArgument='<%# Eval("SALES_SO_ITEM_ID") %>'
                                CausesValidation="false" OnClientClick="return confirm('Are you sure?')" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Button ID="btnUpdate" runat="server" CommandName="Update" Text="Save" CausesValidation="false" />
                            <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" CausesValidation="false" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <table align="center" border="0" cellpadding="7" cellspacing="8" style="width: 199px">
                <tr>
                    <td>
                        <asp:Button ID="btnsave" runat="server" OnClick="btnsave_Click" Text="Save" Width="104px" />
                    </td>
                    <td>
                        <asp:Button ID="btncancel" runat="server" OnClick="btncancel_Click" Text="Cancel"
                            CausesValidation="false" Width="104px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
