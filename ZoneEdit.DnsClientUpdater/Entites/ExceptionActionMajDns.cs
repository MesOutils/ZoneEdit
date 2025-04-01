using System.Net;

namespace ZoneEdit.DnsClientUpdater.Entites
{

    internal class ExceptionActionMajDns : Exception
    {

        internal HttpStatusCode? HttpStatutCode { get; set; }
        internal string? HttpRaw { get; set; }
        

        public ExceptionActionMajDns(string? message) : base(message)
        { }
        public ExceptionActionMajDns(string? message, HttpStatusCode httpStatutCode) : base(message)
        {
            HttpStatutCode = httpStatutCode;
        }
        public ExceptionActionMajDns(string? message, HttpStatusCode httpStatutCode, string httpRaw) : base(message)
        {
            HttpRaw = httpRaw;
            HttpStatutCode = httpStatutCode;
        }
    }
}
