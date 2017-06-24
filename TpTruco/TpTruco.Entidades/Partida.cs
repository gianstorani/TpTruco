using System;
using System.Collections.Generic;
using System.Text;
using TpTruco.Entidades;


namespace TpTruco.Entidades
{
    public class Partida
    {
        public List<Jugador> ListaJugadores { get; set; }
        public Equipo Equipo1 { get; set; }
        public Equipo Equipo2 { get; set; }
        public List<Mano> ManosPartida { get; set; }
        public Mazo MazoPartida { get; set; }



    }
}
