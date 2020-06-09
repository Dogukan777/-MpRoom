using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedipolChat2
{
    public partial class Banlananlar : System.Web.UI.Page
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
                // DataTable AdminBanlananlarGetir = db.AdminUyeSayisiGetir("select COUNT(*) as KSayi from tbl_kullanici where Yetki='K'");

                // lblKSayisi.Text = AdminBanlananlarGetir.Rows[0]["KSayi"].ToString();

                DataTable AdminBanSayisiGetir = db.AdminBanSayisiGetir("select COUNT(*) as KSayi from tbl_kullanici where Yetki='B'");
                if (Convert.ToInt32(AdminBanSayisiGetir.Rows[0]["KSayi"]) == 0)
                {
                    lblBanSayisi.Text = AdminBanSayisiGetir.Rows[0]["KSayi"].ToString();
                    lblBanMesaj.Text = "Banlanan kullanıcı bulunmamaktadır";
                }
                else
                {
                    lblBanSayisi.Text = AdminBanSayisiGetir.Rows[0]["KSayi"].ToString();
                  
                }


                DataTable AdminBanlananlarGetir = db.AdminBanlananlarGetir("select * from tbl_kullanici where Yetki='B' ");
                for (int i = 0; i < AdminBanlananlarGetir.Rows.Count; i++)
                {
                    string UyeKAdi = AdminBanlananlarGetir.Rows[i]["KAdi"].ToString();
                    string UyeKId = AdminBanlananlarGetir.Rows[i]["KId"].ToString();
                    // uyeKAdi.Text = UyeKAdi;
                    Label lblDetay = new Label();
                    lblDetay.Text = "Kullanıcı Adı:";
                    lblDetay.CssClass = "lbldetay";

                    TextBox txtdetay = new TextBox();
                    txtdetay.CssClass = "txtKadi";
                    txtdetay.Text = UyeKAdi;

                    Button detaybutton = new Button();
                    detaybutton.ID = UyeKId;
                    detaybutton.Text = "Banı Kaldır";
                    detaybutton.CssClass = "btnBanKaldir";
                    detaybutton.Click += new EventHandler(BanKaldir);

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
        protected void BanKaldir(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
         
            DbOperation db = new DbOperation();
            db.AdminBanKaldir("update tbl_kullanici set Yetki='K' where Yetki='B' and KId='" + clickedButton.ID + "'");
            lblBanSayisi.Text = "Kullanıcının Banı Kaldırıldı!";
            Response.Redirect("AdminBanlananlar.aspx");

        }
    }
}