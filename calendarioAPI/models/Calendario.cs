using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using calendarioAPI.Interface;

namespace calendarioAPI.models
{
    public class Calendario
    {
        public string  titulo { get; set; }
        public string servidor { get; set; }
        public float cargaHorariaDia { get; set; }
        public float cargaHorariaMes { get; set; }
    }
}