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
    public partial class AdminUyeDetay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DbOperation db = new DbOperation();
    
           DataTable AdminUyeDetayGetir = db.AdminUyeDetayGetir("select * from tbl_kullanici where Yetki='K' and KId='"+ Session["UyeKId"] + "' ");
            txtKAdi.Text = AdminUyeDetayGetir.Rows[0]["KAdi"].ToString();
            txtSoyadi.Text = AdminUyeDetayGetir.Rows[0]["Soyadi"].ToString();

            txtSifre.Text = AdminUyeDetayGetir.Rows[0]["Sifre"].ToString();


            txtEposta.Text = AdminUyeDetayGetir.Rows[0]["EPosta"].ToString();

            txtAdi.Text = AdminUyeDetayGetir.Rows[0]["Adi"].ToString();
        }
        protected void btnCikis_Click(object sender, EventArgs e)
        {
            Session.Remove("KAd");
            Response.Redirect("Login.aspx");


        }
        protected void detayGeriDon_Click(object sender, EventArgs e)
        {
            Session.Remove("UyeKId");
            Response.Redirect("AdminUyeler.aspx");


        }
        protected void KullaniciBanla_Click(object sender, EventArgs e)
        {


            DbOperation db = new DbOperation();

            db.AdminUyeBanla("update tbl_kullanici set Yetki='B' where KId='"+ Session["UyeKId"] +"'");
            Session.Add("UyeBanMesaj", "Kullanıcı Banlandı");
            Response.Redirect("AdminUyeler.aspx");

        }
    }
}