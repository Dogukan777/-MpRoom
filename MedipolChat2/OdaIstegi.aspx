<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OdaIstegi.aspx.cs" Inherits="MedipolChat2.OdaIstegi_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
  
   
  <link href="main.css" rel="stylesheet" />

   

</head>
<body >
    <form id="form2" method="get" runat="server">
        <div class="AnasayfaGenel">
            
            <div class="Sol">
            <div class="menu">
                <div class="logo"></div>
                <a href="Anasayfa.aspx" class="menuler">Anasayfa</a>
                <a href="#" class="menuler">Arkadaşlarım</a>
                <a href="#" class="menuler">Mesajlarım</a>
                <a href="#" class="menuler">Engellenen Kişiler</a>
                <a href="#" class="menuler">Misyonumuz</a>
              
            </div><br />  
             <div class="odalar">
                <div class="odaAdi"><span class="odaisim">Oda:Oda Açma İsteğinde Bulun</span></div>
                <hr class="cizgi"  style="margin-bottom:6%"/>
               
               <div style="float:left;width:75%;height:600px;">
                 <asp:Label ID="Label1" class="labels" runat="server" Text="Oda İsmi:"></asp:Label><br />
                 <asp:TextBox ID="txtOdaAdi" class="TextBoxs" runat="server"></asp:TextBox> <br />

                 <asp:Label ID="Label2" runat="server" class="labels" Text="Odanın Açma Sebebi:"></asp:Label><br />
                 <asp:TextBox ID="txtOdaAcmaSebebi" style="height:40px;"  class="TextBoxs" runat="server"></asp:TextBox><br />

                 <asp:Label ID="Label3" runat="server" class="labels" Text="Oda Şifresi:"></asp:Label><br />
               
                 <asp:TextBox ID="txtOdaSifresi" placeholder="Burayı Boş Geçebilirsiniz"  class="TextBoxs" runat="server"></asp:TextBox><br />

                 <asp:Label ID="Label4" runat="server" class="labels" Text="Mesajınız :"></asp:Label><br />
               <textarea id="txtOdaMesaji" cols="20" rows="2" style="height:160px;" class="TextBoxs" runat="server"></textarea>
                 
                   </div>
                <div style="float:left;width:20%;height:600px;">
                      <div style="margin-top:400px;float:left">
                <asp:Label ID="lblOdaUyari"  runat="server" Text=" "></asp:Label> <br />
                 <asp:Button ID="Button1" runat="server" class="btnistek" style="margin-top:30px" OnClick="IstekGonder_Click" Text="İsteği Gönder" />
</div>           </div>
                      

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
