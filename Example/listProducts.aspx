<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="listProducts.aspx.cs" Inherits="Example.listProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button CssClass="button" ID="btnListUsers" UseSubmitBehavior="false"  Text="Kullanıcılar" runat="server" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;" OnClick="btnListUsers_Click" />
    <asp:Button CssClass="button" ID="btnListProduct" UseSubmitBehavior="false" Text="Ürünler" runat="server" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;"/>
    <asp:Button CssClass="button" ID="btnListLocations" UseSubmitBehavior="false" Text="Lokasyonlar" runat="server" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;" OnClick="btnListLocations_Click" />
    <asp:Button CssClass="button" ID="btnListMovements" UseSubmitBehavior="false" Text="Operasyonlar" runat="server" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;" OnClick="btnListMovements_Click" />
    <br />
    <br />
    <asp:TextBox ID="txtPrCode" runat="server" Style="margin-top: 20px; margin-left: 6px; width: 115px" OnTextChanged="txtPrCode_TextChanged"></asp:TextBox>
    <asp:TextBox ID="txtPrName" runat="server" Style="margin-top: 20px; margin-left: 1px; width: 105px" OnTextChanged="txtPrCode_TextChanged"></asp:TextBox>
    <asp:TextBox ID="txtBirim" runat="server" Style="margin-top: 20px; margin-left: 6px; width: 78px" OnTextChanged="txtPrCode_TextChanged"></asp:TextBox>
    <asp:TextBox ID="txtTitle" runat="server" Style="margin-top: 20px; margin-left: 3px; " Width="80px" OnTextChanged="txtPrCode_TextChanged"></asp:TextBox>
    <asp:TextBox ID="txtSerialNo" runat="server" Style="margin-top: 20px; margin-left: 3px; " Width="132px" OnTextChanged="txtPrCode_TextChanged"></asp:TextBox>
    <asp:TextBox ID="txtStatus" runat="server" Style="margin-top: 20px; margin-left: 3px; " Width="78px" OnTextChanged="txtPrCode_TextChanged"></asp:TextBox>
    <asp:TextBox ID="txtCategory" runat="server" Style="margin-top: 20px; margin-left: 3px; " Width="98px" OnTextChanged="txtPrCode_TextChanged"></asp:TextBox>
    <asp:TextBox ID="txtComment" runat="server" Style="margin-top: 20px; margin-left: 3px; width: 103px" OnTextChanged="txtPrCode_TextChanged"></asp:TextBox>
    <asp:Button ID="btnFilter" Text="Filtrele" runat="server" Style="margin-top: 8px; margin-bottom: 4px; margin-left: 29px; background-color: #555555; border: none; color: white;" Height="20px" Width="64px" OnClick="btnFilter_Click" />
    
    <asp:ListView ID="lstProducts" runat="server">
        <ItemTemplate>
            <tr style="padding: 20px">
                <td style="padding: 20px; border-left: solid; border-collapse: collapse; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("ProductCode").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("ProductName").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("UnitType").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("Title").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("SerialNum").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("StatusType").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("CategoryType").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("Comment").ToString() %>
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table>
                <thead>
                    <tr>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Ürün Kodu
                        </th>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Ürün Adı
                        </th>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Birim
                        </th>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Marka
                        </th>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Seri Numarası
                        </th>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Statü
                        </th>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Kategori
                        </th>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Açıklama
                        </th>
                    </tr>
                </thead>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
            </table>
        </LayoutTemplate>
    </asp:ListView>
</asp:Content>
