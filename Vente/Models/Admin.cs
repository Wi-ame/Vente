using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vente.Models
{
    public class Admin 
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("ID")] // Clé étrangère faisant référence à la table Utilisateurs
        public Utilisateurs Utilisateur { get; set; }
    }
}
