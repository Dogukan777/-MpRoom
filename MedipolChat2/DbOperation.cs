using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MedipolChat2
{
    public class DbOperation
    {
        private string yol;
        public SqlConnection baglanti; // Bağlantı
        public DataTable tablo; // Tablo 
        public SqlDataAdapter adaptor; // 
        public SqlDataReader okuyucu;
        public SqlCommand komut;
        public DbOperation()
        {
            yol = "workstation id=MedipolRoom.mssql.somee.com;packet size=4096;user id=snndgkn00;pwd=mproom123;data source=MedipolRoom.mssql.somee.com;persist security info=False;initial catalog=MedipolRoom";


        }
        public void VeritabaninaBaglan()
        {
            baglanti = new SqlConnection(yol);
            if (baglanti.State == ConnectionState.Closed)
            {
                Console.WriteLine("Veritabanı kapalıydı tekrar bağlandı.");
                baglanti.Open();

            }
            if (baglanti.State == ConnectionState.Open)
            {
                Console.WriteLine("Veritabanina Bağlı");
            }
        }

        public void KullaniciEkle(String Adi, String Soyadi, String KAdi, String Sifre, String Eposta, char Yetki)
        {
            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand("usp_KayitEkle", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@Adi", Adi);
            komut.Parameters.AddWithValue("@Soyadi ", Soyadi);
            komut.Parameters.AddWithValue("@KAdi", KAdi);
            komut.Parameters.AddWithValue("@Sifre", Sifre);
            komut.Parameters.AddWithValue("@EPosta", Eposta);
            komut.Parameters.AddWithValue("@Yetki", Yetki);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();

        }
        public DataTable UyeVarmi(string sorgu)
        {

            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;


        }
        public DataTable AdminMi(string sorgu)
        {

            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;


        }
        public DataTable HesapBilgileriGetir(string sorgu)
        {

            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;


        }
        public void hesapGuncelle(string KAdi,string Sifre,string EPosta)
        {
          
            VeritabaninaBaglan();
            
          
            komut = new System.Data.SqlClient.SqlCommand("usp_HesapGuncelle", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@KAdi", KAdi);
           
            komut.Parameters.AddWithValue("@Sifre", Sifre);
            komut.Parameters.AddWithValue("@EPosta", EPosta);
         
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
        }
        public void sifreAktivasyonu(string sorgu)
        {
            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();

        }
     
        public void hesapSil(string KAdi)
        {
            VeritabaninaBaglan();


            komut = new System.Data.SqlClient.SqlCommand("usp_HesapSil", baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@KAdi", KAdi);


            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
        }
        public void odaMesajEkle(string sorgu)
        {
            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();

        }
        public DataTable OdaMesajGetir(string sorgu)
        {

            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;


        }
        public void OdaIstekEkle(string sorgu)
        {
            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();

        }

        public DataTable OdaIstekGetir(string sorgu)
        {

            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;


        }
        public DataTable OdaAdiGetir(string sorgu)
        {

            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;


        }
        public void OdaIstekKabulEt(string sorgu)
        {
            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();

        }
        public void OdaIstekSil(string sorgu)
        {
            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();

        }
        public void ArkadasIstegiGonder(string sorgu)
        {
            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();

        }
        public DataTable ArkadasIstekListesi(string sorgu)
        {

            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;


        }
        public void ArkadasIstekKabul(string sorgu)
        {
            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();

        }
        public void ArkadasIstekSil(string sorgu)
        {
            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();

        }
        public DataTable ArkadasIstekVarmi(string sorgu)
        {

            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;


        }
        public DataTable ArkadasMi(string sorgu)
        {

            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;


        }
      
        public DataTable ArkadasListesi(string sorgu)
        {

            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;


        }
        public DataTable AdminUyeListesiGetir(string sorgu)
        {

            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;


        }
        public DataTable AdminUyeSayisiGetir(string sorgu)
        {

            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;
        }


            public DataTable AdminUyeDetayGetir(string sorgu)
            {

                VeritabaninaBaglan();
                komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
                komut.ExecuteNonQuery();
                tablo = new DataTable();
                adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
                adaptor.Fill(tablo);
                baglanti.Close();
                return tablo;


            }
            public void AdminUyeBanla(string sorgu)
            {

            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();


        }
        public DataTable AdminBanlananlarGetir(string sorgu)
        {

            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;


        }
        public DataTable AdminBanSayisiGetir(string sorgu)
        {

            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;
        }
        public void AdminBanKaldir(string sorgu)
        {

            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();


        }
        public DataTable UyeBanMi(string sorgu)
        {

            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;
        }
        public DataTable AdminOdaListesi(string sorgu)
        {

            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;
        }
        public void AdminOdaSil(string sorgu)
        {

            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();


        }
        public DataTable AdminOdaSayisiGetir(string sorgu)
        {


            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;


        }
        public void ArkadasSil(string sorgu)
        {
            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();

        }
        public void ArkadasEngelle(string sorgu)
        {
            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();

        }
        public DataTable ArkadasEngelMi(string sorgu)
        {


            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;


        }
        public DataTable EngellenenlenListesi(string sorgu)
        {


            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;


        }
        public void EngelKaldir(string sorgu)
        {
            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();

        }
        public DataTable KullaniciVarmi(string sorgu)
        {


            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;


        }
        public void OzelMesajEkle(string sorgu)
        {
            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();

        }
        public DataTable OzelMesajGetir(string sorgu)
        {

            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;


        }
        public DataTable SonOzelMesajGetir(string sorgu)
        {


            VeritabaninaBaglan();
            komut = new System.Data.SqlClient.SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            tablo = new DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            return tablo;


        }
    }
}