using System.ComponentModel;
using System.Data;
using System.Timers;

namespace ZoneEdit.DnsClientUpdater
{
    public partial class FrmPrincipale : Form
    {
        private Entites.Config _configChargee = new();
        private bool _chargementEnCours = false;
        private Lib.Helpers.Formulaire.TimerPlus _tmrMajDns = new();
        private Lib.Helpers.Formulaire.TimerPlus _tmrCheckIp = new();
        private Lib.Helpers.Formulaire.TimerPlus _tmrMajLibelles = new();

        public FrmPrincipale()
        {
            InitializeComponent();
        }

        #region Evenements

        private void FrmPrincipale_Showm(object sender, EventArgs e)
        {
            try
            {
                InitialiserInterface();
            }
            catch (Entites.ExceptionFonctionnelle exFonct)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(exFonct);
            }
            catch (Exception ex)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(ex);
            }
        }

        private void FrmPrincipale_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (tsslPrincipale.Tag != null)
                {
                    if (tsslPrincipale.Tag.ToString() == Entites.Messages.Statut.NonSauvegarde.Id)
                    {
                        var result = Lib.Helpers.Formulaire.AfficherMessageBoxConfirmation(Entites.Messages.Confirmation.SauvegarderConfig);
                        if (result == DialogResult.Yes)
                        {
                            SauvegarderConfig();
                        }
                        else if (result == DialogResult.Cancel)
                        {
                            e.Cancel = true;
                            return;
                        }
                    }
                }
                SauvegarderLogs();
            }
            catch (Entites.ExceptionFonctionnelle exFonct)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(exFonct);
            }
            catch (Exception ex)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(ex);
            }
        }

        private void Input_Changed(object sender, EventArgs e)
        {
            try
            {
                ChangerProprietesInterfaceApresChangement();
            }
            catch (Entites.ExceptionFonctionnelle exFonct)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(exFonct);
            }
            catch (Exception ex)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(ex);
            }
        }

        private void BlDns_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                ChangerProprietesInterfaceApresChangement();
            }
            catch (Entites.ExceptionFonctionnelle exFonct)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(exFonct);
            }
            catch (Exception ex)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(ex);
            }
        }

        private void BtnSauvegarder_Click(object sender, EventArgs e)
        {
            try
            {
                tsslPrincipale.Text = Entites.Messages.Statut.Vide.Libelle;
                var interfaceValide = ValiderConfigInterface();
                if (!interfaceValide)
                    throw new Entites.ExceptionFonctionnelle(Entites.Messages.ErreurFonctionnelles.ConfigDataInvalide);

                // Sauvegarder les configurations.
                SauvegarderConfig();
                // Réinitialiser les contrôles
                btnSauvegarder.Enabled = false;
                btnAnnuler.Enabled = false;
                tsslPrincipale.Text = Entites.Messages.Statut.Sauvegarde.Libelle;
                tsslPrincipale.Tag = Entites.Messages.Statut.Sauvegarde.Id;
                _tmrCheckIp.Start();
                if (_tmrMajDns.Interval > 100) _tmrMajDns.Start();
            }
            catch (Entites.ExceptionFonctionnelle exFonct)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(exFonct);
            }
            catch (Exception ex)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(ex);
            }
        }

        private void BtnAnnuler_Click(object sender, EventArgs e)
        {
            try
            {
                tsslPrincipale.Text = Entites.Messages.Statut.SauvegardeAnnulee.Libelle;
                tsslPrincipale.Tag = Entites.Messages.Statut.SauvegardeAnnulee.Id;
                ChargerConfigDataDansInterface();
            }
            catch (Entites.ExceptionFonctionnelle exFonct)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(exFonct);
            }
            catch (Exception ex)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(ex);
            }
        }

        private void BtnVerifierUrl_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUrlIpChecker.Text))
                    throw new Entites.ExceptionFonctionnelle(Entites.Messages.ErreurFonctionnelles.UrlIpCheckerVide);

                var ip = Lib.Actions.ObtenirIPSelonUrl(txtUrlIpChecker.Text);
                Lib.Helpers.Formulaire.AfficherMessageBoxInformation($"L'adresse IP trouvée est: {ip}");
            }
            catch (Entites.ExceptionFonctionnelle exFonct)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(exFonct);
            }
            catch (Exception ex)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(ex);
            }
        }

        private void LblIpTrouveValeur_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (_chargementEnCours) return;

                // Actualiser le DNS si la valeur est différente et que l'option de maj est immédiate.
                if (cboIntervaleMaj.SelectedIndex == 0 &&
                    !string.IsNullOrEmpty(lblIpTrouveValeur.Text) &&
                    lblIpMaintenantValeur.Text != lblIpTrouveValeur.Text)
                {
                    LancerMajDns();
                }
            }
            catch (Entites.ExceptionFonctionnelle exFonct)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(exFonct);
            }
            catch (Exception ex)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(ex);
            }
        }

        private void BtnForcer_Click(object sender, EventArgs e)
        {
            try
            {
                if (tsslPrincipale.Tag?.ToString() == Entites.Messages.Statut.NonSauvegarde.Id)
                    throw new Entites.ExceptionFonctionnelle(Entites.Messages.ErreurFonctionnelles.ConfigEnCoursChangement);

                _tmrCheckIp.Stop();
                _tmrMajDns.Stop();

                var ip = Lib.Actions.ObtenirIPSelonUrl(_configChargee.UrlIp);
                AjouterLigneLogInterface(Entites.Log.EnumSeverite.Information, $"Adresse IP trouvée: {ip}.");
                if (!string.IsNullOrWhiteSpace(ip))
                {
                    lblIpTrouveValeur.Text = ip;
                    LancerMajDns();
                }

                Lib.Helpers.Formulaire.AfficherMessageBoxInformation($"Opération effectuée avec succès.");

                _tmrCheckIp.Start();
                if (_tmrMajDns.Interval > 100) _tmrMajDns.Start();
            }
            catch (Entites.ExceptionFonctionnelle exFonct)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(exFonct);
                _tmrCheckIp.Start();
                if (_tmrMajDns.Interval > 100) _tmrMajDns.Start();
            }
            catch (Exception ex)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(ex);
            }
        }

        private void BtnClearAllLog_Click(object sender, EventArgs e)
        {
            try
            {
                ViderLogInterface();
            }
            catch (Entites.ExceptionFonctionnelle exFonct)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(exFonct);
            }
            catch (Exception ex)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(ex);
            }
        }

        #region Evenements lbDns

        private void TxtDnsAjout_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                btnDnsAjout.Enabled = !string.IsNullOrWhiteSpace(txtDnsAjout.Text);
                ChangerProprietesInterfaceApresChangement();
                // Sur ENTER, ajouter le DNS.
                if (e.KeyData == Keys.Enter) BtnDnsAjout_Click("TxtDnsAjout_KeyUp", e);
            }
            catch (Entites.ExceptionFonctionnelle exFonct)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(exFonct);
            }
            catch (Exception ex)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(ex);
            }
        }
        private void LbDns_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ChangerProprietesInterfaceApresChangement();
            }
            catch (Entites.ExceptionFonctionnelle exFonct)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(exFonct);
            }
            catch (Exception ex)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(ex);
            }
        }
        private void BtnDnsAjout_Click(object sender, EventArgs e)
        {
            try
            {
                blDns.Add(txtDnsAjout.Text);
                lbDns.SetSelected(lbDns.Items.Count - 1, true);

                ChangerProprietesInterfaceApresChangement();
            }
            catch (Entites.ExceptionFonctionnelle exFonct)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(exFonct);
            }
            catch (Exception ex)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(ex);
            }
        }
        private void BtnDnsRetirer_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbDns.SelectedItem != null)
                    blDns.RemoveAt(lbDns.SelectedIndex);

                ChangerProprietesInterfaceApresChangement();
            }
            catch (Entites.ExceptionFonctionnelle exFonct)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(exFonct);
            }
            catch (Exception ex)
            {
                Lib.Helpers.Formulaire.AfficherMessageBox(ex);
            }
        }

        #endregion

        private void TmrCheckIp_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                var ip = Lib.Actions.ObtenirIPSelonUrl(_configChargee.UrlIp);
                if (!string.IsNullOrWhiteSpace(ip) &&
                    (string.IsNullOrWhiteSpace(lblIpMaintenantValeur.Text) ||
                     lblIpMaintenantValeur.Text != ip))
                {
                    lblIpTrouveValeur.Text = ip;
                }
                AjouterLigneLogInterface(Entites.Log.EnumSeverite.Information, $"Adresse IP trouvée: {ip}.");
            }
            catch (Entites.ExceptionFonctionnelle exFonct)
            {
                AjouterLigneLogInterface(Entites.Log.EnumSeverite.Avertissement, $"{exFonct.Message}.");
            }
            catch (Exception ex)
            {
                AjouterLigneLogInterface(Entites.Log.EnumSeverite.Erreur, $" Erreur imprévue.\r\n Stack: {ex}.");
            }
        }

        private void TmrMajDns_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(lblIpTrouveValeur.Text) &&
                    (string.IsNullOrWhiteSpace(lblIpMaintenantValeur.Text) ||
                     lblIpTrouveValeur.Text != lblIpMaintenantValeur.Text))
                {
                    LancerMajDns();
                }
            }
            catch (Entites.ExceptionFonctionnelle exFonct)
            {
                AjouterLigneLogInterface(Entites.Log.EnumSeverite.Avertissement, $"{exFonct.Message}.");
            }
            catch (Exception ex)
            {
                AjouterLigneLogInterface(Entites.Log.EnumSeverite.Erreur, $" Erreur imprévue.\r\n Stack: {ex}.");
            }
        }

        private void TmrMajLibelles_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                MajLibellesTimer();
            }
            catch (Entites.ExceptionFonctionnelle exFonct)
            {
                _tmrMajLibelles.Stop();
                Lib.Helpers.Formulaire.AfficherMessageBox(exFonct);
            }
            catch (Exception ex)
            {
                _tmrMajLibelles.Stop();
                Lib.Helpers.Formulaire.AfficherMessageBox(ex);
            }
        }

        #endregion

        #region Methodes

        private void InitialiserInterface()
        {
            // Inialiser les timers.
            _tmrMajDns = new Lib.Helpers.Formulaire.TimerPlus();
            _tmrMajDns.Elapsed += TmrMajDns_Elapsed;
            _tmrCheckIp = new Lib.Helpers.Formulaire.TimerPlus();
            _tmrCheckIp.Elapsed += TmrCheckIp_Elapsed;
            _tmrMajLibelles = new Lib.Helpers.Formulaire.TimerPlus();
            _tmrMajLibelles.Elapsed += TmrMajLibelles_Elapsed;
            _tmrMajLibelles.Interval = 5000;
            _tmrMajLibelles.Start();

            // Charger les config dans l'interface.
            var configCharges = ChargerConfigDataDansInterface();

            // Charger les logs du fichier dans l'interface.
            var logCharges = ChargerLogsDataDansInterface();

            if (!configCharges || !logCharges) return;

            // Si maj Ip à l'ouverture est cochée, lancer la vérification.
            if (_configChargee != null &&
                _configChargee.ValiderIpAuDemarrage.HasValue &&
                _configChargee.ValiderIpAuDemarrage.Value &&
                !string.IsNullOrWhiteSpace(_configChargee.UrlIp))
            {
                var ip = Lib.Actions.ObtenirIPSelonUrl(_configChargee.UrlIp);
                AjouterLigneLogInterface(Entites.Log.EnumSeverite.Information, $"Adresse IP trouvée: {(string.IsNullOrWhiteSpace(ip) ? "Vide": ip)}.");

                if (!string.IsNullOrWhiteSpace(ip))
                {
                    if (lblIpMaintenantValeur.Text != ip)
                    {
                        LancerMajDns();
                    }
                }
            }

            // Activer les timers.
            _tmrCheckIp.Start();
            if (_tmrMajDns.Interval > 100) _tmrMajDns.Start();

            // Mettre les libelles Timers dans la barre de statut.
            MajLibellesTimer();
        }

        private static Entites.Config? ObtenirConfigData()
        {
            // Charger les config du fichier.
            return Lib.Helpers.Json<Entites.Config>.LireDansFichier();
        }

        private bool ValiderConfigData(Entites.Config? config)
        {
            // Obtenir le config si pas obtenu.
            config ??= ObtenirConfigData();

            // Valider le fichier config.
            if (config == null ||
                string.IsNullOrWhiteSpace(config.Identifiant) ||
                string.IsNullOrWhiteSpace(config.MotDePasse) ||
                string.IsNullOrWhiteSpace(config.UrlIp) ||
                string.IsNullOrWhiteSpace(config.UrlZoneEditDnsUpdate) ||
                !config.IntervaleMinIpCheck.HasValue ||
                !config.IntervaleMaj.HasValue ||
                !config.ValiderIpAuDemarrage.HasValue ||
                string.IsNullOrWhiteSpace(config.Zones))
            {
                tpConfig.Focus();
                throw new Entites.ExceptionFonctionnelle(Entites.Messages.ErreurFonctionnelles.ConfigDataInvalide);
            }
            return true;
        }

        private bool ChargerConfigDataDansInterface()
        {
            // Obtenir les config du fichier.
            var config = ObtenirConfigData();
            try
            {
                _chargementEnCours = true;

                // Charger le domaine de valeur de l'intervale de maj.
                var data = new Tuple<int, string>[]
                   {
                    new(0, "Dès que disponible (Recommandé)"),
                    new(10, "10 minutes"),
                    new(30, "30 minutes"),
                    new(60, "60 minutes (Recommandé)"),
                    new(120, "2 heures"),
                    new(360, "6 heures"),
                    new(720, "12 heures"),
                    new(1440, "Quotidienne"),
                    new(10080, "Hebdomadaire"),
                    new(302400, "Mensuelle")
                   };
                cboIntervaleMaj.DataSource = data;
                cboIntervaleMaj.ValueMember = "Item1";
                cboIntervaleMaj.DisplayMember = "Item2";

                // Initialiser la source de données au ListBox pour la première fois.
                if (blDns == null)
                {
                    blDns = [];
                    lbDns.DataSource = blDns;
                }
                blDns.Clear();

                // Charger les config dans l'interface
                if (config != null)
                {
                    txtIdentifiant.Text = config.Identifiant;
                    txtMotDePasse.Text = config.MotDePasse;
                    txtUrlIpChecker.Text = config.UrlIp;
                    txtUrlDnsUpdater.Text = config.UrlZoneEditDnsUpdate;                    
                    
                    nudIntervaleVerifIp.Value =
                        config.IntervaleMinIpCheck.HasValue
                            ? decimal.TryParse(config.IntervaleMinIpCheck.Value.ToString(), out var intTest) ? intTest : nudIntervaleVerifIp.Value
                            : nudIntervaleVerifIp.Minimum;
                    _tmrCheckIp.Interval = (double)nudIntervaleVerifIp.Value * 60000; // Convertir en millisecondes;
                    
                    cboIntervaleMaj.SelectedIndex = config.IntervaleMaj.HasValue
                        ? config.IntervaleMaj.Value
                        : 0;
                    _tmrMajDns.Interval = cboIntervaleMaj.SelectedIndex > 0
                        ? cboIntervaleMaj.SelectedIndex * 60000
                        : 100;
                    
                    txtDnsAjout.Text = string.Empty;
                    
                    if (config.Zones != null && config.Zones.Length != 0)
                    {
                        foreach (var z in config.Zones.Split(','))
                        {
                            blDns.Add(z.Trim());
                        }
                    }
                    lbDns.ClearSelected();
                    _configChargee = config;
                    btnAnnuler.Enabled = false;
                    btnSauvegarder.Enabled = false;
                    btnDnsAjout.Enabled = !string.IsNullOrWhiteSpace(txtDnsAjout.Text);
                    btnDnsRetirer.Enabled = false;
                }
                ValiderConfigData(config);
                return true;
            }
            catch (Entites.ExceptionFonctionnelle exFonct)
            {
                tcPrincipale.SelectTab(tpConfig);
                _tmrMajDns.Stop();
                _tmrCheckIp.Stop();
                MessageBox.Show(exFonct.Message, "Erreur fonctionnelle", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                _chargementEnCours = false;
            }
            return false;
        }

        private bool ValiderConfigInterface()
        {
            if (string.IsNullOrWhiteSpace(txtIdentifiant.Text) ||
                string.IsNullOrWhiteSpace(txtMotDePasse.Text) ||
                string.IsNullOrWhiteSpace(txtUrlIpChecker.Text) ||
                string.IsNullOrWhiteSpace(txtUrlDnsUpdater.Text) ||
                lbDns.Items.Count <= 0)
            {
                return false;
            }
            return true;
        }

        private void ChangerProprietesInterfaceApresChangement()
        {
            if (_chargementEnCours) return;

            btnSauvegarder.Enabled = true;
            btnAnnuler.Enabled = true;
            btnDnsAjout.Enabled = !string.IsNullOrWhiteSpace(txtDnsAjout.Text);
            btnDnsRetirer.Enabled = lbDns.SelectedIndex >= 0;
            tsslPrincipale.Text = Entites.Messages.Statut.NonSauvegarde.Libelle;
            tsslPrincipale.Tag = Entites.Messages.Statut.NonSauvegarde.Id;
            _tmrCheckIp.Stop();
            _tmrMajDns.Stop();
        }

        private void SauvegarderConfig()
        {
            ValiderConfigInterface();

            var config = new Entites.Config()
            {
                Identifiant = txtIdentifiant.Text.Trim(),
                MotDePasse = txtMotDePasse.Text.Trim(),
                IntervaleMinIpCheck = int.Parse(nudIntervaleVerifIp.Value.ToString()),
                IntervaleMaj = cboIntervaleMaj.SelectedIndex,
                ValiderIpAuDemarrage = chkMajAOuverture.Checked,
                UrlIp = txtUrlIpChecker.Text.Trim(),
                UrlZoneEditDnsUpdate = txtUrlDnsUpdater.Text.Trim(),
                Zones = string.Join(',', lbDns.Items.Cast<string>().ToArray())
            };
            Lib.Helpers.Json<Entites.Config>.EcrireDansFichier(config);
            _configChargee = config;
            _tmrCheckIp.Interval = config.IntervaleMinIpCheck.Value * 60000; // Convertir en millisecondes
            _tmrMajDns.Interval = config.IntervaleMaj.Value == 0
                ? 100
                : config.IntervaleMaj.Value * 60000; // Convertir en millisecondes
        }

        private static Entites.Logs ObtenirLogsData()
        {
            // Charger les logs du fichier.
            var logs = Lib.Helpers.Json<Entites.Logs>.LireDansFichier();
            return logs ?? new Entites.Logs();
        }

        private bool ChargerLogsDataDansInterface()
        {
            try
            {
                _chargementEnCours = true;

                // Obtenir les logs du fichier.
                var logs = ObtenirLogsData();
                // Charger les logs dans l'interface
                dtLog = Lib.Helpers.DataTable<Entites.Log>.Convertir(logs.Liste);
                bsLog.DataSource = dtLog;
                dgvLog.DataSource = bsLog;
                dgvLog.AutoGenerateColumns = false;
                bsLog.ResetBindings(false);
                dgvLog.Sort(dgvLog.Columns[dgvtxtcDate.Name], ListSortDirection.Descending);
                if (!string.IsNullOrWhiteSpace(logs.IpActuel))
                    lblIpMaintenantValeur.Text = logs.IpActuel;
                if (!string.IsNullOrWhiteSpace(logs.IpTrouve))
                    lblIpTrouveValeur.Text = logs.IpTrouve;
                if (!string.IsNullOrWhiteSpace(logs.IpPrecedent))
                    lblIpPrecedentValeur.Text = logs.IpPrecedent;
                return true;
            }
            finally
            {
                _chargementEnCours = false;
            }
        }

        private void ViderLogInterface()
        {
            dtLog.Clear();
            bsLog.ResetBindings(false);
        }

        /// <summary>
        /// Sauvegarder les logs dans le fichier.
        /// Sauvegarder seulement les logs d'erreur et d'avertissement.
        /// </summary>
        private void SauvegarderLogs()
        {
            if (bsLog.DataSource == null) return;
            var logs = new Entites.Logs
            {
                IpActuel = lblIpMaintenantValeur.Text,
                IpTrouve = lblIpTrouveValeur.Text,
                IpPrecedent = lblIpPrecedentValeur.Text,
                Liste = Lib.Helpers.DataTable<Entites.Log>.Convertir((DataTable)bsLog.DataSource)
            };
            // Retirer les logs d'information.
            logs.Liste = logs.Liste.Where(l => l.Severite != Entites.Log.EnumSeverite.Information).ToList();
            // Sauvegarder les logs dans le fichier.
            Lib.Helpers.Json<Entites.Logs>.EcrireDansFichier(logs);
        }

        private void AjouterLigneLogInterface(Entites.Log.EnumSeverite severite, string detail)
        {
            dtLog.Rows.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), severite, detail);
            //Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} - {severite} - {detail}");
            //Console.WriteLine($"TimerCheckIp Intv: {_tmrCheckIp.Interval}. TimerMajDNS Intv: {_tmrMajDns.Interval}");
            //Console.WriteLine($"TimerCheckIp Etat: {_tmrCheckIp.Etat}. TimerMajDNS Etat: {_tmrMajDns.Etat}");
        }

        private void LancerMajDns()
        {
            try
            {
                _tmrCheckIp.Stop();
                _tmrMajDns.Stop();

                if (_configChargee == null ||
                    string.IsNullOrWhiteSpace(_configChargee.Identifiant) ||
                    string.IsNullOrWhiteSpace(_configChargee.MotDePasse) ||
                    string.IsNullOrWhiteSpace(_configChargee.UrlZoneEditDnsUpdate) ||
                    _configChargee.Zones == null ||
                    _configChargee.Zones.Length == 0)
                    throw new Entites.ExceptionFonctionnelle(Entites.Messages.ErreurFonctionnelles.ConfigDataInvalide);

                var result = Lib.Actions.MettreAJourDns(
                    _configChargee.Identifiant,
                    _configChargee.MotDePasse,
                    _configChargee.UrlZoneEditDnsUpdate,
                    _configChargee.Zones.Split(',').ToList());

                AjouterLigneLogInterface(Entites.Log.EnumSeverite.Information, Entites.Messages.SuccesActionMajDns);

                lblIpPrecedentValeur.Text = lblIpMaintenantValeur.Text;
                lblIpMaintenantValeur.Text = lblIpTrouveValeur.Text;
                _tmrCheckIp.Start();
                if (_tmrMajDns.Interval > 100) _tmrMajDns.Start();
            }
            catch (Entites.ExceptionActionMajDns exAction)
            {
                AjouterLigneLogInterface(Entites.Log.EnumSeverite.Avertissement, $" StatutCode: {exAction.HttpStatutCode}.\r\n Message: {exAction.Message}.");
                _tmrCheckIp.Start();
                if (_tmrMajDns.Interval > 100) _tmrMajDns.Start();
            }
            catch (Exception ex)
            {
                AjouterLigneLogInterface(Entites.Log.EnumSeverite.Erreur, $" Erreur imprévue.\r\n Stack: {ex.ToString()}.");
            }
        }

        private void MajLibellesTimer()
        {
            _tmrMajLibelles.Stop();
            var dateCheckIp = _tmrCheckIp.TimeLeft.ToString(@"hh\:mm\:ss");
            var dateMajDns = _tmrMajDns.Interval == 100
                ? _tmrMajDns.TimeLeft.ToString(@"hh\:mm\:ss")
                : "Auto";
            //tsslPrincipale.Text = string.Empty;
            tsslTimerIp.Text = $"IP: {dateCheckIp}"; //$"IP: {tmrCheckIp.Interval / 60000} minutes";
            tsslTimerMajDns.Text = $"DNS: {dateMajDns}"; //$"DNS: {tmrMajDns.Interval / 60000} minutes";
            _tmrMajLibelles.Start();
        }

        #endregion
    }
}
