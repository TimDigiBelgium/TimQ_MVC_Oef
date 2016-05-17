using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimQ_MVC_Oef.Models
{
    public class Categorie
    {
        public int CategorieID { get; set; }

        public string Naam { get; set; }

        public virtual List<Component> Componenten { get; set; }
    }

}