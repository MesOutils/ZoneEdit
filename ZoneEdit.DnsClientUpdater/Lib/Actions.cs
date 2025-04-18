﻿using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;

namespace ZoneEdit.DnsClientUpdater.Lib
{
    internal class Actions
    {
        internal static bool MettreAJourDns(string identifiant,
                                   string motDePasse,
                                   string url,
                                   List<string> dns)
        {
            if (string.IsNullOrWhiteSpace(identifiant) ||
                string.IsNullOrWhiteSpace(motDePasse) ||
                string.IsNullOrWhiteSpace(url) ||
                dns == null)
                throw new Entites.ExceptionFonctionnelle(Entites.Messages.ErreurFonctionnelles.ConfigDataInvalide);

            // Construire l'url
            var urlParam = string.Concat("?host=", string.Join(',', dns));//, string.Format("&dnsto={0}", IPAddress));

            // Appeler le service
            HttpResponseMessage reponse;
            Entites.ZoneEditResultats resultats;
            string retour;
            using (HttpClient httpClient = new())
            {
                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{identifiant}:{motDePasse}")));
                httpClient.BaseAddress = new Uri(url);

                reponse = httpClient.GetAsync(urlParam).Result;
                retour = reponse.Content.ReadAsStringAsync().Result;
            }
            // Interpréter le retour.
            resultats = Entites.ZoneEditResultat.LireXml(retour);

            if (reponse.StatusCode == HttpStatusCode.OK ||
                reponse.StatusCode == (HttpStatusCode)201)
            {
                if (resultats.Success)
                    return true;
                else
                    throw new Entites.ExceptionActionMajDns(resultats.Message, reponse.StatusCode);
            }
            else
            {
                throw new Entites.ExceptionActionMajDns(resultats.Message, reponse.StatusCode, retour);
            }
        }

        internal static string ObtenirIPSelonUrl(string? url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new Entites.ExceptionFonctionnelle(Entites.Messages.ErreurFonctionnelles.UrlIpCheckerVide);
            
            HttpResponseMessage reponse;
            string retour;
            using (HttpClient httpClient = new())
            {
                httpClient.BaseAddress = new Uri(url);

                reponse = httpClient.GetAsync("").Result;
                retour = reponse.Content.ReadAsStringAsync().Result;
            }

            if (reponse.StatusCode != HttpStatusCode.OK)
                throw new Exception(
@$"Erreur imprévue à l'obtention du IP. 

Plusieurs éléments peuvent causer l'erreur.
- Vérifier la validité de l'url;
- Vérifier si le site est toujours fonctionnel;
- Vérifier votre connexion internet;
- Investiguer l'erreur suivante:
    StatutCode: {reponse.StatusCode}.
    Body: {reponse.Content?.ToString()}.
    Raison: {reponse.ReasonPhrase}.");

            var regex = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
            var mc = regex.Matches(retour);
            var ip = string.Empty;

            // Parcourir pour trouver l'IP.
            foreach (Match m in mc)
            {
                if (m.Groups.Count > 0)
                {
                    ip = m.Groups[0].ToString();
                    break;
                }
            }
            return ip;
        }
    }
}
