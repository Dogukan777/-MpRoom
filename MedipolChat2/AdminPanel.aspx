<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="MedipolChat2.AdminPanel" %>



<%@ Import Namespace="System.Data" %>


<%@ Import Namespace="MedipolChat2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
   
  <link href="main.css" rel="stylesheet" />

</head>
<body>
    <form id="form2" method="get" runat="server">
        <div class="AnasayfaGenel">

            <div class="Sol">
                <div class="menu">
                    <div class="logo"></div>
                    <a href="AdminPanel.aspx" class="menuler">Anasayfa</a>
                    <a href="AdminOdalarinListesi.aspx" class="menuler">Odaların Listesi</a>
                    <a href="AdminUyeler.aspx" class="menuler">Üyeler</a>
                    <a href="AdminBanlananlar.aspx" class="menuler">Banlanan Kullanıcılar</a>


                </div>
                <br />
                <div class="odalar">
                    <div class="odaAdi"><span class="odaisim">GELEN ODA ISTEKLERI</span></div>
                    <hr class="cizgi" />
                    <div id="OdaIstekleri" runat="server">
                     
                        <% 
                            DbOperation db = new DbOperation();
                            DataTable OdaIstekGetirSonuc = db.OdaIstekGetir("select * from tbl_odalar where OdaDurumu='P' ");
                            for (int i = 0; i < OdaIstekGetirSonuc.Rows.Count; i++)
                            {
                                string OdaAdi= OdaIstekGetirSonuc.Rows[i]["OdaAdi"].ToString();
                                string OdaId = OdaIstekGetirSonuc.Rows[i]["OdaId"].ToString();

                        %>
                        <%=OdaAdi %> <a style="margin-left:10px" href="AdminOdaIstegi.aspx?OdaId= <%=OdaId %>">İsteği göster</a><br /><br />
                       

                        <% }%>
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
