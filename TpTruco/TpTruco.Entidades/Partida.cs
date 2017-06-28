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
        public List<Ronda> RondasPartida { get; set; }
        public Mazo MazoPartida { get; set; }
        public int Repartidor { get; set; }
        public bool JuegoTerminado { get; set; }
        public Equipo GanadorPartida { get; set; }

        public Partida()
        {
            this.ListaJugadores = new List<Jugador>();
            this.RondasPartida = new List<Ronda>();
            this.Equipo1 = new Equipo();
            this.Equipo2 = new Equipo();
            this.Repartidor = 0;
            this.JuegoTerminado = false;
        }

        public void AumentarRepartidor()
        {
            this.Repartidor= this.Repartidor + 1;
            if (this.Repartidor > 4) 
            {
                this.Repartidor = 1;
            }
        }

        public void Repartir()
        {
            foreach (Jugador jugador in ListaJugadores)
            {
                jugador.CartasActuales.Clear();
            }

            //if (RondasPartida.Count == 0)
            //{
                AumentarRepartidor();
            //}
            //else
            //{
            //    this.Repartidor = RondasPartida[RondasPartida.Count - 1].Turno;
            //}
            var nuevaMano = new Ronda(this.Repartidor);
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

            RondasPartida.Add(nuevaMano);
        }
    }    
}
