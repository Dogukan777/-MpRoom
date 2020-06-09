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
            
                if (Session["KAd"] == null)
                {

                    Response.Redirect("Login.aspx");

                }
                else
                {
            
                IsLogin.Login = true;
                    DbOperation db = new DbOperation();
                DataTable AdminOdaSayisiGetir = db.AdminOdaSayisiGetir("select COUNT(*) as odaSayisi from tbl_odalar where OdaDurumu='A'");
                lblOdaSayisi.Text = AdminOdaSayisiGetir.Rows[0]["odaSayisi"].ToString();


                DataTable Sonuc = db.HesapBilgileriGetir("select Adi+Soyadi as AdSoyad,KAdi,Sifre,Eposta from tbl_kullanici where KAdi='" + Session["KAd"].ToString() + "'");
                   LabelAdSoyad.Text = Sonuc.Rows[0]["AdSoyad"].ToString();

                    DataTable AdminOdaListesi = db.AdminOdaListesi("select * from tbl_odalar where OdaDurumu='A'");
                    for (int i = 0; i < AdminOdaListesi.Rows.Count; i++)
                    {
                        string OdaAdi = AdminOdaListesi.Rows[i]["OdaAdi"].ToString();
                        string OdaId = AdminOdaListesi.Rows[i]["OdaId"].ToString();


                        Button btnOda = new Button();
                        btnOda.Text = OdaAdi;
                        btnOda.CssClass = "btnAdminOda";
                    Panel pnlOda = new Panel();
                    pnlOda.CssClass = "pnlAdminOda";

                    Button btnOdaSil = new Button();
                    btnOdaSil.Text = "Odayı Sil";
                    btnOdaSil.ID = OdaId;
                    btnOdaSil.Click += new EventHandler(OdaSil_Click);
                    btnOdaSil.CssClass = "btnOdaSil";
                    pnlOda.Controls.Add(btnOda);
                    pnlOda.Controls.Add(btnOdaSil);
                    btnOdadiv.Controls.Add(pnlOda);
                  

                    }





                
            }
        }
        protected void btnCikis_Click(object sender, EventArgs e)
        {
            Session.Remove("KAd");
            Response.Redirect("Login.aspx");

        }
        protected void OdaSil_Click(object sender, EventArgs e)
        {
            DbOperation db = new DbOperation();
            Button clickedButton = (Button)sender;
            db.AdminOdaSil("delete from tbl_odalar where OdaId='"+clickedButton.ID+"' and OdaDurumu='A'");
            lblOdaSilMesaj.Text = "Oda Silindi.";
            Response.Redirect("AdminOdalarinListesi.aspx");
         
        }

    }
}