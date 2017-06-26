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
            this.MazoCartas = new List<Cartas>();
            MazoCartas.Add(new Cartas("1Espada", 14,1, Palos.Espada, "Images/e1.jpg"));
            MazoCartas.Add(new Cartas("2Espada", 9,2, Palos.Espada, "Images/e2.jpg"));
            MazoCartas.Add(new Cartas("3Espada", 10,3, Palos.Espada, "Images/e3.jpg"));
            MazoCartas.Add(new Cartas("4Espada", 1,4, Palos.Espada, "Images/e4.jpg"));
            MazoCartas.Add(new Cartas("5Espada", 2,5, Palos.Espada, "Images/e5.jpg"));
            MazoCartas.Add(new Cartas("6Espada", 3,6, Palos.Espada, "Images/e6.jpg"));
            MazoCartas.Add(new Cartas("7Espada", 12,7, Palos.Espada, "Images/e7.jpg"));
            MazoCartas.Add(new Cartas("10Espada", 5,0, Palos.Espada, "Images/e10.jpg"));
            MazoCartas.Add(new Cartas("11Espada", 6,0, Palos.Espada, "Images/e11.jpg"));
            MazoCartas.Add(new Cartas("12Espada", 7,0, Palos.Espada, "Images/e12.jpg"));
            MazoCartas.Add(new Cartas("1Basto", 13,1, Palos.Basto, "Images/b1.jpg"));
            MazoCartas.Add(new Cartas("2Basto", 9, 2, Palos.Basto, "Images/b2.jpg"));
            MazoCartas.Add(new Cartas("3Basto", 10,3, Palos.Basto, "Images/b3.jpg"));
            MazoCartas.Add(new Cartas("4Basto", 1, 4, Palos.Basto, "Images/b4.jpg"));
            MazoCartas.Add(new Cartas("5Basto", 2, 5, Palos.Basto, "Images/b5.jpg"));
            MazoCartas.Add(new Cartas("6Basto", 3, 6, Palos.Basto, "Images/b6.jpg"));
            MazoCartas.Add(new Cartas("7Basto", 4, 7, Palos.Basto, "Images/b7.jpg"));
            MazoCartas.Add(new Cartas("10Basto", 5,0, Palos.Basto, "Images/b10.jpg"));
            MazoCartas.Add(new Cartas("11Basto", 6,0, Palos.Basto, "Images/b11.jpg"));
            MazoCartas.Add(new Cartas("12Basto", 7,0, Palos.Basto, "Images/b12.jpg"));
            MazoCartas.Add(new Cartas("1Copa", 8, 1, Palos.Copa, "Images/c1.jpg"));
            MazoCartas.Add(new Cartas("2Copa", 9, 2, Palos.Copa, "Images/c2.jpg"));
            MazoCartas.Add(new Cartas("3Copa", 10,3, Palos.Copa, "Images/c3.jpg"));
            MazoCartas.Add(new Cartas("4Copa", 1, 4, Palos.Copa, "Images/c4.jpg"));
            MazoCartas.Add(new Cartas("5Copa", 2, 5, Palos.Copa, "Images/c5.jpg"));
            MazoCartas.Add(new Cartas("6Copa", 3, 6, Palos.Copa, "Images/c6.jpg"));
            MazoCartas.Add(new Cartas("7Copa", 4, 7, Palos.Copa, "Images/c7.jpg"));
            MazoCartas.Add(new Cartas("10Copa", 5,0, Palos.Copa, "Images/c10.jpg"));
            MazoCartas.Add(new Cartas("11Copa", 6,0, Palos.Copa, "Images/c11.jpg"));
            MazoCartas.Add(new Cartas("12Copa", 7,0, Palos.Copa, "Images/c12.jpg"));
            MazoCartas.Add(new Cartas("1Oro", 8, 1, Palos.Oro, "Images/o1.jpg"));
            MazoCartas.Add(new Cartas("2Oro", 9, 2, Palos.Oro, "Images/o2.jpg"));
            MazoCartas.Add(new Cartas("3Oro", 10,3, Palos.Oro, "Images/o3.jpg"));
            MazoCartas.Add(new Cartas("4Oro", 1, 4, Palos.Oro, "Images/o4.jpg"));
            MazoCartas.Add(new Cartas("5Oro", 2, 5, Palos.Oro, "Images/o5.jpg"));
            MazoCartas.Add(new Cartas("6Oro", 3, 6, Palos.Oro, "Images/o6.jpg"));
            MazoCartas.Add(new Cartas("7Oro", 11,7, Palos.Oro, "Images/o7.jpg"));
            MazoCartas.Add(new Cartas("10Oro", 5,0, Palos.Oro, "Images/o10.jpg"));
            MazoCartas.Add(new Cartas("11Oro", 6,0, Palos.Oro, "Images/o11.jpg"));
            MazoCartas.Add(new Cartas("12Oro", 7,0, Palos.Oro, "Images/o12.jpg"));
        }
        //
        public enum Palos
        {
            Espada, Basto, Oro, Copa
        }
    }
}
