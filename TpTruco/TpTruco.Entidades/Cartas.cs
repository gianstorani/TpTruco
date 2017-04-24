using System;
using System.Collections.Generic;
using System.Text;

namespace TpTruco.Entidades
{
    public enum Palos { Espada = 1, Basto =2, Oro = 3, Copa = 4};

    class Cartas
    {
        public int Numero { get; set; }
        public Palos Palo { get; set; } 
        
    }
}
