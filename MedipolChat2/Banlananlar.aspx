 <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Banlananlar.aspx.cs" Inherits="MedipolChat2.Banlananlar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
  
  <link href="genel.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" method="get" runat="server">
        <div class="AnasayfaGenel">
                  <div class="Sol">

            <div class="menu">
                <div class="logo"></div>
                <a href="AdminPanel.aspx" class="menuler">Anasayfa</a>
                <a href="OdalarinListesi.aspx" class="menuler">Odaların Listesi</a>
                <a href="Uyeler.aspx" class="menuler">Üyeler</a>
                <a href="Banlananlar.aspx" class="menuler">Banlanan Kullanıcılar</a>
             
              
            </div>
            
            <div class="odalar">
                <div class="odaAdi"><span class="odaisim">Banlanan Kullanıcılar(<asp:Label ID="Label2" runat="server" Text="?"></asp:Label>)</span></div>
                <hr class="cizgi" />
                  <asp:Label ID="Label1" runat="server" Text="Label">TuncayTanin</asp:Label> <asp:Button ID="Button1" runat="server" Text="Banı Kaldır" /> <br /> 
        
                 
            </div>
            <div class="onlineKullanicilar">
                <div><p class="baslikOrtalama">Çevrimiçi Kullanıcılar</p></div>
                </div>
                      </div>
             <div class="onlineKullanicilarKutu">
              <div class="hesap">
                  <div>
                     <h3>Hoşgeldiniz :<asp:Label ID="LabelAdSoyad" runat="server" Text="Label"></asp:Label></h3>
                  </div>
                 <div>
                   <a href="HesapBilgileri.aspx" class="BilgilerimBtn"><span class="BilgilerimLabel"> Bilgilerim </span></a>
              <a href="Login.aspx" class="CikisBtn"><span class="CikisLabel"> Çıkış Yap </span></a>
                 </div>
                 

              </div>
                 </div>
        </div>
       
    </form>
</body>
</html>