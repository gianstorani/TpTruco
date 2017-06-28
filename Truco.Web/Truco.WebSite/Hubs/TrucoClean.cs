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

        public int ValorMaximo = 10;

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

        public void VerificarJuego(int ValorMaximo)
        {

            if (juego.Partida.Equipo1.Puntos >= ValorMaximo) 
            {
                juego.Partida.JuegoTerminado = true;
                juego.Partida.GanadorPartida = juego.Partida.Equipo1;                
            }
            if (juego.Partida.Equipo2.Puntos >= ValorMaximo)
            {
                juego.Partida.JuegoTerminado = true; 
                juego.Partida.GanadorPartida = juego.Partida.Equipo2;
            }

            if (juego.Partida.JuegoTerminado == false)
            {
                Clients.All.limpiarTablero();
                Clients.All.deshabilitarMovimientos();
                Repartir();
            }
            else //JuegoTerminado();
            {
                if (juego.Partida.GanadorPartida == juego.Partida.Equipo1)
                {
                    foreach (Jugador item in juego.Partida.ListaJugadores)
                    {
                        if (item.Equipo == 1)
                        {
                            Clients.Client(item.IdConexion).mostrarmensaje("GANASTE‼");
                        }
                        else
                        {
                            Clients.Client(item.IdConexion).mostrarmensaje("PERDISTE, PECHO FRIO...");
                        }
                    }
                }
                else
                {
                    foreach (Jugador item in juego.Partida.ListaJugadores)
                    {
                        if (item.Equipo == 2)
                        {
                            Clients.Client(item.IdConexion).mostrarmensaje("GANASTE‼");
                        }
                        else
                        {
                            Clients.Client(item.IdConexion).mostrarmensaje("PERDISTE, PECHO FRIO...");
                        }
                    }
                }
            }
            

        }

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

            Clients.All.mostrarCarta(c, j.NombreInterno, ronda.NumeroMano);//muestro la carta a todos

            ronda.CartasEnMesa[ronda.NumeroMano - 1, j.Orden - 1] = c;//guardo la carta en la mesa

            Clients.Client(j.IdConexion).deshabilitarMovimientos();//desabilito los movimientos del que tiro

            ronda.AumentarTurno();//Paso el turno

            //Deshabilto a todos
            Clients.All.desabilitarMovimientos();
            Clients.All.hideEnvidoOptions();
            Clients.All.hideTrucoBotton();
            Clients.All.hideReTrucoBotton();
            Clients.All.hideVale4Botton();

            

            //cuando ya jugaron los 4, sacar al equipo ganador
            if (ronda.Turno == ronda.PrimeroQueJugo)
            {
                if (ronda.GanadorMano(ronda.NumeroMano - 1) == 10)//entra cuando es parda
                {
                    switch (ronda.NumeroMano)
                    {
                        case 1:
                            ronda.GanadorR1 = "E";
                            break;
                        case 2:
                            ronda.GanadorR2 = "E";
                            break;
                        case 3:
                            ronda.GanadorR3 = "E";
                            break;
                    }

                    //ronda.AumentarTurno();
                    ronda.NumeroMano++;
                }
                else//Si entra no hay parda
                {
                    if (ronda.GanadorMano(ronda.NumeroMano - 1) == 1 || ronda.GanadorMano(ronda.NumeroMano - 1) == 3)
                    {
                        switch (ronda.NumeroMano)
                        {
                            case 1:
                                ronda.GanadorR1 = "E1";
                                break;
                            case 2:
                                ronda.GanadorR2 = "E1";
                                break;
                            case 3:
                                ronda.GanadorR3 = "E1";
                                break;

                        }
                    }
                    else // if (ronda.GanadorMano(ronda.NumeroMano - 1) == 2 || ronda.GanadorMano(ronda.NumeroMano - 1) == 4)
                    {
                        switch (ronda.NumeroMano)
                        {
                            case 1:
                                ronda.GanadorR1 = "E2";
                                break;
                            case 2:
                                ronda.GanadorR2 = "E2";
                                break;
                            case 3:
                                ronda.GanadorR3 = "E2";
                                break;

                        }
                    }


                    //igualar primero que jugo al ganador 
                    ronda.PrimeroQueJugo = ronda.GanadorMano(ronda.NumeroMano - 1);
                    //Darle el turno al ganador
                    ronda.Turno = ronda.PrimeroQueJugo;
                    //aumentar la mano 
                    ronda.NumeroMano++;
                }
            }

            //Comprobar ganador de la ronda
            if (ronda.NumeroMano - 1 > 1)
            {
                if (ronda.GanadorRonda() != "")
                {
                    ronda.Ganador = true;
                }
            }

            if (ronda.Ganador == true)
            {
                var EquipoQueGano = new Equipo();
                if (ronda.GanadorRonda() == "E1")
                {
                    EquipoQueGano = juego.Partida.Equipo1;
                }
                else
                {
                    EquipoQueGano = juego.Partida.Equipo2;
                }

                //sumarpuntostruco
                ronda.SumarPuntos(EquipoQueGano);

                Clients.All.limpiarpuntos();
                Clients.All.mostrarpuntos("E1", juego.Partida.Equipo1.Puntos);
                Clients.All.mostrarpuntos("E2", juego.Partida.Equipo2.Puntos);

                //muestra alerta con los ganadores
                string data = (EquipoQueGano.JugadoresDelEquipo[0].Nombre + " y " + EquipoQueGano.JugadoresDelEquipo[1].Nombre + " Ganaron la ronda");
                Clients.All.mostrarganadorronda(data);

                Clients.All.limpiarmensaje();//Limpia el panel derecho

                VerificarJuego(ValorMaximo);
            }
            else
            {
                //Habilito al proximo jugador
                var jug = juego.Partida.ListaJugadores.Single(x => x.Orden == ronda.Turno);

                Clients.Client(jug.IdConexion).habilitarMovimientos();
                Clients.Client(jug.IdConexion).hideEnvidoEnvidoBotton();
                Clients.Client(jug.IdConexion).hideVale4Botton();
                Clients.Client(jug.IdConexion).hideReTrucoBotton();
                if (juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].NumeroMano == 1)//Solo muestra opciones de envido en la 1era mano
                {
                    Clients.Client(jug.IdConexion).showEnvidoBotton();
                    Clients.Client(jug.IdConexion).showRealEnvidoBotton();
                    Clients.Client(jug.IdConexion).showFaltaEnvidoBotton();
                }
                if (juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].EstadoTruco == "")
                {
                    Clients.Client(jug.IdConexion).showTrucoBotton();
                }
            }

                    

        }

        public void cantar(string accion)
        {
            var jugador = juego.Partida.ListaJugadores.Single(x => x.IdConexion == Context.ConnectionId);
            juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].IDCantador = Context.ConnectionId;
            Clients.All.limpiarmensaje();
            Clients.Others.mostrarmensaje(jugador.Nombre + " canto " + accion);
            Clients.Caller.mostrarmensaje("Yo cante " + accion);

            Clients.Client(jugador.IdConexion).deshabilitarMovimientos();

            
            switch (accion)
            {
                case "me voy al mazo":
              
                    if (jugador.Equipo == 1)
                    {
                        juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].SumarPuntos(juego.Partida.Equipo2);
                    }
                    else
                    {
                        juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].SumarPuntos(juego.Partida.Equipo1);
                    }

                    //Repartir();
                    break;

                case "envido":
                    Clients.All.hidemazo();
                    Clients.All.hideEnvidoOptions();
                    Clients.All.hideEnvidoBotton();

                    foreach (Jugador item in juego.Partida.ListaJugadores)
                    {
                        if (item.Equipo != jugador.Equipo)
                        {
                            Clients.Client(item.IdConexion).showEnvidoOptions();
                        }
                    }
                    break;

                case "envidoenvido":
                    Clients.All.hidemazo();
                    Clients.All.hideEnvidoEnvidoBotton();
                    Clients.All.hideEnvidoOptions();

                    foreach (Jugador item in juego.Partida.ListaJugadores)
                    {
                        if (item.Equipo != jugador.Equipo)
                        {
                            Clients.Client(item.IdConexion).showEnvidoEnvidoOptions();
                        }
                    }
                    break;
                case "faltaenvido":
                    Clients.All.hidemazo();
                    Clients.All.hideFaltaEnvidoBotton();
                    Clients.All.hideEnvidoEnvidoOptions();
                    Clients.All.hideRealEnvidoOptions();
                    Clients.All.hideEnvidoOptions();

                    foreach (Jugador item in juego.Partida.ListaJugadores)
                    {
                        if (item.Equipo != jugador.Equipo)
                        {
                            Clients.Client(item.IdConexion).showFaltaEnvidoOptions();
                        }
                    }

                    break;
                case "realenvido":
                    Clients.All.hidemazo();
                    Clients.All.hideEnvidoOptions();
                    Clients.All.hideEnvidoEnvidoOptions();
                    Clients.All.hideRealEnvidoBotton();

                    foreach (Jugador item in juego.Partida.ListaJugadores)
                    {
                        if (item.Equipo != jugador.Equipo)
                        {
                            Clients.Client(item.IdConexion).showRealEnvidoOptions();
                        }
                    }
                    break;
                case "truco":
                    Clients.All.hideEnvidoBotton();
                    Clients.All.hideEnvidoEnvidoBotton();
                    Clients.All.hideFaltaEnvidoBotton();
                    Clients.All.hideRealEnvidoBotton();
                    juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].EstadoTruco = "truco";

                    foreach (Jugador item in juego.Partida.ListaJugadores)
                    {
                        if (item.Equipo != jugador.Equipo)
                        {
                            Clients.Client(item.IdConexion).showTrucoOptions();
                        }
                    }
                    break;
                case "retruco":
                    Clients.All.hideTrucoRegion();
                    Clients.All.hideReTrucoBotton();
                    juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].EstadoTruco = "retruco";

                    foreach (Jugador item in juego.Partida.ListaJugadores)
                    {
                        if (item.Equipo != jugador.Equipo)
                        {
                            Clients.Client(item.IdConexion).showReTrucoOptions();
                        }
                    }
                    break;
                case "vale4":
                    Clients.All.hideReTrucoRegion();
                    Clients.All.hideVale4Botton();
                    juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].EstadoTruco = "vale4";

                    foreach (Jugador item in juego.Partida.ListaJugadores)
                    {
                        if (item.Equipo != jugador.Equipo)
                        {
                            Clients.Client(item.IdConexion).showVale4Options();
                        }
                    }

                    break;
            }

            // Si el juego termino...
            Clients.Client(jugador.IdConexion).mostrarMensajeFinal(true); // GANADOR
            Clients.Client(jugador.IdConexion).mostrarMensajeFinal(false); // PERDEDOR
            Clients.All.deshabilitarMovimientos();

            // Sino
            Clients.All.limpiarpuntos();

            // Y mostrar puntos y repartir.
            Clients.All.mostrarpuntos("E1", juego.Partida.Equipo1.Puntos);
            Clients.All.mostrarpuntos("E2", juego.Partida.Equipo2.Puntos);

        }

        public void EjecutarAccion(string accion, bool confirmacion)
        {
            // confirmacion == true => Acepto la acción.
            var jugador = juego.Partida.ListaJugadores.Single(x => x.IdConexion == Context.ConnectionId);
            var equipodelJugador = new Equipo();
            if (jugador.Equipo == 1)
            {
                equipodelJugador = juego.Partida.Equipo1;
            }
            else
            {
                equipodelJugador = juego.Partida.Equipo2;
            }
            Clients.All.limpiarmensaje();

            if (confirmacion)
            {
                Clients.All.mostrarmensaje(jugador.Nombre + " acepto " + accion);
            }
            else
            {
                Clients.All.mostrarmensaje(jugador.Nombre + " se cago de " + accion);
            }


            int EquipoGanadorEnvido = 0;
            foreach (Jugador item in juego.Partida.ListaJugadores)
            {
                if (item.CalcularEnvido() > juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].EnvidoMayor)
                {
                    juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].EnvidoMayor = item.CalcularEnvido();
                    EquipoGanadorEnvido = item.Equipo;
                }
            }
            switch (accion)
            {
               
                case "Envido":
                    if (confirmacion)
                    {
                        juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].EstadoEnvido = "envido";

                        if (EquipoGanadorEnvido == 1)
                        {
                            juego.Partida.Equipo1.Puntos += 2;
                        }
                        else
                        {
                            juego.Partida.Equipo2.Puntos += 2;
                        }
                        Clients.All.hideEnvidoOptions();

                        Clients.All.limpiarmensaje();
                       Clients.All.mostrarmensaje("El equipo " + EquipoGanadorEnvido + " gano el envido con " + juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].EnvidoMayor + " puntos");
                    }
                    else
                    {
                        if(jugador.Equipo==1)
                        {
                            juego.Partida.Equipo2.Puntos += 1;
                            Clients.All.limpiarmensaje();

                            Clients.All.mostrarmensaje("El equipo 1 se cago");

                        }
                        else
                        {
                            juego.Partida.Equipo1.Puntos += 1;
                            Clients.All.limpiarmensaje();

                            Clients.All.mostrarmensaje("El equipo 2 se cago");
                        }
                        Clients.All.hideEnvidoOptions();

                    }
                    Clients.All.limpiarpuntos();
                    Clients.All.mostrarpuntos("E1", juego.Partida.Equipo1.Puntos);
                    Clients.All.mostrarpuntos("E2", juego.Partida.Equipo2.Puntos);
                    

                    break;
                case "EnvidoEnvido":
                    
                    if (confirmacion)
                    {
                        juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].EstadoEnvido = "envidoenvido";

                        if (EquipoGanadorEnvido == 1)
                        {
                            juego.Partida.Equipo1.Puntos += 4;
                        }
                        else
                        {
                            juego.Partida.Equipo2.Puntos += 4;
                        }
                        Clients.All.hideEnvidoOptions();
                        Clients.All.limpiarmensaje();
                        Clients.All.mostrarmensaje("El equipo " + EquipoGanadorEnvido + " gano el EnvidoEnvido con " + juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].EnvidoMayor + " puntos");
                    }
                    else
                    {
                        if (jugador.Equipo == 1)
                        {
                            juego.Partida.Equipo2.Puntos += 2;
                            Clients.All.limpiarmensaje();

                            Clients.All.mostrarmensaje("El equipo 1 se cago");

                        }
                        else
                        {
                            juego.Partida.Equipo1.Puntos += 2;
                            Clients.All.limpiarmensaje();

                            Clients.All.mostrarmensaje("El equipo 2 se cago");

                        }
                    }
                    Clients.All.limpiarpuntos();
                    Clients.All.mostrarpuntos("E1", juego.Partida.Equipo1.Puntos);
                    Clients.All.mostrarpuntos("E2", juego.Partida.Equipo2.Puntos);

                    break;
                case "RealEnvido":
                    if (confirmacion)
                    {
                        juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].EstadoEnvido = "realenvido";

                        if (EquipoGanadorEnvido == 1)
                        {
                            juego.Partida.Equipo1.Puntos += 3;
                        }
                        else
                        {
                            juego.Partida.Equipo2.Puntos += 3;
                        }
                        Clients.All.hideEnvidoOptions();
                        Clients.All.limpiarmensaje();
                        Clients.All.mostrarmensaje("El equipo " + EquipoGanadorEnvido + " gano el RealEnvido con " + juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].EnvidoMayor + " puntos");
                    }
                    else
                    {
                        if (jugador.Equipo == 1)
                        {
                            juego.Partida.Equipo2.Puntos += 1;
                            Clients.All.limpiarmensaje();

                            Clients.All.mostrarmensaje("El equipo 1 se cago");

                        }
                        else
                        {
                            juego.Partida.Equipo1.Puntos += 1;
                            Clients.All.limpiarmensaje();

                            Clients.All.mostrarmensaje("El equipo 2 se cago");

                        }
                    }
                    Clients.All.hideEnvidoOptions();
                    Clients.All.limpiarpuntos();
                    Clients.All.mostrarpuntos("E1", juego.Partida.Equipo1.Puntos);
                    Clients.All.mostrarpuntos("E2", juego.Partida.Equipo2.Puntos);

                    break;
                case "FaltaEnvido":
                    
                    if (confirmacion)
                    {
                        juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].EstadoEnvido = "faltaenvido";

                        if (EquipoGanadorEnvido == 1)
                        {
                            juego.Partida.Equipo1.Puntos += (ValorMaximo - juego.Partida.Equipo2.Puntos);
                        }
                        else
                        {
                            juego.Partida.Equipo2.Puntos += (ValorMaximo - juego.Partida.Equipo1.Puntos);
                        }
                        Clients.All.hideEnvidoOptions();
                        Clients.All.limpiarmensaje();
                        Clients.All.mostrarmensaje("El equipo " + EquipoGanadorEnvido + " gano la Falta envido con " + juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].EnvidoMayor + " puntos");
                    }
                    else
                    {
                        if (jugador.Equipo == 1)
                        {
                            juego.Partida.Equipo2.Puntos += 1;
                            Clients.All.limpiarmensaje();

                            Clients.All.mostrarmensaje("El equipo 1 se cago");

                        }
                        else
                        {
                            juego.Partida.Equipo1.Puntos += 1;
                            Clients.All.limpiarmensaje();

                            Clients.All.mostrarmensaje("El equipo 2 se cago");

                        }
                    }

                    Clients.All.limpiarpuntos();
                    Clients.All.mostrarpuntos("E1", juego.Partida.Equipo1.Puntos);
                    Clients.All.mostrarpuntos("E2", juego.Partida.Equipo2.Puntos);

                    break;
                case "Truco":
                    if (confirmacion)
                    {
                        juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].EstadoTruco = "truco";
                        juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].PuntosTruco = 2;
                    }
                    else
                    {
                        if (jugador.Equipo == 1)
                        {
                            juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].SumarPuntos(juego.Partida.Equipo2); 
                        }
                        else
                        {
                            juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].SumarPuntos(juego.Partida.Equipo1);
                        }
                        VerificarJuego(ValorMaximo);
                    }
                    break;
                case "ReTruco":
                    if (confirmacion)
                    {
                        juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].EstadoTruco = "retruco";
                        juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].PuntosTruco = 3;

                    }
                    else
                    {
                        if (jugador.Equipo == 1)
                        {
                            juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].SumarPuntos(juego.Partida.Equipo2);
                        }
                        else
                        {
                            juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].SumarPuntos(juego.Partida.Equipo1);
                        }
                        VerificarJuego(ValorMaximo);
                    }
                    break;
                case "Vale4":
                    if (confirmacion)
                    {
                        juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].EstadoTruco = "Vale4";
                        juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].PuntosTruco = 4;

                    }
                    else
                    {
                        if (jugador.Equipo == 1)
                        {
                            juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].SumarPuntos(juego.Partida.Equipo2);
                        }
                        else
                        {
                            juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].SumarPuntos(juego.Partida.Equipo1);
                        }
                        VerificarJuego(ValorMaximo);
                    }
                    break;
            }

            Clients.All.hideEnvidoOptions();
            Clients.All.showmazo();
            //var jug = juego.Partida.ListaJugadores.Single(x => x.Orden == juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].Turno);
            Clients.Client(juego.Partida.RondasPartida[juego.Partida.RondasPartida.Count - 1].IDCantador).habilitarMovimientos();

        }


        public void Repartir()
        {
            Clients.All.Limpiar();
            Clients.All.limpiarTablero();
            Clients.All.OcultarElementos(false);
            //Clients.All.limpiarCartas();


            juego.Partida.Repartir();

            //var Ronda = new Ronda(juego.Partida.Repartidor);
            

            var jug = juego.Partida.ListaJugadores.Single(x => x.Orden == juego.Partida.Repartidor);
            foreach (Jugador jugador in juego.Partida.ListaJugadores)
            {
                Clients.Client(jugador.IdConexion).mostrarCartas(jugador.CartasActuales);
            
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