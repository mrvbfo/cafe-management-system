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
    public partial class MutfakFormu : Form
    {
        public MutfakFormu()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Urunler c = new Urunler();
            c.UrunAd1 = textBox2.Text.Trim();
            c.KategoriId1 = Convert.ToInt32(textBox1.Text);
            c.Fiyat1 = Convert.ToInt32(textBox3.Text);
            int sonuc = c.UrunEkle(c);

            if (sonuc==1)
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
            Urunler c = new Urunler();
            c.UrunAd1 = textBox2.Text.Trim();
            c.KategoriId1 = Convert.ToInt32(textBox1.Text);
            c.Fiyat1 = Convert.ToInt32(textBox3.Text);
            c.UrunId1 = Convert.ToInt32(textBox4.Text);
            int sonuc = c.UrunGuncelle(c);

            if (sonuc==1)
            {
                MessageBox.Show("Kayıt Başarıyla Güncellenmiştir.");

            }
            else
            {
                MessageBox.Show("Kayıt Güncellenirken Hata Oluştu!");
            }
        }

        private void MutfakFormu_Load(object sender, EventArgs e)
        {
            Urunler c = new Urunler();
            c.UrunleriListele(lvUrunler);

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silmek İstediğinize Emin Misiniz!!", "uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Urunler c = new Urunler();
                c.UrunId1 = Convert.ToInt32(textBox4.Text);
                int sonuc = c.UrunSil(c);
                if (sonuc==1)
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

        private void button1_Click(object sender, EventArgs e)
        {
            Urunler c = new Urunler();
            c.UrunleriListele(lvUrunler);
        }

        private void btnCikiss_Click(object sender, EventArgs e)
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
    }
}
