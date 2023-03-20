using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe
{
    public partial class MenuFormu : Form
    {
        public MenuFormu()
        {
            InitializeComponent();
        }

        private void MenuFormu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MasaFormu frm= new MasaFormu();
            this.Close();
            frm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SefFormu sef = new SefFormu();
            this.Close();
            sef.Show();
         
        }

        private void btnRezervasyonn_Click(object sender, EventArgs e)
        {
            RezervasyonFormu frm = new RezervasyonFormu();
            this.Close();
            frm.Show();
        }

        private void btnMusterii_Click(object sender, EventArgs e)
        {
            MusteriFormu frm = new MusteriFormu();
            this.Close();
            frm.Show();
        }

        private void btnCikiss_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cikmak istediginize emin misiniz?", "Sistem Uyarisi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {
            PersonelFormu frm = new PersonelFormu();
            this.Close();
            frm.Show();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            GirisFormu fr = new GirisFormu();
            this.Close();
            fr.Show();
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            RaporFormu frm= new RaporFormu();
            this.Close();
            frm.Show();
        }
    }
}
