using System;
using System.Collections.Generic;
using System.Text;

namespace TpTruco.Entidades
{
    public class Mano
    {

        public void Repartir()
        {
            List<Cartas> MazoCartas;
        }

        public void Mezclar()
        {
            var mazo = new Mazo();
            var cartas = mazo.MazoCartas;
            Shuffle(cartas);
        }
        private Random rng = new Random();

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
