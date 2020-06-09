using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedipolChat2
{
    public partial class EngellenenlerListesi : System.Web.UI.Page
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
                DataTable HesapBiglileriGetir = db.HesapBilgileriGetir("select Adi+Soyadi as AdSoyad,KAdi,Sifre,Eposta from tbl_kullanici where KAdi='" + Session["KAd"].ToString() + "'");
                LabelAdSoyad.Text = HesapBiglileriGetir.Rows[0]["AdSoyad"].ToString();

                DataTable Engellenenler = db.HesapBilgileriGetir("select * from tbl_Arkadaslar where MyName='" + Session["KAd"].ToString() + "' and Durum='E'");

                for (int i = 0; i < Engellenenler.Rows.Count; i++)
                {
                   
                    Panel panelEngel = new Panel();
                    panelEngel.CssClass = "pnlEngel";

                    Label lblEngel = new Label();
                    lblEngel.CssClass = "lblEngel";
                    lblEngel.Text = "Kullanıcı Adı:";

                    TextBox txtEngel = new TextBox();
                    txtEngel.CssClass = "txtEngel";
                    txtEngel.Text= Engellenenler.Rows[i]["FriendName"].ToString();

                    Button btnEngel = new Button();
                    btnEngel.Text = "Engeli Kaldır";
                    btnEngel.CssClass = "btnEngel";
                    btnEngel.ID = Engellenenler.Rows[i]["FriendName"].ToString();
                    btnEngel.Click += new EventHandler(EngelKaldir_Click);

                    panelEngel.Controls.Add(lblEngel);
                    panelEngel.Controls.Add(txtEngel);
                    panelEngel.Controls.Add(btnEngel);

                    divEngellenenler.Controls.Add(panelEngel);
                }
            }
        }
        protected void btnCikis_Click(object sender, EventArgs e)
        {
            Session.Remove("KAd");
            Response.Redirect("Login.aspx");

        }
        protected void EngelKaldir_Click(object sender, EventArgs e)
        {

            DbOperation db = new DbOperation();
            Button clickedButton = (Button)sender;
       
            db.EngelKaldir("delete from tbl_Arkadaslar where Durum = 'E' and MyName = '"+ Session["KAd"].ToString() + "' and FriendName = '"+ clickedButton.ID + "'");
            db.EngelKaldir("delete from tbl_Arkadaslar where Durum='M' and MyName='"+ clickedButton.ID + "' and FriendName='"+ Session["KAd"].ToString() + "'");
            Response.Redirect("EngellenenlerListesi.aspx");
        }
    }
}