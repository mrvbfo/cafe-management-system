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
    public partial class OdemeFormu : Form
    {
        public OdemeFormu()
        {
            InitializeComponent();
        }

        private void labelToplam2_Click(object sender, EventArgs e)
        {

        }

        private void OdemeFormu_Load(object sender, EventArgs e)
        {
            Kasiyer k = new Kasiyer();
            k.KasiyerListele(lvKasiyerler);
            UrunSiparis cs = new UrunSiparis();

            lblAdisyonId.Text = Genel.AdisyonId;

            cs.SiparisListele(lvOdeme, Convert.ToInt32(lblAdisyonId.Text));
            if (lvOdeme.Items.Count > 0)
            {
                decimal toplam = 0;
                for (int i = 0; i < lvOdeme.Items.Count; i++)
                {
                    toplam += Convert.ToDecimal(lvOdeme.Items[i].SubItems[3].Text);
                }

                labelToplam.Text = string.Format("{0:0.000}", toplam);

            }

        }

        private void btnHesap_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void labelToplam_Click(object sender, EventArgs e)
        {

        }
        Masa ms = new Masa();
        private void btnHesapKapat_Click(object sender, EventArgs e)
        {
            int MasaId = ms.MasaNoBul(Genel.ButtonName);
            int MusteriId = 0;

            if (ms.MasaDurumu(MasaId, 3) == true)
            {
              
            }
            else
            {
                MusteriId = 1;
            }
            
            Odeme odeme = new Odeme();

            odeme.AdisyonId1 = Convert.ToInt32(lblAdisyonId.Text);
            odeme.MusteriId1 = MusteriId;
            odeme.ToplamTutar1 = Convert.ToDecimal(labelToplam.Text);
            odeme.KasiyerId1 = Convert.ToInt32(txtKasiyerId.Text);

            bool result = odeme.HesapKapat(odeme);

            if (result)
            {
                MessageBox.Show("Hesap Kapatılmıştır.");
                ms.MasaDurumuDegistir(Convert.ToString(MasaId), 1);

                Adisyon a = new Adisyon();
                a.AdisyonKapat(Convert.ToInt32(lblAdisyonId.Text), 1);

                this.Close();
                MasaFormu frm = new MasaFormu();
                frm.Show();

            }
            else
            {
                MessageBox.Show("Hesap kapatılırken bir hata oluştu.");
            }

        }
        Font Baslik = new Font("Verdana", 15, FontStyle.Bold);
        Font altBaslik = new Font("Verdana", 12, FontStyle.Regular);
        Font icerik = new Font("Verdana", 10);
        SolidBrush sb = new SolidBrush(Color.Black);
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat st = new StringFormat();
            st.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("Cafe", Baslik, sb, 350, 100, st);

            e.Graphics.DrawString("_____________________________________________", Baslik, sb, 350, 120, st);
            e.Graphics.DrawString("Ürün Adı            Adet            Fiyat", Baslik, sb, 150, 250, st);
            e.Graphics.DrawString("__________________________________________________________", Baslik, sb, 150, 280, st);
            for (int i = 0; i < lvOdeme.Items.Count; i++)
            {
                e.Graphics.DrawString(lvOdeme.Items[i].SubItems[0].Text, icerik, sb, 150, 350 + i * 30, st);
                e.Graphics.DrawString(lvOdeme.Items[i].SubItems[1].Text, icerik, sb, 350, 350 + i * 30, st);
                e.Graphics.DrawString(lvOdeme.Items[i].SubItems[3].Text, icerik, sb, 480, 350 + i * 30, st);

            }
            e.Graphics.DrawString("Toplam Tutar : ................." + labelToplam.Text + "TL", altBaslik, sb, 250, 350 + 30 * (lvOdeme.Items.Count + 3), st);
            e.Graphics.DrawString("Ödediğiniz Tutar : ............." + labelToplam.Text + "TL", altBaslik, sb, 250, 350 + 30 * (lvOdeme.Items.Count + 4), st);
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
            MasaFormu fr = new MasaFormu();
            this.Close();
            fr.Show();
        }

        private void lvOdeme_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvGarsonlar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
