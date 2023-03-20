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
    public partial class GirisFormu : Form
    {
        public GirisFormu()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
           Personel p = new Personel();
            p.PersonelBilgileri(cbKullaniciAdi);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Personel p = (Personel)cbKullaniciAdi.SelectedItem;
            Genel.PersonelID = p.PersonelID1;
            Genel.GorevID= p.GorevID1;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cikmak istediginize emin misiniz?","Sistem Uyarisi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Yonetici p = new Yonetici();
            bool result = p.YoneticiGirisi(txtSifre.Text, txtKullaniciAdi.Text);
            if (result)
            {
                PersonelHareket ch = new PersonelHareket();
                ch.PersonelID1 = Genel.PersonelID;
                ch.Islem1 = "Giriş Yaptı";
                ch.Tarih1 = DateTime.Now;
                ch.GirisKayidi(ch);

                this.Hide();
                MenuFormu menu = new MenuFormu();
                menu.Show();

            }
            else
            {
                MessageBox.Show("Şifreniz Yanlış", "Uyarı!!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            /*
            Genel gnl = new Genel();
            Personel p = new Personel();
            if (txtKullaniciAdi.Text == "Yusuf34" && txtSifre.Text == "07123")
            {
                PersonelHareket ch = new PersonelHareket();
                ch.PersonelID1 = 4;
                ch.Islem1 = "Giris Yapildi";
                ch.Tarih1 = DateTime.Now;
                ch.GirisKayidi(ch);

                this.Hide(); //bu formu gizle
                MenuFormu menu = new MenuFormu();
                menu.Show();

            }
            else
            {
                MessageBox.Show("Şifreniz Yanlış", "Uyarı!!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            } */
        }
    }
}
