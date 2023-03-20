using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe
{
    internal class Musteri
    {
        Genel gnl = new Genel();

        private int MusteriId;
        private string MusteriAd;
        private string MusteriSoyad;
        private string Telefon;
        private string Adres;

        public int MusteriId1 { get => MusteriId; set => MusteriId = value; }
        public string MusteriAd1 { get => MusteriAd; set => MusteriAd = value; }
        public string MusteriSoyad1 { get => MusteriSoyad; set => MusteriSoyad = value; }
        public string Telefon1 { get => Telefon; set => Telefon = value; }
        public string Adres1 { get => Adres; set => Adres = value; }

        public bool MusteriEkle(Musteri m)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Musteriler (AD, SOYAD, ADRES, TELEFON) values (@AD, @SOYAD, @ADRES, @TELEFON)", con);
            cmd.Parameters.Add("AD", SqlDbType.VarChar).Value = MusteriAd;
            cmd.Parameters.Add("SOYAD", SqlDbType.VarChar).Value = MusteriSoyad;
            cmd.Parameters.Add("TELEFON", SqlDbType.VarChar).Value = Telefon;
            cmd.Parameters.Add("ADRES", SqlDbType.VarChar).Value = Adres;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                throw;
            }

            con.Close();

            return sonuc;
        }
        public bool MusteriGuncelle(Musteri m)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Musteriler set AD=@AD, SOYAD=@SOYAD, ADRES=@ADRES, TELEFON=@TELEFON where ID=@ID", con);
            cmd.Parameters.Add("ID", SqlDbType.Int).Value = MusteriId;
            cmd.Parameters.Add("AD", SqlDbType.VarChar).Value = MusteriAd;
            cmd.Parameters.Add("SOYAD", SqlDbType.VarChar).Value = MusteriSoyad;
            cmd.Parameters.Add("ADRES", SqlDbType.VarChar).Value = Adres;
            cmd.Parameters.Add("TELEFON", SqlDbType.VarChar).Value = Telefon;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                throw;
            }

            con.Close();

            return sonuc;
        }

        public void MusteriListele(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString); 
            SqlCommand cmd = new SqlCommand("Select* from Musteriler where durum = 0", con);

            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();

                int sayac = 0;
                while (dr.Read())
                {
                    lv.Items.Add(dr["ID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADRES"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["TELEFON"].ToString());

                    sayac++;
                }

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                dr.Close();
                con.Dispose();
                con.Close();

            }
        }
    }
}
