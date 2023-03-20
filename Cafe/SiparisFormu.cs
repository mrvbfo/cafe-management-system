using Cafe;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace Cafe
{
    public partial class SiparisFormu : Form
    {
        public SiparisFormu()
        {
            InitializeComponent();
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            Genel.ServisTurNo = 1;
            Genel.AdisyonId = AdditionId.ToString();
            KasiyerFormu frm = new KasiyerFormu();
            this.Close();
            frm.Show();
         

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

        int tableId=0,AdditionId=0;
        private void SiparisFormu_Load(object sender, EventArgs e)
        {
            Garson m = new Garson();
            m.GarsonListele(lvGarsonlar);
            UrunSiparis cs = new UrunSiparis();
            lblMasaNo.Text = Genel.ButtonValue;
            Masa ms = new Masa();
            tableId = ms.MasaNoBul(Genel.ButtonName);
            if (ms.MasaDurumu(tableId, 2) == true)
            {

                Adisyon Ad = new Adisyon();
                AdditionId = Ad.AdisyonBul(tableId);
                UrunSiparis order = new UrunSiparis();
                order.SiparisListele(listView2, AdditionId);
            }
        }

        private void btnYiyecek1_Click(object sender, EventArgs e)
        {
            UrunCesitleri Uc = new UrunCesitleri();
            Uc.UrunTipi(listView1, btnYiyecek1);
        }

        private void btnIcecek2_Click(object sender, EventArgs e)
        {
            UrunCesitleri Uc = new UrunCesitleri();
            Uc.UrunTipi(listView1, btnIcecek2);

        }

        private void btnTatli3_Click(object sender, EventArgs e)
        {
            UrunCesitleri Uc = new UrunCesitleri();
            Uc.UrunTipi(listView1, btnTatli3);
        }

        ArrayList array = new ArrayList();
        private void btnSiparis_Click(object sender, EventArgs e)
        {
            Masa masa = new Masa();
            MasaFormu ms = new MasaFormu();
            Adisyon newAddition = new Adisyon();

            UrunSiparis saveOrder = new UrunSiparis();
            bool sonuc = false;

            if (masa.MasaDurumu(tableId, 1) == true)
            {
                newAddition.ServisTurNo1 = 1;
                newAddition.GarsonId1 = Convert.ToInt32(txtGarsonId.Text);
                newAddition.MasaId1 = tableId;
                newAddition.Tarih1 = DateTime.Now;

                sonuc = newAddition.AdisyonAc(newAddition);
                masa.MasaDurumuDegistir(Genel.ButtonName, 2);

                if (listView2.Items.Count > 0)
                {
                    for (int i = 0; i < listView2.Items.Count; i++)
                    {
                        saveOrder.MasaId1 = tableId;
                        saveOrder.UrunId1 = Convert.ToInt32(listView2.Items[i].SubItems[2].Text);
                        saveOrder.AdisyonId1 = newAddition.AdisyonBul(tableId);
                        saveOrder.Adet1 = Convert.ToInt32(listView2.Items[i].SubItems[1].Text);
                        saveOrder.GarsonId1 = Convert.ToInt32(txtGarsonId.Text);
                        saveOrder.Tarih1 = DateTime.Now;
                        saveOrder.SiparisAl(saveOrder);

                    }
                    this.Close();
                    ms.Show();
                   
                }
            }

            else if (masa.MasaDurumu(tableId, 2) == true)
            {

                if (listView3.Items.Count > 0)
                {
                    for (int i = 0; i < listView3.Items.Count; i++)
                    {
                        saveOrder.MasaId1 = tableId;
                        saveOrder.UrunId1 = Convert.ToInt32(listView3.Items[i].SubItems[1].Text);
                        saveOrder.AdisyonId1 = newAddition.AdisyonBul(tableId);
                        saveOrder.Adet1 = Convert.ToInt32(listView3.Items[i].SubItems[2].Text);
                        saveOrder.GarsonId1 = Convert.ToInt32(txtGarsonId.Text);
                        saveOrder.Tarih1 = DateTime.Now;
                        saveOrder.SiparisAl(saveOrder);
                    }

                    Genel.AdisyonId= Convert.ToString(newAddition.AdisyonBul(tableId));
                }
                if (array.Count > 0)
                {
                    foreach (string item in array)
                    {
                        saveOrder.SiparisKaldir(Convert.ToInt32(item));
                    }

                }


                this.Close();
                ms.Show();


            }
            else if (masa.MasaDurumu(tableId, 3) == true)
            {
                masa.MasaDurumuDegistir(Genel.ButtonName, 3);

                if (listView2.Items.Count > 0)
                {
                    for (int i = 0; i < listView2.Items.Count; i++)
                    {
                        saveOrder.MasaId1 = tableId;
                        saveOrder.UrunId1 = Convert.ToInt32(listView2.Items[i].SubItems[2].Text);
                        saveOrder.AdisyonId1 = newAddition.AdisyonBul(tableId);
                        saveOrder.Adet1 = Convert.ToInt32(listView2.Items[i].SubItems[1].Text);
                        saveOrder.GarsonId1 = Convert.ToInt32(txtGarsonId.Text);
                        saveOrder.Tarih1 = DateTime.Now;
                        saveOrder.SiparisAl(saveOrder);

                    }
                    this.Close();
                    ms.Show();

                }
            }
        }

        private void listView2_DoubleClick(object sender, EventArgs e)
        {
            if (listView2.Items.Count > 0)
            {
                if (listView2.SelectedItems[0].SubItems[4].Text != "0")
                {
                    UrunSiparis saveOrder = new UrunSiparis();
                    saveOrder.SiparisKaldir(Convert.ToInt32(listView2.SelectedItems[0].SubItems[4].Text));
                }
                else
                {
                    for (int i = 0; i < listView3.Items.Count; i++)
                    {
                        if (listView3.Items[i].SubItems[4].Text == listView2.SelectedItems[0].SubItems[5].Text)
                        {
                            listView3.Items.RemoveAt(i);
                        }

                    }
                }
                listView2.Items.RemoveAt(listView2.SelectedItems[0].Index);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            
            if (txtAdet.Text == "")
            {
                txtAdet.Text = "1";
            } 
            int sayac, sayac2;
            if (listView1.Items.Count > 0)
            {
                sayac = listView2.Items.Count;
                listView2.Items.Add(listView1.SelectedItems[0].Text);
                listView2.Items[sayac].SubItems.Add(txtAdet.Text);
                listView2.Items[sayac].SubItems.Add(listView1.SelectedItems[0].SubItems[2].Text);
                listView2.Items[sayac].SubItems.Add((Convert.ToDecimal(listView1.SelectedItems[0].SubItems[1].Text) * Convert.ToDecimal(txtAdet.Text)).ToString());
                listView2.Items[sayac].SubItems.Add("0");
                sayac2 = listView3.Items.Count;
                listView2.Items[sayac].SubItems.Add(sayac2.ToString());


                listView3.Items.Add(AdditionId.ToString());
                listView3.Items[sayac2].SubItems.Add(listView1.SelectedItems[0].SubItems[2].Text);
                listView3.Items[sayac2].SubItems.Add(txtAdet.Text);
                listView3.Items[sayac2].SubItems.Add(tableId.ToString());
                listView3.Items[sayac2].SubItems.Add(sayac2.ToString());

                sayac2++;

                txtAdet.Text = "";
            }
        }
    }
}
