namespace ZoneEdit.DnsClientUpdater.Entites
{
    internal class Log
    {
        public enum EnumSeverite
        {
            Information,
            Avertissement,
            Erreur
        }

        public required string Date { get; set; }
        public required EnumSeverite Severite { get; set; }
        public required string Detail { get; set; }

    }

    internal class Logs
    {
        public string? IpActuel { get; set; }
        public string? IpTrouve { get; set; }
        public string? IpPrecedent { get; set; }

        public Logs() {
            Liste = [];
        }
        public List<Log> Liste { get; set; }
    }
}
