using System;
using System.Collections.Generic;
using System.Text;

namespace TpTruco.Entidades
{
    public class Jugador
    {
        public string Nombre { get; set; }

        public string NombreInterno { get; set; } //user1 - user2...

        public string IdConexion { get; set; }

        public int Orden { get; set; }

        public List<Cartas> CartasActuales { get; set; }

        public Jugador(string nombre, string id)
        {
            this.Nombre = nombre;
            this.IdConexion = id;
        }
        //
    }
}
