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

        public int Equipo { get; set; }

        public List<Cartas> CartasActuales { get; set; }

        public Jugador(string nombre, string id)
        {
            this.Nombre = nombre;
            this.IdConexion = id;
            this.CartasActuales = new List<Cartas>();
        }
        //

        public int CalcularEnvido()
        {
            int esp=0, bas=0, oro=0, cop = 0;
            bool besp=false, bbas=false, boro=false, bcop = false;

            foreach (Cartas item in CartasActuales)
            {
                switch (item.Palo)
                {
                    case Mazo.Palos.Espada:
                        if (esp != 0 || item.ValorEnvido == 0)
                        {
                            besp = true;
                        }
                        esp += item.ValorEnvido;

                        break;

                    case Mazo.Palos.Basto:
                        if (bas != 0 || item.ValorEnvido == 0)
                        {
                            bbas = true;
                        }
                        bas += item.ValorEnvido;
                        break;

                    case Mazo.Palos.Oro:
                        if (oro != 0 || item.ValorEnvido == 0)
                        {
                            boro = true;
                        }
                        oro += item.ValorEnvido;
                        break;

                    case Mazo.Palos.Copa:
                        if (cop != 0 || item.ValorEnvido == 0)
                        {
                            bcop = true;
                        }
                        cop += item.ValorEnvido;
                        break;
                    default:
                        break;
                }
            }

            if (esp != 0 && besp == true)
            {
                esp += 20;
            }

            if (bas != 0 && bbas == true)
            {
                bas += 20;
            }

            if (cop != 0 && bcop == true)
            {
                cop += 20;
            }

            if (oro != 0 && boro == true)
            {
                oro += 20;
            }

            if (esp>bas && esp>oro && esp>cop)
            {
                return esp;
            }

            if (bas>esp && bas>oro && bas >cop)
            {
                return bas;
            }

            if (oro > esp && oro>bas && oro > cop)
            {
                return oro;
            }
            else
            {
                return cop;
            }
        }
    }
}
