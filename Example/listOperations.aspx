<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="listOperations.aspx.cs" Inherits="Example.listOperations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button CssClass="button" ID="btnListUsers" Text="Kullanıcılar" UseSubmitBehavior="false" runat="server" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;" OnClick="btnListUsers_Click" />
    <asp:Button CssClass="button" ID="btnListProduct" Text="Ürünler" UseSubmitBehavior="false" runat="server" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;" OnClick="btnListProduct_Click" />
    <asp:Button CssClass="button" ID="btnListLocations" Text="Lokasyonlar" UseSubmitBehavior="false" runat="server" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;" OnClick="btnListLocations_Click" />
    <asp:Button CssClass="button" ID="btnListMovements" Text="Operasyonlar" UseSubmitBehavior="false" runat="server" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;" OnClick="btnListMovements_Click" />
    <br />
    <br />
    <asp:TextBox ID="txtUser" runat="server" Style="margin-top: 20px; margin-left: 6px; " OnTextChanged="txtPrCode_TextChanged" Width="120px"></asp:TextBox>
    <asp:TextBox ID="txtPrCode" runat="server" Style="margin-top: 20px; margin-left: 6px; width: 115px" OnTextChanged="txtPrCode_TextChanged"></asp:TextBox>
    <asp:TextBox ID="txtPrName" runat="server" Style="margin-top: 20px; margin-left: 1px; width: 105px" OnTextChanged="txtPrCode_TextChanged"></asp:TextBox>
    <asp:DropDownList ID="ddlstType" runat="server" Style="margin-top: 20px; margin-left: 3px; width: 142px" OnTextChanged="txtPrCode_TextChanged"></asp:DropDownList>
    <asp:TextBox ID="txtAmount" runat="server" Style="margin-top: 20px; margin-left: 2px;" Width="84px" OnTextChanged="txtPrCode_TextChanged"></asp:TextBox>
    <asp:TextBox ID="txtUnit" runat="server" Style="margin-top: 20px; margin-left: 12px; " OnTextChanged="txtPrCode_TextChanged" Width="67px"></asp:TextBox>
    <asp:TextBox ID="txtDate" runat="server" TextMode="DateTime" Style="margin-top: 20px; margin-left: 6px;" Width="157px"></asp:TextBox>
    <asp:Button ID="btnFilter" Text="Filtrele" runat="server" Style="margin-top: 8px; margin-bottom: 4px; margin-left: 29px; background-color: #555555; border: none; color: white;" Height="20px" Width="64px" OnClick="btnFilter_Click" />

    <!---------------------Movements List----------------------------------------->
    <asp:ListView ID="lstMovementsView" runat="server">
        <EmptyDataTemplate>
            Kayıtlı Hareket Bulunmamaktadır.
        </EmptyDataTemplate>
        <ItemTemplate>
            <tr style="padding: 20px">
                <td style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("UserName").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-collapse: collapse; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("ProductCode").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("ProductName").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("MoveType").Equals(1) ? "sevk" : "mal kabul" %>
                </td>
                <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <%# (Convert.ToInt32(Eval("Amount")).CompareTo(0) < 0) ? ((-1)*Convert.ToInt32(Eval("Amount"))).ToString() : Eval("Amount").ToString() %>
                </td>
                 <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("UnitType").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("DateOfMovement").ToString() %>
                </td>

            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table>
                <thead>
                    <tr>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Kullanıcı
                        </th>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Ürün Kodu
                        </th>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Ürün Adı
                        </th>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Operasyon tipi
                        </th>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Miktar
                        </th>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Birim
                        </th>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Operasyon Tarihi
                        </th>
                    </tr>
                </thead>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
            </table>
        </LayoutTemplate>
    </asp:ListView>
</asp:Content>
