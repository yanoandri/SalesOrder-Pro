<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridEdit.aspx.cs" Inherits="EditableNested.GridEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" AllowPaging="True" BackColor="#F1F1F1"
            AutoGenerateColumns="False" DataSourceID="AccessDataSource1"
            DataKeyNames="CustomerID"
            Style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 32px"
            ShowFooter="True" Font-Size="Small"
            Font-Names="Verdana" runat="server" GridLines="None" BorderStyle="Outset" AllowSorting="True"
            OnRowDataBound="GridView1_RowDataBound"
            OnRowCommand="GridView1_RowCommand"
            OnRowUpdating="GridView1_RowUpdating"
            OnRowDeleting="GridView1_RowDeleting"
            OnRowDeleted="GridView1_RowDeleted"
            OnRowUpdated="GridView1_RowUpdated">
            <Columns>
                <asp:TemplateField HeaderText="CustomerID" SortExpression="CustomerID">
                    <EditItemTemplate>
                        <asp:Label ID="lblCustomerID" runat="server" Text='<%# Eval("CustomerID") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblCustomerID" runat="server" Text='<%# Bind("CustomerID") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CompanyName" SortExpression="CompanyName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CompanyName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("CompanyName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ContactName" SortExpression="ContactName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("ContactName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("ContactName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ContactTitle" SortExpression="ContactTitle">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("ContactTitle") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("ContactTitle") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address" SortExpression="Address">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Address") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="Edit" ShowEditButton="True" />
                <asp:TemplateField HeaderText="Delete">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkDeleteCust" CommandName="Delete"
                            runat="server">Delete</asp:LinkButton>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="linkAddCust" CommandName="AddCustomer" Text="ADD" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server"
            DataFile="App_Data/Northwind.mdb"
            SelectCommand="SELECT [Customers].[CustomerID], 
    [Customers].[CompanyName],[Customers].[ContactName],
    [Customers].[ContactTitle],[Customers].[Address] FROM [Customers] 
    ORDER BY [Customers].[CustomerID]"></asp:AccessDataSource>
    </form>
</body>
</html>
