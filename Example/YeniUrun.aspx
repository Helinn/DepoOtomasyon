<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="YeniUrun.aspx.cs" Inherits="Example.YeniUrun" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <br />
        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" >
            <asp:Label Text="Ürün Kodu" runat="server" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;"></asp:Label>
            <asp:TextBox ID="txtPcode" runat="server" Style="margin-top: 20px; margin-left: 51px;"></asp:TextBox>
            <asp:Label Text="*" runat="server" Font-Bold="true"></asp:Label>
            <asp:Label  ID="PcodeLabel" runat="server" Font-Bold="true"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPcode" ErrorMessage="Ürün Kodu alanı zorunludur." Font-Bold="True"></asp:RequiredFieldValidator>
            <br />
            <asp:Label Text="Ürün Adı" runat="server" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;"></asp:Label>
            <asp:TextBox ID="txtPName" runat="server" Style="margin-top: 20px; margin-left: 63px;"></asp:TextBox>
            <asp:Label Text="*" runat="server" Font-Bold="true"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPName" ErrorMessage="Ürün adı alanı zorunludur." Font-Bold="True"></asp:RequiredFieldValidator>
            <br />
            <asp:Label Text="Ürün Kategorisi" runat="server" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;"></asp:Label>
            <asp:DropDownList ID="ddlstCategory" runat="server" Style="margin-top: 20px; margin-left: 26px;"></asp:DropDownList>
            <br />
            <asp:Label Text="Açıklama" runat="server" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;"></asp:Label>
            <asp:TextBox ID="txtComm" runat="server" Style="margin-top: 20px; margin-left: 68px;"></asp:TextBox>
            <br />
            <br />
        </asp:Panel>
        <br />
        <asp:Panel  ID="Panel2" runat="server" BorderStyle="Solid" >
            <asp:Label Text="Birim" runat="server" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;"></asp:Label>
            <asp:DropDownList ID="ddlstUnit" runat="server" Style="margin-top: 20px; margin-left: 95px;"></asp:DropDownList>
            <br />
            <asp:Label Text="Marka" runat="server" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;"></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server"  Style="margin-top: 20px; margin-left: 89px;"></asp:TextBox>
            <br />
            <asp:Label Text="Seri Numarası" runat="server" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;"></asp:Label>
            <asp:TextBox ID="txtSerialNo" runat="server" Style="margin-top: 20px; margin-left: 39px;"></asp:TextBox>
            <asp:Label Text="*" runat="server" Font-Bold="true"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSerialNo" ErrorMessage="Seri numaras alanı zorunludur." Font-Bold="True"></asp:RequiredFieldValidator>
            <br />
            <asp:Label Text="Statü" runat="server" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;"></asp:Label>
            <asp:DropDownList ID="ddlstStatus" runat="server"  Style="margin-top: 20px; margin-left: 97px;"></asp:DropDownList>
            
            <br/>
            <br/>
        </asp:Panel>
        <asp:Button CssClass="button" ID="btnKaydet" runat="server" Text="Kaydet" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px; display: block;" OnClick="btnKaydet_Click" />
    </div>
</asp:Content>
