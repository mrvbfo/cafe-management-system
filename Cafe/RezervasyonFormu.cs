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
    public partial class RezervasyonFormu : Form
    {
        public RezervasyonFormu()
        {
            InitializeComponent();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            MenuFormu fr = new MenuFormu();
            this.Close();
            fr.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cikmak istediginize emin misiniz?", "Sistem Uyarisi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void RezervasyonFormu_Load(object sender, EventArgs e)
        {

        }
    }
}
