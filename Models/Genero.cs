using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIDisney.Models
{
    public class Genero
    {
        [Key]
        public int Id { get; set; }
        public string ImagenGenero { get; set; }
        public string Nombre { get; set; }
        public string PeliculasAsociadas { get; set; }
    }
}
