using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Cafe
{
    internal class UrunSiparis
    {
        Genel gnl = new Genel();
        private int Id;
        private int AdisyonId;
        private int UrunId;
        private int Adet;
        private int MasaId;
        private int GarsonId;
        private DateTime Tarih;

        public int Id1 { get => Id; set => Id = value; }
        public int AdisyonId1 { get => AdisyonId; set => AdisyonId = value; }
        public int UrunId1 { get => UrunId; set => UrunId = value; }
        public int Adet1 { get => Adet; set => Adet = value; }
        public int MasaId1 { get => MasaId; set => MasaId = value; }
        public int GarsonId1 { get => GarsonId; set => GarsonId = value; }
        public DateTime Tarih1 { get => Tarih; set => Tarih = value; }

        public void SiparisListele(ListView lv, int AdisyonId)
        {

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("select URUNAD,FIYAT,Satislar.ID,Satislar.URUNID,Satislar.ADET from Satislar Inner Join Urunler on Satislar.URUNID=Urunler.ID Where ADISYONID = @AdisyonId", con);
            SqlDataReader dr = null;
            cmd.Parameters.Add("@AdisyonId", SqlDbType.Int).Value = AdisyonId;

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
                    lv.Items.Add(dr["URUNAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["ADET"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["URUNID"].ToString());
                    lv.Items[sayac].SubItems.Add(Convert.ToString(Convert.ToDecimal(dr["FIYAT"]) * Convert.ToDecimal(dr["ADET"])));
                    lv.Items[sayac].SubItems.Add(dr["ID"].ToString());

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
        
        public bool SiparisAl(UrunSiparis Bilgiler)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Satislar (ADISYONID,URUNID,ADET,MASAID,GARSONID,TARIH) values (@ADISYONID,@URUNID,@ADET,@MASAID,@GARSONID,@TARIH)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@ADISYONID", SqlDbType.Int).Value = Bilgiler.AdisyonId;
                cmd.Parameters.Add("@URUNID", SqlDbType.Int).Value = Bilgiler.UrunId;
                cmd.Parameters.Add("@ADET", SqlDbType.Int).Value = Bilgiler.Adet;
                cmd.Parameters.Add("@MASAID", SqlDbType.Int).Value = Bilgiler.MasaId;
                cmd.Parameters.Add("@GARSONID", SqlDbType.Int).Value = Bilgiler.GarsonId;
                cmd.Parameters.Add("@TARIH", SqlDbType.DateTime).Value = Bilgiler.Tarih;
                sonuc = Convert.ToBoolean(cmd.ExecuteNonQuery());



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
        public void SiparisKaldir(int satisid)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Delete From satislar Where ID=@satisid)", con);

            cmd.Parameters.Add("@satisid", SqlDbType.Int).Value = satisid;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();

        }
    }
}
