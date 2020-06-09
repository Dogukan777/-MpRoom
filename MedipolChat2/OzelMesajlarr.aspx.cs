using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedipolChat2
{
    public partial class OzelMesajlar : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KAd"] == null)
            {

                Response.Redirect("Login.aspx");

            }
            else
            {
                DbOperation db = new DbOperation();
                DataTable Sonuc = db.HesapBilgileriGetir("select Adi+Soyadi as AdSoyad,KAdi,Sifre,Eposta from tbl_kullanici where KAdi='" + Session["KAd"].ToString() + "'");
                LabelAdSoyad.Text = Sonuc.Rows[0]["AdSoyad"].ToString();
                this.txtMessage.Attributes.Add(
                               "onkeypress", "button_click(this,'" + this.btnSendMessage.ClientID + "')");
                lblArkadasAdi.Text = Session["ArkadasAdi"].ToString();
                txtUsername.Text = Session["KAd"].ToString();
                DataTable mesajSonuc = db.OzelMesajGetir("select * from tbl_OzelMesajlar O,tbl_Arkadaslar A where O.ArkadasNo = A.Id and((MyName = '"+ Session["KAd"].ToString() + "' and FriendName = '"+ Session["ArkadasAdi"].ToString() + "') or(MyName = '"+ Session["ArkadasAdi"].ToString() + "' and FriendName = '"+ Session["KAd"].ToString() + "')) and Durum = 'A'");
                for (int i = 0; i < mesajSonuc.Rows.Count; i++)
                {
                    string mesajTarih = mesajSonuc.Rows[i]["Tarih"].ToString();
                    string saat = mesajTarih.Substring(12, 1);
                    string dakika = mesajTarih.Substring(13, 3);
                    string tarih;
                    string yenisaat = "";
                    //if (Convert.ToInt32(saat) < 12)
                    //{
                        yenisaat = '1' + saat;
                    //}
                    tarih = yenisaat + dakika;
                    if (Session["KAd"].ToString() == mesajSonuc.Rows[i]["MyName"].ToString())
                    {
                        messages.InnerHtml += "<div class=IBox><div class=ImessageBox><div class=messageUst><span class=ImessageName>" + mesajSonuc.Rows[i]["MyName"].ToString() + "</span><span class=ImessageDate>" + tarih + "</span></div>" + mesajSonuc.Rows[i]["Mesaj"].ToString() + "</div></div>";
                    }
                    else 
                    {
                        messages.InnerHtml += "<div class=Box><div class=messageBox><div class=messageUst><span class=messageName>" + mesajSonuc.Rows[i]["MyName"].ToString() + "</span><span class=messageDate>" + tarih + "</span></div>" + mesajSonuc.Rows[i]["Mesaj"].ToString() + "</div></div>";
                    }
                    


                }
            }
        }
        protected void btnCikis_Click(object sender, EventArgs e)
        {
            Session.Remove("KAd");
            Response.Redirect("Login.aspx");

        }
    }
}