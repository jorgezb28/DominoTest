using System;
using System.Collections.Generic;
using System.Linq;
using Domino.Logic;
using Domino.Test.Factory;

namespace Domino.Test.Mocking
{
    public class MockMezaConPiezasExtremoB
    {
        private readonly List<KeyValuePair<int, Pieza>> _mesaJuego;

        public int Turno { get; set; }

        public MockMezaConPiezasExtremoB()
        {
            _mesaJuego = new List<KeyValuePair<int, Pieza>>(PiezasFactory.GenerarPiezasExtremoB(10));
        }

        public bool InsertarPieza(KeyValuePair<int, Pieza> piezaJugador)
        {
            var piezaExtremoA = _mesaJuego.ElementAt(0);
            var indiceExtremoB = _mesaJuego.Count - 1;
            var piezaExtremoB = _mesaJuego.ElementAt(indiceExtremoB);


            if (piezaExtremoA.Value.PiezaA == null)
            {
                if (piezaExtremoA.Value.ValorA == piezaJugador.Value.ValorA)
                {
                    var tempValorB = piezaJugador.Value.ValorB;
                    piezaJugador.Value.ValorB = piezaExtremoA.Value.ValorA;
                    piezaJugador.Value.PiezaB = piezaExtremoA.Value;
                    piezaJugador.Value.ValorA = tempValorB;
                    piezaExtremoA.Value.PiezaA = piezaJugador.Value;
                    _mesaJuego.RemoveAt(0);
                    _mesaJuego.Insert(0, piezaJugador);
                    _mesaJuego.Insert(1, piezaExtremoA);
                    return true;
                }
                if (piezaExtremoA.Value.ValorA == piezaJugador.Value.ValorB)
                {
                    piezaJugador.Value.PiezaB = piezaExtremoA.Value;
                    piezaExtremoA.Value.PiezaA = piezaJugador.Value;
                    _mesaJuego.RemoveAt(0);
                    _mesaJuego.Insert(0, piezaJugador);
                    _mesaJuego.Insert(1, piezaExtremoA);
                    return true;
                }
                return false;
            }

            if (piezaExtremoB.Value.PiezaB == null)
            {
                if (piezaExtremoB.Value.ValorB == piezaJugador.Value.ValorA)
                {
                    piezaJugador.Value.PiezaA = piezaExtremoB.Value;
                    piezaExtremoB.Value.PiezaB = piezaJugador.Value;
                    _mesaJuego.RemoveAt(0);
                    _mesaJuego.Insert(0, piezaJugador);
                    _mesaJuego.Insert(1, piezaExtremoB);
                    return true;
                }
                if (piezaExtremoB.Value.ValorB == piezaJugador.Value.ValorB)
                {
                    var tempValorB = piezaJugador.Value.ValorA;
                    piezaJugador.Value.ValorA = piezaExtremoB.Value.ValorB;
                    piezaJugador.Value.PiezaA = piezaExtremoB.Value;
                    piezaJugador.Value.ValorB = tempValorB;
                    piezaExtremoB.Value.PiezaB = piezaJugador.Value;
                    _mesaJuego.RemoveAt(indiceExtremoB);
                    _mesaJuego.Insert(indiceExtremoB, piezaJugador);
                    _mesaJuego.Insert(indiceExtremoB + 1, piezaExtremoB);
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
