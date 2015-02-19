using System;
using System.Collections.Generic;
using System.Linq;
using Domino.Logic;
using Domino.Test.Factory;

namespace Domino.Test.Mocking
{
    public class MockJugador2SinMasPiezas
    {
        private readonly List<KeyValuePair<int, Pieza>> _piezasJugador1;
        private readonly List<KeyValuePair<int, Pieza>> _piezasJugador2;

        private readonly List<KeyValuePair<int, Pieza>> _mesaJuego;
        private readonly Stack<KeyValuePair<int, Pieza>> _pozoPiezas;

        public int Turno { get; set; }

        public int Ganador { get; set; }

        public MockJugador2SinMasPiezas()
        {
            _mesaJuego = new List<KeyValuePair<int, Pieza>>(PiezasFactory.GenerarPiezasExtremoA(10));
            _pozoPiezas = new Stack<KeyValuePair<int, Pieza>>();
            Ganador = 0;

            _piezasJugador1 = new List<KeyValuePair<int, Pieza>>
            {
                new KeyValuePair<int, Pieza>(3, new Pieza(11,44)), 
                new KeyValuePair<int, Pieza>(3, new Pieza(11,44)),
                new KeyValuePair<int, Pieza>(3, new Pieza(21,44)), 
                new KeyValuePair<int, Pieza>(3, new Pieza(31,44)),
                new KeyValuePair<int, Pieza>(3, new Pieza(11,44)), 
                new KeyValuePair<int, Pieza>(3, new Pieza(21,44)),
                new KeyValuePair<int, Pieza>(3, new Pieza(11,44)) 
                
            };

            _piezasJugador2 = new List<KeyValuePair<int, Pieza>>
            {
                new KeyValuePair<int, Pieza>(3, new Pieza(1,7))
            };
        }




        private bool ValidarPosicionPiezaEnJugador(int jugador, int posPieza)
        {
            switch (jugador)
            {
                case 1:
                    return posPieza >= 0 && posPieza < _piezasJugador1.Count;
                case 2:
                    return posPieza >= 0 && posPieza < _piezasJugador2.Count;
                default:
                    return false;
            }
        }

        public void CambiarTurno(Pieza piezaJugador)
        {
            Turno = piezaJugador.DuenoPieza.Equals('1') ? 2 : 1;
        }

        public bool PrimeraPiezaEnMezaPorJugador(int jugador, int posPieza)
        {
            switch (jugador)
            {
                case 1:
                    if (_mesaJuego.Count == 0)
                    {
                        if (!ValidarPosicionPiezaEnJugador(jugador, posPieza))
                            return false;

                        var piezaTemp = _piezasJugador1.ElementAt(posPieza);
                        _piezasJugador1.RemoveAt(posPieza);
                        _mesaJuego.Add(piezaTemp);
                        CambiarTurno(piezaTemp.Value);
                        return true;
                    }
                    return false;
                case 2:
                    if (_mesaJuego.Count == 0)
                    {
                        if (!ValidarPosicionPiezaEnJugador(jugador, posPieza))
                            return false;

                        var piezaTemp = _piezasJugador2.ElementAt(posPieza);
                        _piezasJugador2.RemoveAt(posPieza);
                        _mesaJuego.Add(piezaTemp);
                        CambiarTurno(piezaTemp.Value);
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
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

        private void TomarPiezaDelPozo(int jugador)
        {
            KeyValuePair<int, Pieza> nuevaPieza;
            switch (jugador)
            {
                case 1:
                    if (_pozoPiezas.Count != 0)
                    {
                        nuevaPieza = _pozoPiezas.Pop();
                        _piezasJugador1.Add(nuevaPieza);
                    }
                    break;
                case 2:
                    if (_pozoPiezas.Count != 0)
                    {
                        nuevaPieza = _pozoPiezas.Pop();
                        _piezasJugador1.Add(nuevaPieza);
                    }
                    break;
            }
        }

        public bool PonerPizaEnMesaPorJugador(int jugador, int posPieza)
        {
            switch (jugador)
            {
                case 1:
                    if (!PrimeraPiezaEnMezaPorJugador(jugador, posPieza))
                    {
                        var piezaJugador = _piezasJugador1.ElementAt(posPieza);
                        var idicePieza = _piezasJugador1.IndexOf(piezaJugador);
                        if (InsertarPieza(piezaJugador))
                        {
                            _piezasJugador1.RemoveAt(idicePieza);
                            if (_piezasJugador1.Count == 0)
                            {
                                DefinirGanadorPorFaltaDePiezas(1);
                            }
                            return true;
                        }
                        TomarPiezaDelPozo(jugador);
                        return false;
                    }
                    break;
                case 2:
                    if (!PrimeraPiezaEnMezaPorJugador(jugador, posPieza))
                    {
                        var piezaJugador = _piezasJugador2.ElementAt(posPieza);
                        var idicePieza = _piezasJugador2.IndexOf(piezaJugador);
                        if (InsertarPieza(piezaJugador))
                        {
                            _piezasJugador2.RemoveAt(idicePieza);
                            if (_piezasJugador2.Count == 0)
                            {
                                DefinirGanadorPorFaltaDePiezas(2);
                            }
                            return true;
                        }
                        TomarPiezaDelPozo(jugador);
                        return false;
                    }
                    break;
                default:
                    return false;
            }
            return false;
        }

        public void DefinirGanadorPorFaltaDePiezas(int jugador)
        {
            switch (jugador)
            {
                case 1:
                    Console.WriteLine("Ha Ganado el Jugador 1 por quedarse antes sin piezas");
                    Ganador = 1;
                    break;
                case 2:
                    Console.WriteLine("Ha Ganado el Jugador 2 por quedarse antes sin piezas");
                    Ganador = 2;
                    break;
            }
        }

    }
}