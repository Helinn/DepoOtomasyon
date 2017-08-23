<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="lists.aspx.cs" Inherits="Example.lists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button CssClass="button" ID="btnListUsers" Text="Kullanıcılar" runat="server" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;" OnClick="btnListUsers_Click" />
    <asp:Button CssClass="button" ID="btnListProduct" Text="Ürünler" runat="server" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;" OnClick="btnListProduct_Click"/>
    <asp:Button CssClass="button" ID="btnListLocations" Text="Lokasyonlar" runat="server" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;" OnClick="btnListLocations_Click" />
    <asp:Button CssClass="button" ID="btnListMovements" Text="Operasyonlar" runat="server" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;" OnClick="btnListMovements_Click" />
    <br />
    <br />
</asp:Content>
