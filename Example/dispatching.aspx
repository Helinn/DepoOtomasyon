<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="dispatching.aspx.cs" Inherits="Example.dispatching" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .HiddenText label {
            display: none;
        }
    </style>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:Label Text="Ürün Kodu" runat="server" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;"></asp:Label>
    <asp:DropDownList ID="ddlstPCode" runat="server" Style="margin-top: 20px; margin-left: 49px;" OnTextChanged="ddlstPCode_TextChanged" AutoPostBack="true"></asp:DropDownList>
    <br />
    <asp:Label Text="Miktar" runat="server" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;"></asp:Label>
    <asp:TextBox ID="txtAmount" runat="server" Style="margin-top: 20px; margin-left: 75px;"></asp:TextBox>
    <asp:Label ID="lblamount" Text="  " runat="server" CssClass="labelClass" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;"></asp:Label>
    <br />
    <asp:Button CssClass="button" ID="btnSearch" Text="Ara" runat="server" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;" OnClick="btnSearch_Click" />
    <br />
    <asp:Label ID="lblSevk" runat="server" Visible="false" Text="Seçili ürün miktarı" Style="margin-left: 10px"></asp:Label>
    <asp:TextBox ID="txtSevk" runat="server"  Visible="false" Style="margin-top: 20px; margin-left: 28px;" ReadOnly="true"></asp:TextBox>
    <asp:Button CssClass="button" ID="btnSevk"  Visible="false" Text="Sevk Et" runat="server" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;" OnClick="btnSevk_Click" />
    <br />

   
    <asp:ListView runat="server" ID="lstDispatchsView">
        <EmptyDataTemplate>
            Stockta bu ürün koduna ait kayıt bulunmamaktadır.
        </EmptyDataTemplate>
        <ItemTemplate>
            <tr style="padding: 20px" class='<%# getColor(Convert.ToInt32(Eval("Amount"))) %>'>
                <td style="padding: 20px">
                    <asp:CheckBox ID="chckAmount" runat="server" AutoPostBack="True" Text='<%# Eval("Amount") %>' Checked="false" CssClass="HiddenText" OnCheckedChanged="chckAmount_CheckedChanged" />
                </td>
                <td style="padding: 20px">
                    <asp:Label ID="lblProductCode" runat="server" Text=' <%# Eval("ProductCode") %>'></asp:Label>
                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("Id") %>' Visible="false"></asp:Label>
                </td>
                <td style="padding: 20px">
                    <%# Eval("ProductName")  %>
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
                        <th style="padding: 20px">Lokasyon(depo-koridor-kolon-kat)
                        </th>
                    </tr>
                </thead>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </table>
        </LayoutTemplate>
    </asp:ListView>
</asp:Content>
