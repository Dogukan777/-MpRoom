 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminBanlananlar.aspx.cs" Inherits="MedipolChat2.Banlananlar" %>

<%@ Import Namespace="System.Data" %>


<%@ Import Namespace="MedipolChat2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
   
  <link href="main.css" rel="stylesheet" />
</head>
<body >
    <form id="form1" method="get" runat="server">
        <div class="AnasayfaGenel">
              <div class="Sol">

            <div class="menu">
                <div class="logo"></div>
                <a href="AdminPanel.aspx" class="menuler">Anasayfa</a>
                <a href="AdminOdalarinListesi.aspx" class="menuler">Odaların Listesi</a>
                <a href="AdminUyeler.aspx" class="menuler">Üyeler</a>
                <a href="AdminBanlananlar.aspx" class="menuler">Banlanan Kullanıcılar</a>
             
              
            </div>
           
            <div class="odalar">
                <div class="odaAdi"><span class="odaisim">Banlananlar(<asp:Label ID="lblBanSayisi" runat="server" Text="Label"></asp:Label>)</span></div>
                <hr class="cizgi" />
                 
             <div class="uyeListesi" id="btndetaydiv" runat="server">
             <asp:Label ID="lblBanMesaj" class="lblBanMesaj" runat="server" ></asp:Label>
                         

                      
                  </div>
                 
            </div>
            
            </div>
              <div class="onlineKullanicilarKutu">
              <div class="hesap">
                  <div>
                     <h3>Hoşgeldiniz :<asp:Label ID="LabelAdSoyad" runat="server" Text="Label"></asp:Label></h3>
                  </div>
                 <div>
                   <a href="AdminHesapBilgileri.aspx" class="BilgilerimBtn"><span class="BilgilerimLabel"> Bilgilerim </span></a>
 
                     <a href="Login.aspx" id="btnCikis" class="CikisBtn" >Çıkış Yap</a>
                     
                 </div>
                 

              </div>


          
            <div class="onlineKullanicilar">
                <div><p class="baslikOrtalama">Çevrimiçi Kullanıcılar</p></div>
                <div><p>Çevrimiçi Arkadaşlarım</p></div>
                <div><p>Gelen Mesajlar</p></div>
                </div>
                </div>   </div>
             
    </form>
</body>
</html>