using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Input;

namespace Cafe
{
    internal class UrunCesitleri
    {
        Genel gnl = new Genel();
        private int UrunTurNo;
        private string KategoriAd;

        public int UrunTurNo1 { get => UrunTurNo; set => UrunTurNo = value; }
        public string KategoriAd1 { get => KategoriAd; set => KategoriAd = value; }
        public void UrunTipi(ListView Cesitler, Button btn)
        {
            Cesitler.Items.Clear();
            SqlConnection conn = new SqlConnection(gnl.conString);
            SqlCommand comm = new SqlCommand("Select URUNAD,FIYAT,Urunler.ID From Kategori Inner Join Urunler on Kategori.ID=Urunler.KATEGORIID where Urunler.KATEGORIID = @KATEGORIID and Urunler.DURUM=0", conn);

            string aa = btn.Name;
            int uzunluk = aa.Length;

            comm.Parameters.Add("@KATEGORIID", SqlDbType.Int).Value = aa.Substring(uzunluk - 1, 1);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlDataReader dr = comm.ExecuteReader();
            int i = 0;
            while(dr.Read())
            {
                Cesitler.Items.Add(dr["URUNAD"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["FIYAT"].ToString());
                Cesitler.Items[i].SubItems.Add(dr["ID"].ToString());
                i++;
            }
            dr.Close();
            conn.Dispose();
            conn.Close();
        }

    }
}
    
