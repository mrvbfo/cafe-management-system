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
    internal class Yonetici
    {
        Genel gnl = new Genel();
        public void YoneticiListele(ListView lv)
        {
            lv.Items.Clear();
            

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select* from Personel where GOREVID = 4 and DURUM=0", con);

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
        public bool YoneticiGirisi(string password, string UserName)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Personel where KULLANICIADI=@KULLANICIADI and PAROLA=@PAROLA and GOREVID=4", con);
            cmd.Parameters.AddWithValue("@KULLANICIADI", UserName);
            cmd.Parameters.AddWithValue("@PAROLA", password);

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
                throw;
            }

            return result;
        }
    }
}
