using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe
{
    public partial class MasaFormu : Form
    {
        public MasaFormu()
        {
            InitializeComponent();
        }

        Genel gnl = new Genel();
        private void MasaFormu_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(gnl.conString);
            SqlCommand cmd = new SqlCommand("Select DURUM,ID from Masa", con);
            SqlDataReader dr = null;

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                foreach(Control item in this.Controls)
                {
                    if(item is Button)
                    {
                        if(item.Name=="btnMasa" + dr["ID"].ToString() &&dr["DURUM"].ToString()=="1")
                        {
                            item.ForeColor = Color.Green;
                        }
                        else if(item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "2")
                        {
                            item.ForeColor = Color.Red;
                        }
                        else if (item.Name == "btnMasa" + dr["ID"].ToString() && dr["DURUM"].ToString() == "3")
                        {
                            item.ForeColor = Color.Blue;
                        }
                    }
                }
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cikmak istediginize emin misiniz?", "Sistem Uyarisi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            MenuFormu fr= new MenuFormu();
            this.Close();
            fr.Show();
        }

        private void btnMasa1_Click(object sender, EventArgs e)
        {
            SiparisFormu frm = new SiparisFormu();
            int uzunluk = btnMasa1.Text.Length;

            Genel.ButtonValue = btnMasa1.Text.Substring(uzunluk-6,6);
            Genel.ButtonName = btnMasa1.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa2_Click(object sender, EventArgs e)
        {
            SiparisFormu frm = new SiparisFormu();
            int uzunluk = btnMasa2.Text.Length;

            Genel.ButtonValue = btnMasa2.Text.Substring(uzunluk - 6, 6);
            Genel.ButtonName = btnMasa2.Name;
            this.Close();
            frm.ShowDialog();

        }

        private void btnMasa3_Click(object sender, EventArgs e)
        {
            SiparisFormu frm = new SiparisFormu();
            int uzunluk = btnMasa3.Text.Length;

            Genel.ButtonValue = btnMasa3.Text.Substring(uzunluk - 6, 6);
            Genel.ButtonName = btnMasa3.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa4_Click(object sender, EventArgs e)
        {
            SiparisFormu frm = new SiparisFormu();
            int uzunluk = btnMasa4.Text.Length;

            Genel.ButtonValue = btnMasa4.Text.Substring(uzunluk - 6, 6);
            Genel.ButtonName = btnMasa4.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa5_Click(object sender, EventArgs e)
        {
            SiparisFormu frm = new SiparisFormu();
            int uzunluk = btnMasa5.Text.Length;

            Genel.ButtonValue = btnMasa5.Text.Substring(uzunluk - 6, 6);
            Genel.ButtonName = btnMasa5.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa6_Click(object sender, EventArgs e)
        {
            SiparisFormu frm = new SiparisFormu();
            int uzunluk = btnMasa6.Text.Length;

            Genel.ButtonValue = btnMasa6.Text.Substring(uzunluk - 6, 6);
            Genel.ButtonName = btnMasa6.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa7_Click(object sender, EventArgs e)
        {
            SiparisFormu frm = new SiparisFormu();
            int uzunluk = btnMasa7.Text.Length;

            Genel.ButtonValue = btnMasa7.Text.Substring(uzunluk - 6, 6);
            Genel.ButtonName = btnMasa7.Name;
            this.Close();
            frm.ShowDialog();
        }

        private void btnMasa8_Click(object sender, EventArgs e)
        {
            SiparisFormu frm = new SiparisFormu();
            int uzunluk = btnMasa8.Text.Length;

            Genel.ButtonValue = btnMasa8.Text.Substring(uzunluk - 6, 6);
            Genel.ButtonName = btnMasa8.Name;
            this.Close();
            frm.ShowDialog();
        }
    }
}
