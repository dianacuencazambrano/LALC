using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LALC.Models
{
    public class Practica
    {
        public int PracticaID { get; set; }
        public int CantidadConceptos { get; set; }

        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
    }
}

//hola mundo :D