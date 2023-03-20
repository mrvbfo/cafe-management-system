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
    internal class Gorev
    {
        Genel gnl = new Genel();
        private int PersonelGorevId;
        private string Tanim;

        public int PersonelGorevId1 { get => PersonelGorevId; set => PersonelGorevId = value; }
        public string Tanim1 { get => Tanim; set => Tanim = value; }

        public void GorevYazdir(ComboBox cb)
        {
            cb.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Gorev", con);
            SqlDataReader dr = null;

            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Gorev c = new Gorev();
                    c.PersonelGorevId = Convert.ToInt32(dr["ID"].ToString());
                    c.Tanim = dr["GOREV"].ToString();
                    cb.Items.Add(c);
                }
            }
            catch (SqlException ex)
            {
                string hata = ex.Message;
                throw;
            }
            dr.Close();
            con.Close();

        }
        public void GorevListele(ListView lv)
        {
            lv.Items.Clear();
            Genel gnl = new Genel();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select* from Gorev where DURUM = 0", con);

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
                    lv.Items[sayac].SubItems.Add(dr["GOREV"].ToString());
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
        public override string ToString()
        {
            return Tanim;
        } 
    }
}
