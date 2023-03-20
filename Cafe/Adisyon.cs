using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace Cafe
{
    internal class Adisyon
    {
        Genel gnl = new Genel();
        private int ID;
        private int ServisTurNo;
        private decimal Tutar;
        private DateTime Tarih;
        private int GarsonId;
        private int Durum;
        private int MasaId;

        public int ID1 { get => ID; set => ID = value; }
        public int ServisTurNo1 { get => ServisTurNo; set => ServisTurNo = value; }
        public decimal Tutar1 { get => Tutar; set => Tutar = value; }
        public DateTime Tarih1 { get => Tarih; set => Tarih = value; }
        public int GarsonId1 { get => GarsonId; set => GarsonId = value; }
        public int Durum1 { get => Durum; set => Durum = value; }
        public int MasaId1 { get => MasaId; set => MasaId = value; }

        public int AdisyonBul(int MasaId) {

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select top 1 ID From Adisyon Where MASAID=@MasaId Order by ID desc", con);
            cmd.Parameters.Add("@MasaId", SqlDbType.Int).Value = MasaId;
            try
            {
                if (con.State == ConnectionState.Closed)
                { con.Open(); }

                MasaId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
            }
            finally
            { con.Close(); }

            return MasaId;
        }

        public bool AdisyonAc(Adisyon Bilgiler)
        {
            bool sonuc = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Adisyon(SERVISTURNO,GARSONID,MASAID,TARIH,DURUM) values(@SERVISTURNO, @GARSONID, @MASAID, @TARIH, @DURUM)", con);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@SERVISTURNO", SqlDbType.Int).Value = Bilgiler.ServisTurNo;
                cmd.Parameters.Add("@GARSONID", SqlDbType.Int).Value = Bilgiler.GarsonId;
                cmd.Parameters.Add("@MASAID", SqlDbType.Int).Value = Bilgiler.MasaId;
                cmd.Parameters.Add("@TARIH", SqlDbType.DateTime).Value = Bilgiler.Tarih;
                cmd.Parameters.Add("@DURUM", SqlDbType.Bit).Value = 0;
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

        public void AdisyonKapat(int AdisyonId, int durum)
        {
            Genel gnl = new Genel();


            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Adisyon set DURUM=@DURUM where ID=@ADISYONID", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                cmd.Parameters.Add("ADISYONID", SqlDbType.Int).Value = AdisyonId;
                cmd.Parameters.Add("DURUM", SqlDbType.Int).Value = durum;
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            finally
            {
                con.Dispose();
                con.Close();

            }

        }
    }    
}
