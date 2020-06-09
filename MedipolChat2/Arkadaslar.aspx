<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Arkadaslar.aspx.cs" Inherits="MedipolChat2.Arkadaslar" %>


<%@ Import Namespace="MedipolChat2" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link href="https://fonts.googleapis.com/css2?family=Playfair+Display:wght@600&display=swap" rel="stylesheet"/>
    
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
                <a href="EngellenenlerListesi.aspx#" class="menuler">Engellenen Kişiler</a>
                <a href="#" class="menuler">Misyonumuz</a>
              
            </div><br />  
             <div class="odalar">
              <div class="Arkadaslarim">
                  <span style="color:red;margin-left:35%">ARKADAŞLARIM</span>
                   <hr class="cizgi" />
                  <asp:Label ID="lblArkadasUyari" runat="server" style="color:green"></asp:Label>
                <div id="Arkadaslarim" runat="server">




                </div>




                  
              </div>
                 <div class="ArkadasIsteklerim">

                       <span style="color:red;margin-left:35%">ARKADAŞ İSTEKLERİM</span>
                   <hr class="cizgi" />


                  <asp:TextBox ID="txtArkadasName" class="arkadasTextBox" placeholder="Arkadaşınızın Kullanıcı Adını Giriniz" runat="server"></asp:TextBox>
                  <asp:Button ID="Button1" class="arkadasEkleBtn" OnClick="ArkadasIstegi_Click" runat="server" Text="Arkadaş İsteği Gönder" /><br /><br />
                <asp:Label ID="lblUyari" style="float:left;width:100%;height:35px;font-size:18px;color:green;font-weight:bolder" runat="server" ></asp:Label>
                      
                     <% 
                          DbOperation db = new DbOperation();

                          DataTable ArkadasIstekListesi= db.ArkadasIstekListesi("select * from tbl_Arkadaslar where FriendName='"+Session["KAd"].ToString()+"' and Durum='P' ");
                          for (int i = 0; i < ArkadasIstekListesi.Rows.Count; i++)
                          {
                              string ArkadasKAdi= ArkadasIstekListesi.Rows[i]["MyName"].ToString();
                              string ArkadasId = ArkadasIstekListesi.Rows[i]["Id"].ToString();
                             // txtArkadasId.Text = ArkadasId;
                              lblArkadasKAdi.Text = ArkadasKAdi;
                             
                              

                        %>
                        <div style="width:100%;height:30px;float:left;margin-top:10px">
                      <asp:Label ID="lblArkadasKAdi" style="float:left" runat="server" Text="Label"></asp:Label>
                  <a href="Arkadaslar.aspx?FriendName=<%=ArkadasKAdi %>" class="btnArkadasTick"> </a> 
                      <a href="Arkadaslar.aspx?FriendDelete=<%=ArkadasKAdi %>" class="btnArkadasCarpi" > </a>  
               </div>
                   
                       
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
                   <a href="HesapBilgileri.aspx" class="BilgilerimBtn"><span class="BilgilerimLabel"> Bilgilerim </span></a>
 
                     <a href="Login.aspx" id="btnCikis" style="font-size:16px;padding-bottom:15px" class="CikisBtn" >Çıkış Yap</a>
                     
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

