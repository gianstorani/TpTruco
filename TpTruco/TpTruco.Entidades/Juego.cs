using System;
using System.Collections.Generic;
using System.Text;


namespace TpTruco.Entidades
{
    public class Juego
    {
        public bool JuegoCompleto { get; set; }

        public Partida Partida { get; set; }

        public Juego()
        {
            JuegoCompleto = false;
        }

        public void CrearPartida()
        {

        }

        public void AgregarJugador(string nombre)
        {
            if (JuegoCompleto == false)
            {
                var jugador = new Jugador(nombre);

                Partida.ListaJugadores.Add(jugador);

                jugador.Orden = Partida.ListaJugadores.Count;

                switch (jugador.Orden)
                {
                    case 1: jugador.NombreInterno = "User1";
                            break;

                    case 2:
                        jugador.NombreInterno = "User2";
                        break;

                    case 3:
                        jugador.NombreInterno = "User3";
                        break;

                    case 4:
                        jugador.NombreInterno = "User4";
                        break;
                }


                if(Partida.ListaJugadores.Count == 4)
                {
                    JuegoCompleto = true;
                }
                
                
            }
        }


    }
}
