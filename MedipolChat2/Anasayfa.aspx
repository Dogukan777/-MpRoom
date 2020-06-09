<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Anasayfa.aspx.cs" Inherits="MedipolChat2.Anasayfa" %>

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
    <form id="form2" method="get" runat="server">
        <div class="AnasayfaGenel">
            
            <div class="Sol">
            <div class="menu">
                <div class="logo"></div>
                  <a href="Anasayfa.aspx" class="menuler">Anasayfa</a>
                <a href="Arkadaslar.aspx" class="menuler">Arkadaşlarım</a>
                 <a href="Mesajlarim.aspx" class="menuler">Mesajlarım</a>
                <a href="EngellenenlerListesi.aspx" class="menuler">Engellenen Kişiler</a>
                <a href="#" class="menuler">Misyonumuz</a>
              
            </div><br />  
             <div class="odalar">
                <div class="odaAdi"><span class="odaisim">ODALAR</span></div>
                <hr class="cizgi" />
                  <a href="OdaIstegi.aspx" class="odaIstekHref"><span class="odaIstekLabel">Oda Açma İsteğinde Bulun </span></a><br /><br />
                 <div style="width:103%;height:100%;" id ="OdaListesi">
                      <asp:Button ID="btnGenel" runat="server" OnClick="btnOdaGenel_Click" Text="Genel"  class="btnOdalar"/>
                      <% 
                          DbOperation db = new DbOperation();
                          DataTable OdalarListesiSonuc = db.OdaIstekGetir("select * from tbl_odalar where OdaDurumu='A' ");
                          for (int i = 0; i < OdalarListesiSonuc.Rows.Count; i++)
                          {
                              string OdaAdi= OdalarListesiSonuc.Rows[i]["OdaAdi"].ToString();
                              string OdaId = OdalarListesiSonuc.Rows[i]["OdaId"].ToString();
                              string OdaSifresi = OdalarListesiSonuc.Rows[i]["OdaSifresi"].ToString();
                            


                        %>
                           <a href="Anasayfa.aspx?OdaId=<%=OdaId %>" class="btnOdaHref"><%=OdaAdi %> </a>
                        
                        <% }%>
                        
                     <div class="OdaSifre" id="OdaSifre" runat="server">
                         <label style="color:white;font-size:25px">Odanın Şifresi:</label><br />
                         <asp:TextBox ID="txtOdaSifre" type="password" style="width:50%;height:10%;border-radius:5px;margin-bottom:25px;padding-left:1%" runat="server"></asp:TextBox><br />
                          <asp:Label ID="lblSifreUyari" style="color:black;font-weight:bold;font-size:22px" runat="server" Text=""></asp:Label>
                        <div style="width:100%;height:60px;margin-top:110px">
                           
                         <asp:Button ID="Button1" style="width:300px;height:60px;background-color:brown;font-size:22px;color:white;border:1px solid #00a0ce;border-radius:10px" OnClick="btnOdaSifreOnayla_Click" runat="server" Text="Odaya Gir" />
                         <asp:Button ID="Button3" style="width:300px;height:60px;margin-left:50px;background-color:burlywood;font-size:22px;color:white;border:1px solid #00a0ce;border-radius:10px" OnClick="btnOdaSifreVazgec_Click" runat="server" Text="Vazgeç" />
                         </div>
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
