using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace MedipolChat2
{
    public partial class Uyeler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KAd"] == null)
            {

                Response.Redirect("Login.aspx");

            }
            else
            {
                if (Session["UyeBanMesaj"] != null)
                {
                    lblBanMesaj.Text = Session["UyeBanMesaj"].ToString();
                    Session.Remove("UyeBanMesaj");

                }

                DbOperation db = new DbOperation();
                DataTable AdminUyeSayisiGetir = db.AdminUyeSayisiGetir("select COUNT(*) as KSayi from tbl_kullanici where Yetki='K'");
                lblKSayisi.Text = AdminUyeSayisiGetir.Rows[0]["KSayi"].ToString();
                DataTable Sonuc = db.HesapBilgileriGetir("select Adi+Soyadi as AdSoyad,KAdi,Sifre,Eposta from tbl_kullanici where KAdi='" + Session["KAd"].ToString() + "'");
                LabelAdSoyad.Text = Sonuc.Rows[0]["AdSoyad"].ToString();
               


                DataTable AdminUyeListesi = db.OdaIstekGetir("select * from tbl_kullanici where Yetki='K' ");
                for (int i = 0; i < AdminUyeListesi.Rows.Count; i++)
                {
                    string UyeKAdi = AdminUyeListesi.Rows[i]["KAdi"].ToString();
                    string UyeKId = AdminUyeListesi.Rows[i]["KId"].ToString();
                    // uyeKAdi.Text = UyeKAdi;
                    Label lblDetay = new Label();
                    lblDetay.Text = "Kullanıcı Adı:";
                    lblDetay.CssClass = "lbldetay";

                    TextBox txtdetay = new TextBox();
                    txtdetay.CssClass = "txtKadi";
                    txtdetay.Text = UyeKAdi;

                    Button detaybutton = new Button();
                    detaybutton.ID = UyeKId;
                    detaybutton.Text = "Detay Göster";
                    detaybutton.CssClass = "btnKDetay";
                    detaybutton.Click += new EventHandler(UyeDetayGoster);
                   
                    Panel detaypanel = new Panel();
                    detaypanel.CssClass = "uye";

                    detaypanel.Controls.Add(lblDetay);

                    detaypanel.Controls.Add(txtdetay);
                    detaypanel.Controls.Add(detaybutton);


                    btndetaydiv.Controls.Add(detaypanel);

                }
            }
            }
            protected void btnCikis_Click(object sender, EventArgs e)
        {
            Session.Remove("KAd");
            Response.Redirect("Login.aspx");

        }
        protected void UyeDetayGoster(object sender, EventArgs e)
        {     
            Button clickedButton = (Button)sender;
            Session.Add("UyeKId", clickedButton.ID);
          
            Response.Redirect("AdminUyeDetay.aspx");
            
        }
       
    }
}