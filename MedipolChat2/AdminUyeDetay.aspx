<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminUyeDetay.aspx.cs" Inherits="MedipolChat2.AdminUyeDetay" %>

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
                <a href="Banlananlar.aspx" class="menuler">Banlanan Kullanıcılar</a>
             
              
            </div>
           
            <div class="odalar">
                
             <div class="uyeListesi">
                <div class="detayUye">
                 <asp:Label  runat="server" Text="Adı:"></asp:Label><br />
                 <asp:TextBox ID="txtAdi" runat="server"></asp:TextBox><br />
                       <asp:Label ID="Label2" runat="server" Text="Soyadı"></asp:Label><br />
                   <asp:TextBox ID="txtSoyadi" runat="server"></asp:TextBox><br />
                       <asp:Label ID="Label3" runat="server" Text="Kullanıcı Adı:"></asp:Label><br />
                   <asp:TextBox ID="txtKAdi" runat="server"></asp:TextBox><br />
                       <asp:Label ID="Label4" runat="server" Text="Şifre:"></asp:Label><br />
                   <asp:TextBox ID="txtSifre" runat="server"></asp:TextBox><br />
                       <asp:Label ID="Label5" runat="server" Text="E-Posta:"></asp:Label><br />
                   <asp:TextBox ID="txtEposta" runat="server"></asp:TextBox><br />
                    <asp:Button ID="Button1" OnClick="detayGeriDon_Click" class="detayButton" style="width:25%;height:6%;color:white;font-size:20px;margin-top:4%;" runat="server"  Text="Geri Dön" />
                    <asp:Button ID="Button3" OnClick="KullaniciBanla_Click" class="detayButton" style="width:25%;height:6%;color:white;font-size:20px;margin-top:4%;background-color:	#C62828;margin-left:20%" runat="server" Text="Kullanıcıyı Banla" />
                  </div>
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
                </div>
        </div>
       
    </form>
</body>
</html>