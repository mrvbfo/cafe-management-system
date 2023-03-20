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
    internal class Urunler
    {
        Genel gnl = new Genel();

        private int UrunId;
        private int KategoriId;
        private string UrunAd;
        private decimal Fiyat;
        private string Aciklama;

        public int UrunId1 { get => UrunId; set => UrunId = value; }
        public int KategoriId1 { get => KategoriId; set => KategoriId = value; }
        public string UrunAd1 { get => UrunAd; set => UrunAd = value; }
        public decimal Fiyat1 { get => Fiyat; set => Fiyat = value; }
        public string Aciklama1 { get => Aciklama; set => Aciklama = value; }

        public int UrunEkle(Urunler urun)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Urunler(URUNAD, KATEGORIID, FIYAT) values (@URUNAD, @KATEGORIID, @FIYAT)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@URUNAD", SqlDbType.VarChar).Value = urun.UrunAd;
                cmd.Parameters.Add("@KATEGORIID", SqlDbType.Int).Value = urun.KategoriId;
                cmd.Parameters.Add("@FIYAT", SqlDbType.Money).Value = urun.Fiyat;
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {

                con.Dispose();
                con.Close();
            }

            return sonuc;
        }
        public void UrunleriListele(ListView lv)
        {
            lv.Items.Clear();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select Urunler.*, KATEGORIADI from Urunler Inner Join Kategori on Kategori.ID=Urunler.KATEGORIID where Urunler.DURUM=0", con);

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
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KATEGORIADI"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(Convert.ToString(Convert.ToDecimal(dr["FIYAT"])));
                    

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
        public int UrunGuncelle(Urunler urun)
        {
            int sonuc = 0;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Urunler set URUNAD=@URUNAD, KATEGORIID=@KATEGORIID, FIYAT=@FIYAT where ID=@URUNID", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@URUNAD", SqlDbType.VarChar).Value = urun.UrunAd;
                cmd.Parameters.Add("@KATEGORIID", SqlDbType.Int).Value = urun.KategoriId;
                cmd.Parameters.Add("@FIYAT", SqlDbType.Money).Value = urun.Fiyat;
                cmd.Parameters.Add("@URUNID", SqlDbType.Int).Value = urun.UrunId;

                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            {
                con.Dispose();
                con.Close();
            }
            return sonuc;
        }
        public int UrunSil(Urunler urun)
        {
            int sonuc = 0;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Urunler set DURUM=1 where ID=@ID", con);
            cmd.Parameters.Add("ID", SqlDbType.Int).Value = UrunId;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                sonuc = Convert.ToInt32(cmd.ExecuteNonQuery());
            }
            catch (Exception)
            {
                throw;
            }

            con.Close();

            return sonuc;
        }
    }
}
