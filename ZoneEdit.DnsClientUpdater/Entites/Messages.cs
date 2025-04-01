namespace ZoneEdit.DnsClientUpdater.Entites
{
    internal class Messages
    {
        internal class ErreurFonctionnelles
        {
            public const string ConfigDataInvalide =
@"Une ou plusieurs éléments de configuration sont invalides. 
Veuillez alimenter adéquatement les configurations.
                  
 - Identifiant est obligatoire
 - Mot de passe est obligatoire
 - Url Ip Check est obligatoire
 - Url du service de m.a.j. DNS est obligatoire
 - Un DNS est obligatoire
 - L'intervale de la vérification du IP est obligatoire
 - L'intervale de la mise à jour du DNS est obligatoire";

            public const string UrlIpCheckerVide = "L'URL du service de vérification de l'adresse IP est vide.";
            public const string ConfigEnCoursChangement = @"Une configuration est en cours de changement. Impossible d'exécuter l'opération.";
        }

        internal class Confirmation
        {
            public const string SauvegarderConfig = @"Des configurations n'ont pas été sauvegardées. Voulez-vous les sauvegarder avant de quitter?";
        }

        internal class Statut
        {
            public class Vide
            {
                public const string Id = "";
                public const string Libelle = "";
            }
            public class NonSauvegarde
            {
                public const string Id = "NotSave";
                public const string Libelle = "Configurations non sauvegardées!";
            }


            internal class Sauvegarde
            {
                public const string Id = "Saved";
                public const string Libelle = "Configurations sauvegardées avec succès";
            }
            internal class SauvegardeAnnulee
            {
                public const string Id = "Canceled";
                public const string Libelle = "Sauvegarde annulée. Réinitialisation des valeurs effectuées avec succès.";
            }
        }

        internal const string SuccesActionMajDns = "Mise à jour DNS effectuée avec succès.";
    }
}
