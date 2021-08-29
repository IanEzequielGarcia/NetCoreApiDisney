using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIDisney.Models
{
    public class Pelicula
    {
        [Key]
        public int Id { get; set; }
        public string ImagenPelicula { get; set; }
        public string Titulo { get; set; }
        public int FechaEstreno { get; set; }
        [Range(1,5,ErrorMessage ="Las calificaciones deben ser entre 1 y 5.")]
        public int Calificacion { get; set; }
        public string PeronsajesAsociados { get; set; }
    }
}
