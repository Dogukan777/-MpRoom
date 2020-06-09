<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deneme.aspx.cs" Inherits="MedipolChat2.denemeaspx" %>

<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Index</title>
      <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/jquery.signalR-2.4.1.min.js"></script>

    <script src="/SignalR/Hubs"></script>
  
    <script>
        $(function () {

            var chat = $.connection.chatHub;
            var $username = $('#txtUsername');
            var $message = $('#txtMessage');
            var $messages = $('#messages');

            $message.focus();

            chat.client.sendMessage = function (name, message) {

                $messages.append('<li><strong>' + name + '</strong>: ' + message + '</li>');
            };

            $.connection.hub.start().done(function () {
                $('#btnSendMessage').click(function () {

                    chat.server.send($username.val(), $message.val());

                    $message.val('').focus();
                });
            });
        });

    </script>
</head>
<body>
      <form runat="server">
    <div>
      
        <label for="txtUserName">Kullanıcı: </label><asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br />
        <label for="txtMessage">Mesaj: </label><asp:TextBox ID="txtMessage" runat="server"></asp:TextBox><button id="btnSendMessage">Mesaj Yolla</button>
    </div>
    <div id="messages"></div>
    </form>
</body>
</html>
