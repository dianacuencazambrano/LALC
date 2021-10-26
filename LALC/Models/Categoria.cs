using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LALC.Models
{
    public class Categoria
    {
        public int CategoriaID { get; set; }
        public String Nombre { get; set; }
        public String Color { get; set; }
        public String Descripcion { get; set; }
        public Boolean esPrioritaria { get; set; }

        public virtual ICollection<Categoria> Subcategoria { get; set; }
    }
}