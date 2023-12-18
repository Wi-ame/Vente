namespace Vente.Models
{
    public class Proprietaire
    {
       
            // Nouvelles propriétés spécifiques aux propriétaires
            public string NomEntreprise { get; set; }
            public string AdresseEntreprise { get; set; }

            // Clé étrangère
            public int? IDUtilisateur { get; set; }

            // Propriété de navigation
            public Utilisateurs Utilisateur { get; set; }
        

    }
}
