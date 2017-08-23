<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="purchase.aspx.cs" Inherits="Example.purchase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label Text="Ürün Kodu" runat="server" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;"></asp:Label>
    <asp:DropDownList ID="ddlstProduct" AutoPostBack="true" runat="server" Style="height:25px; width:80px; margin-top: 20px; margin-left: 50px;" Height="16px" OnTextChanged="ddlstProduct_TextChanged"></asp:DropDownList>
    <asp:Label ID="lblExpDate" Text="Son Kullanım Tarihi" runat="server" Visible="true" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 50px;"></asp:Label>
    <asp:TextBox ID="txtExpDate" runat="server" Visible="true" Style="margin-top: 20px; margin-left: 20px;" ReadOnly="true" ></asp:TextBox>
    <asp:ImageButton ID="ImageButton1" runat="server" Height="16px" ImageUrl="~/img/calendar.png" OnClick="ImageButton1_Click" Width="16px" />
    <asp:Label ID="ExpDateLabel" runat="server" CssClass="labelClass"></asp:Label>   
    <div style="margin-left: 440px">
        <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" BackColor="White" Visible="false" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="180px" Width="200px">
            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
            <NextPrevStyle VerticalAlign="Bottom" />
            <OtherMonthDayStyle ForeColor="#808080" />
            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
            <SelectorStyle BackColor="#CCCCCC" />
            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
            <WeekendDayStyle BackColor="#FFFFCC" />
        </asp:Calendar>
    </div>
    
    <br />
    <asp:Label ID="lblamount" Text="Miktar" runat="server" CssClass="labelClass" Visible="true" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;"></asp:Label>
    <asp:TextBox ID="txtAmount" runat="server" Columns="15" Visible="true" Style="margin-top: 20px; margin-left: 78px;" Width="67px"></asp:TextBox>
    <asp:Label ID="lblUnit" Text="  " runat="server" Style="margin-top: 20px; margin-bottom: 20px;"></asp:Label>

    <asp:Label ID="lblStatus" Text="Stok Statüsü" runat="server" CssClass="labelClass" Visible="true" Style="margin-top: 20px; margin-bottom: 20px; margin-left:40px;"></asp:Label>
    <asp:DropDownList ID="ddlstStatus" runat="server" Style="margin-top: 20px; margin-left: 70px;"></asp:DropDownList>
    <br />
    <asp:Label ID="lblLocation" Text="Lokasyon:" runat="server" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px; margin-right:10px"></asp:Label>
    <asp:Label ID="Label4" runat="server" Text="Depo"></asp:Label>
    <asp:DropDownList ID="ddlstLocStore" Visible="true" runat="server" Style="margin-top: 20px; margin-left: 8px; margin-right: 19px;" Height="17px" Width="79px"></asp:DropDownList>
    <asp:Label ID="Label1" runat="server" Text="Koridor"></asp:Label>
    <asp:DropDownList ID="ddlstLocHall" Visible="true" runat="server" Style="margin-top: 20px;margin-right:17px; margin-left: 8px;" Height="22px" Width="78px"></asp:DropDownList>
    <asp:Label ID="Label2" runat="server" Text="Kolon"></asp:Label>
    <asp:DropDownList ID="ddlstColon" Visible="true" runat="server" Style="margin-top: 20px; margin-left: 10px; margin-right: 21px;" Height="22px" Width="85px"></asp:DropDownList>
    <asp:Label ID="Label3" runat="server" Text="Kat"></asp:Label>
    <asp:DropDownList ID="ddlstShelf" Visible="true" runat="server" Style="margin-top: 20px; margin-left: 6px;" Height="23px" Width="85px"></asp:DropDownList>

    <br />

    <br />
    <asp:Button CssClass="button" ID="btnInsert" Text="Ekle" runat="server" Visible="true" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;" OnClick="btnInsert_Click"/>
    <br />
    <asp:ListView runat="server" ID="lstPurchaseView">
        <EmptyDataTemplate>
            Stok tablosunda bu ürün koduna ait kayıt bulunmamaktadır. 
        </EmptyDataTemplate>
        <ItemTemplate>
            <tr style="padding: 20px">
                <td style="padding: 20px">
                    <asp:Label runat="server" ID="lblPCode" Text='<%#Eval("ProductCode") %>'></asp:Label>
                    <asp:Label runat="server" ID="lblStockID" Text='<%#Eval("Id") %>' Visible="false"></asp:Label>
                </td>                
                <td style="padding: 20px">
                    <asp:Label runat="server" ID="lblPName" Text='<%#Eval("ProductName") %>' ></asp:Label>
                </td>
                <td style="padding: 20px">
                    <%# Eval("Amount") %>
                </td>
                <td style="padding: 20px">
                    <%# Eval("UnitType") %>
                </td>
                <td style="padding: 20px">
                    <%# Eval("RegistrationDate") %>
                </td>
                <td style="padding: 20px">
                    <%# Eval("ExpirationDate") %>
                </td>
                <td style="padding: 20px">
                    <%# Eval("Location") %>
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table>
                <thead>
                    <tr>
                        <th style="padding: 20px">Ürün Kodu
                        </th>
                        <th style="padding: 20px">Ürün Adı
                        </th>
                        <th style="padding: 20px">Miktar
                        </th>
                        <th style="padding: 20px">Birim
                        </th>
                        <th style="padding: 20px">Kayıt Tarihi
                        </th>
                        <th style="padding: 20px">Son Kullanma Tarihi
                        </th>
                        <th style="padding: 20px">Lokasyon
                        </th>
                    </tr>
                </thead>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </table>
        </LayoutTemplate>
    </asp:ListView>
</asp:Content>
