<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MedipolChat2.Scripts.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
   
  <link href="main.css" rel="stylesheet" />

</head>
<body id="LoginGenel">
  

    <div class="LoginCerceve">
        <div class="Logo">
            <img src="images/MedipolLogo.png" style="width: 160px; height: 160px" />
        </div>
        <div class="LoginBaslik">
            <h2>MEDİPOL ÜNİVERSİTESİ SOHBET ODALARI</h2>
        </div>
        <form runat="server">
            <asp:Label class="LoginLabel" runat="server" Text="Kullanıcı Adı"></asp:Label>
            <br />
            <asp:TextBox    class="LoginTextBox"  ID="txtKAdi" runat="server"></asp:TextBox><asp:Label ID="lbl_uyariKAdi" CssClass="LoginUyariMesaj"  runat="server" ></asp:Label>
            <br />

            <asp:Label class="LoginLabel" runat="server" Text="Şifre"></asp:Label>
            <br />
            <asp:TextBox class="LoginTextBox" type="password" ID="txtSifre" runat="server"></asp:TextBox><asp:Label ID="lbl_uyariSifre" CssClass="LoginUyariMesaj"  runat="server" ></asp:Label>
            <br />
             <asp:Label ID="uyariGiris" runat="server" Text=""></asp:Label>
            <br />
           <a href="#" class="BeniHatirla">Beni Hatırla</a>
             <a href="SifremiUnuttum.aspx" class="SifremiUnuttum">Şifremi Unuttum</a>
           
            <div class="ButtonDiv">
               
            <asp:Button class="LoginButton" ID="Button1" onClick="girisYap_Button" runat="server" Text="Giriş Yap" />
           <a href="Register.aspx" class="SignUpHref"><span class="KayıtOlLabel"> Kayıt Ol </span></a>
                </div>

        </form>
    </div>

</body>
</html>
