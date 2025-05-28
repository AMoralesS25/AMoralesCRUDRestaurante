using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Restaurante
    {
        public int IdRestaurante { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public string Eslogan { get; set; }
        public string FechaInaguracion { get; set; }
        public List<Object> Restaurantes { get; set; }
    }
}
