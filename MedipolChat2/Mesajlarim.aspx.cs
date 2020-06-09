using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MedipolChat2
{
    public partial class Mesajlarim : System.Web.UI.Page
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
                int Arkadas1 = 0;
                int Arkadas2 = 0;
                int Arkadas3 = 0;
                int Arkadas4 = 0;
                int sayac = 0;
                int sayac2 = 0;
               
               DataTable SonMesajGetir = db.SonOzelMesajGetir("select ArkadasNo from tbl_OzelMesajlar O, tbl_Arkadaslar A where O.ArkadasNo = A.Id and ((MyName = '"+ Session["KAd"].ToString() + "' or FriendName = '"+ Session["KAd"].ToString() + "')) and Durum = 'A' group by ArkadasNo  ");
                for (int i = 0; i < SonMesajGetir.Rows.Count; i++)
                {
                    if (Convert.ToInt32(SonMesajGetir.Rows[i]["ArkadasNo"]) % 2 == 0)
                    {
                        Arkadas2 = Convert.ToInt32(SonMesajGetir.Rows[i]["ArkadasNo"]);
                        sayac++;
                    }
                    else if (Convert.ToInt32(SonMesajGetir.Rows[i]["ArkadasNo"]) % 2 == 1)
                    {
                        Arkadas1 = Convert.ToInt32(SonMesajGetir.Rows[i]["ArkadasNo"]);
                        sayac++;
                    }

                    if (Convert.ToInt32(SonMesajGetir.Rows[i]["ArkadasNo"]) % 2 == 0)
                    {
                        Arkadas3 = Convert.ToInt32(SonMesajGetir.Rows[i]["ArkadasNo"]);
                    }
                    else if (Convert.ToInt32(SonMesajGetir.Rows[i]["ArkadasNo"]) % 2 == 1)
                    {
                        Arkadas4 = Convert.ToInt32(SonMesajGetir.Rows[i]["ArkadasNo"]);
                    }
                    if (i % 2 == 1)
                    {
                       
                        DataTable SonMesajGetir2 = db.SonOzelMesajGetir("select * from tbl_OzelMesajlar O, tbl_Arkadaslar A where O.ArkadasNo = A.Id and ((MyName = '"+ Session["KAd"].ToString() + "') or(FriendName = '"+ Session["KAd"].ToString() + "')) and ArkadasNo in ("+Arkadas1+", "+Arkadas2+") and Durum = 'A' order by O.Id desc ");
                        Panel pnlOzelMesaj = new Panel();
                        pnlOzelMesaj.CssClass = "pnlOzelMesaj";

                        Panel pnlUst = new Panel();
                        pnlUst.CssClass = "pnlUst";
                        Label lblName = new Label();

                        if(SonMesajGetir2.Rows[0]["MyName"].ToString()== Session["KAd"].ToString()) { 
                        lblName.Text = SonMesajGetir2.Rows[0]["FriendName"].ToString();
                        }
                        else if(SonMesajGetir2.Rows[0]["FriendName"].ToString() == Session["KAd"].ToString())
                        {
                            lblName.Text = SonMesajGetir2.Rows[0]["MyName"].ToString();
                        }


                        lblName.CssClass = "lblName";
                        Label lblTarih = new Label();
                        lblTarih.Text = SonMesajGetir2.Rows[0]["Tarih"].ToString();
                        lblTarih.CssClass = "lblTarih";
                        pnlUst.Controls.Add(lblName);
                        pnlUst.Controls.Add(lblTarih);


                        Panel pnlAlt = new Panel();
                        pnlAlt.CssClass = "pnlAlt";
                        Label lblMesaj = new Label();

                        if (SonMesajGetir2.Rows[0]["MyName"].ToString() == Session["KAd"].ToString())
                        {

                            lblMesaj.Text = SonMesajGetir2.Rows[0]["MyName"].ToString() + ":" + SonMesajGetir2.Rows[0]["Mesaj"].ToString();
                        }
                        else if (SonMesajGetir2.Rows[0]["FriendName"].ToString() == Session["KAd"].ToString())
                        {
                            lblMesaj.Text = SonMesajGetir2.Rows[0]["MyName"].ToString() + ":" + SonMesajGetir2.Rows[0]["Mesaj"].ToString();
                        }
                        lblMesaj.CssClass = "lblMesaj";

                        Panel pnlButton = new Panel();
                        pnlButton.CssClass = "pnlButton";
                        Button btnMesajGoster = new Button();
                        btnMesajGoster.CssClass = "btnMesajGoster";
                        if (SonMesajGetir2.Rows[0]["MyName"].ToString() == Session["KAd"].ToString())
                        {
                            btnMesajGoster.ID = SonMesajGetir2.Rows[0]["FriendName"].ToString(); 
                        }
                        else if (SonMesajGetir2.Rows[0]["FriendName"].ToString() == Session["KAd"].ToString())
                        {
                            btnMesajGoster.ID = SonMesajGetir2.Rows[0]["MyName"].ToString();
                        }

                      
                        btnMesajGoster.Click += new EventHandler(ArkadasMesajGoster);


                        btnMesajGoster.Text = "Sohbeti Göster";
                        Button btnMesajTemizle = new Button();
                        btnMesajTemizle.CssClass = "btnMesajTemizle";
                        btnMesajTemizle.Text = "Sohbeti temizle";
                        pnlButton.Controls.Add(btnMesajGoster);
                        pnlButton.Controls.Add(btnMesajTemizle);


                        pnlAlt.Controls.Add(lblMesaj);

                        pnlOzelMesaj.Controls.Add(pnlUst);
                        pnlOzelMesaj.Controls.Add(pnlAlt);
                        pnlOzelMesaj.Controls.Add(pnlButton);

                        divOzelMesaj.Controls.Add(pnlOzelMesaj);
                        if ((divOzelMesaj.Controls.Count +i) % 2 == 0)
                        {
                            if (divOzelMesaj.Controls.Count <= i)
                            {

                                divOzelMesaj.Controls.RemoveAt(i-2-sayac2);
                                sayac2++;

                            }
                            else { 
                            divOzelMesaj.Controls.RemoveAt(i);
                            }
                        }
                        else if((divOzelMesaj.Controls.Count + i) % 2 == 1)
                        {
                            if (divOzelMesaj.Controls.Count <= i)
                            {
                                divOzelMesaj.Controls.RemoveAt(i - 2-sayac2);
                            }
                            else
                            {
                                divOzelMesaj.Controls.RemoveAt(i);
                            }
                        }

                    }
                    else if (i%2==0) {
                        DataTable SonMesajGetir2 = db.SonOzelMesajGetir("select * from tbl_OzelMesajlar O, tbl_Arkadaslar A where O.ArkadasNo = A.Id and ((MyName = '" + Session["KAd"].ToString() + "') or(FriendName = '" + Session["KAd"].ToString() + "')) and ArkadasNo in (" + Arkadas3 + ", " + Arkadas4 + ") and Durum = 'A' order by O.Id desc ");
                        Panel pnlOzelMesaj = new Panel();
                        pnlOzelMesaj.CssClass = "pnlOzelMesaj";

                        Panel pnlUst = new Panel();
                        pnlUst.CssClass = "pnlUst";
                        Label lblName = new Label();

                        if (SonMesajGetir2.Rows[0]["MyName"].ToString() == Session["KAd"].ToString())
                        {
                            lblName.Text = SonMesajGetir2.Rows[0]["FriendName"].ToString();
                        }
                        else if (SonMesajGetir2.Rows[0]["FriendName"].ToString() == Session["KAd"].ToString())
                        {
                            lblName.Text = SonMesajGetir2.Rows[0]["MyName"].ToString();
                        }


                        lblName.CssClass = "lblName";
                        Label lblTarih = new Label();
                        lblTarih.Text = SonMesajGetir2.Rows[0]["Tarih"].ToString();
                        lblTarih.CssClass = "lblTarih";
                        pnlUst.Controls.Add(lblName);
                        pnlUst.Controls.Add(lblTarih);


                        Panel pnlAlt = new Panel();
                        pnlAlt.CssClass = "pnlAlt";
                        Label lblMesaj = new Label();

                        if (SonMesajGetir2.Rows[0]["MyName"].ToString() == Session["KAd"].ToString())
                        {

                            lblMesaj.Text = SonMesajGetir2.Rows[0]["MyName"].ToString() + ":" + SonMesajGetir2.Rows[0]["Mesaj"].ToString();
                        }
                        else if (SonMesajGetir2.Rows[0]["FriendName"].ToString() == Session["KAd"].ToString())
                        {
                            lblMesaj.Text = SonMesajGetir2.Rows[0]["MyName"].ToString() + ":" + SonMesajGetir2.Rows[0]["Mesaj"].ToString();
                        }
                        lblMesaj.CssClass = "lblMesaj";

                        Panel pnlButton = new Panel();
                        pnlButton.CssClass = "pnlButton";
                        Button btnMesajGoster = new Button();
                        btnMesajGoster.CssClass = "btnMesajGoster";
                        if (SonMesajGetir2.Rows[0]["MyName"].ToString() == Session["KAd"].ToString())
                        {
                            btnMesajGoster.ID = SonMesajGetir2.Rows[0]["FriendName"].ToString();
                        }
                        else if (SonMesajGetir2.Rows[0]["FriendName"].ToString() == Session["KAd"].ToString())
                        {
                            btnMesajGoster.ID = SonMesajGetir2.Rows[0]["MyName"].ToString();
                        }


                        btnMesajGoster.Click += new EventHandler(ArkadasMesajGoster);


                        btnMesajGoster.Text = "Sohbeti Göster";
                        Button btnMesajTemizle = new Button();
                        btnMesajTemizle.CssClass = "btnMesajTemizle";
                        btnMesajTemizle.Text = "Sohbeti temizle";
                        pnlButton.Controls.Add(btnMesajGoster);
                        pnlButton.Controls.Add(btnMesajTemizle);


                        pnlAlt.Controls.Add(lblMesaj);

                        pnlOzelMesaj.Controls.Add(pnlUst);
                        pnlOzelMesaj.Controls.Add(pnlAlt);
                        pnlOzelMesaj.Controls.Add(pnlButton);

                        divOzelMesaj.Controls.Add(pnlOzelMesaj);

                    }
                 

                   
                }
            
            
            }


        }
        protected void btnCikis_Click(object sender, EventArgs e)
        {
            Session.Remove("KAd");
            Response.Redirect("Login.aspx");

        }
        protected void ArkadasMesajGoster(object sender, EventArgs e)
        {
            Session.Remove("ArkadasAdi");
            Button clickedButton = (Button)sender;
            Session.Add("ArkadasAdi", clickedButton.ID.Trim());
            Response.Redirect("OzelMesajlarr.aspx");

        }
    }
}