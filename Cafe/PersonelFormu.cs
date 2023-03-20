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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cafe
{
    public partial class PersonelFormu : Form
    {
        public PersonelFormu()
        {
            InitializeComponent();
        }

       
        private void PersonelFormu_Load(object sender, EventArgs e)
        {
            Gorev gorev = new Gorev();
            gorev.GorevYazdir(cbGorev);

            Personel m = new Personel();
            m.PersonelListele(lvPersoneller);

            gorev.GorevListele(lvGorev);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Personel c = new Personel();
            c.PersonelName1 = txtAd.Text.Trim();
            c.PersonelSurname1 = txtSoyad.Text.Trim();
            c.Password1 = txtSifre.Text;
            c.GorevID1 = Convert.ToInt32(txtGorevId2.Text);
            c.PersonelUsername1 = txtKullanıcıAdı.Text.Trim();
            bool sonuc = c.PersonelEkle(c);

            if (sonuc)
            {
                MessageBox.Show("Kayıt Başarıyla Eklenmiştir.");
            }
            else
            {
                MessageBox.Show("Kayıt Eklenirken Hata Oluştu!");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek İstediğinize Emin Misiniz!!", "uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Personel c = new Personel();
                int id = Convert.ToInt32(txtPersonelId.Text);
                bool sonuc = c.PersonelSil(Convert.ToInt32(id));
                if (sonuc)
                {
                    MessageBox.Show("Kayıt Başarıyla Silinmiştir");
                }
                else
                {
                    MessageBox.Show("Kayıt Silinirken Bir Hata Oluştu!");
                }

            }
            else
            {
                MessageBox.Show("Kayıt Seçiniz.");
            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Personel c = new Personel();
            c.PersonelID1 = Convert.ToInt32(txtPersonelId.Text);
            c.PersonelName1 = txtAd.Text.Trim();
            c.PersonelSurname1 = txtSoyad.Text.Trim();
            c.Password1 = txtSifre.Text;
            c.GorevID1 = Convert.ToInt32(txtGorevId2.Text);
            c.PersonelUsername1 = txtKullanıcıAdı.Text.Trim();
            bool sonuc = c.PersonelGuncelle(c, Convert.ToInt32(txtPersonelId.Text));

            if (sonuc)
            {
                MessageBox.Show("Kayıt Başarıyla Güncellenmiştir.");

            }
            else
            {
                MessageBox.Show("Kayıt Eklenirken Hata Oluştu!");
            }

        }


        private void btnCikiss_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cikmak istediginize emin misiniz?", "Sistem Uyarisi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuFormu fr = new MenuFormu();
            this.Close();
            fr.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Personel m = new Personel();
            m.PersonelListele(lvPersoneller);
        }
    }
              
}



    

