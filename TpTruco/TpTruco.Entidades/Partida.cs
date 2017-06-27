using System;
using System.Collections.Generic;
using System.Linq;
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
        public Partida()
        {
            this.ListaJugadores = new List<Jugador>();
            this.ManosPartida = new List<Mano>();
            this.Equipo1 = new Equipo();
            this.Equipo2 = new Equipo();
        }

        public void Repartir()
        {
            var nuevaMano = new Mano();
            var MazoPartida = new Mazo();
            var cartas = MazoPartida.MazoCartas;
            Random rng = new Random();

            int x = 3;
            bool cambio = false;
            while (x>0)
            {
                x = x - 1;
                foreach (Jugador jugador in ListaJugadores)
                {
                    while (cambio == false)
                    {

                        int puntero = rng.Next(0, 39);

                        if (cartas[puntero].Dispobile == true)
                        {
                            jugador.CartasActuales.Add(cartas[puntero]);
                            cartas[puntero].Dispobile = false;
                            cambio = true;
                        }
                    }
                    cambio = false;
                }
            }

            ManosPartida.Add(nuevaMano);
        }
    }    
}
