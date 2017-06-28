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

            this.Partida = new Partida();

        }


        public void AgregarJugador(string nombre, string id)
        {
            if (JuegoCompleto == false)
            {
                var jugador = new Jugador(nombre,id);

                Partida.ListaJugadores.Add(jugador);

                jugador.Orden = Partida.ListaJugadores.Count;


                switch (jugador.Orden)
                {
                    case 1: jugador.NombreInterno = "user1";
                        jugador.Equipo = 1;
                        Partida.Equipo1.JugadoresDelEquipo.Add(jugador);
                        
                            break;

                    case 2:
                        jugador.NombreInterno = "user2";
                        jugador.Equipo = 2;
                        Partida.Equipo2.JugadoresDelEquipo.Add(jugador);

                        break;

                    case 3:
                        jugador.NombreInterno = "user3";
                        jugador.Equipo = 1;
                        Partida.Equipo1.JugadoresDelEquipo.Add(jugador);

                        break;

                    case 4:
                        jugador.NombreInterno = "user4";
                        jugador.Equipo = 2;
                        Partida.Equipo2.JugadoresDelEquipo.Add(jugador);

                        break;
                }

                if(Partida.ListaJugadores.Count == 4)
                {
                    JuegoCompleto = true;
                }      
            }
        }

        public int PuntosEnvido(Equipo equipo)
        {
            int puntos = 0;
            
            foreach (Jugador item in equipo.JugadoresDelEquipo)
            {
                if (item.CalcularEnvido() > puntos)
                {
                    puntos = item.CalcularEnvido();
                }
                
            }
            return puntos;
        }

        public Equipo GanadorEnvido(Equipo e1,Equipo e2)
        {
            if (PuntosEnvido(e1) > PuntosEnvido(e2))
            {
                return e1;
            }
            else
            {
                return e2;
            }
        }


        //public void JuegoTerminado()
        //{

        //}

    }
}
