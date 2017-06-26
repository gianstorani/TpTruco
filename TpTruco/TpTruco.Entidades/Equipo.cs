using System;
using System.Collections.Generic;
using System.Text;

namespace TpTruco.Entidades
{
    public class Equipo
    {
        public string Nombre { get; set; }
        public List<Jugador> JugadoresDelEquipo { get; set; }
        public int Puntos { get; set; }

        public Equipo()
        {
            this.JugadoresDelEquipo = new List<Jugador>();
        }


    }
}
