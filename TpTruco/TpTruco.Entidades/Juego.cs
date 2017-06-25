using System;
using System.Collections.Generic;
using System.Text;



namespace TpTruco.Entidades
{
    public class Juego
    {
        public bool JuegoCompleto { get; set; }

        public Partida partida { get; set; }

        public List<Jugador> ListaJugadores { get; set; }

        public Juego()
        {
            JuegoCompleto = false;

            this.partida = new Partida();

            this.ListaJugadores = new List<Jugador>();
        }


        public void AgregarJugador(string nombre, string id)
        {
            if (JuegoCompleto == false)
            {
                var jugador = new Jugador(nombre,id);

                ListaJugadores.Add(jugador);

                jugador.Orden = ListaJugadores.Count;


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


                if(ListaJugadores.Count == 4)
                {
                    JuegoCompleto = true;
                }
                
                
            }
        }


        public int PuntosEnvido(Equipo equipo)
        {
            
            return 0;
        }

        public Equipo GanadorEnvido() {


            return new Equipo();
        }

        public void ComenzarJuego(int ValorMaximo)
        {
            while(partida.Equipo1.Puntos > ValorMaximo && partida.Equipo2.Puntos > ValorMaximo)
            {
                Jugar();
            }
            //JuegoTerminado();
        }

        public void Jugar()
        {
            //Repartir Mano
            //Desarrollo de la mano (envido, truco, etc)
            //Contar puntos
        }

        //public void JuegoTerminado()
        //{

        //}

    }
}
