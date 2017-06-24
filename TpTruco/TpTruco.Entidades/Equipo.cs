using System;
using System.Collections.Generic;
using System.Text;

namespace TpTruco.Entidades
{
    public class Equipo
    {
        public string Nombre { get; set; }
        public Jugador J1 { get; set; }
        public Jugador J2 { get; set; }
        public int Puntos { get; set; }


    }
}
