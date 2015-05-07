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
                Width="890px" BorderStyle="Solid" ScrollBars="Auto">
                &nbsp&nbsp<asp:Button ID="btnAdd" runat="server" Text="ADD SO" OnClick="btnAdd_Click" />
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="SalesSoId" OnRowDeleting="GridView1_RowDeleting"
                    OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging" Height="252px" PageSize="5" Width="719px" CellPadding="4" ForeColor="#333333" GridLines="Both" HorizontalAlign="Center"
                    OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="NO" SortExpression="SalesSoId">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"SalesSoId") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#009933" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SO NO" SortExpression="SalesOrderNumber">
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"SalesOrderNo") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#009933" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ORDER DATE" SortExpression="OrderDate">
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<% #DataBinder.Eval(Container.DataItem,"OrderDate")  %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#009933" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="CUSTOMER" SortExpression="CustomerName">
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"CustomerName") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#009933" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ADDRESS" SortExpression="Address">
                            <ItemTemplate>
                                <asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Address") %>'></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#009933" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False" HeaderText="ACTION">
                            <ItemTemplate>
                                <asp:Button ID="btnEdit" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"SalesSoId") %>' />
                                <asp:Button ID="btnDelete" runat="server" CausesValidation="true" CommandName="Delete" Text="Delete" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"SalesSoId") %>'
                                  OnClientClick="return confirm('Are you sure?')" />
                            </ItemTemplate>
                            <HeaderStyle BackColor="#009933" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <PagerSettings PageButtonCount="5" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <RowStyle BackColor="#E3EAEB" HorizontalAlign="Left" VerticalAlign="Middle" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </asp:Panel>
        </div>
    </form>
</asp:Content>
