<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesList.aspx.cs" Inherits="asp_3.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/jquery-ui.css" rel="stylesheet" />
    <script src="Scripts/jquery.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            $('.txtCalendarCss').datepicker({
                dateFormat: "dd-mm-yy",

                showOn: "button",
                buttonImage: "image/Calendar.png",
                buttonImageOnly: true
            });

        });
    </script>
    <style>
        body
        {
            background-color: #E6E6E6;
            font-size: small;
            font-family: Lucida Sans Unicode;
        }
        #main
        {
            background-color: White;
            width: 907px;
            margin-left: 200px;
            margin-top: 100px;
            padding: 25px;
            -webkit-border-radius: 20px;
            height: 523px;
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
            margin-left: 0px;
        }
        
        .GridView
        {
            margin: 15px;
        }
        .btn
        {
            border-radius: 10px 10px 10px 10px;
            -moz-border-radius: 10px 10px 10px 10px;
            -webkit-border-radius: 10px 10px 10px 10px;
            border: 0px double #000000;
            background-color:#0015ff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="form">
    <div id="main" class="Center">
<fieldset style="border-style: solid; border-width: thin">
    <legend>Search</legend>
            <br />
            <table runat="server" align="center">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="KEYWORDS" Font-Bold="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtkey" runat="server" Width="194px" MaxLength="20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="ORDER DATE" Font-Bold="False"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDate" CssClass="txtCalendarCss" runat="server" Width="162px"
                            ClientIDMode="Static" MaxLength="10" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="right">
                        <asp:Button ID="btnsearch" runat="server" Text="SEARCH" CssClass="btn" OnClick="btnsearch_Click" ForeColor="White" />
                    </td>
                </tr>
            </table>
    </fieldset>
        <br />
        <br />
<fieldset style="border-style: solid; border-width: thin">
            <asp:Button ID="ADD" runat="server" Text="ADD SO" CssClass="btn" OnClick="btnadd_Click" ForeColor="White" />
            <br />
            <asp:GridView ID="GridList" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                DataKeyNames="SALES_SO_ID" BorderWidth="1px" BorderColor="#3366CC" OnRowDeleting="GridList_RowDeleting"
                OnRowDataBound="GridList_RowDataBound" OnRowCommand="GridList_RowCommand" OnPageIndexChanging="GridList_PageIndexChanging"
                HeaderStyle-BackColor="#1C5E55" FooterStyle-BackColor="#1C5E55" CellPadding="4"
                PageSize="5" Width="859px" CssClass="GridView" BackColor="White" BorderStyle="None">
                <FooterStyle HorizontalAlign="Center" BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left"/>
                <RowStyle BackColor="White" ForeColor="#003399" />
                <Columns>
                    <asp:TemplateField HeaderText="NO" HeaderStyle-HorizontalAlign="Center">

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" BorderColor="Black" />
                        <ItemTemplate>
                            <asp:Label ID="lblNumber" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SALES ORDER NO" HeaderStyle-HorizontalAlign="Center">

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" BorderColor="Black" />
                        <ItemTemplate>
                            <asp:Label ID="lblsales" runat="server" Text='<%#Bind("SO_NO") %>'></asp:Label>
                            <asp:Label ID="lblSoID" runat="server" Text='<%# Bind("SALES_SO_ID") %>' Visible="false"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ORDER DATE" HeaderStyle-HorizontalAlign="Center">

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" BorderColor="Black" />
                        <ItemTemplate>
                            <asp:Label ID="lbldate" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ORDER_DATE","{0:d}") %>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CUSTOMER" HeaderStyle-HorizontalAlign="Center">

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" BorderColor="Black" />
                        <ItemTemplate>
                            <asp:Label ID="lblcustomer" runat="server" Text='<%#Bind("CUSTOMER_NAME") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ACTION" HeaderStyle-HorizontalAlign="Center">

<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

                        <ItemStyle HorizontalAlign="Center" BorderColor="Black" />
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" CommandArgument='<%# Eval("SALES_SO_ID") %>' />
                            <asp:Button ID="btnDelete" runat="server" CommandName="Delete" Text="Delete" CommandArgument='<%# Eval("SALES_SO_ID") %>'
                                CausesValidation="true" OnClientClick="return confirm('Are you sure?')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
</fieldset>
        <br />
    </div>
    </form>
</body>
</html>
