<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="YeniKayit.aspx.cs" Inherits="Example.YeniKayit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label Text="Ad" runat="server" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;"></asp:Label>
        <asp:TextBox ID="txtName" runat="server" Style="margin-top: 20px; margin-left: 107px;"></asp:TextBox>
        <asp:Label Text="*" runat="server" Font-Bold="true"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Ad alanı zorunludur." Font-Bold="True"></asp:RequiredFieldValidator>
        <br />
        <asp:Label Text="Soyad" runat="server" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;"></asp:Label>
        <asp:TextBox ID="txtSurname" runat="server" Style="margin-top: 20px; margin-left: 89px;"></asp:TextBox>
        <asp:Label Text="*" runat="server" Font-Bold="true"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSurname" ErrorMessage="Soyad  alanı zorunludur." Font-Bold="True"></asp:RequiredFieldValidator>
        <br />
        <asp:Label Text="Kullanıcı Adı" runat="server" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;"></asp:Label>
        <asp:TextBox ID="txtUsername" runat="server" Style="margin-top: 20px; margin-left: 41px;"></asp:TextBox>
        <asp:Label Text="*" runat="server" Font-Bold="true"></asp:Label>
        <asp:Label  ID="UnameLabel" runat="server" Font-Bold="true"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUsername" ErrorMessage="Kullanıcı adı  alanı zorunludur." Font-Bold="True"></asp:RequiredFieldValidator>
        <br />
        <asp:Label Text="Şifre" runat="server" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;"></asp:Label>
        <asp:TextBox ID="txtPass" TextMode="Password" runat="server" Style="margin-top: 20px; margin-left: 95px;"></asp:TextBox>
        <asp:Label Text="*" runat="server" Font-Bold="true"></asp:Label>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPass" ErrorMessage="Şifre  alanı zorunludur." Font-Bold="True"></asp:RequiredFieldValidator>
        <br />
        <asp:Label Text="Departman" runat="server" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;"></asp:Label>
        <asp:DropDownList ID="ddlstDep" runat="server" Style="margin-top: 20px; margin-left: 59px;"></asp:DropDownList>
        <br />
        <asp:Label Text="Email" runat="server" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" Style="margin-top: 20px; margin-left: 93px;"></asp:TextBox>
        <br />
        <asp:Label Text="Telefon Numarası" runat="server" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;"></asp:Label>
        <asp:TextBox ID="txtPhoneNum" runat="server" Style="margin-top: 20px; margin-left: 19px;"></asp:TextBox>
        <br />
        <asp:Label Text="Açıklama" runat="server" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;"></asp:Label>
        <asp:TextBox ID="txtComment" runat="server" Style="margin-top: 20px; margin-left: 71px;"></asp:TextBox>
        <br />
        <asp:Label Text="Yetki" runat="server" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left:20px; "></asp:Label>
        <asp:DropDownList ID="ddlstRole" runat="server" Style="margin-top: 20px; margin-left: 95px"></asp:DropDownList>
        <br />
        <asp:Button CssClass="button" ID="btnKaydet" runat="server" Text="Kaydet" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px; display: block;" OnClick="btnKaydet_Click" />
    </div>


</asp:Content>
