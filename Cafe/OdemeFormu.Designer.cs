namespace Cafe
{
    partial class OdemeFormu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OdemeFormu));
            this.lvOdeme = new System.Windows.Forms.ListView();
            this.UrunAdı = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelToplam = new System.Windows.Forms.Label();
            this.labelToplam2 = new System.Windows.Forms.Label();
            this.btnHesap = new System.Windows.Forms.Button();
            this.btnHesapKapat = new System.Windows.Forms.Button();
            this.lblAdisyonId = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.btnGeri = new System.Windows.Forms.Button();
            this.btnCikiss = new System.Windows.Forms.Button();
            this.lvKasiyerler = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtKasiyerId = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvOdeme
            // 
            this.lvOdeme.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UrunAdı,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvOdeme.FullRowSelect = true;
            this.lvOdeme.GridLines = true;
            this.lvOdeme.HideSelection = false;
            this.lvOdeme.Location = new System.Drawing.Point(38, 33);
            this.lvOdeme.Name = "lvOdeme";
            this.lvOdeme.Size = new System.Drawing.Size(679, 433);
            this.lvOdeme.TabIndex = 0;
            this.lvOdeme.UseCompatibleStateImageBehavior = false;
            this.lvOdeme.View = System.Windows.Forms.View.Details;
            this.lvOdeme.SelectedIndexChanged += new System.EventHandler(this.lvOdeme_SelectedIndexChanged);
            // 
            // UrunAdı
            // 
            this.UrunAdı.Text = "Urun Adi";
            this.UrunAdı.Width = 147;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Adet";
            this.columnHeader1.Width = 127;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Urun Id";
            this.columnHeader2.Width = 122;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Fiyat";
            this.columnHeader3.Width = 165;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "SatisId";
            this.columnHeader4.Width = 445;
            // 
            // labelToplam
            // 
            this.labelToplam.AutoSize = true;
            this.labelToplam.BackColor = System.Drawing.Color.Transparent;
            this.labelToplam.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelToplam.Location = new System.Drawing.Point(825, 523);
            this.labelToplam.Name = "labelToplam";
            this.labelToplam.Size = new System.Drawing.Size(43, 46);
            this.labelToplam.TabIndex = 1;
            this.labelToplam.Text = "0";
            this.labelToplam.Click += new System.EventHandler(this.labelToplam_Click);
            // 
            // labelToplam2
            // 
            this.labelToplam2.AutoSize = true;
            this.labelToplam2.BackColor = System.Drawing.Color.Transparent;
            this.labelToplam2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelToplam2.ForeColor = System.Drawing.Color.CadetBlue;
            this.labelToplam2.Location = new System.Drawing.Point(543, 523);
            this.labelToplam2.Name = "labelToplam2";
            this.labelToplam2.Size = new System.Drawing.Size(248, 46);
            this.labelToplam2.TabIndex = 2;
            this.labelToplam2.Text = "Ara Toplam:";
            this.labelToplam2.Click += new System.EventHandler(this.labelToplam2_Click);
            // 
            // btnHesap
            // 
            this.btnHesap.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnHesap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHesap.ForeColor = System.Drawing.Color.CadetBlue;
            this.btnHesap.Location = new System.Drawing.Point(38, 490);
            this.btnHesap.Name = "btnHesap";
            this.btnHesap.Size = new System.Drawing.Size(194, 107);
            this.btnHesap.TabIndex = 3;
            this.btnHesap.Text = "Adisyon";
            this.btnHesap.UseVisualStyleBackColor = false;
            this.btnHesap.Click += new System.EventHandler(this.btnHesap_Click);
            // 
            // btnHesapKapat
            // 
            this.btnHesapKapat.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnHesapKapat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHesapKapat.ForeColor = System.Drawing.Color.CadetBlue;
            this.btnHesapKapat.Location = new System.Drawing.Point(247, 489);
            this.btnHesapKapat.Name = "btnHesapKapat";
            this.btnHesapKapat.Size = new System.Drawing.Size(194, 106);
            this.btnHesapKapat.TabIndex = 4;
            this.btnHesapKapat.Text = "Hesap Kapat";
            this.btnHesapKapat.UseVisualStyleBackColor = false;
            this.btnHesapKapat.Click += new System.EventHandler(this.btnHesapKapat_Click);
            // 
            // lblAdisyonId
            // 
            this.lblAdisyonId.AutoSize = true;
            this.lblAdisyonId.Location = new System.Drawing.Point(617, 547);
            this.lblAdisyonId.Name = "lblAdisyonId";
            this.lblAdisyonId.Size = new System.Drawing.Size(44, 16);
            this.lblAdisyonId.TabIndex = 6;
            this.lblAdisyonId.Text = "label2";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Text = "Baskı önizleme";
            this.printPreviewDialog1.Visible = false;
            // 
            // btnGeri
            // 
            this.btnGeri.BackgroundImage = global::Cafe.Properties.Resources.geri;
            this.btnGeri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGeri.Font = new System.Drawing.Font("Cambria Math", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGeri.ForeColor = System.Drawing.Color.Goldenrod;
            this.btnGeri.Location = new System.Drawing.Point(0, 647);
            this.btnGeri.Name = "btnGeri";
            this.btnGeri.Size = new System.Drawing.Size(91, 80);
            this.btnGeri.TabIndex = 17;
            this.btnGeri.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGeri.UseVisualStyleBackColor = true;
            this.btnGeri.Click += new System.EventHandler(this.btnGeri_Click);
            // 
            // btnCikiss
            // 
            this.btnCikiss.BackgroundImage = global::Cafe.Properties.Resources._7877220391555590625_1281;
            this.btnCikiss.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCikiss.Font = new System.Drawing.Font("Old Antic Decorative", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCikiss.Location = new System.Drawing.Point(1081, 647);
            this.btnCikiss.Name = "btnCikiss";
            this.btnCikiss.Size = new System.Drawing.Size(88, 79);
            this.btnCikiss.TabIndex = 18;
            this.btnCikiss.UseVisualStyleBackColor = true;
            this.btnCikiss.Click += new System.EventHandler(this.btnCikiss_Click);
            // 
            // lvKasiyerler
            // 
            this.lvKasiyerler.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvKasiyerler.GridLines = true;
            this.lvKasiyerler.HideSelection = false;
            this.lvKasiyerler.Location = new System.Drawing.Point(732, 33);
            this.lvKasiyerler.Name = "lvKasiyerler";
            this.lvKasiyerler.Size = new System.Drawing.Size(308, 217);
            this.lvKasiyerler.TabIndex = 19;
            this.lvKasiyerler.UseCompatibleStateImageBehavior = false;
            this.lvKasiyerler.View = System.Windows.Forms.View.Details;
            this.lvKasiyerler.SelectedIndexChanged += new System.EventHandler(this.lvGarsonlar_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ID";
            this.columnHeader5.Width = 65;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "AD";
            this.columnHeader6.Width = 97;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "SOYAD";
            this.columnHeader7.Width = 115;
            // 
            // txtKasiyerId
            // 
            this.txtKasiyerId.Location = new System.Drawing.Point(833, 284);
            this.txtKasiyerId.Name = "txtKasiyerId";
            this.txtKasiyerId.Size = new System.Drawing.Size(100, 22);
            this.txtKasiyerId.TabIndex = 20;
            // 
            // OdemeFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Cafe.Properties.Resources.pastel_blue_wall_with_wooden_floor_product_background2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1171, 728);
            this.Controls.Add(this.txtKasiyerId);
            this.Controls.Add(this.lvKasiyerler);
            this.Controls.Add(this.btnCikiss);
            this.Controls.Add(this.btnGeri);
            this.Controls.Add(this.btnHesapKapat);
            this.Controls.Add(this.btnHesap);
            this.Controls.Add(this.labelToplam2);
            this.Controls.Add(this.labelToplam);
            this.Controls.Add(this.lvOdeme);
            this.Controls.Add(this.lblAdisyonId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OdemeFormu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OdemeFormu";
            this.Load += new System.EventHandler(this.OdemeFormu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvOdeme;
        private System.Windows.Forms.ColumnHeader UrunAdı;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label labelToplam;
        private System.Windows.Forms.Label labelToplam2;
        private System.Windows.Forms.Button btnHesap;
        private System.Windows.Forms.Button btnHesapKapat;
        private System.Windows.Forms.Label lblAdisyonId;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button btnGeri;
        private System.Windows.Forms.Button btnCikiss;
        private System.Windows.Forms.ListView lvKasiyerler;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.TextBox txtKasiyerId;
    }
}