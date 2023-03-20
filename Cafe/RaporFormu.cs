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
    public partial class RaporFormu : Form
    {
        public RaporFormu()
        {
            InitializeComponent();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            MenuFormu fr = new MenuFormu();
            this.Close();
            fr.Show();
        }

        private void RaporFormu_Load(object sender, EventArgs e)
        {

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cikmak istediginize emin misiniz?", "Sistem Uyarisi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnHaftalik_Click(object sender, EventArgs e)
        {
            Rapor r = new Rapor();
            r.HaftalikListeleme(lvSatislar);
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Rapor r = new Rapor();
            r.GunlukListeleme(lvSatislar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rapor r = new Rapor();
            r.AylikListeleme(lvSatislar);
        }

        private void lvSatislar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
