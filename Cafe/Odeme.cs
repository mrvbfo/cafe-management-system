using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    internal class Odeme
    {
        Genel gnl = new Genel();
     
        private int OdemeId;
        private int AdisyonId;
        private decimal ToplamTutar;
        private DateTime Tarih;
        private int MusteriId;
        private int KasiyerId;

        public int OdemeId1 { get => OdemeId; set => OdemeId = value; }
        public int AdisyonId1 { get => AdisyonId; set => AdisyonId = value; }
        public decimal ToplamTutar1 { get => ToplamTutar; set => ToplamTutar = value; }
        public DateTime Tarih1 { get => Tarih; set => Tarih = value; }
        public int MusteriId1 { get => MusteriId; set => MusteriId = value; }
        public int KasiyerId1 { get => KasiyerId; set => KasiyerId = value; }

        public bool HesapKapat(Odeme hesap)
        {
            Genel gnl = new Genel();

            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into HesapOdeme (ADISYONID, MUSTERIID, TOPLAMTUTAR, KASIYERID) values (@ADISYONID, @MUSTERIID, @TOPLAMTUTAR, @KASIYERID)", con);

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("ADISYONID", SqlDbType.Int).Value = hesap.AdisyonId1;
                cmd.Parameters.Add("MUSTERIID", SqlDbType.Int).Value = hesap.MusteriId1;
                cmd.Parameters.Add("TOPLAMTUTAR", SqlDbType.Money).Value = hesap.ToplamTutar1;
                cmd.Parameters.Add("KASIYERID", SqlDbType.Int).Value = hesap.KasiyerId1;

                result = Convert.ToBoolean(cmd.ExecuteNonQuery());
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
            return result;

        }
        
    }
}
