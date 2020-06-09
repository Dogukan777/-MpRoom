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
    public partial class Anasayfa : System.Web.UI.Page
    {
        public DataTable OdalarSifresiSonuc = null;
        public static int OdaId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["KAd"]==null )
            {
                
                Response.Redirect("Login.aspx");

            }
            else {
                if (!Page.IsPostBack) { 
            OdaId =  Convert.ToInt32(Request.QueryString["OdaId"]) ;
                

                if (OdaId != 0)
                {
                    DbOperation db2 = new DbOperation();
                    OdalarSifresiSonuc = db2.OdaIstekGetir("select OdaSifresi from tbl_odalar where OdaDurumu='A' and OdaId='" + OdaId+"' ");
                    if (OdalarSifresiSonuc.Rows[0]["OdaSifresi"].ToString()=="")
                    {
                        Response.Redirect("Odalarr.aspx?OdaId=" + OdaId);
                    }
                    else
                    {
                        OdaSifre.Style.Add("display", "inline");
                        


                    }
                }
                }


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
        protected void btnOdaGenel_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("OdaGenel.aspx");

        }

        protected void btnOdaSifreOnayla_Click(object sender, EventArgs e)
        {
           
            DbOperation db3 = new DbOperation();
            DataTable SifreUyusmasi = db3.OdaIstekGetir("select OdaSifresi from tbl_odalar where OdaDurumu='A' and OdaId=" + OdaId + " ");
            if(txtOdaSifre.Text== SifreUyusmasi.Rows[0]["OdaSifresi"].ToString() )
            {
                Response.Redirect("Odalarr.aspx?OdaId=" + OdaId);
            }
            else
            {
                lblSifreUyari.Text = "ŞİFRE YANLIŞ !";
            }
        }
        protected void btnOdaSifreVazgec_Click(object sender, EventArgs e)
        {
            Response.Redirect("Anasayfa.aspx");

        }
    }
    }
