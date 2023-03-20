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
    public partial class SefFormu : Form
    {
        public SefFormu()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Sef p = new Sef();
            bool result = p.GirisKontrolu(txtSifre.Text, txtKullaniciAdi.Text);
            if (result)
            {
                PersonelHareket ch = new PersonelHareket();
                ch.PersonelID1 = Genel.PersonelID;
                ch.Islem1 = "Giriş Yaptı";
                ch.Tarih1 = DateTime.Now;
                ch.GirisKayidi(ch);

                this.Hide();
                MutfakFormu mutfak = new MutfakFormu(); 
                mutfak.Show();
            }
            else
            {
                MessageBox.Show("Şifreniz Yanlış", "Uyarı!!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void cbKullaniciAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void SefFormu_Load(object sender, EventArgs e)
        {
            Sef m = new Sef();
            m.SefListele(lvSef);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
