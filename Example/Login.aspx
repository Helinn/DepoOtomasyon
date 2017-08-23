<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Example.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Css\Site.css" rel="stylesheet" />
    <title></title>
</head>
<body>

    <div class="container">
        <img src="img/loginImage.jpg" />
        <form id="form1" runat="server">
            <div>
                <input id="txtUserName" runat="server" name ="username" placeholder="Kullanıcı Adı" type="text" style="background-image: url('img/user.png'); background-repeat: no-repeat; background-attachment: scroll;background-position: 1px 1px; font-size: 18px; padding-left: 40px; margin-bottom: 20px; width: 300px; height: 45px; "/>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName" ErrorMessage="*" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
            </div>
            <div>
                <input id="txtPassword" runat="server" name ="password" type="password" placeholder="Şifre" style="background-image: url('img/lock.png'); background-repeat: no-repeat; background-attachment: scroll; background-position: 1px 1px; font-size: 18px; padding-left: 40px; margin-bottom: 20px; height: 45px; width: 300px; " />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ForeColor="Red" Font-Bold="true"></asp:RequiredFieldValidator>
                <br />
            </div>
            <asp:Button ID="LoginButton" runat="server" OnClick="LoginButton_Click" Style="margin-left:10px; border-style: none; border-color: inherit; border-width: medium; background-color:rgb(123, 170, 72);
                         color: black; border-radius: 4px;  margin-left: 0px; margin-top: 21px;" Text="GİRİŞ" Height="37px" Width="136px"/>
         
        </form>
    </div>

</body>
</html>
