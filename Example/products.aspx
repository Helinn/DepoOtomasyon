<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="Example.products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button CssClass="button" ID="UrunEkle" runat="server" Text="Ürün Ekle" OnClick="UrunEkle_Click" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;" />
    <br />
    <asp:ListView runat="server" ID="lstProductsView" OnItemCommand="lstProducts_ItemCommand" OnItemEditing="lstProductsView_ItemEditing" OnItemUpdating="lstProductsView_ItemUpdating" OnItemCanceling="lstProductsView_ItemCanceling">
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
                <td style="padding: 20px">
                    <asp:Button ID="btnSil" Text="Sil" CssClass="button" runat="server" CommandName="cmdSil" CommandArgument='<%# Eval("Id") %>' />
                    <asp:Button ID="EditButton" CssClass="button" runat="Server" Text="Düzenle" CommandName="Edit" />
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
                <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
            </table>
        </LayoutTemplate>
        <EditItemTemplate>
            <tr>
                <td style="padding: 20px; border-left: solid; border-collapse: collapse; border-bottom: solid; border-top: solid; border-color: black">
                   <asp:Label ID="lblpcode" runat="server" Text='<%# Eval("ProductCode") %>'></asp:Label>
                </td>
                <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <asp:TextBox ID="txtPname" runat="server" Text='<%#Bind("ProductName") %>'></asp:TextBox>
                </td>
                <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <asp:Label ID="lblUnitType" runat="server" Text='<%# Eval("UnitType").ToString() %>'></asp:Label>
                </td>
                <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <asp:Label runat="server" ID="lblTitle" Text='<%# Eval("Title").ToString() %>'></asp:Label>
                </td>
                <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <asp:Label runat="server" ID="lblSerialNum" Text='<%# Eval("SerialNum").ToString() %>'></asp:Label>
                </td>
                <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <asp:Label runat="server" ID="lblStatus" Text='<%# Eval("StatusType").ToString() %>'></asp:Label>
                </td>
                <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <asp:Label runat="server" ID="lblCategory" Text='<%# Eval("CategoryType").ToString() %>'></asp:Label>
                </td>
                <td style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <asp:TextBox ID="txtComment" runat="server" Text='<%#Bind("Comment") %>'></asp:TextBox>
                </td>
                <td style="padding: 20px;">
                    <asp:Button ID="UpdateButton" runat="server"   CommandName="Update" Text="Güncelle"  CommandArgument='<%# Eval("Id") %>' style="background-color:#555555; color:white; padding: 12px 20px; border:none; text-align: center;text-decoration: none;font-size: 12px;" />
                    <asp:Button ID="CancelButton" runat="server"   CommandName="Cancel" Text="İptal" CommandArgument='<%# Eval("Id") %>' style="background-color:#555555; color:white; padding: 12px 15px; border:none; text-align: center;text-decoration: none;font-size: 12px;" />
                    </td>
            </tr>
        </EditItemTemplate>
    </asp:ListView>
</asp:Content>
