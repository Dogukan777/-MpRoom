<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MedipolChat2.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
  
   
  <link href="main.css" rel="stylesheet" />
</head>
<body id="LoginGenel" >

    <div class="LoginCerceve">
        <div class="Logo">
            <img src="images/MedipolLogo.png" style="width: 160px; height: 160px" />
        </div>
        <div class="LoginBaslik">
            <h2>MEDİPOL ÜNİVERSİTESİ SOHBET ODALARI</h2>
        </div>
        <form runat="server">
            <asp:Label class="LoginLabel" runat="server" Text="Ad"></asp:Label>
            <br />
            <asp:TextBox    class="LoginTextBox"  ID="txtAd" runat="server" Text="">
            </asp:TextBox>
            <asp:RequiredFieldValidator CssClass="LoginUyariMesaj" ID="Validator4" ControlToValidate="txtAd" runat="server" ErrorMessage="Bu alan boş geçilemez!"></asp:RequiredFieldValidator>

            <br />
            
            <asp:Label class="LoginLabel" runat="server" Text="Soyad"></asp:Label>
            <br />
            <asp:TextBox    class="LoginTextBox"  ID="txtSoyad" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator CssClass="LoginUyariMesaj" ID="RequiredFieldValidator1" ControlToValidate="txtSoyad" runat="server" ErrorMessage="Bu alan boş geçilemez!"></asp:RequiredFieldValidator>
            <br />
            <asp:Label class="LoginLabel" runat="server" Text="Kullanıcı Adı:"></asp:Label>
            <br />
            <asp:TextBox class="LoginTextBox"  ID="txt_KAdi" runat="server" Text=""></asp:TextBox>
              <asp:RequiredFieldValidator CssClass="LoginUyariMesaj" ID="RequiredFieldValidator2" ControlToValidate="txt_KAdi" runat="server" ErrorMessage="Bu alan boş geçilemez!"></asp:RequiredFieldValidator>
            <br />

              <asp:Label class="LoginLabel" runat="server" Text="Şifre"></asp:Label>
            <br />
            <asp:TextBox class="LoginTextBox"  type="password" ID="txt_Sifre" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator CssClass="LoginUyariMesaj" ID="RequiredFieldValidator3" ControlToValidate="txt_Sifre" runat="server" ErrorMessage="Bu alan boş geçilemez!"></asp:RequiredFieldValidator>
            <br />
              <asp:Label class="LoginLabel" runat="server" Text="E-Posta"></asp:Label>
            <br />

            <asp:TextBox class="LoginTextBox"   ID="txtEposta" runat="server"></asp:TextBox>
              <asp:RequiredFieldValidator CssClass="LoginUyariMesaj" ID="RequiredFieldValidator4" ControlToValidate="txtEposta" runat="server" ErrorMessage="Bu alan boş geçilemez!"></asp:RequiredFieldValidator>
            <br />
             <asp:Label Style="color:green;font-weight:bolder;" class="LoginLabel" runat="server" ID="lbl_Uyari" Text="Uyari"></asp:Label>
           
          
            <div class="KayıtOlButtonDiv">
              <a href="Login.aspx" class="SignUpHref"><span class="GirisEkraniLabel"> Giriş Ekranı</span> </a>
            <asp:Button class="SignUpButton" OnClick="Kaydol_Click" ID="Button2" runat="server" Text="Kayıt Ol" />
                </div>

        </form>
    </div>

</body>
</html>
