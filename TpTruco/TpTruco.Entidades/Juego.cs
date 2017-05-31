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



                if(Partida.ListaJugadores.Count == 4)
                {
                    JuegoCompleto = true;
                }
                
                
            }
        }


    }
}
