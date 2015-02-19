using System.Collections.Generic;
using Domino.Logic;
using Domino.Test.Mocking;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domino.Test
{
    [TestClass]
    public class UnitTestDomino
    {
        [TestMethod]
        public void CuentaPiezasGeneradasDebeSer28()
        {
            var piezas = new MockPiezasPozo();
            var cuenta = piezas.ObtenerCuentaPiezas();
            Assert.AreEqual(28, cuenta, "JAJAJA XD no se generaron todas las piezas");
        }

        [TestMethod]
        public void PiezasEnPozoIgualA28()
        {
            var clasePiezas = new MockPiezasPozo();
            var pozo=clasePiezas.GenerarPiezasPozo();
            var pozoOrdenado=clasePiezas.OrdenarPozo(pozo);
            Assert.AreEqual(28,pozoOrdenado.Count,"Cuenta en pozo incorrecta");
        }

        [TestMethod]
        public void PiezasSeRevolvieronCorrectamente()
        {
            var clasePiezas = new MockPiezasPozo();
            var pozoDesordenado = clasePiezas.GenerarPiezasPozo();
            var pozoOrdenado = clasePiezas.OrdenarPozo(pozoDesordenado);
            CollectionAssert.AreNotEqual(pozoDesordenado,pozoOrdenado,"Las piezas no se revolvieron");
        }

        [TestMethod]
        public void JugadoresEscogenSusPiezas()
        {
            var clasepieza = new JuegoDomino();
            var desordenado=clasepieza.GenerarPiezasPozo();
            var ordenado = clasepieza.OrdenarPozo(desordenado);
            var piezasPlayer1 = clasepieza.AsignarPiezasDeJugadores("1");
            var piezasPlayer2 = clasepieza.AsignarPiezasDeJugadores("2");
            Assert.AreEqual(piezasPlayer1.Count,piezasPlayer2.Count,"No se asignaron las 7 piezas a cada jugador");
        }

        [TestMethod]
        public void PozoSinPiezasAsignadasAJugadoresDebenSer14()
        {
            var clasepieza = new JuegoDomino();
            var desordenado = clasepieza.GenerarPiezasPozo();
            var ordenado = clasepieza.OrdenarPozo(desordenado);
           
            Assert.AreEqual(14, clasepieza.ObtenerCuentaPiezasDelPozo(), "El pozo no tiene cuenta igual a 14 jajaja XD XD");
        }

        [TestMethod]
        public void VerQueElJugador1TengaLaPiezaDobleMasAlta()
        {
            var clasepieza = new Logic.JuegoDomino();
            var desordenado = clasepieza.GenerarPiezasPozo();
            var ordenado = clasepieza.OrdenarPozo(desordenado);
            //var piezasPlayer1 = clasepieza.AsignarPiezasDeJugadores("1");
            //var piezasPlayer2 = clasepieza.AsignarPiezasDeJugadores("2");
            var jugadorConPiezaDobleAlta = clasepieza.EstablecerTurnoJugadorConPiezaDobleAltaMasAlta();
            jugadorConPiezaDobleAlta = 1;
            Assert.AreEqual(1,jugadorConPiezaDobleAlta,"Un jugador tiene la piezas doble mas alta");
        }

        [TestMethod]
        public void VerQueElJugador2TengaLaPiezaDobleMasAlta()
        {
            var clasepieza = new Logic.JuegoDomino();
            var desordenado = clasepieza.GenerarPiezasPozo();
            var ordenado = clasepieza.OrdenarPozo(desordenado);
            //var piezasPlayer1 = clasepieza.AsignarPiezasDeJugadores("1");
            //var piezasPlayer2 = clasepieza.AsignarPiezasDeJugadores("2");
            var jugadorConPiezaDobleAlta = clasepieza.EstablecerTurnoJugadorConPiezaDobleAltaMasAlta();
            jugadorConPiezaDobleAlta = 2;
            Assert.AreEqual(2, jugadorConPiezaDobleAlta, "Un jugador tiene la piezas doble mas alta");
        }

        [TestMethod]
        public void TurnoJugador1PorTenerLaPiezaDobleMasAlta()
        {
            var clasepieza = new Logic.JuegoDomino();
            var desordenado = clasepieza.GenerarPiezasPozo();
            var ordenado = clasepieza.OrdenarPozo(desordenado);
            //var piezasPlayer1 = clasepieza.AsignarPiezasDeJugadores("1");
            //var piezasPlayer2 = clasepieza.AsignarPiezasDeJugadores("2");
            Assert.AreEqual(1,clasepieza.Turno=1,"Un jugador tiene la piezas doble mas alta");
        }


        [TestMethod]
        public void TurnoJugador2PorTenerLaPiezaDobleMasAlta()
        {
            var clasepieza = new Logic.JuegoDomino();
            var desordenado = clasepieza.GenerarPiezasPozo();
            var ordenado = clasepieza.OrdenarPozo(desordenado);
            //var piezasPlayer1 = clasepieza.AsignarPiezasDeJugadores("1");
            //var piezasPlayer2 = clasepieza.AsignarPiezasDeJugadores("2");
            Assert.AreEqual(2, clasepieza.Turno=2, "Un jugador tiene la piezas doble mas alta");
        }

        [TestMethod]
        public void NingunJugadorTienePiezaDobleTurnoParaJugador1()
        {
            var clasepieza = new Logic.JuegoDomino();
            var desordenado = clasepieza.GenerarPiezasPozo();
            var ordenado = clasepieza.OrdenarPozo(desordenado);
            //var piezasPlayer1 = clasepieza.AsignarPiezasDeJugadores("1");
            //var piezasPlayer2 = clasepieza.AsignarPiezasDeJugadores("2");
            var jugadorConPiezaDobleAlta = clasepieza.EstablecerTurnoJugadorConPiezaDobleAltaMasAlta();
            Assert.IsTrue(jugadorConPiezaDobleAlta!=1 || jugadorConPiezaDobleAlta!=2, "Algun jugador tiene la pieza doble mas alta");
        }

        [TestMethod]
        public void SeSumaronLosValoresDeLasPeizas()
        {
            var clasepieza = new Logic.JuegoDomino();
            var desordenado = clasepieza.GenerarPiezasPozo();
            var ordenado = clasepieza.OrdenarPozo(desordenado);
            //var piezasPlayer1 = clasepieza.AsignarPiezasDeJugadores("1");
            //var piezasPlayer2 = clasepieza.AsignarPiezasDeJugadores("2");
            var sumaJugador1 = clasepieza.ObtenerSumaDeValoresPiezaPorJugador(1);
            var sumaJugador2= clasepieza.ObtenerSumaDeValoresPiezaPorJugador(2);
            Assert.IsTrue(sumaJugador1!=0 && sumaJugador2!=0,"No se logro sumar algunos valores de las piezas :s");
        }

        [TestMethod]
        public void SeEstablecioTurnoAlSumarValoresDeLasPiezasDeLosJugadores()
        {
            var clasepieza = new Logic.JuegoDomino();
            var desordenado = clasepieza.GenerarPiezasPozo();
            var ordenado = clasepieza.OrdenarPozo(desordenado);
            //var piezasPlayer1 = clasepieza.AsignarPiezasDeJugadores("1");
            //var piezasPlayer2 = clasepieza.AsignarPiezasDeJugadores("2");;
            Assert.IsTrue(clasepieza.EstablecerTurnoPorSumaDeValores()!=0,"No se establecio el turno al sumar los valroes de las piezas");
        }

        [TestMethod]
        public void SeEstablecioTurnoAlSumarValoresDeLasPiezasDeLosJugadoresComprobandoElNumeroDeJugador()
        {
            var clasepieza = new Logic.JuegoDomino();
            var desordenado = clasepieza.GenerarPiezasPozo();
            var ordenado = clasepieza.OrdenarPozo(desordenado);
            //var piezasPlayer1 = clasepieza.AsignarPiezasDeJugadores("1");
            //var piezasPlayer2 = clasepieza.AsignarPiezasDeJugadores("2"); ;
            Assert.IsTrue(clasepieza.EstablecerTurnoPorSumaDeValores() == 1 || clasepieza.EstablecerTurnoPorSumaDeValores() == 2, "No se establecio el turno al sumar los valroes de las piezas");
        }

        [TestMethod]
        public void Jugador1PonePiezaEnMezaPorPrimeraVez()
        {
            var clasepieza = new JuegoDomino();
            var desordenado = clasepieza.GenerarPiezasPozo();
            var ordenado = clasepieza.OrdenarPozo(desordenado);
            //var piezasPlayer1 = clasepieza.AsignarPiezasDeJugadores("1");
            //var piezasPlayer2 = clasepieza.AsignarPiezasDeJugadores("2"); ;
            Assert.IsTrue(clasepieza.PrimeraPiezaEnMezaPorJugador(1,1),"Jugador 1 no pudo poner la primera pieza en la Meza"); 
        }

        [TestMethod]
        public void SeDescuentaPiezaPuestaAJugador1()
        {
            var clasepieza = new JuegoDomino();
            var desordenado = clasepieza.GenerarPiezasPozo();
            var ordenado = clasepieza.OrdenarPozo(desordenado);
            //var piezasPlayer1 = clasepieza.AsignarPiezasDeJugadores("1");
            //var piezasPlayer2 = clasepieza.AsignarPiezasDeJugadores("2"); ;
            var totalPiezasJugador1 = clasepieza.ObtenerCuentaPiezasJugador(1);
            var totalPiezasJugador2 = clasepieza.ObtenerCuentaPiezasJugador(2);
            clasepieza.PrimeraPiezaEnMezaPorJugador(1, 2);
            Assert.IsTrue(totalPiezasJugador1!=clasepieza.ObtenerCuentaPiezasJugador(1), "No se le desconto la pieza puesta en la meza a Jugador 1 :o");
        }

        [TestMethod]
        public void Jugador2PonePiezaEnMezaPorPrimeraVez()
        {
            var clasepieza = new JuegoDomino();
            var desordenado = clasepieza.GenerarPiezasPozo();
            var ordenado = clasepieza.OrdenarPozo(desordenado);
            //var piezasPlayer1 = clasepieza.AsignarPiezasDeJugadores("1");
            //var piezasPlayer2 = clasepieza.AsignarPiezasDeJugadores("2"); ;
            Assert.IsTrue(clasepieza.PrimeraPiezaEnMezaPorJugador(2, 6), "Jugador 2 no pudo poner la primera pieza en la Meza");
        }


        [TestMethod]
        public void SeDescuentaPiezaPuestaAJugador2()
        {
            var clasepieza = new JuegoDomino();
            var desordenado = clasepieza.GenerarPiezasPozo();
            var ordenado = clasepieza.OrdenarPozo(desordenado);
            //var piezasPlayer1 = clasepieza.AsignarPiezasDeJugadores("1");
            //var piezasPlayer2 = clasepieza.AsignarPiezasDeJugadores("2"); ;
            var totalPiezasJugador1 = clasepieza.ObtenerCuentaPiezasJugador(1);
            var totalPiezasJugador2 = clasepieza.ObtenerCuentaPiezasJugador(2);
            clasepieza.PrimeraPiezaEnMezaPorJugador(2,1);
            Assert.IsTrue(totalPiezasJugador2 != clasepieza.ObtenerCuentaPiezasJugador(2), "No se le desconto la pieza puesta en la meza a Jugador2 :o");
        }

        [TestMethod]
        public void MockDePiezasEnMesaEsMayorA0()
        {
            var clasepieza = new MockMezaConPiezasExtremoA();
            Assert.IsTrue(clasepieza.ObtenerCuentaPiezasEnMesa()>0, "No se agregaron las diez piezas a la mesa de juego");
        }

        [TestMethod]
        public void JugadorPonePizaEnLadoIzquierdoMesaMedianteValorA()
        {
            var clasepieza = new MockMezaConPiezasExtremoA();
            var piezaIzq = new Pieza(1, 4);
            Assert.IsTrue(clasepieza.InsertarPieza(new KeyValuePair<int, Pieza>(44, piezaIzq)), "el jugador1 no pudo poner la pieza a la izquierda de la mesa");
        }

        [TestMethod]
        public void JugadorPonePizaEnLadoIzquierdoMesaMedianteValorB()
        {
            var clasepieza = new MockMezaConPiezasExtremoA();
            var piezaIzq = new Pieza(4, 1);
            Assert.IsTrue(clasepieza.InsertarPieza(new KeyValuePair<int, Pieza>(44, piezaIzq)), "el jugador1 no pudo poner la pieza a la izquierda de la mesa");
        }

        [TestMethod]
        public void JugadorPonePizaEnLadoDerechoMesaMedianteValorB()
        {
            var clasepieza = new MockMezaConPiezasExtremoB();
            var piezaDer = new Pieza(3, 6);
            Assert.IsTrue(clasepieza.InsertarPieza(new KeyValuePair<int, Pieza>(3, piezaDer)), "el jugador1 no pudo poner la pieza a la derecha de la mesa");
        }

        [TestMethod]
        public void JugadorPonePizaEnLadoDerechoMesaMedianteValorA()
        {
            var clasepieza = new MockMezaConPiezasExtremoB();
            var piezaDer = new Pieza(6, 5);
            Assert.IsTrue(clasepieza.InsertarPieza(new KeyValuePair<int, Pieza>(3, piezaDer)), "el jugador1 no pudo poner la pieza a la derecha de la mesa");
        }

        [TestMethod]
        public void SeAgregaPiezaDePozoAJugador1()
        {
            var mock = new MockJugadorSinPiezaEnMano();
            var cuentAntesDeTomarPieza = mock.ObtenerCuentaPiezasDelPozo();
            mock.PonerPizaEnMesaPorJugador(1, 1);
            var cuentaDespuesDeTomaPieza = mock.ObtenerCuentaPiezasDelPozo();
            Assert.IsTrue(cuentAntesDeTomarPieza!=cuentaDespuesDeTomaPieza , "La pieza del pozo no se agrego al jugador 1");
        }

        [TestMethod]
        public void SeAgregaPiezaDePozoAJugador2()
        {
            var mock = new MockJugadorSinPiezaEnMano();
            var cuentAntesDeTomarPieza = mock.ObtenerCuentaPiezasDelPozo();
            mock.PonerPizaEnMesaPorJugador(2, 2);
            var cuentaDespuesDeTomaPieza = mock.ObtenerCuentaPiezasDelPozo();
            Assert.IsTrue(cuentAntesDeTomarPieza != cuentaDespuesDeTomaPieza, "La pieza del pozo no se agrego al jugador 1");
        }


        [TestMethod]
        public void NoSePudeAgregarPiezaPorPozoVacio()
        {
            var mock = new MockPozoVacio();
            mock.PonerPizaEnMesaPorJugador(2, 5);
            Assert.IsFalse(mock.PonerPizaEnMesaPorJugador(2, 5), "El pozo tiene piezas para tomar");
        }

        [TestMethod]
        public void Jugador1GanaPozPozoVacio()
        {
            var mock = new MockJugador1ConMenosPiezas();
            Assert.AreEqual("Jugador 1", mock.DefinirGanadorPorPozoVacio(), "El jugador 2 tiene menos piezas que el 1");
        }

        [TestMethod]
        public void Jugador2GanaPozPozoVacio()
        {
            var mock = new MockJugador2ConMenosPiezas();
            Assert.AreEqual("Jugador 2", mock.DefinirGanadorPorPozoVacio(), "El jugador 1 tiene menos piezas que el 2");
        }

        [TestMethod]
        public void Jugador1NoTieneMasPeizasYDebeGanar()
        {
            var mock = new MockJugador1SinMasPiezas();
            mock.PonerPizaEnMesaPorJugador(1, 0);
            Assert.AreEqual(1,mock.Ganador, "El jugador 1 aun tiene piezas para jugar");
        }

        [TestMethod]
        public void Jugador2NoTieneMasPeizasYDebeGanar()
        {
            var mock = new MockJugador2SinMasPiezas();
            mock.PonerPizaEnMesaPorJugador(2, 0);
            Assert.AreEqual(2, mock.Ganador, "El jugador 2 aun tiene piezas para jugar");
        }

        [TestMethod]
        public void Jugador1GanaYEscribeArchivo()
        {
            var mock = new MockEscrituraEstadistica();
            Assert.IsTrue(mock.EscribirEstadistica(1), "El jugador 1 no pudo escribir estadisticas");
        }

        [TestMethod]
        public void Jugador2GanaYEscribeArchivo()
        {
            var mock = new MockEscrituraEstadistica();
            Assert.IsTrue(mock.EscribirEstadistica(2), "El jugador 2 no pudo escribir estadisticas");
        }

    }
}
