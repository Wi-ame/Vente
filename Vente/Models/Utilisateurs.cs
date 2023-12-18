
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Vente.Models
{
    public class Utilisateurs
    {
        [Key]
       public int ID { get; set; }  
        public string Nom {  get; set; }    
        public string Prenom { get; set; }  
        public string Email { get; set; }   
        public string Tel { get; set; }
        public string password { get; set; }   
        
    }
}
