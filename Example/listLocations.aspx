<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="listLocations.aspx.cs" Inherits="Example.listLocations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button CssClass="button" ID="btnListUsers" Text="Kullanıcılar" UseSubmitBehavior="false"  runat="server" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;" OnClick="btnListUsers_Click" />
    <asp:Button CssClass="button" ID="btnListProduct" Text="Ürünler" UseSubmitBehavior="false"  runat="server" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;" OnClick="btnListProduct_Click"/>
    <asp:Button CssClass="button" ID="btnListLocations" Text="Lokasyonlar" UseSubmitBehavior="false"  runat="server" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;" />
    <asp:Button CssClass="button" ID="btnListMovements" Text="Operasyonlar" UseSubmitBehavior="false"  runat="server" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;" OnClick="btnListMovements_Click" />
    <br />
    <br />
    <asp:TextBox ID="txtStore" runat="server" Style="margin-top: 20px; margin-left: 6px; " Width="85px" OnTextChanged="txtStore_TextChanged"></asp:TextBox>
    <asp:TextBox ID="txtHall" runat="server" Style="margin-top: 20px; margin-left: 4px; " Width="92px" OnTextChanged="txtStore_TextChanged"></asp:TextBox>
    <asp:TextBox ID="txtColon" runat="server" Style="margin-top: 20px; margin-left: 4px; " Width="77px" OnTextChanged="txtStore_TextChanged"></asp:TextBox>
    <asp:TextBox ID="txtShelf" runat="server" Style="margin-top: 20px; margin-left: 3px; " Width="64px" OnTextChanged="txtStore_TextChanged"></asp:TextBox>
    <asp:Button ID="btnFiltre" Text="Filtrele" runat="server" Style="margin-top: 8px; margin-bottom: 4px; margin-left: 29px; background-color: #555555; border: none; color: white;" CommandName="cmdFilter" CommandArgument='<%# Eval("Id") %>' Height="20px" Width="64px" OnClick="btnFiltre_Click" />

    <!-------------------Location List------------------>
    <asp:ListView ID="lstLocationsView" runat="server">
        <EmptyDataTemplate>
            Kayıtlı Lokasyon bulunmamaktadır.
        </EmptyDataTemplate>
        <ItemTemplate>
            <tr style="padding: 20px">
                <td style="padding: 20px; border-left: solid; border-collapse: collapse; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("StoreType").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("HallType").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("Column").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("Shelf").ToString() %>
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table>
                <thead>
                    <tr>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Depo
                        </th>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Koridor
                        </th>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Kolon
                        </th>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Kat
                        </th>
                    </tr>
                </thead>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
            </table>
        </LayoutTemplate>
    </asp:ListView>

</asp:Content>
