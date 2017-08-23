<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="listUsers.aspx.cs" Inherits="Example.listUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button CssClass="button" ID="btnListUsers" UseSubmitBehavior="false" Text="Kullanıcılar" runat="server" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;" />
    <asp:Button CssClass="button" ID="btnListProduct" UseSubmitBehavior="false" Text="Ürünler" runat="server" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;" OnClick="btnListProduct_Click" />
    <asp:Button CssClass="button" ID="btnListLocations" UseSubmitBehavior="false" Text="Lokasyonlar" runat="server" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;" OnClick="btnListLocations_Click" />
    <asp:Button CssClass="button" ID="btnListMovements" UseSubmitBehavior="false" Text="Operasyonlar" runat="server" Style="margin-top: 30px; margin-bottom: 20px; margin-left: 50px;" OnClick="btnListMovements_Click"/>
    <br />
    <br />
    <asp:TextBox ID="txtUserName" runat="server" Style="margin-top: 20px; margin-left: 6px;" Width="125px" OnTextChanged="txtUserName_TextChanged"></asp:TextBox>
    <asp:TextBox ID="txtName" runat="server" Style="margin-top: 20px; margin-left: 6px;" Width="87px" OnTextChanged="txtUserName_TextChanged"></asp:TextBox>
    <asp:TextBox ID="txtSurname" runat="server" Style="margin-top: 20px; margin-left: 2px;" Width="89px" OnTextChanged="txtUserName_TextChanged"></asp:TextBox>
    <asp:TextBox ID="txtDepartment" runat="server" Style="margin-top: 20px; margin-left: 6px;" Width="140px" OnTextChanged="txtUserName_TextChanged"></asp:TextBox>
    <asp:TextBox ID="txtEmail" runat="server" Style="margin-top: 20px; margin-left: 6px;" Width="214px" OnTextChanged="txtUserName_TextChanged"></asp:TextBox>
    <asp:TextBox ID="txtPhoneNum" runat="server" Style="margin-top: 20px; margin-left: 6px;" Width="87px" OnTextChanged="txtUserName_TextChanged"></asp:TextBox>
    <asp:TextBox ID="txtComment" runat="server" Style="margin-top: 20px; margin-left: 6px;" Width="103px" OnTextChanged="txtUserName_TextChanged"></asp:TextBox>
    <asp:Button ID="btnFilter" Text="Filtrele" runat="server" Style="margin-top: 8px; margin-bottom: 4px; margin-left: 29px; background-color: #555555; border: none; color: white;" Height="20px" Width="64px" OnClick="btnFilter_Click" />

    <asp:ListView ID="lstUsersView" runat="server">
        <ItemTemplate>
            <tr style="padding: 20px">
                <td style="padding: 20px; border-left: solid; border-collapse: collapse; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("Username").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("Name").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("Surname").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("Department").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("Email").ToString() %>
                </td>
                <td style="padding: 20px; border-left: solid; border-bottom: solid; border-top: solid; border-color: black">
                    <%# Eval("PhoneNumber").ToString() %>
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
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Kullanıcı Adı
                        </th>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Adı
                        </th>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Soyadı
                        </th>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Departman Adı
                        </th>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Email
                        </th>
                        <th style="padding: 20px; border-left: solid; border-right: solid; border-bottom: solid; border-top: solid; border-color: black">Telefon
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
