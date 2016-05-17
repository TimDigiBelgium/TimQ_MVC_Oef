using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TimQ_MVC_Oef.Models
{
    public class Component
    {
        public int ComponentID { get; set; }

        public int CategorieID { get; set; }

        
        public virtual Categorie Categorie { get; set; }

        [Required]
        public string Naam { get; set; }

        public string DataSheetLink { get; set; }


        public int? Aantal { get; set; }

        public decimal Aankoopprijs { get; set; }


    }

}