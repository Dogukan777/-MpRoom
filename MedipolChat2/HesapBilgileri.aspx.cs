using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedipolChat2
{
    public partial class HesapBilgileri : System.Web.UI.Page
    {
        public static string newSifre = "";
        public static string newEPosta = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KAd"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                newSifre = txtSifre.Text;
                newEPosta = txtEPosta.Text;

                DbOperation db = new DbOperation();
                DataTable HesapBiglileriGetir = db.HesapBilgileriGetir("select Adi+Soyadi as AdSoyad,KAdi,Sifre,Eposta from tbl_kullanici where KAdi='" + Session["KAd"].ToString() + "'");


                  txtKAd.Text= HesapBiglileriGetir.Rows[0]["KAdi"].ToString();
                  txtAdSoyad.Text= HesapBiglileriGetir.Rows[0]["AdSoyad"].ToString();

                  txtSifre.Text= HesapBiglileriGetir.Rows[0]["Sifre"].ToString();


                  txtEPosta.Text= HesapBiglileriGetir.Rows[0]["EPosta"].ToString();

                 LabelAdSoyad.Text= HesapBiglileriGetir.Rows[0]["AdSoyad"].ToString();


            }
        }

        protected void btn_hesapguncelle_Click(object sender, EventArgs e)
        {



            DbOperation db = new DbOperation();
            string nickname = Session["KAd"].ToString(); ;

                
            db.hesapGuncelle(nickname, newSifre, newEPosta);

            DataTable HesapBiglileriGetir = db.HesapBilgileriGetir("select Adi+Soyadi as AdSoyad,KAdi,Sifre,Eposta from tbl_kullanici where KAdi='" + Session["KAd"].ToString() + "'");
            txtKAd.Text = HesapBiglileriGetir.Rows[0]["KAdi"].ToString();
            txtAdSoyad.Text = HesapBiglileriGetir.Rows[0]["AdSoyad"].ToString();

            txtSifre.Text = HesapBiglileriGetir.Rows[0]["Sifre"].ToString();


            txtEPosta.Text = HesapBiglileriGetir.Rows[0]["EPosta"].ToString();
            lblHesapGuncelleUyari.Text = "Hesabınız güncellenmiştir !";
        }
        protected void btnCikis_Click(object sender, EventArgs e)
        {
            Session.Remove("KAd");
            Response.Redirect("Login.aspx");

        }

        protected void btn_HesapSilKutucuk_Click(object sender, EventArgs e)
        {

            SilKutucuk.Style.Add("display", "inline");
            HesapSayfasi.Style.Add("background-color", "white");
            HesapSayfasi.Style.Add("opacity", "0.4");
            SilKutucuk.Style.Add("opacity", "10");
           

        }
        protected void btn_HesapSilOnayla_Click(object sender, EventArgs e)
        {

            
            DbOperation db = new DbOperation();
            
            db.hesapSil(Session["KAd"].ToString());
            Session.Remove("KAd");
            Response.Redirect("Login.aspx");

        }
        protected void btn_HesapSilVazgec_Click(object sender, EventArgs e)
        {

            SilKutucuk.Style.Add("display", "none");
            HesapSayfasi.Style.Add("background-color", "white");
            HesapSayfasi.Style.Add("opacity", "1");
       


        }
    }
}