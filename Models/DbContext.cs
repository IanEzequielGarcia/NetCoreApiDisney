using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDisney.Models;

namespace APIDisney.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Personaje> Personaje { get; set; }
        public DbSet<APIDisney.Models.Pelicula> Pelicula { get; set; }
        public DbSet<APIDisney.Models.Genero> Genero { get; set; }
    }
}
