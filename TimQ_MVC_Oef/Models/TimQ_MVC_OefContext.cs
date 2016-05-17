using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TimQ_MVC_Oef.Models
{
    public class TimQ_MVC_OefContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TimQ_MVC_OefContext() : base("name=TimQ_MVC_OefContext")
        {
        }

        public System.Data.Entity.DbSet<TimQ_MVC_Oef.Models.Categorie> Categories { get; set; }

        public System.Data.Entity.DbSet<TimQ_MVC_Oef.Models.Component> Components { get; set; }
    }
}
