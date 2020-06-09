<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHesapBilgileri.aspx.cs" Inherits="MedipolChat2.AdminHesapBilgileri" %>



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
                <a href="AdminPanel.aspx" class="menuler">Anasayfa</a>
                <a href="AdminOdalarinListesi.aspx" class="menuler">Odaların Listesi</a>
                <a href="AdminUyeler.aspx" class="menuler">Üyeler</a>
                <a href="AdminBanlananlar.aspx" class="menuler">Banlanan Kullanıcılar</a>
             
              
            </div>
              
            <div class="odalar">
                <div class="odaAdi"><span class="odaisim">Hesap Bilgilerim</span></div>
                <hr class="cizgi" />
                <br />
                <br />
                <br />
                <asp:Label ID="Label1" class="HesapBilgilerimLabel" runat="server" Text="Ad Ve Soyad:"></asp:Label><br />
                <asp:TextBox ID="txtAdSoyad" class="HesapBilgilerimTxtBox" Text="" runat="server"></asp:TextBox><br />
                <asp:Label ID="Label2"  class="HesapBilgilerimLabel" runat="server" Text="Kullanıcı Adı:"></asp:Label><br />
                <asp:TextBox ID="txtKAd" class="HesapBilgilerimTxtBox" Text="" name="txtKAdi" runat="server"></asp:TextBox><br />
                <asp:Label ID="Label3"  class="HesapBilgilerimLabel" runat="server" Text="Şifre:"></asp:Label><br />
                <asp:TextBox ID="txtSifre" class="HesapBilgilerimTxtBox" name="Sifre" runat="server"></asp:TextBox> <br />
                <asp:Label ID="Label4"  class="HesapBilgilerimLabel" runat="server" Text="E-Posta:"></asp:Label><br />
                <asp:TextBox ID="txtEPosta" class="HesapBilgilerimTxtBox" runat="server"></asp:TextBox> <br /><br />

                <asp:Label ID="lblHesapGuncelleUyari" runat="server" Text="" style="color:green;font-weight:bold;font-size:20px;margin-left:5%" class="lblHesapGuncelleUyari"></asp:Label><br />
            
                <asp:Button ID="btn_hesapguncelle" OnClick="btn_hesapguncelle_Click" class="HesapBtn" runat="server" Text="HESABIMI GÜNCELLE" />
              
                <asp:Button ID="Button2" class="HesapBtn" OnClick="btn_HesapSilKutucuk_Click" style="background-color:red" runat="server" Text="HESABIMI SİL" />
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
                </div>


              </div>
     
         <div class="Sil-Kutucuk" id="SilKutucuk" runat="server">
                   <asp:Label ID="Label5" Class="lbl-sil" runat="server" Text="Hesabınızı Silmek İstediğinize Emin Misiniz?"></asp:Label><br />
                   <asp:Button ID="Button1" Class="btn-sil" runat="server"  OnClick="btn_HesapSilOnayla_Click" Text="ONAYLA" />
                   <asp:Button ID="Button3" Class="btn-sil" runat="server" OnClick="btn_HesapSilVazgec_Click" Text="VAZGEÇ" />
               </div>
    </form>
</body>
</html>
