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
    public partial class MusteriFormu : Form
    {
        public MusteriFormu()
        {
            InitializeComponent();
        }

        private void MusteriFormu_Load(object sender, EventArgs e)
        {
            Musteri m = new Musteri();
            m.MusteriListele(lvMusteriler);
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            Musteri m = new Musteri();
            m.MusteriAd1 = textBox1.Text.Trim();
            m.MusteriSoyad1 = textBox2.Text.Trim();
            m.Adres1 = richTextBox1.Text;
            m.Telefon1 =textBox3.Text;
            bool sonuc = Convert.ToBoolean(m.MusteriEkle(m));

            if (sonuc)
            {
                MessageBox.Show("Kayıt Başarıyla Eklenmiştir.");
            }
            else
            {
                MessageBox.Show("Kayıt Eklenirken Hata Oluştu!");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Musteri m = new Musteri();
            m.MusteriAd1 = textBox1.Text.Trim();
            m.MusteriSoyad1 = textBox2.Text.Trim();
            m.Adres1 = richTextBox1.Text;
            m.Telefon1 = textBox3.Text;
            m.MusteriId1 = Convert.ToInt32(textBox4.Text);
            bool sonuc = m.MusteriGuncelle(m);

            if (sonuc)
            {
                MessageBox.Show("Kayıt Başarıyla Eklenmiştir.");

            }
            else
            {
                MessageBox.Show("Kayıt Eklenirken Hata Oluştu!");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Musteri m = new Musteri();
            m.MusteriListele(lvMusteriler);
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            MenuFormu fr = new MenuFormu();
            this.Close();
            fr.Show();
        }

        private void lvMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
