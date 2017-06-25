using System;
using System.Collections.Generic;
using System.Text;

namespace TpTruco.Entidades
{
    public class Mazo
    {
        public List<Cartas> MazoCartas { get; set; }

        public Mazo()
        {
            MazoCartas.Add(new Cartas("1Espada", 14,1, Palos.Espada));
            MazoCartas.Add(new Cartas("2Espada", 9,2, Palos.Espada));
            MazoCartas.Add(new Cartas("3Espada", 10,3, Palos.Espada));
            MazoCartas.Add(new Cartas("4Espada", 1,4, Palos.Espada));
            MazoCartas.Add(new Cartas("5Espada", 2,5, Palos.Espada));
            MazoCartas.Add(new Cartas("6Espada", 3,6, Palos.Espada));
            MazoCartas.Add(new Cartas("7Espada", 12,7, Palos.Espada));
            MazoCartas.Add(new Cartas("10Espada", 5,0, Palos.Espada));
            MazoCartas.Add(new Cartas("11Espada", 6,0, Palos.Espada));
            MazoCartas.Add(new Cartas("12Espada", 7,0, Palos.Espada));
            MazoCartas.Add(new Cartas("1Basto", 13,1, Palos.Basto));
            MazoCartas.Add(new Cartas("2Basto", 9, 2, Palos.Basto));
            MazoCartas.Add(new Cartas("3Basto", 10,3, Palos.Basto));
            MazoCartas.Add(new Cartas("4Basto", 1, 4, Palos.Basto));
            MazoCartas.Add(new Cartas("5Basto", 2, 5, Palos.Basto));
            MazoCartas.Add(new Cartas("6Basto", 3, 6, Palos.Basto));
            MazoCartas.Add(new Cartas("7Basto", 4, 7, Palos.Basto));
            MazoCartas.Add(new Cartas("10Basto", 5,0, Palos.Basto));
            MazoCartas.Add(new Cartas("11Basto", 6,0, Palos.Basto));
            MazoCartas.Add(new Cartas("12Basto", 7,0, Palos.Basto));
            MazoCartas.Add(new Cartas("1Copa", 8, 1, Palos.Copa));
            MazoCartas.Add(new Cartas("2Copa", 9, 2, Palos.Copa));
            MazoCartas.Add(new Cartas("3Copa", 10,3, Palos.Copa));
            MazoCartas.Add(new Cartas("4Copa", 1, 4, Palos.Copa));
            MazoCartas.Add(new Cartas("5Copa", 2, 5, Palos.Copa));
            MazoCartas.Add(new Cartas("6Copa", 3, 6, Palos.Copa));
            MazoCartas.Add(new Cartas("7Copa", 4, 7, Palos.Copa));
            MazoCartas.Add(new Cartas("10Copa", 5,0, Palos.Copa));
            MazoCartas.Add(new Cartas("11Copa", 6,0, Palos.Copa));
            MazoCartas.Add(new Cartas("12Copa", 7,0, Palos.Copa));
            MazoCartas.Add(new Cartas("1Oro", 8, 1, Palos.Oro));
            MazoCartas.Add(new Cartas("2Oro", 9, 2, Palos.Oro));
            MazoCartas.Add(new Cartas("3Oro", 10,3, Palos.Oro));
            MazoCartas.Add(new Cartas("4Oro", 1, 4, Palos.Oro));
            MazoCartas.Add(new Cartas("5Oro", 2, 5, Palos.Oro));
            MazoCartas.Add(new Cartas("6Oro", 3, 6, Palos.Oro));
            MazoCartas.Add(new Cartas("7Oro", 11,7, Palos.Oro));
            MazoCartas.Add(new Cartas("10Oro", 5,0, Palos.Oro));
            MazoCartas.Add(new Cartas("11Oro", 6,0, Palos.Oro));
            MazoCartas.Add(new Cartas("12Oro", 7,0, Palos.Oro));
        }
        //
        public enum Palos
        {
            Espada, Basto, Oro, Copa
        }
    }
}
