using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TpTruco.Entidades;

namespace Truco.WebSite.Hubs
{
    [HubName("truco")]
    public class Truco : Hub
    {

        public int ValorMaximo = 18;

        public static Juego juego = new Juego();

        public void AgregarJugador(string nombre)
        {
            // Si el juego esta completo...
            if (juego.JuegoCompleto)
            {
                Clients.Caller.mostrarmensaje("El juego ya está completo!");
                
            }
            else // Sino ...
            {
                juego.AgregarJugador(nombre, Context.ConnectionId);
                Clients.Others.mostrarnuevousuario(nombre);

                Clients.Caller.mostrarmensaje("Te uniste a la partida!");

                // Por cada jugador - Les avisa que hay un nuevo jugador asdasd
                foreach (Jugador item in juego.Partida.ListaJugadores)
                {
                    Clients.All.mostrarnombre(item);
                }

                // Si es el ultimo jugador...
                if (juego.Partida.ListaJugadores.Count == 4 )
                {                
                    
                        Clients.All.mostrarpuntos("E1", 0);
                        Clients.All.mostrarpuntos("E2", 0);

                        //ComenzarJuego(ValorMaximo);

                        Repartir();
                    
                }
            }

            
            
        }


        //public void ComenzarJuego(int ValorMaximo)
        //{
           
          
        //    while (juego.Partida.Equipo1.Puntos < ValorMaximo && juego.Partida.Equipo2.Puntos < ValorMaximo)
        //    {
        //        Jugar();
        //    }
        //    //JuegoTerminado();
        //}

        //public void Jugar()
        //{
        //    //
        //    //Repartir Mano            
        //    juego.Partida.Repartir();
        //    Repartir();
            
        //    //Desarrollo de la mano (envido, truco, etc)
        //    while (juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].Ganador == false)
        //    {        
        //        juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].Ganador = true;//solo para cortar 
        //    }
        //    //Contar puntos
        //}

        public void JugarCarta(string codCarta)
        {
            var j = juego.Partida.ListaJugadores.Single(x => x.IdConexion == Context.ConnectionId);
            var c = j.CartasActuales.Single(x => x.Codigo == codCarta);
            var ronda = juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1];

            Clients.All.mostrarCarta(c, j.NombreInterno, ronda.Manos);

            ronda.CartasEnMesa[ronda.Manos - 1, j.Orden - 1] = c;

            Clients.Client(j.IdConexion).deshabilitarMovimientos();

            ronda.AumentarTurno();//Paso el turno

            //cuando ya jugaron los 4, sacar al equipo ganador
            if (ronda.Turno == ronda.PrimeroQueJugo)
            {
                if (ronda.GanadorMano(ronda.Manos-1) == 1 || ronda.GanadorMano(ronda.Manos-1) == 3 )
                {
                    switch (ronda.Manos)
                    {
                        case 1:
                            ronda.GanadorR1 = juego.Partida.Equipo1;
                            break;
                        case 2:
                            ronda.GanadorR2 = juego.Partida.Equipo1;
                            break;
                        case 3:
                            ronda.GanadorR3 = juego.Partida.Equipo1;
                            break;

                    }
                }
                else
                {
                    switch (ronda.Manos)
                    {
                        case 1:
                            ronda.GanadorR1 = juego.Partida.Equipo2;
                            break;
                        case 2:
                            ronda.GanadorR2 = juego.Partida.Equipo2;
                            break;
                        case 3:
                            ronda.GanadorR3 = juego.Partida.Equipo2;
                            break;

                    }
                }
             
                //igualar primero que jugo al ganador 
                ronda.PrimeroQueJugo = ronda.GanadorMano(ronda.Manos - 1);
                //Darle el turno al ganador
                ronda.Turno = ronda.PrimeroQueJugo;
                //aumentar la mano 
                ronda.Manos++;
            }

            //Deshabilto a todos
            Clients.All.desabilitarMovimientos();
            Clients.All.hideEnvidoOptions();
            Clients.All.hideTrucoBotton();
            Clients.All.hideReTrucoBotton();
            Clients.All.hideVale4Botton();

            //Habilito al proximo jugador
            var jug = juego.Partida.ListaJugadores.Single(x => x.Orden == ronda.Turno);            
            
            Clients.Client(jug.IdConexion).habilitarMovimientos();
            Clients.Client(jug.IdConexion).hideEnvidoEnvidoBotton();
            Clients.Client(jug.IdConexion).hideVale4Botton();
            Clients.Client(jug.IdConexion).hideReTrucoBotton();
            Clients.Client(jug.IdConexion).showEnvidoBotton();
            Clients.Client(jug.IdConexion).showTrucoBotton();
            Clients.Client(jug.IdConexion).showRealEnvidoBotton();
            Clients.Client(jug.IdConexion).showFaltaEnvidoBotton();
            
            
        }

