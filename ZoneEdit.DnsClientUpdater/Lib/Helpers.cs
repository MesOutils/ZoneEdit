using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;

namespace ZoneEdit.DnsClientUpdater.Lib
{
    internal class Helpers
    {
        internal class Json<T>
        {
            public static void EcrireDansFichier(T data)
            {
                var path = IO<T>.ObtenirPath();
                string json = JsonSerializer.Serialize(data);
                if (File.Exists(path))
                    File.Delete(path);
                File.WriteAllText(path, json);
            }

            public static T? LireDansFichier()
            {
                var path = IO<T>.ObtenirPath();
                if (!File.Exists(path))
                    return default;

                string text = File.ReadAllText(path);
                if (string.IsNullOrWhiteSpace(text))
                    return default;

                return JsonSerializer.Deserialize<T>(text);
            }
        }

        internal class IO<T>
        {

            private const string _nomFichierConfig = "_config.json";
            private const string _nomFichierLog = "_log.json";

            public static string ObtenirPath()
            {
                var pathApp = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                if (pathApp == null || pathApp == string.Empty)
                    throw new Entites.ExceptionFonctionnelle($"Impossible d'accéder au répertoire de l'application «{Process.GetCurrentProcess().MainModule.FileName}».");

                var fich = typeof(T) == typeof(Entites.Config)
                    ? _nomFichierConfig
                    : typeof(T) == typeof(Entites.Logs)
                        ? _nomFichierLog
                        : string.Empty;
                if (fich == string.Empty)
                    throw new Exception("Type inconnu!");

                var path = Path.Combine(pathApp, fich);
                return path;
            }
        }

        internal class Formulaire
        {
            public static void AfficherMessageBox(Exception ex)
            {
                var message = ex.ToString();
                var titre = "Erreur imprévue";
                var messageBoxButtons = MessageBoxButtons.OK;
                var messageBoxIcon = MessageBoxIcon.Error;

                if (ex.GetType() == typeof(Entites.ExceptionFonctionnelle))
                {
                    message = ex.Message;
                    titre = "Erreur fonctionnelle";
                    messageBoxButtons = MessageBoxButtons.OK;
                    messageBoxIcon = MessageBoxIcon.Warning;
                }
                MessageBox.Show(message, titre, messageBoxButtons, messageBoxIcon);
            }

            public static DialogResult AfficherMessageBoxConfirmation(string message)
            {
                return MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            }

            public static void AfficherMessageBoxInformation(string message)
            {
                MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            public class TimerPlus : System.Timers.Timer
            {
                private DateTime _dueTime;
                public enum EnumEtat
                {
                    Started,
                    Stopped
                };
                private EnumEtat _etat = EnumEtat.Stopped;

                public TimerPlus() : base()
                {
                    _etat = EnumEtat.Stopped;
                    Elapsed += ElapsedAction;
                }

                public EnumEtat Etat => _etat;

                public TimeSpan TimeLeft
                {
                    get
                    {
                        var dateMaintenant = DateTime.Now;
                        return (_etat == EnumEtat.Started
                            ? _dueTime
                            : dateMaintenant.AddMilliseconds(Interval))
                            - dateMaintenant;
                    }
                }

                public new void Start()
                {
                    this._dueTime = DateTime.Now.AddMilliseconds(Interval);
                    this._etat = EnumEtat.Started;
                    base.Start();
                }

                public new void Stop()
                {
                    this._etat = EnumEtat.Stopped;
                    base.Stop();
                }

                private void ElapsedAction(object sender, System.Timers.ElapsedEventArgs e)
                {
                    if (AutoReset)
                        _dueTime = DateTime.Now.AddMilliseconds(Interval);
                }
                protected new void Dispose()
                {
                    this.Elapsed -= ElapsedAction;
                    base.Dispose();
                }
            }
        }

        internal class DataTable<T>
        {
            public static DataTable Convertir(List<T> data)
            {
                PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
                DataTable table = new();
                for (int i = 0; i < props.Count; i++)
                {
                    PropertyDescriptor prop = props[i];
                    if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                        table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                    else
                        table.Columns.Add(prop.Name, prop.PropertyType);
                }

                object[] values = new object[props.Count];
                for (int r = 0; r < data.Count; r++)
                {
                    for (int c = 0; c < values.Length; c++)
                    {
                        if (props[c] == null)
                            continue;
                        values[c] = props[c].GetValue(data[r]);
                    }
                    table.Rows.Add(values);
                }
                return table;
            }

            public static List<T> Convertir(DataTable dt)
            {
                if (dt == null || dt.Rows == null || dt.Rows.Count == 0)
                    return new();

                var liste = new List<T>();
                foreach (DataRow r in dt.Rows)
                {
                    var entite = Activator.CreateInstance(typeof(T));
                    foreach (DataColumn c in dt.Columns)
                    {
                        // Trouver la propriété dans l'objet T.
                        var pi = entite.GetType().GetProperty(c.ColumnName);
                        if (pi == null) continue;
                        // Affecter la valeur.
                        pi.SetValue(entite, r[c]);
                    }
                    liste.Add((T)entite);
                }
                return liste;
            }
        }
    }
}
