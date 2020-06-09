using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedipolChat2
{
    public partial class SifremiUnuttum : System.Web.UI.Page
    {
        string rastgeleSifre = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void AktivasyonGonder_Click(object sender, EventArgs e)
        {
            Random rastgele = new Random();


            for (int i = 0; i < 100; i++)
            {
                int sayi = rastgele.Next(100000, 900000);
                rastgeleSifre = sayi.ToString();
            }
            DbOperation db = new DbOperation();
            DataTable Sonuc = db.UyeVarmi("select * from tbl_kullanici where EPosta='" + txtEPosta.Text + "'");


            if (Sonuc.Rows.Count > 0)
            {

                // MailMessage mesajim = new MailMessage();
                // SmtpClient istemci = new SmtpClient();
                // istemci.Credentials = new System.Net.NetworkCredential("MpSohbetOdalari@hotmail.com", "mproom123");
                // istemci.Port = 587;
                // istemci.Host = "smtp.live.com";
                // istemci.EnableSsl = true;
                // mesajim.To.Add(txtEPosta.Text);
                // mesajim.From = new MailAddress("MpSohbetOdalari@hotmail.com");
                // mesajim.Subject = "ŞİFRE YENİLEME";
                // mesajim.Body = "Yeni Şifreniz:" + rastgeleSifre;
                // istemci.Send(mesajim);


                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                string msg = string.Empty;
                try
                {
                    MailAddress fromAddress = new MailAddress("MpSohbetOdalari@hotmail.com");
                    message.From = fromAddress;
                    message.To.Add(txtEPosta.Text);
                    //if (ccList != null && ccList != string.Empty)
                    //    message.CC.Add(ccList);
                    message.Subject = "ŞİFRE YENİLEME";
                    message.IsBodyHtml = true;
                    message.Body = "Kullanıcı Adınız:"+ Sonuc.Rows[0]["KAdi"].ToString() +"<br/>"+"Yeni Şifreniz:" + rastgeleSifre;
                    // We use gmail as our smtp client
                    smtpClient.Host = "smtp.live.com";
                    message.From = new MailAddress("MpSohbetOdalari@hotmail.com");
                    //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new System.Net.NetworkCredential(
                        "MpSohbetOdalari@hotmail.com", "mproom123");

                    smtpClient.Send(message);
                    msg = "Successful<BR>";
                    lbl_Uyari.Text = "E-Postanıza yeni şifre gönderildi.";
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                    lbl_Uyari.Text = ex.Message;
                }


                db.sifreAktivasyonu("update tbl_kullanici set Sifre='" + rastgeleSifre + "' where EPosta='" + txtEPosta.Text + "'");
            }
            else
            {
                lbl_Uyari.Text = "Böyle bir eposta bulunmamaktadır!";

            }



        }
    }
}
