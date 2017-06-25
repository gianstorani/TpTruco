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

        public void Repartir()
        {
            var nuevaMano = new Mano();
            var cartas = MazoPartida.MazoCartas;
            Shuffle(cartas);

            var jugadoresOrdenados = new List<Jugador>();
            jugadoresOrdenados.AddRange(ListaJugadores.OrderBy(x => x.Orden));

            int xi = 4;
            while(xi > 0)
            {
                xi = xi - 1;
                foreach (var jugador in jugadoresOrdenados)
                {
                    //asignar una carta a cada jugador, deshabilitar la carta
                }
            }

            ManosPartida.Add(nuevaMano);

        }

        public Random rng = new Random();
        public void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    
}
