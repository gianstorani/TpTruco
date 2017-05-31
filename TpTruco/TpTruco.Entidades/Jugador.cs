using System;
using System.Collections.Generic;
using System.Text;

namespace TpTruco.Entidades
{
    class Jugador
    {
        public string Nombre { get; set; }

        public string NombreInterno { get; set; } //user1 - user2...

        public string IdConexion { get; set; }

        public int Orden { get; set; }

        public Jugador(string nombre)
        {
            this.Nombre = nombre;
        }

    }
}
