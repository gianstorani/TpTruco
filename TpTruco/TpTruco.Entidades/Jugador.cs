using System;
using System.Collections.Generic;
using System.Text;

namespace TpTruco.Entidades
{
    class Jugador
    {
        public string Nombre { get; set; }

        public bool TieneLaMano { get; set; }

        public List<Cartas> Cartas { get; set; }

    }
}
