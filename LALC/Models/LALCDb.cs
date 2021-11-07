﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LALC.Models
{
    public class LALCDb : DbContext
    {
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Concepto> Concepto { get; set; }

        public DbSet<Subcategoria> Subcategoria { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        public System.Data.Entity.DbSet<LALC.Models.Practica> Practicas { get; set; }
    }
}