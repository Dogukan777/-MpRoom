using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedipolChat2
{
    public partial class OdalarinListesi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["KAd"] == null)
                {

                    Response.Redirect("Login.aspx");

                }
                else
                {

                    IsLogin.Login = true;
                    DbOperation db = new DbOperation();


                    DataTable Sonuc = db.HesapBilgileriGetir("select Adi+Soyadi as AdSoyad,KAdi,Sifre,Eposta from tbl_kullanici where KAdi='" + Session["KAd"].ToString() + "'");
                    LabelAdSoyad.Text = Sonuc.Rows[0]["AdSoyad"].ToString();
                  

                    //  DataTable Mesajlar= db.OdaMesajGetir("select * from tbl_OdaMesajlar");

                    // messages.InnerHtml+= Mesajlar.Rows[0]["Mesaj"].ToString()+"<br/>";
                  
                    



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