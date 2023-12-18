
using System.ComponentModel.DataAnnotations;

namespace Vente.Models
{
    public class Categorie
    {
        [Key]
        public int CategorieID { get; set; }
        public string CategorieName { get; set; }

    }
}
