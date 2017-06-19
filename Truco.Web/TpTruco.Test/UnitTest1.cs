using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TpTruco.Entidades;

namespace TpTruco.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //arrange

            var juego = new Juego();

            //act
            juego.AgregarJugador("Carlitos");
            juego.AgregarJugador("Pedrito");
            juego.AgregarJugador("Juancito");
            juego.AgregarJugador("Pepito");
            juego.AgregarJugador("Este forro no deberia entrar");



            int total = juego.ListaJugadores.Count;


            //assert
            Assert.AreEqual(4, total);
        }
    }
}
