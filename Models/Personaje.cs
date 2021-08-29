﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIDisney.Models
{
    public class Personaje
    {
        [Key]
        public int Id { get; set; }
        public string ImagenPersonaje { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int Peso { get; set; }
        public string Historia { get; set; }
        public string Peliculas { get; set; }
    }
}
