<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="Example.users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Button CssClass="button" ID="YeniKayit" runat="server" Text="Yeni Kayıt" OnClick="YeniKayıtClick" Style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px;" />
    <br />
    <asp:ListView runat="server" ID="lstUsers" OnItemCommand="lstUsers_ItemCommand" OnItemEditing="lstUsers_ItemEditing" OnItemUpdating="lstUsers_ItemUpdating" OnItemCanceling="lstUsers_ItemCanceling">
        <ItemTemplate>
            <tr style="padding: 20px">
                <td style="padding: 20px; border-left: solid; border-collapse: collapse; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("Role").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-collapse: collapse; border-bottom: solid; border-top: solid; border-color: black">
                     <%# Eval("Username").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-collapse: collapse; border-bottom: solid; border-top: solid; border-color: black">
                     <%# Eval("Name").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-collapse: collapse; border-bottom: solid; border-top: solid; border-color: black">
                     <%# Eval("Surname").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-collapse: collapse; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("Department").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-collapse: collapse; border-bottom: solid; border-top: solid; border-color: black">
                     <%# Eval("Email").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-collapse: collapse; border-bottom: solid; border-top: solid; border-color: black">
                     <%# Eval("PhoneNumber").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-collapse: collapse; border-bottom: solid; border-top: solid; border-right:solid; border-color: black">
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
                        <th>Kullanıcı Rolü
                        </th>
                        <th>Kullanıcı Adı
                        </th>
                        <th>Adı
                        </th>
                        <th>Soyadı
                        </th>
                        <th>Departman Adı
                        </th>
                        <th>Email
                        </th>
                        <th>Telefon
                        </th>
                        <th>Açıklama
                        </th>
                    </tr>
                </thead>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
            </table>
        </LayoutTemplate>
        <EditItemTemplate>
            <tr style="padding: 20px">
                <td style="padding: 20px; border-left: solid; border-collapse: collapse; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("Role").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-collapse: collapse; border-bottom: solid; border-top: solid; border-color: black">
                    <asp:TextBox runat="server" ID="txtuname" Text='<%#Bind("Username") %>' style="width:50px;height:20px"></asp:TextBox>
                </td>
                <td style="padding: 20px; border-left: solid; border-collapse: collapse; border-bottom: solid; border-top: solid; border-color: black">
                    <asp:TextBox runat="server" ID="txtname" Text='<%#Bind("Name") %>' style="width:50px;height:20px"></asp:TextBox>
                </td>
                <td style="padding: 20px; border-left: solid; border-collapse: collapse; border-bottom: solid; border-top: solid; border-color: black">
                    <asp:TextBox runat="server" ID="txtsurname" Text='<%#Bind("Surname")%>' style="width:50px;height:20px"></asp:TextBox>
                </td>
                <td style="padding: 20px; border-left: solid; border-collapse: collapse; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("Department").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-collapse: collapse; border-bottom: solid; border-top: solid; border-color: black">
                    <asp:TextBox runat="server" ID="txtEmail" Text='<%#Bind("Email") %>' style="width:50px;height:20px"></asp:TextBox>
                </td>
                <td style="padding: 20px; border-left: solid; border-collapse: collapse; border-bottom: solid; border-top: solid; border-color: black">
                    <asp:TextBox runat="server" ID="txtPhone" Text='<%#Bind("PhoneNumber") %>' style="width:50px;height:20px"></asp:TextBox>
                </td>
                <td style="padding: 20px; border-left: solid; border-collapse: collapse; border-bottom: solid; border-top: solid; border-right:solid; border-color: black">
                    <asp:TextBox runat="server" ID="txtComment" Text='<%#Bind("Comment") %>' style="width:50px;height:20px"></asp:TextBox>
                </td>
                <td style="padding: 20px;">
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Güncelle" CommandArgument='<%# Eval("Id") %>' Style="background-color: #555555; color: white; padding: 12px 20px; border: none; text-align: center; text-decoration: none; font-size: 12px;" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="İptal" CommandArgument='<%# Eval("Id") %>' Style="background-color: #555555; color: white; padding: 12px 15px; border: none; text-align: center; text-decoration: none; font-size: 12px;" />
                </td>
            </tr>
        </EditItemTemplate>
    </asp:ListView>

</asp:Content>
