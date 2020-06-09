<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SifremiUnuttum.aspx.cs" Inherits="MedipolChat2.SifremiUnuttum" %>

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
            <asp:Label class="LoginLabel" runat="server" Text="E-Posta:"></asp:Label>
            <br />
            <asp:TextBox    class="LoginTextBox"  ID="txtEPosta" runat="server" >
            </asp:TextBox>
            <asp:RequiredFieldValidator CssClass="LoginUyariMesaj" ID="Validator4" ControlToValidate="txtEPosta" runat="server" ErrorMessage="Bu alan boş geçilemez!"></asp:RequiredFieldValidator>

            <br />
           
             <asp:Label Style="color:green;font-weight:bolder;" class="LoginLabel" runat="server" ID="lbl_Uyari" Text=""></asp:Label>
           
          
            <div class="KayıtOlButtonDiv">
              <a href="Login.aspx" class="SignUpHref"><span class="GirisEkraniLabel"> Giriş Ekranı</span> </a>
                <asp:Button ID="Btn_Mail" class="SignUpButton" OnClick="AktivasyonGonder_Click" runat="server" Text="GÖNDER" />
                </div>

        </form>
    </div>

</body>
</html>
