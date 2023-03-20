using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cafe
{
    public partial class GarsonFormu : Form
    {
        public GarsonFormu()
        {
            InitializeComponent();
        }

        private void GarsonFormu_Load(object sender, EventArgs e)
        {
            Garson m = new Garson();
            m.GarsonListele(lvGarsonlar);
        }

        private void lvGarsonlar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click_1(object sender, EventArgs e)
        {
            Garson p = new Garson();
            bool result = p.GirisKontrolu(txtSifre.Text, txtKullaniciAdi.Text);
            if (result)
            {
                PersonelHareket ch = new PersonelHareket();
                ch.PersonelID1 = Genel.PersonelID;
                ch.Islem1 = "Giriş Yaptı";
                ch.Tarih1 = DateTime.Now;
                ch.GirisKayidi(ch);

                this.Hide();
                SiparisFormu mutfak = new SiparisFormu();
                mutfak.Show();
            }
            else
            {
                MessageBox.Show("Şifreniz Yanlış", "Uyarı!!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
    }
}
