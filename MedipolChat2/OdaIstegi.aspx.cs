using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedipolChat2
{
    public partial class OdaIstegi_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KAd"] == null)
            {

                Response.Redirect("Login.aspx");

            }
            else
            {

                IsLogin.Login = true;
                DbOperation db = new DbOperation();
                // HttpContext context = HttpContext.Current;
                //String NickName = (string)(context.Session["NickName"]);


                DataTable Sonuc = db.HesapBilgileriGetir("select Adi+Soyadi as AdSoyad,KAdi,Sifre,Eposta from tbl_kullanici where KAdi='" + Session["KAd"].ToString() + "'");
                LabelAdSoyad.Text = Sonuc.Rows[0]["AdSoyad"].ToString();
            }

        }
        protected void btnCikis_Click(object sender, EventArgs e)
        {
            Session.Remove("KAd");
            Response.Redirect("Login.aspx");

        }

        protected void IstekGonder_Click(object sender, EventArgs e)
        {
            DbOperation db = new DbOperation();

            string odaAdi = txtOdaAdi.Text;
            string odaAcmaSebebi = txtOdaAcmaSebebi.Text;
            string odaMesaji = txtOdaMesaji.Value;
            if (odaAdi.Trim()=="" || odaAcmaSebebi.Trim()=="" || odaMesaji.Trim()=="")
            {
                lblOdaUyari.Text = "Oda Şifresi hariç diğer alanları doldurmak zorunludur!";
            }
            else
            { 
            db.OdaIstekEkle("insert into tbl_odalar values('"+txtOdaAdi.Text+"', '"+txtOdaAcmaSebebi.Text+"', '"+txtOdaSifresi.Text+"', '"+txtOdaMesaji.Value+"', 'P')");
            lblOdaUyari.Text = "Oda açma isteği gönderildi";
            }
        }
    }
}