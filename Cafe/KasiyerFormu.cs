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
    public partial class KasiyerFormu : Form
    {
        public KasiyerFormu()
        {
            InitializeComponent();
        }

        private void KasiyerFormu_Load(object sender, EventArgs e)
        {
            Kasiyer m = new Kasiyer();
            m.KasiyerListele(lvKasiyer);
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Kasiyer p = new Kasiyer();
            bool result = p.GirisKontrolu(txtSifre.Text, txtKullaniciAdi.Text);
            if (result)
            {
                PersonelHareket ch = new PersonelHareket();
                ch.PersonelID1 = Genel.PersonelID;
                ch.Islem1 = "Giriş Yaptı";
                ch.Tarih1 = DateTime.Now;
                ch.GirisKayidi(ch);

                this.Hide();
                OdemeFormu odeme = new OdemeFormu();
                odeme.Show();
            }
            else
            {
                MessageBox.Show("Şifreniz Yanlış", "Uyarı!!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
