using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
namespace MedipolChat2
{
    public class ChatHub : Hub
    {
       public void Send(string nickname, string mesaj)
      {
          
            Clients.All.sendMessage(nickname, mesaj);
      
      }
        public void mesajEkle(string username,string message)
        {

            DbOperation db = new DbOperation();
            db.odaMesajEkle("insert into tbl_OdaMesajlar values(1,'"+message+"','"+username+"',GETDATE())");

            Clients.All.mesajEkle(username,message);
        }
        public void newOdaMesajEkle(string username, string message, string odaAdi)
        {
            DbOperation db = new DbOperation();
            db.odaMesajEkle("insert into tbl_OdaMesajlar values((select OdaId from tbl_odalar where OdaAdi = '" + odaAdi + "'),'" + message + "', '" + username + "', GETDATE())");


            Clients.All.newOdaMesajEkle(username, message, odaAdi);
        }
        public void newOdaSend(string nickname, string mesaj, string odaAdi)
        {

            Clients.All.newOdaSend(nickname, mesaj, odaAdi);

        }
        public void ozelMesajEkle(string myname,string friendname, string mesaj)
        {
            DbOperation db = new DbOperation();
            db.OzelMesajEkle("insert into tbl_OzelMesajlar values('"+mesaj+"', GETDATE(), (select Id from tbl_Arkadaslar where MyName = '"+ myname + "' and FriendName = '"+ friendname + "' and Durum = 'A'))");
       
            Clients.All.ozelMesajEkle(myname,friendname, mesaj);
        }
        public void ozelMesajSend(string myname, string friendname, string mesaj)
        {

            Clients.All.ozelMesajSend(myname, friendname, mesaj);

        }


    }
}