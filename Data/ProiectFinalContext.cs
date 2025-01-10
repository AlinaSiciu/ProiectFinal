using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectFinal.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProiectFinal.Data
{
    public class ProiectFinalContext : IdentityDbContext<IdentityUser>
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
