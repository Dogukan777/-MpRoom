using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedipolChat2
{
    public partial class AdminOdaIstegi : System.Web.UI.Page
    {

        public static int odaId=0;
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KAd"] == null)
            {

                Response.Redirect("Login.aspx");

            }
            else
            {

                if (!Page.IsPostBack) { 
                IsLogin.Login = true;
                DbOperation db = new DbOperation();
                // HttpContext context = HttpContext.Current;
                //String NickName = (string)(context.Session["NickName"]);


                DataTable Sonuc = db.HesapBilgileriGetir("select Adi+Soyadi as AdSoyad,KAdi,Sifre,Eposta from tbl_kullanici where KAdi='" + Session["KAd"].ToString() + "'");
                LabelAdSoyad.Text = Sonuc.Rows[0]["AdSoyad"].ToString();
                odaId = Convert.ToInt32(Request.QueryString["OdaId"]);
                DataTable odaIstekSonuc=db.OdaIstekGetir("select * from tbl_odalar where OdaId=" + odaId + " and OdaDurumu='P' ");
                txtOdaAdi.Text = odaIstekSonuc.Rows[0]["OdaAdi"].ToString();
                txtOdaAcmaSebebi.Text= odaIstekSonuc.Rows[0]["OdaAcmaSebebi"].ToString();
                txtOdaSifresi.Text= odaIstekSonuc.Rows[0]["OdaSifresi"].ToString();
                txtOdaMesaji.Value= odaIstekSonuc.Rows[0]["OdaMesaj"].ToString();
                }

            }
           
        }
        protected void btnCikis_Click(object sender, EventArgs e)
        {
            Session.Remove("KAd");
            Response.Redirect("Login.aspx");

        }

        protected void OdaIstekKabulEt_Click(object sender, EventArgs e)
        {
          
            DbOperation db = new DbOperation();
            db.OdaIstekKabulEt("update tbl_odalar set OdaDurumu='A' where OdaId='"+ odaId + "'");
            lblOdaUyari.Text = "İstek Kabul Edildi";
        }
        protected void OdaIstekSil_Click(object sender, EventArgs e)
        {
  
            DbOperation db = new DbOperation();
            db.OdaIstekSil("delete from tbl_odalar where OdaId = '"+ odaId + "'");
            Response.Redirect("AdminPanel.aspx");

        }
    }
}