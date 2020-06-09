using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace MedipolChat2
{
    public partial class Register : System.Web.UI.Page
    {
        public DataTable tablo; // Tablo 
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_Uyari.Text = "";
     


        }

        protected void Kaydol_Click(object sender, EventArgs e)
        {
            DbOperation db = new DbOperation();
            db.VeritabaninaBaglan();
            String Ad = txtAd.Text;
            String Soyad = txtSoyad.Text;
            String KAdi = txt_KAdi.Text;
            String Sifre = txt_Sifre.Text;
            String EPosta = txtEposta.Text;

            DataTable Sonuc = db.UyeVarmi("select dbo.fn_UyeKontrol ('" + KAdi + "','" + EPosta + "')  as result");
            if (Convert.ToChar(Sonuc.Rows[0]["result"]) == 'N')
            {
                lbl_Uyari.Text = "Böyle bir kullanıcı adı bulunmaktadır.";
            }
            if (Convert.ToChar(Sonuc.Rows[0]["result"]) == 'E')
            {
                lbl_Uyari.Text = "Böyle bir e-posta adresi kullanılmaktadır. Farklı bir eposta adresi deneyiniz.";
            }
            
            if (Ad.Length>0 && Soyad.Length>0 && KAdi.Length>0 && Sifre.Length>0 && EPosta.Length>0)
            {
                if (Convert.ToChar(Sonuc.Rows[0]["result"]) == 'Y')
                {
                    db.KullaniciEkle(Ad, Soyad, KAdi, Sifre, EPosta, 'K');
                    lbl_Uyari.Text = "Başarılı bir şekilde kayıt olundu.";
                }
            }


        }


    }
}