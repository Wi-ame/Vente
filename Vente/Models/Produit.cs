using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace Vente.Models
{
    public class Produit
    {
        public int  IdPr { get; set; }   
        public string Name { get; set; }    
        public string Description { get; set; }
        public double prix { get; set; }
       
        [ForeignKey("Categorie")]
        public int IDC { get; set; }
        public Categorie Categories { get; set; }
        [ForeignKey("Proprietaire")]
        public int IDP { get; set; }    
        public Proprietaire proprietaires { get; set; }  

        public DateTime DateExpiration { get; set; }
        public byte[] ImageData { get; set; } 



    }
}
