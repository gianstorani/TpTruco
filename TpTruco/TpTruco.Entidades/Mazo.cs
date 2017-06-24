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
            MazoCartas.Add(new Cartas("e1", 10 ));
        }
    }
}
