
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TpTruco.Entidades;

namespace UnitTest_TpTrucoEntidades
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange

            var juego = new Juego();
            //var j1 = new Jugador("Carlitos");
            //var j2 = new Jugador("Pedrito");
            //var j3 = new Jugador("Juancito");
            //var j4 = new Jugador("Pepito");
            //var j5 = new Jugador("Drogon");

            //act
            juego.AgregarJugador("Carlitos");
            juego.AgregarJugador("Pedrito");
            juego.AgregarJugador("Juancito");
            juego.AgregarJugador("Pepito");
            juego.AgregarJugador("Drogon");


            //assert
            Assert.AreEqual(4, juego.Partida.ListaJugadores.Count);
        }
    }
}