        //public void cantar(string accion)
        //{
        //    Clients.Others.mostrarmensaje("Jugador X canto ACCION");
        //    Clients.Caller.mostrarmensaje("Yo cante ACCION");

        //    Clients.Client(jugador.IdConexion).deshabilitarMovimientos();

        //    // Si el juego termino...
        //    Clients.Client(jugador.IdConexion).mostrarMensajeFinal(true); // GANADOR
        //    Clients.Client(jugador.IdConexion).mostrarMensajeFinal(false); // PERDEDOR
        //    Clients.All.deshabilitarMovimientos();

        //    // Sino
        //    Clients.All.limpiarpuntos();

        //    // Y mostrar puntos y repartir.


        //    switch (accion)
        //    {
        //        case "me voy al mazo":
        //            break;
        //        case "envido":
        //            Clients.All.hidemazo();
        //            juego.Partida.ManosPartida[juego.Partida.ManosPartida.Count - 1].Envido = true;
        //            break;
        //        case "envidoenvido":
        //            Clients.All.hidemazo();
        //            break;
        //        case "faltaenvido":
        //            Clients.All.hidemazo();
        //            break;
        //        case "realenvido":
        //            Clients.All.hidemazo();
        //            break;
        //        case "truco":
        //            break;
        //        case "retruco":
        //            break;
        //        case "vale4":
        //            break;
        //    }
        //}

        //public void EjecutarAccion(string accion, bool confirmacion)
        //{
        //    // confirmacion == true => Acepto la acción.
        //    Clients.All.mostrarmensaje("Jugador X acepto/rechazo la ACCION");

        //    switch (accion)
        //    {
        //        case "Envido":
        //            Clients.All.showmazo();
        //            Clients.Client(jugador.IdConexion).habilitarMovimientos();
        //            break;
        //        case "EnvidoEnvido":
        //            Clients.All.showmazo();
        //            Clients.Client(jugador.IdConexion).habilitarMovimientos();
        //            break;
        //        case "RealEnvido":
        //            Clients.All.showmazo();
        //            Clients.Client(jugador.IdConexion).habilitarMovimientos();
        //            break;
        //        case "FaltaEnvido":
        //            Clients.All.showmazo();
        //            Clients.Client(jugador.IdConexion).habilitarMovimientos();
        //            break;
        //        case "Truco":
        //            break;
        //        case "ReTruco":
        //            break;
        //        case "Vale4":
        //            break;
        //    }
        //}

        //public void JugarCarta(string codigoCarta)
        //{
        //    Clients.All.mostrarCarta(carta, nombreInterno, cartaElegida); //mostrarCarta(carta, selector)
        //}

        public void Repartir()
        {
            juego.Partida.Repartir();

            var Ronda = new Ronda(juego.Partida.Repartidor);
            Clients.All.limpiarTablero();
            Clients.All.OcultarElementos(false);

            foreach (Jugador jugador in juego.Partida.ListaJugadores)
            {
                Clients.Client(jugador.IdConexion).mostrarCartas(jugador.CartasActuales);

                /*
                 * Propiedades de la Carta:
                 * Codigo "1Espada"
                 * Imagen "Images/e1.jpg"                        
                 */

            
                var jug = juego.Partida.ListaJugadores.Single(x => x.Orden == juego.Partida.Repartidor);
                if (jugador == jug)
                {
                    Clients.Client(jug.IdConexion).habilitarMovimientos();
                    Clients.Client(jug.IdConexion).hideEnvidoEnvidoBotton();
                    Clients.Client(jug.IdConexion).hideVale4Botton();
                    Clients.Client(jug.IdConexion).hideReTrucoBotton();
                    Clients.Client(jug.IdConexion).showEnvidoBotton();
                    Clients.Client(jug.IdConexion).showTrucoBotton();
                    Clients.Client(jug.IdConexion).showRealEnvidoBotton();
                    Clients.Client(jug.IdConexion).showFaltaEnvidoBotton();
                }
                else
                {

                    Clients.Client(jugador.IdConexion).desabilitarMovimientos();
                    Clients.Client(jugador.IdConexion).hideEnvidoOptions();
                    Clients.Client(jugador.IdConexion).hideTrucoBotton();
                    Clients.Client(jugador.IdConexion).hideReTrucoBotton();
                    Clients.Client(jugador.IdConexion).hideVale4Botton();
                }
            }
        }
    }
}
      //  }

    //}