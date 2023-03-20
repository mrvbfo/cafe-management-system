using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;

namespace Cafe
{
    internal class Masa
    {
        private int ID;
        private int Kapasite;
        private int ServisTuru;
        private int Durum;
        private int Onay;
        public object masa_id { get; set; }
        public int ID1 { get => ID; set => ID = value; }
        public int Kapasite1 { get => Kapasite; set => Kapasite = value; }
        public int ServisTuru1 { get => ServisTuru; set => ServisTuru = value; }
        public int Durum1 { get => Durum; set => Durum = value; }
        public int Onay1 { get => Onay; set => Onay = value; }

        Genel gnl = new Genel();
        

        public int MasaNoBul(string TableValue)
        {
            string aa = TableValue;
            int length = aa.Length;
            return Convert.ToInt32(aa.Substring(length - 1, 1));

        }
    
        public bool MasaDurumu(int ButtonName, int state)
        { 
            bool result = false;
            SqlConnection con =new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select DURUM From Masa Where ID=@TableId and DURUM=@state", con);
            cmd.Parameters.Add("@TableId", SqlDbType.Int).Value = ButtonName;
            cmd.Parameters.Add("@state", SqlDbType.Int).Value = state;
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                result = Convert.ToBoolean(cmd.ExecuteScalar());
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
            return result;
        }

        public void MasaDurumuDegistir(string ButonName, int durum)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Masa Set DURUM=@DURUM Where ID=@MASAID", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //Sondaki rakami bulmak icin
            string btn = ButonName;
            int uzunluk = btn.Length;

            cmd.Parameters.Add("@durum", SqlDbType.Int).Value = durum;
            if (uzunluk > 8)
            {
               masa_id = btn.Substring(uzunluk - 2, 2);
            }
            else
            {
                masa_id = btn.Substring(uzunluk - 1, 1);
            }

            cmd.Parameters.Add("@MASAID", SqlDbType.Int).Value = masa_id;
            cmd.ExecuteNonQuery();
            con.Dispose();
            con.Close();


        }
    }
}

