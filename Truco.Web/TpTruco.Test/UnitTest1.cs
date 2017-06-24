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
            juego.AgregarJugador("Carlitos", "123");
            juego.AgregarJugador("Pedrito", "123");
            juego.AgregarJugador("Juancito", "123");
            juego.AgregarJugador("Pepito", "123");
            juego.AgregarJugador("Este forro no deberia entrar", "123");



            int total = juego.ListaJugadores.Count;


            //assert
            Assert.AreEqual(4, total);
        }
    }
}
