using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LALC.Models
{
    public class Subcategoria
    {
        public int SubcategoriaID { get; set; }
        public int CategoriaID { get; set; }
        public String Nombre { get; set; }
        public String Color { get; set; }
        public String Descripcion { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<Concepto> Concepto { get; set; }
    }
}