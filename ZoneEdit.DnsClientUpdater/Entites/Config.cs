namespace ZoneEdit.DnsClientUpdater.Entites
{
    internal class Config
    {
        public string? Identifiant { get; set; }
        public string? MotDePasse { get; set; }

        public string? UrlIp { get; set; }
        public string? UrlZoneEditDnsUpdate { get; set; }
        public string? Zones {  get; set; }
        public int? IntervaleMinIpCheck { get; set; }

        public int? IntervaleMaj { get; set; }

        public bool? ValiderIpAuDemarrage { get; set; }
    }
}
