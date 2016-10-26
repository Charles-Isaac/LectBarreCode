namespace LectBarreCode
{
    partial class frmFacture
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gbTransmission = new System.Windows.Forms.GroupBox();
            this.rbActif = new System.Windows.Forms.RadioButton();
            this.rbArret = new System.Windows.Forms.RadioButton();
            this.gbParite = new System.Windows.Forms.GroupBox();
            this.rbAucun = new System.Windows.Forms.RadioButton();
            this.rbImpair = new System.Windows.Forms.RadioButton();
            this.rbPair = new System.Windows.Forms.RadioButton();
            this.gbDonne = new System.Windows.Forms.GroupBox();
            this.rbHuitBit = new System.Windows.Forms.RadioButton();
            this.rbSeptBit = new System.Windows.Forms.RadioButton();
            this.gbArret = new System.Windows.Forms.GroupBox();
            this.rbDeuxBit = new System.Windows.Forms.RadioButton();
            this.rbUnBit = new System.Windows.Forms.RadioButton();
            this.cbVitesse = new System.Windows.Forms.ComboBox();
            this.gbConfiguration = new System.Windows.Forms.GroupBox();
            this.lblVitesse = new System.Windows.Forms.Label();
            this.btnLire = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNomArt = new System.Windows.Forms.TextBox();
            this.txtPrixArt = new System.Windows.Forms.TextBox();
            this.txtCheckSum = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtTaxe = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtQuantitéRest = new System.Windows.Forms.TextBox();
            this.spComm = new System.IO.Ports.SerialPort(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.txtMotDePasse = new System.Windows.Forms.TextBox();
            this.btnCreerInventaire = new System.Windows.Forms.Button();
            this.gbTransmission.SuspendLayout();
            this.gbParite.SuspendLayout();
            this.gbDonne.SuspendLayout();
            this.gbArret.SuspendLayout();
            this.gbConfiguration.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbTransmission
            // 
            this.gbTransmission.Controls.Add(this.rbActif);
            this.gbTransmission.Controls.Add(this.rbArret);
            this.gbTransmission.Location = new System.Drawing.Point(141, 19);
            this.gbTransmission.Name = "gbTransmission";
            this.gbTransmission.Size = new System.Drawing.Size(200, 100);
            this.gbTransmission.TabIndex = 7;
            this.gbTransmission.TabStop = false;
            this.gbTransmission.Text = "Transmission";
            // 
            // rbActif
            // 
            this.rbActif.AutoSize = true;
            this.rbActif.Checked = true;
            this.rbActif.Location = new System.Drawing.Point(7, 53);
            this.rbActif.Name = "rbActif";
            this.rbActif.Size = new System.Drawing.Size(46, 17);
            this.rbActif.TabIndex = 1;
            this.rbActif.TabStop = true;
            this.rbActif.Text = "Actif";
            this.rbActif.UseVisualStyleBackColor = true;
            // 
            // rbArret
            // 
            this.rbArret.AutoSize = true;
            this.rbArret.Location = new System.Drawing.Point(7, 20);
            this.rbArret.Name = "rbArret";
            this.rbArret.Size = new System.Drawing.Size(47, 17);
            this.rbArret.TabIndex = 0;
            this.rbArret.Text = "Arrêt";
            this.rbArret.UseVisualStyleBackColor = true;
            // 
            // gbParite
            // 
            this.gbParite.Controls.Add(this.rbAucun);
            this.gbParite.Controls.Add(this.rbImpair);
            this.gbParite.Controls.Add(this.rbPair);
            this.gbParite.Location = new System.Drawing.Point(17, 19);
            this.gbParite.Name = "gbParite";
            this.gbParite.Size = new System.Drawing.Size(118, 94);
            this.gbParite.TabIndex = 6;
            this.gbParite.TabStop = false;
            this.gbParite.Text = "Parité";
            // 
            // rbAucun
            // 
            this.rbAucun.AutoSize = true;
            this.rbAucun.Checked = true;
            this.rbAucun.Location = new System.Drawing.Point(7, 66);
            this.rbAucun.Name = "rbAucun";
            this.rbAucun.Size = new System.Drawing.Size(56, 17);
            this.rbAucun.TabIndex = 2;
            this.rbAucun.TabStop = true;
            this.rbAucun.Text = "Aucun";
            this.rbAucun.UseVisualStyleBackColor = true;
            this.rbAucun.CheckedChanged += new System.EventHandler(this.rbParite_CheckedChanged);
            // 
            // rbImpair
            // 
            this.rbImpair.AutoSize = true;
            this.rbImpair.Location = new System.Drawing.Point(7, 43);
            this.rbImpair.Name = "rbImpair";
            this.rbImpair.Size = new System.Drawing.Size(53, 17);
            this.rbImpair.TabIndex = 1;
            this.rbImpair.Text = "Impair";
            this.rbImpair.UseVisualStyleBackColor = true;
            this.rbImpair.CheckedChanged += new System.EventHandler(this.rbParite_CheckedChanged);
            // 
            // rbPair
            // 
            this.rbPair.AutoSize = true;
            this.rbPair.Location = new System.Drawing.Point(7, 20);
            this.rbPair.Name = "rbPair";
            this.rbPair.Size = new System.Drawing.Size(43, 17);
            this.rbPair.TabIndex = 0;
            this.rbPair.Text = "Pair";
            this.rbPair.UseVisualStyleBackColor = true;
            this.rbPair.CheckedChanged += new System.EventHandler(this.rbParite_CheckedChanged);
            // 
            // gbDonne
            // 
            this.gbDonne.Controls.Add(this.rbHuitBit);
            this.gbDonne.Controls.Add(this.rbSeptBit);
            this.gbDonne.Location = new System.Drawing.Point(505, 19);
            this.gbDonne.Name = "gbDonne";
            this.gbDonne.Size = new System.Drawing.Size(138, 94);
            this.gbDonne.TabIndex = 5;
            this.gbDonne.TabStop = false;
            this.gbDonne.Text = "Données";
            // 
            // rbHuitBit
            // 
            this.rbHuitBit.AutoSize = true;
            this.rbHuitBit.Checked = true;
            this.rbHuitBit.Location = new System.Drawing.Point(7, 53);
            this.rbHuitBit.Name = "rbHuitBit";
            this.rbHuitBit.Size = new System.Drawing.Size(112, 17);
            this.rbHuitBit.TabIndex = 1;
            this.rbHuitBit.TabStop = true;
            this.rbHuitBit.Text = "8 Bits de Données";
            this.rbHuitBit.UseVisualStyleBackColor = true;
            this.rbHuitBit.CheckedChanged += new System.EventHandler(this.rbBitDonnees_CheckedChanged_1);
            // 
            // rbSeptBit
            // 
            this.rbSeptBit.AutoSize = true;
            this.rbSeptBit.Location = new System.Drawing.Point(7, 20);
            this.rbSeptBit.Name = "rbSeptBit";
            this.rbSeptBit.Size = new System.Drawing.Size(112, 17);
            this.rbSeptBit.TabIndex = 0;
            this.rbSeptBit.Text = "7 Bits de Données";
            this.rbSeptBit.UseVisualStyleBackColor = true;
            this.rbSeptBit.CheckedChanged += new System.EventHandler(this.rbBitDonnees_CheckedChanged_1);
            // 
            // gbArret
            // 
            this.gbArret.Controls.Add(this.rbDeuxBit);
            this.gbArret.Controls.Add(this.rbUnBit);
            this.gbArret.Location = new System.Drawing.Point(358, 19);
            this.gbArret.Name = "gbArret";
            this.gbArret.Size = new System.Drawing.Size(141, 94);
            this.gbArret.TabIndex = 4;
            this.gbArret.TabStop = false;
            this.gbArret.Text = "Arrêt";
            // 
            // rbDeuxBit
            // 
            this.rbDeuxBit.AutoSize = true;
            this.rbDeuxBit.Location = new System.Drawing.Point(7, 53);
            this.rbDeuxBit.Name = "rbDeuxBit";
            this.rbDeuxBit.Size = new System.Drawing.Size(106, 17);
            this.rbDeuxBit.TabIndex = 1;
            this.rbDeuxBit.Text = "Deux bits d\'arrêts";
            this.rbDeuxBit.UseVisualStyleBackColor = true;
            this.rbDeuxBit.CheckedChanged += new System.EventHandler(this.rbBitArret_CheckedChanged);
            // 
            // rbUnBit
            // 
            this.rbUnBit.AutoSize = true;
            this.rbUnBit.Checked = true;
            this.rbUnBit.Location = new System.Drawing.Point(7, 20);
            this.rbUnBit.Name = "rbUnBit";
            this.rbUnBit.Size = new System.Drawing.Size(86, 17);
            this.rbUnBit.TabIndex = 0;
            this.rbUnBit.TabStop = true;
            this.rbUnBit.Text = "Un Bit d\'arrêt";
            this.rbUnBit.UseVisualStyleBackColor = true;
            this.rbUnBit.CheckedChanged += new System.EventHandler(this.rbBitArret_CheckedChanged);
            // 
            // cbVitesse
            // 
            this.cbVitesse.FormattingEnabled = true;
            this.cbVitesse.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600"});
            this.cbVitesse.Location = new System.Drawing.Point(454, 125);
            this.cbVitesse.Name = "cbVitesse";
            this.cbVitesse.Size = new System.Drawing.Size(121, 21);
            this.cbVitesse.TabIndex = 2;
            this.cbVitesse.Text = "9600";
            // 
            // gbConfiguration
            // 
            this.gbConfiguration.Controls.Add(this.lblVitesse);
            this.gbConfiguration.Controls.Add(this.gbArret);
            this.gbConfiguration.Controls.Add(this.cbVitesse);
            this.gbConfiguration.Controls.Add(this.gbDonne);
            this.gbConfiguration.Controls.Add(this.gbTransmission);
            this.gbConfiguration.Controls.Add(this.gbParite);
            this.gbConfiguration.Location = new System.Drawing.Point(12, 12);
            this.gbConfiguration.Name = "gbConfiguration";
            this.gbConfiguration.Size = new System.Drawing.Size(664, 153);
            this.gbConfiguration.TabIndex = 8;
            this.gbConfiguration.TabStop = false;
            this.gbConfiguration.Text = "Configuration:";
            // 
            // lblVitesse
            // 
            this.lblVitesse.AutoSize = true;
            this.lblVitesse.Location = new System.Drawing.Point(383, 128);
            this.lblVitesse.Name = "lblVitesse";
            this.lblVitesse.Size = new System.Drawing.Size(44, 13);
            this.lblVitesse.TabIndex = 2;
            this.lblVitesse.Text = "Vitesse:";
            // 
            // btnLire
            // 
            this.btnLire.Location = new System.Drawing.Point(291, 183);
            this.btnLire.Name = "btnLire";
            this.btnLire.Size = new System.Drawing.Size(119, 23);
            this.btnLire.TabIndex = 9;
            this.btnLire.Text = "Lire le mot de passe";
            this.btnLire.UseVisualStyleBackColor = true;
            this.btnLire.Click += new System.EventHandler(this.btnLire_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nom l\'article:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Prix de l\'article:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(195, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(376, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Check sum:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(545, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Quantité restante:";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(376, 277);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(34, 13);
            this.lbl.TabIndex = 15;
            this.lbl.Text = "Total:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(195, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Taxe:";
            // 
            // txtNomArt
            // 
            this.txtNomArt.Location = new System.Drawing.Point(28, 225);
            this.txtNomArt.Name = "txtNomArt";
            this.txtNomArt.Size = new System.Drawing.Size(100, 20);
            this.txtNomArt.TabIndex = 17;
            // 
            // txtPrixArt
            // 
            this.txtPrixArt.Location = new System.Drawing.Point(28, 293);
            this.txtPrixArt.Name = "txtPrixArt";
            this.txtPrixArt.Size = new System.Drawing.Size(100, 20);
            this.txtPrixArt.TabIndex = 18;
            // 
            // txtCheckSum
            // 
            this.txtCheckSum.Location = new System.Drawing.Point(378, 225);
            this.txtCheckSum.Name = "txtCheckSum";
            this.txtCheckSum.Size = new System.Drawing.Size(100, 20);
            this.txtCheckSum.TabIndex = 19;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(197, 225);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(100, 20);
            this.txtDate.TabIndex = 19;
            // 
            // txtTaxe
            // 
            this.txtTaxe.Location = new System.Drawing.Point(198, 293);
            this.txtTaxe.Name = "txtTaxe";
            this.txtTaxe.Size = new System.Drawing.Size(100, 20);
            this.txtTaxe.TabIndex = 20;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(379, 293);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 21;
            // 
            // txtQuantitéRest
            // 
            this.txtQuantitéRest.Location = new System.Drawing.Point(548, 270);
            this.txtQuantitéRest.Name = "txtQuantitéRest";
            this.txtQuantitéRest.Size = new System.Drawing.Size(100, 20);
            this.txtQuantitéRest.TabIndex = 22;
            // 
            // spComm
            // 
            this.spComm.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.spComm_DataReceived);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(615, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Port :";
            // 
            // cbPort
            // 
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(615, 206);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(121, 21);
            this.cbPort.TabIndex = 23;
            this.cbPort.SelectedIndexChanged += new System.EventHandler(this.cbPort_SelectedIndexChanged);
            // 
            // txtMotDePasse
            // 
            this.txtMotDePasse.Location = new System.Drawing.Point(185, 185);
            this.txtMotDePasse.Name = "txtMotDePasse";
            this.txtMotDePasse.Size = new System.Drawing.Size(100, 20);
            this.txtMotDePasse.TabIndex = 25;
            this.txtMotDePasse.TabStop = false;
            this.txtMotDePasse.Text = "PWNED";
            this.txtMotDePasse.UseSystemPasswordChar = true;
            // 
            // btnCreerInventaire
            // 
            this.btnCreerInventaire.Location = new System.Drawing.Point(682, 12);
            this.btnCreerInventaire.Name = "btnCreerInventaire";
            this.btnCreerInventaire.Size = new System.Drawing.Size(103, 23);
            this.btnCreerInventaire.TabIndex = 26;
            this.btnCreerInventaire.Text = "Créer Inventaire";
            this.btnCreerInventaire.UseVisualStyleBackColor = true;
            this.btnCreerInventaire.Click += new System.EventHandler(this.btnCreerInventaire_Click);
            // 
            // frmFacture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 416);
            this.Controls.Add(this.btnCreerInventaire);
            this.Controls.Add(this.txtMotDePasse);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbPort);
            this.Controls.Add(this.txtQuantitéRest);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtTaxe);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtCheckSum);
            this.Controls.Add(this.txtPrixArt);
            this.Controls.Add(this.txtNomArt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLire);
            this.Controls.Add(this.gbConfiguration);
            this.Name = "frmFacture";
            this.Text = "Facture";
            this.gbTransmission.ResumeLayout(false);
            this.gbTransmission.PerformLayout();
            this.gbParite.ResumeLayout(false);
            this.gbParite.PerformLayout();
            this.gbDonne.ResumeLayout(false);
            this.gbDonne.PerformLayout();
            this.gbArret.ResumeLayout(false);
            this.gbArret.PerformLayout();
            this.gbConfiguration.ResumeLayout(false);
            this.gbConfiguration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbTransmission;
        private System.Windows.Forms.RadioButton rbActif;
        private System.Windows.Forms.RadioButton rbArret;
        private System.Windows.Forms.GroupBox gbParite;
        private System.Windows.Forms.RadioButton rbImpair;
        private System.Windows.Forms.RadioButton rbPair;
        private System.Windows.Forms.GroupBox gbDonne;
        private System.Windows.Forms.RadioButton rbHuitBit;
        private System.Windows.Forms.RadioButton rbSeptBit;
        private System.Windows.Forms.GroupBox gbArret;
        private System.Windows.Forms.RadioButton rbDeuxBit;
        private System.Windows.Forms.RadioButton rbUnBit;
        private System.Windows.Forms.ComboBox cbVitesse;
        private System.Windows.Forms.GroupBox gbConfiguration;
        private System.Windows.Forms.Label lblVitesse;
        private System.Windows.Forms.RadioButton rbAucun;
        private System.Windows.Forms.Button btnLire;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNomArt;
        private System.Windows.Forms.TextBox txtPrixArt;
        private System.Windows.Forms.TextBox txtCheckSum;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtTaxe;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtQuantitéRest;
        private System.IO.Ports.SerialPort spComm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.TextBox txtMotDePasse;
        private System.Windows.Forms.Button btnCreerInventaire;
    }
}

