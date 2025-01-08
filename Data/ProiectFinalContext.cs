using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectFinal.Models;

namespace ProiectFinal.Data
{
    public class ProiectFinalContext : DbContext
    {
        public ProiectFinalContext (DbContextOptions<ProiectFinalContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectFinal.Models.Cal> Cal { get; set; } = default!;
        public DbSet<ProiectFinal.Models.Instructor> Instructor { get; set; } = default!;
        public DbSet<ProiectFinal.Models.Categorie> Categorie { get; set; } = default!;
    }
}
