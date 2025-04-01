using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace ZoneEdit.DnsClientUpdater.Entites
{
    /* ZoneEdit seems to return odd payloads for success and errors
     * We need to convert that to something usable
      
    <SUCCESS CODE = "201" TEXT="no update required for foo.com to 10.10.175.5" ZONE="foo.com">
    <SUCCESS CODE = "200" TEXT="foo.com updated to 10.10.175.5" ZONE="foo.com">

    <ERROR CODE = "702" PARAM="600" TEXT="Minimum 600 seconds between requests" ZONE="foo.com"/>
    */

    public class ZoneEditResultats : List<ZoneEditResultat>
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
    }

    public class ZoneEditResultat
    {
        [XmlAttribute("CODE")]
        public int Code { get; set; }
        [XmlAttribute("TEXT")]
        public string Text { get; set; }
        [XmlAttribute("ZONE")]
        public string Zone { get; set; }


        public static ZoneEditResultats LireXml(string xmlString)
        {
            ZoneEditResultats resultats = new();

            if (xmlString.IndexOf("ERROR") > -1)
            {
                string el = $"{xmlString}</ERROR>";
                var reponse = DeserializeZoneEditResultat(el, "ERROR");
                resultats.Message = reponse.Text;
                resultats.Add(reponse);
            }
            else
            {
                string pattern = "<SUCCESS[^>]*>";
                MatchCollection matches = Regex.Matches(xmlString, pattern, RegexOptions.Singleline);
                resultats.Success = true;
                foreach (Match match in matches)
                {
                    string el = $"{match.Value}</SUCCESS>";
                    var reponse = DeserializeZoneEditResultat(el, "SUCCESS");
                    if (reponse.Code == 201)
                        resultats.Message = reponse.Text;
                    resultats.Add(reponse);
                }
            }
            return resultats;
        }

        private static ZoneEditResultat DeserializeZoneEditResultat(string xmlString, string elementName)
        {
            XmlSerializer serializer = new(typeof(ZoneEditResultat), new XmlRootAttribute(elementName));
            using StringReader stringReader = new(xmlString);
            return (ZoneEditResultat)serializer.Deserialize(stringReader);

        }

    }
}
