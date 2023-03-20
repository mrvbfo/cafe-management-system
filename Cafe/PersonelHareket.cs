using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Cafe
{
    internal class PersonelHareket
    {
        Genel gnl = new Genel();
        private int ID;
        private int PersonelID;
        private string Islem;
        private DateTime Tarih;
        private bool Durum;

        public int ID1 { get => ID; set => ID = value; }
        public int PersonelID1 { get => PersonelID; set => PersonelID = value; }
        public string Islem1 { get => Islem; set => Islem = value; }
        public DateTime Tarih1 { get => Tarih; set => Tarih = value; }
        public bool Durum1 { get => Durum; set => Durum = value; }
  
        public bool GirisKayidi(PersonelHareket ph)
        {
            bool result = false;

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into PersonelHareket(PERSONELID,ISLEM,TARIH)Values(@PERSONELID,@ISLEM,@TARIH)", con);

            try
            {
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.Add("@PERSONELID", SqlDbType.Int).Value = ph.PersonelID;
                cmd.Parameters.Add("@ISLEM", SqlDbType.VarChar).Value = ph.Islem;
                cmd.Parameters.Add("@TARIH", SqlDbType.DateTime).Value = ph.Tarih;
           
                result= Convert.ToBoolean(cmd.ExecuteNonQuery());
            }

            catch (SqlException ex)
            {
                string hata= ex.Message;
                throw;
            }

            return result;
        }
    
    
    }
}
