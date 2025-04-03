
using System.ComponentModel;
using System.Data;
using System.Net;

namespace ZoneEdit.DnsClientUpdater
{
    partial class FrmPrincipale
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FrmPrincipale));
            ssPrincipale = new StatusStrip();
            tsslPrincipale = new ToolStripStatusLabel();
            tsslTimerIp = new ToolStripStatusLabel();
            tsslTimerMajDns = new ToolStripStatusLabel();
            tcPrincipale = new TabControl();
            tpEventLog = new TabPage();
            btnForcer = new Button();
            btnClearAllLog = new Button();
            dgvLog = new DataGridView();
            dgvtxtcDate = new DataGridViewTextBoxColumn();
            dgvtxtcSeverite = new DataGridViewTextBoxColumn();
            dgvtxtcDetail = new DataGridViewTextBoxColumn();
            tpConfig = new TabPage();
            btnAnnuler = new Button();
            btnSauvegarder = new Button();
            gpbDns = new GroupBox();
            btnDnsRetirer = new Button();
            btnDnsAjout = new Button();
            txtDnsAjout = new TextBox();
            lbDns = new ListBox();
            gpbParametres = new GroupBox();
            btnVerifierUrl = new Button();
            gpbIpHist = new GroupBox();
            lblIpTrouveTitre = new Label();
            lblIpTrouveValeur = new Label();
            lblIpPrecedentTitre = new Label();
            lblIpMaintenantTitre = new Label();
            lblIpMaintenantValeur = new Label();
            lblIpPrecedentValeur = new Label();
            lblMajAOuverture = new Label();
            chkMajAOuverture = new CheckBox();
            cboIntervaleMaj = new ComboBox();
            lblIntervalMaj = new Label();
            nudIntervaleVerifIp = new NumericUpDown();
            lblIntervaleVerifIp = new Label();
            txtUrlDnsUpdater = new TextBox();
            lblUrlDnsUpdater = new Label();
            txtUrlIpChecker = new TextBox();
            lblUrlIpChecker = new Label();
            gpbAuthentification = new GroupBox();
            txtMotDePasse = new TextBox();
            txtIdentifiant = new TextBox();
            lblMotDePasse = new Label();
            lblIdentifiant = new Label();
            bsDomIntervaleMaj = new BindingSource(components);
            niPrincipal = new NotifyIcon(components);
            cmsTray = new ContextMenuStrip(components);
            tsTraytxtIp = new ToolStripTextBox();
            toolStripSeparator1 = new ToolStripSeparator();
            tsmiTrayOuvrir = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            tsmiTrayQuitter = new ToolStripMenuItem();
            bsLog = new BindingSource(components);
            msPrincipal = new MenuStrip();
            tsmiPrincipalFichier = new ToolStripMenuItem();
            tsmiPrincipalQuitter = new ToolStripMenuItem();
            ssPrincipale.SuspendLayout();
            tcPrincipale.SuspendLayout();
            tpEventLog.SuspendLayout();
            ((ISupportInitialize)dgvLog).BeginInit();
            tpConfig.SuspendLayout();
            gpbDns.SuspendLayout();
            gpbParametres.SuspendLayout();
            gpbIpHist.SuspendLayout();
            ((ISupportInitialize)nudIntervaleVerifIp).BeginInit();
            gpbAuthentification.SuspendLayout();
            ((ISupportInitialize)bsDomIntervaleMaj).BeginInit();
            cmsTray.SuspendLayout();
            ((ISupportInitialize)bsLog).BeginInit();
            msPrincipal.SuspendLayout();
            SuspendLayout();
            // 
            // ssPrincipale
            // 
            ssPrincipale.Items.AddRange(new ToolStripItem[] { tsslPrincipale, tsslTimerIp, tsslTimerMajDns });
            ssPrincipale.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            ssPrincipale.Location = new Point(0, 739);
            ssPrincipale.Name = "ssPrincipale";
            ssPrincipale.ShowItemToolTips = true;
            ssPrincipale.Size = new Size(584, 22);
            ssPrincipale.TabIndex = 0;
            // 
            // tsslPrincipale
            // 
            tsslPrincipale.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsslPrincipale.Name = "tsslPrincipale";
            tsslPrincipale.Size = new Size(0, 17);
            // 
            // tsslTimerIp
            // 
            tsslTimerIp.AutoToolTip = true;
            tsslTimerIp.BorderStyle = Border3DStyle.RaisedInner;
            tsslTimerIp.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsslTimerIp.Name = "tsslTimerIp";
            tsslTimerIp.Size = new Size(65, 17);
            tsslTimerIp.Text = "IP: 00:00:00";
            tsslTimerIp.ToolTipText = "Temps avant la vérification du IP";
            // 
            // tsslTimerMajDns
            // 
            tsslTimerMajDns.AutoToolTip = true;
            tsslTimerMajDns.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsslTimerMajDns.Name = "tsslTimerMajDns";
            tsslTimerMajDns.Size = new Size(78, 17);
            tsslTimerMajDns.Text = "DNS: 00:00:00";
            tsslTimerMajDns.ToolTipText = "Temps avant la mise à jour des DNS";
            // 
            // tcPrincipale
            // 
            tcPrincipale.Controls.Add(tpEventLog);
            tcPrincipale.Controls.Add(tpConfig);
            tcPrincipale.Dock = DockStyle.Fill;
            tcPrincipale.Location = new Point(0, 24);
            tcPrincipale.Name = "tcPrincipale";
            tcPrincipale.SelectedIndex = 0;
            tcPrincipale.Size = new Size(584, 715);
            tcPrincipale.TabIndex = 1;
            // 
            // tpEventLog
            // 
            tpEventLog.Controls.Add(btnForcer);
            tpEventLog.Controls.Add(btnClearAllLog);
            tpEventLog.Controls.Add(dgvLog);
            tpEventLog.Location = new Point(4, 24);
            tpEventLog.Name = "tpEventLog";
            tpEventLog.Padding = new Padding(3);
            tpEventLog.Size = new Size(576, 687);
            tpEventLog.TabIndex = 0;
            tpEventLog.Text = "Log";
            tpEventLog.UseVisualStyleBackColor = true;
            // 
            // btnForcer
            // 
            btnForcer.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnForcer.Location = new Point(340, 658);
            btnForcer.Name = "btnForcer";
            btnForcer.Size = new Size(101, 23);
            btnForcer.TabIndex = 16;
            btnForcer.Text = "Forcer la m.a.j.";
            btnForcer.UseVisualStyleBackColor = true;
            btnForcer.Click += BtnForcer_Click;
            // 
            // btnClearAllLog
            // 
            btnClearAllLog.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClearAllLog.Location = new Point(447, 658);
            btnClearAllLog.Name = "btnClearAllLog";
            btnClearAllLog.Size = new Size(121, 23);
            btnClearAllLog.TabIndex = 1;
            btnClearAllLog.Text = "Effacer tous les log";
            btnClearAllLog.UseVisualStyleBackColor = true;
            btnClearAllLog.Click += BtnClearAllLog_Click;
            // 
            // dgvLog
            // 
            dgvLog.AllowUserToAddRows = false;
            dgvLog.AllowUserToDeleteRows = false;
            dgvLog.AllowUserToOrderColumns = true;
            dgvLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLog.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvLog.BackgroundColor = SystemColors.MenuBar;
            dgvLog.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.ActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLog.Columns.AddRange(new DataGridViewColumn[] { dgvtxtcDate, dgvtxtcSeverite, dgvtxtcDetail });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ButtonFace;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvLog.DefaultCellStyle = dataGridViewCellStyle2;
            dgvLog.Location = new Point(3, 3);
            dgvLog.MultiSelect = false;
            dgvLog.Name = "dgvLog";
            dgvLog.ReadOnly = true;
            dgvLog.RowHeadersVisible = false;
            dgvLog.RowTemplate.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvLog.RowTemplate.ReadOnly = true;
            dgvLog.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLog.ShowCellErrors = false;
            dgvLog.ShowCellToolTips = false;
            dgvLog.ShowEditingIcon = false;
            dgvLog.ShowRowErrors = false;
            dgvLog.Size = new Size(570, 647);
            dgvLog.TabIndex = 0;
            // 
            // dgvtxtcDate
            // 
            dgvtxtcDate.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvtxtcDate.DataPropertyName = "Date";
            dgvtxtcDate.FillWeight = 89.0862961F;
            dgvtxtcDate.HeaderText = "Date";
            dgvtxtcDate.Name = "dgvtxtcDate";
            dgvtxtcDate.ReadOnly = true;
            dgvtxtcDate.Width = 56;
            // 
            // dgvtxtcSeverite
            // 
            dgvtxtcSeverite.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvtxtcSeverite.DataPropertyName = "Severite";
            dgvtxtcSeverite.FillWeight = 121.827408F;
            dgvtxtcSeverite.HeaderText = "Sévérité";
            dgvtxtcSeverite.Name = "dgvtxtcSeverite";
            dgvtxtcSeverite.ReadOnly = true;
            dgvtxtcSeverite.Width = 73;
            // 
            // dgvtxtcDetail
            // 
            dgvtxtcDetail.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvtxtcDetail.DataPropertyName = "Detail";
            dgvtxtcDetail.FillWeight = 89.0862961F;
            dgvtxtcDetail.HeaderText = "Détail";
            dgvtxtcDetail.Name = "dgvtxtcDetail";
            dgvtxtcDetail.ReadOnly = true;
            // 
            // tpConfig
            // 
            tpConfig.Controls.Add(btnAnnuler);
            tpConfig.Controls.Add(btnSauvegarder);
            tpConfig.Controls.Add(gpbDns);
            tpConfig.Controls.Add(gpbParametres);
            tpConfig.Controls.Add(gpbAuthentification);
            tpConfig.Location = new Point(4, 24);
            tpConfig.Name = "tpConfig";
            tpConfig.Padding = new Padding(3);
            tpConfig.Size = new Size(576, 687);
            tpConfig.TabIndex = 1;
            tpConfig.Text = "Config";
            tpConfig.UseVisualStyleBackColor = true;
            // 
            // btnAnnuler
            // 
            btnAnnuler.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAnnuler.Enabled = false;
            btnAnnuler.Location = new Point(97, 658);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(83, 23);
            btnAnnuler.TabIndex = 28;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = true;
            btnAnnuler.Click += BtnAnnuler_Click;
            // 
            // btnSauvegarder
            // 
            btnSauvegarder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSauvegarder.Enabled = false;
            btnSauvegarder.Location = new Point(8, 658);
            btnSauvegarder.Name = "btnSauvegarder";
            btnSauvegarder.Size = new Size(83, 23);
            btnSauvegarder.TabIndex = 28;
            btnSauvegarder.Text = "Sauvegarder";
            btnSauvegarder.UseVisualStyleBackColor = true;
            btnSauvegarder.Click += BtnSauvegarder_Click;
            // 
            // gpbDns
            // 
            gpbDns.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gpbDns.Controls.Add(btnDnsRetirer);
            gpbDns.Controls.Add(btnDnsAjout);
            gpbDns.Controls.Add(txtDnsAjout);
            gpbDns.Controls.Add(lbDns);
            gpbDns.Location = new Point(8, 309);
            gpbDns.Name = "gpbDns";
            gpbDns.Size = new Size(562, 343);
            gpbDns.TabIndex = 4;
            gpbDns.TabStop = false;
            gpbDns.Text = "DNS";
            // 
            // btnDnsRetirer
            // 
            btnDnsRetirer.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDnsRetirer.Enabled = false;
            btnDnsRetirer.Location = new Point(474, 299);
            btnDnsRetirer.Name = "btnDnsRetirer";
            btnDnsRetirer.Size = new Size(75, 23);
            btnDnsRetirer.TabIndex = 27;
            btnDnsRetirer.Text = "Retirer";
            btnDnsRetirer.UseVisualStyleBackColor = true;
            btnDnsRetirer.Click += BtnDnsRetirer_Click;
            // 
            // btnDnsAjout
            // 
            btnDnsAjout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDnsAjout.Enabled = false;
            btnDnsAjout.Location = new Point(393, 299);
            btnDnsAjout.Name = "btnDnsAjout";
            btnDnsAjout.Size = new Size(75, 23);
            btnDnsAjout.TabIndex = 26;
            btnDnsAjout.Text = "Ajouter";
            btnDnsAjout.UseVisualStyleBackColor = true;
            btnDnsAjout.Click += BtnDnsAjout_Click;
            // 
            // txtDnsAjout
            // 
            txtDnsAjout.AcceptsReturn = true;
            txtDnsAjout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtDnsAjout.Location = new Point(6, 299);
            txtDnsAjout.Name = "txtDnsAjout";
            txtDnsAjout.Size = new Size(381, 23);
            txtDnsAjout.TabIndex = 25;
            txtDnsAjout.KeyUp += TxtDnsAjout_KeyUp;
            // 
            // lbDns
            // 
            lbDns.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbDns.FormattingEnabled = true;
            lbDns.ItemHeight = 15;
            lbDns.Location = new Point(6, 22);
            lbDns.Name = "lbDns";
            lbDns.Size = new Size(548, 259);
            lbDns.TabIndex = 24;
            lbDns.SelectedIndexChanged += LbDns_SelectedIndexChanged;
            // 
            // gpbParametres
            // 
            gpbParametres.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gpbParametres.Controls.Add(btnVerifierUrl);
            gpbParametres.Controls.Add(gpbIpHist);
            gpbParametres.Controls.Add(lblMajAOuverture);
            gpbParametres.Controls.Add(chkMajAOuverture);
            gpbParametres.Controls.Add(cboIntervaleMaj);
            gpbParametres.Controls.Add(lblIntervalMaj);
            gpbParametres.Controls.Add(nudIntervaleVerifIp);
            gpbParametres.Controls.Add(lblIntervaleVerifIp);
            gpbParametres.Controls.Add(txtUrlDnsUpdater);
            gpbParametres.Controls.Add(lblUrlDnsUpdater);
            gpbParametres.Controls.Add(txtUrlIpChecker);
            gpbParametres.Controls.Add(lblUrlIpChecker);
            gpbParametres.Location = new Point(8, 112);
            gpbParametres.Name = "gpbParametres";
            gpbParametres.Size = new Size(560, 191);
            gpbParametres.TabIndex = 3;
            gpbParametres.TabStop = false;
            gpbParametres.Text = "Paramètres";
            // 
            // btnVerifierUrl
            // 
            btnVerifierUrl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnVerifierUrl.Location = new Point(479, 50);
            btnVerifierUrl.Name = "btnVerifierUrl";
            btnVerifierUrl.Size = new Size(75, 23);
            btnVerifierUrl.TabIndex = 11;
            btnVerifierUrl.Text = "Check";
            btnVerifierUrl.UseVisualStyleBackColor = true;
            btnVerifierUrl.Click += BtnVerifierUrl_Click;
            // 
            // gpbIpHist
            // 
            gpbIpHist.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            gpbIpHist.Controls.Add(lblIpTrouveTitre);
            gpbIpHist.Controls.Add(lblIpTrouveValeur);
            gpbIpHist.Controls.Add(lblIpPrecedentTitre);
            gpbIpHist.Controls.Add(lblIpMaintenantTitre);
            gpbIpHist.Controls.Add(lblIpMaintenantValeur);
            gpbIpHist.Controls.Add(lblIpPrecedentValeur);
            gpbIpHist.Location = new Point(381, 80);
            gpbIpHist.Name = "gpbIpHist";
            gpbIpHist.Size = new Size(173, 100);
            gpbIpHist.TabIndex = 17;
            gpbIpHist.TabStop = false;
            // 
            // lblIpTrouveTitre
            // 
            lblIpTrouveTitre.AutoSize = true;
            lblIpTrouveTitre.ForeColor = Color.OrangeRed;
            lblIpTrouveTitre.Location = new Point(24, 46);
            lblIpTrouveTitre.Name = "lblIpTrouveTitre";
            lblIpTrouveTitre.Size = new Size(45, 15);
            lblIpTrouveTitre.TabIndex = 20;
            lblIpTrouveTitre.Text = "Trouvé:";
            // 
            // lblIpTrouveValeur
            // 
            lblIpTrouveValeur.AutoSize = true;
            lblIpTrouveValeur.ForeColor = Color.OrangeRed;
            lblIpTrouveValeur.Location = new Point(75, 46);
            lblIpTrouveValeur.Name = "lblIpTrouveValeur";
            lblIpTrouveValeur.Size = new Size(88, 15);
            lblIpTrouveValeur.TabIndex = 21;
            lblIpTrouveValeur.Text = "255.255.255.255";
            // 
            // lblIpPrecedentTitre
            // 
            lblIpPrecedentTitre.AutoSize = true;
            lblIpPrecedentTitre.ForeColor = SystemColors.ControlDarkDark;
            lblIpPrecedentTitre.Location = new Point(6, 72);
            lblIpPrecedentTitre.Name = "lblIpPrecedentTitre";
            lblIpPrecedentTitre.Size = new Size(63, 15);
            lblIpPrecedentTitre.TabIndex = 22;
            lblIpPrecedentTitre.Text = "Précédent:";
            // 
            // lblIpMaintenantTitre
            // 
            lblIpMaintenantTitre.AutoSize = true;
            lblIpMaintenantTitre.ForeColor = Color.FromArgb(0, 192, 0);
            lblIpMaintenantTitre.Location = new Point(25, 19);
            lblIpMaintenantTitre.Name = "lblIpMaintenantTitre";
            lblIpMaintenantTitre.Size = new Size(44, 15);
            lblIpMaintenantTitre.TabIndex = 18;
            lblIpMaintenantTitre.Text = "Actuel:";
            // 
            // lblIpMaintenantValeur
            // 
            lblIpMaintenantValeur.AutoSize = true;
            lblIpMaintenantValeur.ForeColor = Color.FromArgb(0, 192, 0);
            lblIpMaintenantValeur.Location = new Point(75, 19);
            lblIpMaintenantValeur.Name = "lblIpMaintenantValeur";
            lblIpMaintenantValeur.Size = new Size(88, 15);
            lblIpMaintenantValeur.TabIndex = 19;
            lblIpMaintenantValeur.Text = "255.255.255.255";
            // 
            // lblIpPrecedentValeur
            // 
            lblIpPrecedentValeur.AutoSize = true;
            lblIpPrecedentValeur.ForeColor = SystemColors.ControlDarkDark;
            lblIpPrecedentValeur.Location = new Point(75, 72);
            lblIpPrecedentValeur.Name = "lblIpPrecedentValeur";
            lblIpPrecedentValeur.Size = new Size(88, 15);
            lblIpPrecedentValeur.TabIndex = 23;
            lblIpPrecedentValeur.Text = "255.255.255.255";
            // 
            // lblMajAOuverture
            // 
            lblMajAOuverture.Location = new Point(11, 138);
            lblMajAOuverture.Name = "lblMajAOuverture";
            lblMajAOuverture.Size = new Size(144, 42);
            lblMajAOuverture.TabIndex = 16;
            lblMajAOuverture.Text = "Mettre à jour à l'ouverture si différent";
            lblMajAOuverture.TextAlign = ContentAlignment.MiddleRight;
            // 
            // chkMajAOuverture
            // 
            chkMajAOuverture.AutoSize = true;
            chkMajAOuverture.Checked = true;
            chkMajAOuverture.CheckState = CheckState.Checked;
            chkMajAOuverture.Location = new Point(165, 153);
            chkMajAOuverture.Name = "chkMajAOuverture";
            chkMajAOuverture.Size = new Size(15, 14);
            chkMajAOuverture.TabIndex = 17;
            chkMajAOuverture.UseVisualStyleBackColor = true;
            chkMajAOuverture.CheckedChanged += Input_Changed;
            // 
            // cboIntervaleMaj
            // 
            cboIntervaleMaj.FormattingEnabled = true;
            cboIntervaleMaj.Location = new Point(164, 109);
            cboIntervaleMaj.Name = "cboIntervaleMaj";
            cboIntervaleMaj.Size = new Size(211, 23);
            cboIntervaleMaj.TabIndex = 15;
            cboIntervaleMaj.SelectedIndexChanged += Input_Changed;
            // 
            // lblIntervalMaj
            // 
            lblIntervalMaj.AutoSize = true;
            lblIntervalMaj.Location = new Point(71, 112);
            lblIntervalMaj.Name = "lblIntervalMaj";
            lblIntervalMaj.Size = new Size(84, 15);
            lblIntervalMaj.TabIndex = 14;
            lblIntervalMaj.Text = "Intervale m.a.j.";
            // 
            // nudIntervaleVerifIp
            // 
            nudIntervaleVerifIp.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            nudIntervaleVerifIp.Location = new Point(165, 80);
            nudIntervaleVerifIp.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            nudIntervaleVerifIp.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            nudIntervaleVerifIp.Name = "nudIntervaleVerifIp";
            nudIntervaleVerifIp.Size = new Size(75, 23);
            nudIntervaleVerifIp.TabIndex = 13;
            nudIntervaleVerifIp.Value = new decimal(new int[] { 60, 0, 0, 0 });
            nudIntervaleVerifIp.ValueChanged += Input_Changed;
            // 
            // lblIntervaleVerifIp
            // 
            lblIntervaleVerifIp.AutoSize = true;
            lblIntervaleVerifIp.Location = new Point(11, 83);
            lblIntervaleVerifIp.Name = "lblIntervaleVerifIp";
            lblIntervaleVerifIp.Size = new Size(145, 15);
            lblIntervaleVerifIp.TabIndex = 12;
            lblIntervaleVerifIp.Text = "Intervale verif. IP (en min.)";
            // 
            // txtUrlDnsUpdater
            // 
            txtUrlDnsUpdater.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUrlDnsUpdater.Location = new Point(165, 22);
            txtUrlDnsUpdater.Name = "txtUrlDnsUpdater";
            txtUrlDnsUpdater.Size = new Size(389, 23);
            txtUrlDnsUpdater.TabIndex = 8;
            txtUrlDnsUpdater.Text = "https://dynamic.zoneedit.com/auth/dynamic.html";
            txtUrlDnsUpdater.TextChanged += Input_Changed;
            // 
            // lblUrlDnsUpdater
            // 
            lblUrlDnsUpdater.AutoSize = true;
            lblUrlDnsUpdater.Location = new Point(10, 25);
            lblUrlDnsUpdater.Name = "lblUrlDnsUpdater";
            lblUrlDnsUpdater.Size = new Size(149, 15);
            lblUrlDnsUpdater.TabIndex = 7;
            lblUrlDnsUpdater.Text = "URL DNS ZoneEdit Updater";
            // 
            // txtUrlIpChecker
            // 
            txtUrlIpChecker.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtUrlIpChecker.Location = new Point(165, 51);
            txtUrlIpChecker.Name = "txtUrlIpChecker";
            txtUrlIpChecker.Size = new Size(308, 23);
            txtUrlIpChecker.TabIndex = 10;
            txtUrlIpChecker.Text = "https://ipecho.net/plain";
            txtUrlIpChecker.TextChanged += Input_Changed;
            // 
            // lblUrlIpChecker
            // 
            lblUrlIpChecker.AutoSize = true;
            lblUrlIpChecker.Location = new Point(74, 54);
            lblUrlIpChecker.Name = "lblUrlIpChecker";
            lblUrlIpChecker.Size = new Size(85, 15);
            lblUrlIpChecker.TabIndex = 9;
            lblUrlIpChecker.Text = "URL IP checker";
            // 
            // gpbAuthentification
            // 
            gpbAuthentification.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gpbAuthentification.Controls.Add(txtMotDePasse);
            gpbAuthentification.Controls.Add(txtIdentifiant);
            gpbAuthentification.Controls.Add(lblMotDePasse);
            gpbAuthentification.Controls.Add(lblIdentifiant);
            gpbAuthentification.Location = new Point(8, 6);
            gpbAuthentification.Name = "gpbAuthentification";
            gpbAuthentification.Size = new Size(560, 100);
            gpbAuthentification.TabIndex = 2;
            gpbAuthentification.TabStop = false;
            gpbAuthentification.Text = "Authentification ZoneEdit";
            // 
            // txtMotDePasse
            // 
            txtMotDePasse.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMotDePasse.Location = new Point(165, 54);
            txtMotDePasse.Name = "txtMotDePasse";
            txtMotDePasse.PasswordChar = '*';
            txtMotDePasse.Size = new Size(389, 23);
            txtMotDePasse.TabIndex = 6;
            txtMotDePasse.TextChanged += Input_Changed;
            // 
            // txtIdentifiant
            // 
            txtIdentifiant.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtIdentifiant.Location = new Point(165, 22);
            txtIdentifiant.Name = "txtIdentifiant";
            txtIdentifiant.Size = new Size(389, 23);
            txtIdentifiant.TabIndex = 4;
            txtIdentifiant.TextChanged += Input_Changed;
            // 
            // lblMotDePasse
            // 
            lblMotDePasse.AutoSize = true;
            lblMotDePasse.Location = new Point(82, 57);
            lblMotDePasse.Name = "lblMotDePasse";
            lblMotDePasse.Size = new Size(77, 15);
            lblMotDePasse.TabIndex = 5;
            lblMotDePasse.Text = "Mot de passe";
            // 
            // lblIdentifiant
            // 
            lblIdentifiant.AutoSize = true;
            lblIdentifiant.Location = new Point(98, 25);
            lblIdentifiant.Name = "lblIdentifiant";
            lblIdentifiant.Size = new Size(61, 15);
            lblIdentifiant.TabIndex = 3;
            lblIdentifiant.Text = "Identifiant";
            // 
            // niPrincipal
            // 
            niPrincipal.ContextMenuStrip = cmsTray;
            niPrincipal.Icon = (Icon)resources.GetObject("niPrincipal.Icon");
            niPrincipal.Text = "ZoneEdit DNS Updater";
            niPrincipal.Visible = true;
            niPrincipal.MouseDoubleClick += tsmiOuvrir_Click;
            // 
            // cmsTray
            // 
            cmsTray.Items.AddRange(new ToolStripItem[] { tsTraytxtIp, toolStripSeparator1, tsmiTrayOuvrir, toolStripSeparator2, tsmiTrayQuitter });
            cmsTray.Name = "cmsTray";
            cmsTray.ShowImageMargin = false;
            cmsTray.Size = new Size(156, 100);
            // 
            // tsTraytxtIp
            // 
            tsTraytxtIp.BackColor = Color.FromArgb(0, 192, 0);
            tsTraytxtIp.BorderStyle = BorderStyle.None;
            tsTraytxtIp.ForeColor = SystemColors.Window;
            tsTraytxtIp.Name = "tsTraytxtIp";
            tsTraytxtIp.ReadOnly = true;
            tsTraytxtIp.Size = new Size(100, 16);
            tsTraytxtIp.Text = "255.255.255.255";
            tsTraytxtIp.TextBoxTextAlign = HorizontalAlignment.Center;
            tsTraytxtIp.ToolTipText = "IP actuel";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(152, 6);
            // 
            // tsmiTrayOuvrir
            // 
            tsmiTrayOuvrir.Name = "tsmiTrayOuvrir";
            tsmiTrayOuvrir.Size = new Size(155, 22);
            tsmiTrayOuvrir.Text = "&Ouvrir";
            tsmiTrayOuvrir.Click += tsmiOuvrir_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(152, 6);
            // 
            // tsmiTrayQuitter
            // 
            tsmiTrayQuitter.Name = "tsmiTrayQuitter";
            tsmiTrayQuitter.Size = new Size(155, 22);
            tsmiTrayQuitter.Text = "&Quitter";
            tsmiTrayQuitter.Click += tsmiQuitter_Click;
            // 
            // msPrincipal
            // 
            msPrincipal.Items.AddRange(new ToolStripItem[] { tsmiPrincipalFichier });
            msPrincipal.Location = new Point(0, 0);
            msPrincipal.Name = "msPrincipal";
            msPrincipal.Size = new Size(584, 24);
            msPrincipal.TabIndex = 2;
            msPrincipal.Text = "menuStrip1";
            // 
            // tsmiPrincipalFichier
            // 
            tsmiPrincipalFichier.DropDownItems.AddRange(new ToolStripItem[] { tsmiPrincipalQuitter });
            tsmiPrincipalFichier.Name = "tsmiPrincipalFichier";
            tsmiPrincipalFichier.Size = new Size(54, 20);
            tsmiPrincipalFichier.Text = "&Fichier";
            // 
            // tsmiPrincipalQuitter
            // 
            tsmiPrincipalQuitter.Name = "tsmiPrincipalQuitter";
            tsmiPrincipalQuitter.Size = new Size(111, 22);
            tsmiPrincipalQuitter.Text = "&Quitter";
            tsmiPrincipalQuitter.Click += tsmiQuitter_Click;
            // 
            // FrmPrincipale
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 761);
            Controls.Add(tcPrincipale);
            Controls.Add(ssPrincipale);
            Controls.Add(msPrincipal);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = msPrincipal;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(600, 800);
            Name = "FrmPrincipale";
            Tag = "ZoneEdit DNS Updater";
            Text = "ZoneEdit DNS Updater";
            FormClosing += FrmPrincipale_FormClosing;
            Shown += FrmPrincipale_Showm;
            ssPrincipale.ResumeLayout(false);
            ssPrincipale.PerformLayout();
            tcPrincipale.ResumeLayout(false);
            tpEventLog.ResumeLayout(false);
            ((ISupportInitialize)dgvLog).EndInit();
            tpConfig.ResumeLayout(false);
            gpbDns.ResumeLayout(false);
            gpbDns.PerformLayout();
            gpbParametres.ResumeLayout(false);
            gpbParametres.PerformLayout();
            gpbIpHist.ResumeLayout(false);
            gpbIpHist.PerformLayout();
            ((ISupportInitialize)nudIntervaleVerifIp).EndInit();
            gpbAuthentification.ResumeLayout(false);
            gpbAuthentification.PerformLayout();
            ((ISupportInitialize)bsDomIntervaleMaj).EndInit();
            cmsTray.ResumeLayout(false);
            cmsTray.PerformLayout();
            ((ISupportInitialize)bsLog).EndInit();
            msPrincipal.ResumeLayout(false);
            msPrincipal.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip ssPrincipale;
        private TabControl tcPrincipale;
        private TabPage tpEventLog;
        private TabPage tpConfig;
        private DataGridView dgvLog;
        private GroupBox gpbAuthentification;
        private Label lblMotDePasse;
        private Label lblIdentifiant;
        private GroupBox gpbParametres;
        private TextBox txtMotDePasse;
        private TextBox txtIdentifiant;
        private TextBox txtUrlDnsUpdater;
        private Label lblUrlDnsUpdater;
        private TextBox txtUrlIpChecker;
        private Label lblUrlIpChecker;
        private GroupBox gpbDns;
        private NumericUpDown nudIntervaleVerifIp;
        private Label lblIntervaleVerifIp;
        private Button btnAnnuler;
        private Button btnSauvegarder;
        private TextBox txtDnsAjout;
        private ListBox lbDns;
        private BindingList<string> blDns;
        private Button btnDnsRetirer;
        private Button btnDnsAjout;
        private Button btnClearAllLog;
        private Button btnForcer;
        private NotifyIcon niPrincipal;
        private ContextMenuStrip cmsTray;
        private ToolStripTextBox tsTraytxtIp;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem tsmiTrayOuvrir;
        private BindingSource bsLog;
        private DataTable dtLog;
        private ToolStripStatusLabel tsslPrincipale;
        private DataGridViewTextBoxColumn dgvtxtcDate;
        private DataGridViewTextBoxColumn dgvtxtcSeverite;
        private DataGridViewTextBoxColumn dgvtxtcDetail;
        private Label lblIntervalMaj;
        private ComboBox cboIntervaleMaj;
        private BindingSource bsDomIntervaleMaj;
        private CheckBox chkMajAOuverture;
        private Label lblMajAOuverture;
        private GroupBox gpbIpHist;
        private Label lblIpMaintenantTitre;
        private Label lblIpMaintenantValeur;
        private Label lblIpPrecedentValeur;
        private Label lblIpPrecedentTitre;
        private Label lblIpTrouveTitre;
        private Label lblIpTrouveValeur;
        private Button btnVerifierUrl;
        private ToolStripStatusLabel tsslTimerIp;
        private ToolStripStatusLabel tsslTimerMajDns;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem tsmiTrayQuitter;
        private MenuStrip msPrincipal;
        private ToolStripMenuItem tsmiPrincipalFichier;
        private ToolStripMenuItem tsmiPrincipalQuitter;
    }
}
