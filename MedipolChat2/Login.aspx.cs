using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
namespace MedipolChat2.Scripts
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("KAd");
            lbl_uyariKAdi.Text = "";
            lbl_uyariSifre.Text = "";
            uyariGiris.Text = "";

            if (Session["KAd"] != null)
            {

                Response.Redirect("Anasayfa.aspx");

            }



        }

        protected void girisYap_Button(object sender, EventArgs e)
        {
         
            String KAdi = txtKAdi.Text;
            String Sifre = txtSifre.Text;

            DbOperation db = new DbOperation();
            DataTable Sonuc= db.UyeVarmi("select dbo.fn_UyeGirisi('"+KAdi+"','"+Sifre+"') as result");
            if (KAdi == "" && Sifre == "")
            {
                lbl_uyariKAdi.Text = "Bu alan boş geçilemez!";
                lbl_uyariSifre.Text = "Bu alan boş geçilemez!";
            }
            else if (Sifre == "")
            {
                lbl_uyariKAdi.Text = "";
                lbl_uyariSifre.Text = "Bu alan boş geçilemez!";
            }
            else if (KAdi == "")
            {
                lbl_uyariKAdi.Text = "Bu alan boş geçilemez!";
                lbl_uyariSifre.Text = "";
            }
            else
            {
                DataTable BanMi = db.UyeBanMi("select COUNT(*) as Banmi from tbl_kullanici where Yetki='B' and KAdi='" + KAdi + "'");
                if (Convert.ToInt32(BanMi.Rows[0]["Banmi"]) != 0)
                {
                    uyariGiris.Text = "Bu hesap kalıcı olarak banlanmıştır!";
                }
                else { 
                if (Convert.ToChar(Sonuc.Rows[0]["result"]) == 'E')
                {

                    // IsLogin.Login = true;
                    //HttpContext context = HttpContext.Current;
                    //context.Session["NickName"] = Server.HtmlEncode(txtKAdi.Text); 


                    if (Session["KAd"] == null)
                    {
                        Session.Add("KAd", txtKAdi.Text);
                    }

                    // IsLogin.Login = true;


                    if (Session["KAd"] != null)
                    {
                        DataTable AdminSonuc = db.AdminMi("select Yetki from tbl_kullanici where  KAdi='" + KAdi + "' and Sifre='" + Sifre + "'");
                        if (Convert.ToChar(AdminSonuc.Rows[0]["Yetki"]) == 'A')
                        {
                            Response.Redirect("AdminPanel.aspx");
                        }
                        else
                        {
                            Response.Redirect("Anasayfa.aspx");
                        }

                    }

                }

                else if (Convert.ToChar(Sonuc.Rows[0]["result"]) == 'H')
                {
                    lbl_uyariKAdi.Text = "";
                    lbl_uyariSifre.Text = "";
                    uyariGiris.Text = "Yanlış kullanıcı adı veya şifre !";
                }
            }
            }
        }
    }
}