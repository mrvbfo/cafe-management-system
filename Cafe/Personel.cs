using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Cafe
{
    internal class Personel
    {

        Genel gnl = new Genel();

        private int PersonelID;
        private int GorevID;
        private string PersonelName;
        private string PersonelSurname;
        private string Password;
        private string PersonelUsername;
        private bool PersonelState;

        public int PersonelID1 { get => PersonelID; set => PersonelID = value; }
        public int GorevID1 { get => GorevID; set => GorevID = value; }
        public string PersonelName1 { get => PersonelName; set => PersonelName = value; }
        public string PersonelSurname1 { get => PersonelSurname; set => PersonelSurname = value; }
        public string Password1 { get => Password; set => Password = value; }
        public string PersonelUsername1 { get => PersonelUsername; set => PersonelUsername = value; }
        public bool PersonelState1 { get => PersonelState; set => PersonelState = value; }

        public bool GirisKontrolu(string password, string UserName)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Personel where KULLANICIADI=@KULLANICIADI and PAROLA=@PAROLA", con);
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

        public void PersonelBilgileri(ComboBox cb)
        {
            cb.Items.Clear();
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select * from Personel", con);



            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlDataReader dt = cmd.ExecuteReader();

            while(dt.Read())
            {
                Personel p = new Personel();
                p.PersonelID = Convert.ToInt32(dt["ID"]);
                p.GorevID = Convert.ToInt32(dt["GOREVID"]);
                p.PersonelName = Convert.ToString(dt["AD"]);
                p.PersonelSurname = Convert.ToString(dt["SOYAD"]);
                p.Password = Convert.ToString(dt["Parola"]);
                p.PersonelUsername = Convert.ToString(dt["KULLANICIADI"]);
                p.PersonelState = Convert.ToBoolean(dt["DURUM"]);
                cb.Items.Add(p);

            }
            dt.Close();
            con.Close();


        }
        
        public override string ToString()
        {
            return PersonelName1 + " " + PersonelSurname1;
        } 

        public bool PersonelEkle(Personel cp)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Insert Into Personel (AD, SOYAD, KULLANICIADI, PAROLA, GOREVID) values (@AD, @SOYAD, @KULLANICIADI, @PAROLA, @GOREVID)", con);
            cmd.Parameters.Add("AD", SqlDbType.VarChar).Value = PersonelName;
            cmd.Parameters.Add("SOYAD", SqlDbType.VarChar).Value = PersonelSurname;
            cmd.Parameters.Add("KULLANICIADI", SqlDbType.VarChar).Value = PersonelUsername;
            cmd.Parameters.Add("PAROLA", SqlDbType.VarChar).Value = Password;
            cmd.Parameters.Add("GOREVID", SqlDbType.Int).Value = GorevID;

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

        public bool PersonelGuncelle(Personel cp, int ID)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Personel set AD=@AD, SOYAD=@SOYAD, KULLANICIADI=@KULLANICIADI, PAROLA=@PAROLA, GOREVID=@GOREVID where ID=@ID", con);
            cmd.Parameters.Add("ID", SqlDbType.Int).Value = PersonelID;
            cmd.Parameters.Add("AD", SqlDbType.VarChar).Value = PersonelName;
            cmd.Parameters.Add("SOYAD", SqlDbType.VarChar).Value = PersonelSurname;
            cmd.Parameters.Add("KULLANICIADI", SqlDbType.VarChar).Value = PersonelUsername;
            cmd.Parameters.Add("PAROLA", SqlDbType.Int).Value = Password;
            cmd.Parameters.Add("GOREVID", SqlDbType.Int).Value = GorevID;

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

        public bool PersonelSil(int ID)
        {
            bool sonuc = false;
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Update Personel set DURUM=1 where ID=@ID", con);
            cmd.Parameters.Add("ID", SqlDbType.Int).Value = ID;

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

        public void PersonelListele(ListView lv)
        {
            lv.Items.Clear();
            Genel gnl = new Genel();

            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select* from Personel where DURUM = 0", con);

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
                    lv.Items[sayac].SubItems.Add(dr["GOREVID"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["AD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["SOYAD"].ToString());
                    lv.Items[sayac].SubItems.Add(dr["KULLANICIADI"].ToString());
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

