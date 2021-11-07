using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LALC.Models
{
    public class Categoria
    {
        [Required(ErrorMessage ="Este campo es obligatorio")]
        public int CategoriaID { get; set; }
        [Required(ErrorMessage ="Este campo es obligatorio")]
        [MinLength(1)]
        public String Nombre { get; set; }
        public String Color { get; set; }
        public String Descripcion { get; set; }
        public Boolean esPrioritaria { get; set; }

        public virtual ICollection<Categoria> Subcategoria { get; set; }
    }
}