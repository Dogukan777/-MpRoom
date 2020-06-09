<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EngellenenlerListesi.aspx.cs" Inherits="MedipolChat2.EngellenenlerListesi" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

  
   
  <link href="main.css" rel="stylesheet" />
</head>
<body >
    <form id="form1" runat="server" >
        <div class="AnasayfaGenel" id="HesapSayfasi" runat="server">
            <div class="Sol">
            <div class="menu">
                <div class="logo"></div>
                  <a href="Anasayfa.aspx" class="menuler">Anasayfa</a>
                <a href="Arkadaslar.aspx" class="menuler">Arkadaşlarım</a>
                <a href="#" class="menuler">Mesajlarım</a>
                <a href="EngellenenlerListesi.aspx" class="menuler">Engellenen Kişiler</a>
                <a href="#" class="menuler">Misyonumuz</a>
              
            </div>
              
            <div class="odalar">
                <div class="odaAdi"><span class="odaisim">Engellenen Kişiler</span></div>
                <hr class="cizgi" />
              <div id="divEngellenenler" class="Engellenenler" runat="server">


              </div>
            </div>
            

            </div>
            
             <div class="onlineKullanicilarKutu">
              <div class="hesap">
                  <div>
                     <h3>Hoşgeldiniz :<asp:Label ID="LabelAdSoyad" runat="server" Text="Label"></asp:Label></h3>
                  </div>
                 <div>
                   <a href="HesapBilgileri.aspx" class="BilgilerimBtn"><span class="BilgilerimLabel"> Bilgilerim </span></a>
 
                     <a href="Login.aspx" id="btnCikis" class="CikisBtn" >Çıkış Yap</a>
                     
                 </div>
                 

              </div>


          
            <div class="onlineKullanicilar">
                <div><p class="baslikOrtalama">Çevrimiçi Kullanıcılar</p></div>
                <div><p>Çevrimiçi Arkadaşlarım</p></div>
                <div><p>Gelen Mesajlar</p></div>
                </div>
                </div>


              </div>
     
       
    </form>
</body>
</html>
