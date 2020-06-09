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
    public partial class Arkadaslar : System.Web.UI.Page
    {
        public static string FriendName = "";
        public static string FriendDelete = "";
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




                DbOperation db2 = new DbOperation();

                DataTable ArkadasListesi = db2.ArkadasListesi("select * from tbl_Arkadaslar where MyName='" + Session["KAd"].ToString() + "' and Durum='A' ");
                for (int i = 0; i < ArkadasListesi.Rows.Count; i++)
                {
                    string ArkadasKAdi = ArkadasListesi.Rows[i]["FriendName"].ToString();
                    // lblArkadaslar.Text = ArkadasKAdi;
                    Label lblArkadas = new Label();
                    lblArkadas.Text = ArkadasKAdi;
                    lblArkadas.CssClass = "lblArkadas";


                    Button btnArkadasMessage = new Button();
                    btnArkadasMessage.CssClass = "btnArkadasMessage";
                    btnArkadasMessage.Click += new EventHandler(ArkadasMesaj_Click);
                    btnArkadasMessage.ID = ArkadasKAdi + " ";
                    Button btnArkadasEngelle = new Button();
                    btnArkadasEngelle.CssClass = "btnArkadasEngelle";
                    btnArkadasEngelle.ID = ArkadasKAdi + "  ";
                    btnArkadasEngelle.Click += new EventHandler(ArkadasEngelle_Click);
                    Button btnArkadasSil = new Button();
                    btnArkadasSil.CssClass = "btnArkadasSil";
                    btnArkadasSil.ID = ArkadasKAdi;
                    btnArkadasSil.Click += new EventHandler(ArkadasSil_Click);


                    Panel pnlArkadas = new Panel();
                    pnlArkadas.CssClass = "Arkadas";
                    Panel cizgi = new Panel();
                    cizgi.CssClass = "cizgiArkadas";
                    pnlArkadas.Controls.Add(lblArkadas);
                    pnlArkadas.Controls.Add(btnArkadasMessage);
                    pnlArkadas.Controls.Add(btnArkadasEngelle);
                    pnlArkadas.Controls.Add(btnArkadasSil);
                    pnlArkadas.Controls.Add(cizgi);




                    Arkadaslarim.Controls.Add(pnlArkadas);



                }



                FriendName = Request.QueryString["FriendName"];

                if (FriendName != null)
                {
                    DataTable ArkadasSonuc = db.ArkadasMi("select * from tbl_Arkadaslar where MyName='" + Session["KAd"].ToString() + "' and FriendName='" + FriendName + "' and Durum='A'");
                    if (ArkadasSonuc.Rows.Count == 0)
                    {
                        db.ArkadasIstekKabul("insert into tbl_Arkadaslar values('" + Session["KAd"].ToString() + "','" + FriendName + "','A')");
                        db.ArkadasIstekKabul("update tbl_Arkadaslar set Durum = 'A' where MyName = '" + FriendName + "' and FriendName='" + Session["KAd"].ToString() + "'");
                        Response.Redirect("Arkadaslar.aspx");
                    }
                }
                FriendDelete = Request.QueryString["FriendDelete"];
                if (FriendDelete != null)
                {
                    db.ArkadasIstekSil("delete from tbl_Arkadaslar where MyName='" + FriendDelete + "' and FriendName='" + Session["KAd"].ToString() + "'and Durum='P'");
                    lblUyari.Text = "Arkadaş isteği silindi";
                }

            }
        }
        protected void btnCikis_Click(object sender, EventArgs e)
        {
            Session.Remove("KAd");
            Response.Redirect("Login.aspx");

        }
        protected void ArkadasIstegi_Click(object sender, EventArgs e)
        {
            DbOperation db = new DbOperation();
            DataTable ArkadasIstekVarmi = db.ArkadasIstekVarmi("select * from tbl_Arkadaslar where MyName='" + txtArkadasName.Text + "' and FriendName='" + Session["KAd"].ToString() + "' and Durum='P'");
            DataTable ArkadasEngelMi = db.ArkadasEngelMi("select * from tbl_Arkadaslar where MyName='" + Session["KAd"].ToString() + "' and FriendName='" + txtArkadasName.Text + "' and Durum='E'");
            DataTable ArkadasEngelli = db.ArkadasEngelMi("select * from tbl_Arkadaslar where MyName='" + Session["KAd"].ToString() + "' and FriendName='" + txtArkadasName.Text + "' and Durum='M'");
            DataTable KullaniciVarmi = db.KullaniciVarmi("select * from tbl_Kullanici where KAdi='"+ txtArkadasName.Text + "'");
            if (KullaniciVarmi.Rows.Count == 0)
            {
                lblUyari.Text = "Böyle bir kullanıcı bulunmamaktadır.";
            }
            else
            {
                if (ArkadasEngelli.Rows.Count > 0)
                {
                    lblUyari.Text = "Bu kişi sizi engellemiş. Arkadaş isteği gönderemezsiniz!";
                }
                else if (ArkadasEngelMi.Rows.Count > 0)
                {
                    lblUyari.Text = "Bu kişi siz tarafından engellenmiştir";
                }
                else
                {
                    if (ArkadasIstekVarmi.Rows.Count == 0)
                    {
                        DataTable ArkadasVarmiSonuc = db.ArkadasMi("select * from tbl_Arkadaslar where MyName = '" + Session["KAd"].ToString() + "' and FriendName = '" + txtArkadasName.Text + "' and Durum = 'A'");
                        if (Session["KAd"].ToString() == txtArkadasName.Text)
                        {
                            lblUyari.Text = "Kendinize arkadaşlık isteği gönderemezsiniz.";
                        }
                        else if (ArkadasVarmiSonuc.Rows.Count == 0)
                        {



                            DataTable ArkadasIstekVarmi2 = db.ArkadasIstekVarmi("select * from tbl_Arkadaslar where MyName='" + Session["KAd"].ToString() + "' and FriendName='" + txtArkadasName.Text + "' and Durum='P'");
                            if (ArkadasIstekVarmi2.Rows.Count == 0)
                            {
                                db.ArkadasIstegiGonder("insert into tbl_Arkadaslar values('" + Session["KAd"].ToString() + "','" + txtArkadasName.Text + "','P')");
                                lblUyari.Text = "Arkadaşlık isteği gönderildi.";
                            }
                            else
                            {
                                lblUyari.Text = "Daha önce arkadaşlık isteği gönderilmiş.";
                            }

                        }
                        else
                        {
                            lblUyari.Text = "Bu kullanıcıyla zaten arkadaşsınız.";
                        }


                    }
                    else
                    {
                        lblUyari.Text = " Arkadaşlık isteği zaten var.İstek gönderemezsiniz!";
                    }
                }
            }

        }
        protected void ArkadasSil_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            DbOperation db = new DbOperation();

            db.ArkadasSil("delete from tbl_Arkadaslar where MyName='" + Session["KAd"].ToString() + "' and FriendName='" + clickedButton.ID + "'");

            db.ArkadasSil("delete from tbl_Arkadaslar where MyName='" + clickedButton.ID + "' and FriendName='" + Session["KAd"].ToString() + "'");

            Response.Redirect("Arkadaslar.aspx");
        }
        protected void ArkadasEngelle_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            DbOperation db = new DbOperation();

            // clickedButton.ID.Trim()
            db.ArkadasEngelle("update tbl_Arkadaslar set Durum='E' where MyName='" + Session["KAd"].ToString() + "' and  FriendName='" + clickedButton.ID.Trim() + "'");
            db.ArkadasEngelle("update tbl_Arkadaslar set Durum='M' where MyName='" + clickedButton.ID.Trim() + "' and  FriendName='" + Session["KAd"].ToString() + "'");
            Response.Redirect("Arkadaslar.aspx");
        }
        protected void ArkadasMesaj_Click(object sender, EventArgs e)
        {
            Session.Remove("ArkadasAdi");
            Button clickedButton = (Button)sender;
            Session.Add("ArkadasAdi", clickedButton.ID.Trim());
            Response.Redirect("OzelMesajlarr.aspx");
         
        }
        }
}