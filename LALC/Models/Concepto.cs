using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LALC.Models
{
    public class Concepto
    {
        public int ConceptoID { get; set; }
        public int SubcategoriaID { get; set; }
        public String Definicion { get; set; }
        public String Titulo { get; set; }
        public virtual Subcategoria Subcategoria { get; set; }

    }
}