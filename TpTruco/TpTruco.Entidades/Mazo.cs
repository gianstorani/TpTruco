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

            MazoCartas.Add(new Cartas("e1", 14, 1, "Espada"));
            MazoCartas.Add(new Cartas("e2", 9));
            MazoCartas.Add(new Cartas("e3", 10));
            MazoCartas.Add(new Cartas("e4", 1));
            MazoCartas.Add(new Cartas("e5", 2));
            MazoCartas.Add(new Cartas("e6", 3));
            MazoCartas.Add(new Cartas("e7", 12));
            MazoCartas.Add(new Cartas("e10", 5));
            MazoCartas.Add(new Cartas("e11", 6));
            MazoCartas.Add(new Cartas("e12", 7));
            MazoCartas.Add(new Cartas("b1", 13));
            MazoCartas.Add(new Cartas("b2", 9));
            MazoCartas.Add(new Cartas("b3", 10));
            MazoCartas.Add(new Cartas("b4", 1));
            MazoCartas.Add(new Cartas("b5", 2));
            MazoCartas.Add(new Cartas("b6", 3));
            MazoCartas.Add(new Cartas("b7", 4));
            MazoCartas.Add(new Cartas("b10", 5));
            MazoCartas.Add(new Cartas("b11", 6));
            MazoCartas.Add(new Cartas("b12", 7));
            MazoCartas.Add(new Cartas("c1", 8));
            MazoCartas.Add(new Cartas("c2", 9));
            MazoCartas.Add(new Cartas("c3", 10));
            MazoCartas.Add(new Cartas("c4", 1));
            MazoCartas.Add(new Cartas("c5", 2));
            MazoCartas.Add(new Cartas("c6", 3));
            MazoCartas.Add(new Cartas("c7", 4));
            MazoCartas.Add(new Cartas("c10", 5));
            MazoCartas.Add(new Cartas("c11", 6));
            MazoCartas.Add(new Cartas("c12", 7));
            MazoCartas.Add(new Cartas("o1", 8));
            MazoCartas.Add(new Cartas("o2", 9));
            MazoCartas.Add(new Cartas("o3", 10));
            MazoCartas.Add(new Cartas("o4", 1));
            MazoCartas.Add(new Cartas("o5", 2));
            MazoCartas.Add(new Cartas("o6", 3));
            MazoCartas.Add(new Cartas("o7", 11));
            MazoCartas.Add(new Cartas("o10", 5));
            MazoCartas.Add(new Cartas("o11", 6));
            MazoCartas.Add(new Cartas("o12", 7));

        }
    }
}
