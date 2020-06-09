<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OdaGenel.aspx.cs" Inherits="MedipolChat2.OdaGenel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    
   
  <link href="main.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/jquery.signalR-2.4.1.min.js"></script>

    <script src="/SignalR/Hubs"></script>

    
    <script>
        $(function () {
            scrollBottom();
            var d = new Date();
            var strDate = d.getHours() + ":" + d.getMinutes();
            if (d.getMinutes() < 10) {
                strDate = "";
                var strDate = d.getHours() + ":0" + d.getMinutes();
            }
            var chat = $.connection.chatHub;
            var $username = $('#txtUsername');
            var $message = $('#txtMessage');
            var $messages = $('#messages');
            scrollingElement = (document.scrollingElement || document.body)
            $(scrollingElement).animate({
                scrollTop: document.body.scrollHeight
            });
            $message.focus();

            chat.client.sendMessage = function (name, message) {

                if (name == $username.val() && message.trim()!="") {
                    $messages.append('<div class="IBox"><div class="ImessageBox" ><div class="messageUst"><span class="ImessageName">' + name + '</span>' + '<span class="ImessageDate">' + strDate + '</span></div>' + '' + message + '</div></div>');
                        scrollBottom();
                    }
                else if (message.trim() != ""){
                    $messages.append('<div class="Box"><div class="messageBox"><div class="messageUst"><span class="messageName">' + name + '</span>' + '<span class="messageDate">' + strDate + '</span></div>' + '' + message + '</div></div>');
                        scrollBottom();
                    }
              
                };
           
            $.connection.hub.start().done(function () {
                $('#btnSendMessage').click(function () {
                    if ($message.val().trim() != "") {
                        chat.server.mesajEkle($username.val(), $message.val());
                    }
                    chat.server.send($username.val(), $message.val());

                    $message.val('').focus();
                });
            });
        });

    </script>
    <script>
        function button_click(objTextBox, objBtnID) {
            if (window.event.keyCode == 13) {
                document.getElementById(objBtnID).focus();
                document.getElementById(objBtnID).click();
            }
        }

        function scrollBottom() {

            scrollingElement = document.getElementById('messages');
            $(scrollingElement).animate({
                scrollTop: scrollingElement.scrollHeight
            });

        }
    </script>

</head>
<body >
    <form id="form1" method="get" runat="server">
        <div class="AnasayfaGenel">
            
            <div class="Sol">
            <div class="menu">
                <div class="logo"></div>
                <a href="Anasayfa.aspx" class="menuler">Anasayfa</a>
                <a href="#" class="menuler">Arkadaşlarım</a>
                    <a href="Mesajlarim.aspx" class="menuler">Mesajlarım</a>
                <a href="EngellenenlerListesi.aspx" class="menuler">Engellenen Kişiler</a>
                <a href="#" class="menuler">Misyonumuz</a>
              
            </div><br />  
             <div class="odalar">
                <div class="odaAdi"><span class="odaisim">Oda:GENEL</span></div>
                <hr class="cizgi" />
                 <asp:TextBox ID="txtUsername" style="display:none" runat="server"></asp:TextBox>
                <div class="Mesajlar"  id="messages" runat="server">
                    

                </div>
                <asp:TextBox ID="txtMessage" runat="server" class="txtMesaj"></asp:TextBox>
               
                    <button type="button"  runat="server" onclick="button_click" id="btnSendMessage" class="btnMesaj">Gönder</button>
                
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
