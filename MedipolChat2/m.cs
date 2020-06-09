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
        
    }
}