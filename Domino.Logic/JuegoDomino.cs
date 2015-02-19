using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using Domino.Logic.Interfaces;

namespace Domino.Logic
{
    public class JuegoDomino:IDomino
    {
        private readonly List<Pieza> _arregloPiezas;
        private readonly Stack<KeyValuePair<int, Pieza>> _pozoPiezas;
        private List<KeyValuePair<int, Pieza>> _mesaJuego;
        private readonly Random _rand;

        private List<KeyValuePair<int, Pieza>> _piezasJugador1;
        private List<KeyValuePair<int, Pieza>> _piezasJugador2;
        
        public List<KeyValuePair<int, Pieza>>  PiezasJugador1
        {
            get { return _piezasJugador1; }
            set { _piezasJugador1 = value; }
        }
        public List<KeyValuePair<int, Pieza>> PiezasJugador2
        {
            get { return _piezasJugador2; }
            set { _piezasJugador2 = value; }
        }
        public List<KeyValuePair<int, Pieza>> MesaJuego
        {
            get { return _mesaJuego; }
            set { _mesaJuego = value; }
        }
        
        public int Turno { get; set; }

        public JuegoDomino()
        {
            _rand = new Random(Environment.TickCount);
            _arregloPiezas = GenerarPiezas();
            _pozoPiezas = new Stack<KeyValuePair<int, Pieza>>(GenerarPiezasPozo());
            _mesaJuego = new List<KeyValuePair<int, Pieza>>();
            _pozoPiezas = OrdenarPozo(_pozoPiezas.ToList());
            _piezasJugador1 = new List<KeyValuePair<int, Pieza>>(AsignarPiezasDeJugadores("1"));
            _piezasJugador2 = new List<KeyValuePair<int, Pieza>>(AsignarPiezasDeJugadores("2"));

        }

        public Stack<KeyValuePair<int, Pieza>> OrdenarPozo(List<KeyValuePair<int, Pieza>> pozoInicial)
        {
            var pozoOrdenado = new Stack<KeyValuePair<int, Pieza>>(pozoInicial.OrderBy(p => p.Key));
            return pozoOrdenado;
        }

        public List<Pieza> GenerarPiezas()
        {
            var temPiezas = new List<Pieza>();
            for (var i = 0; i <= 6; i++)
            {
                for (var j = 0; j <= i; j++)
                {
                    temPiezas.Add(new Pieza(i, j));
                }
            }
            return temPiezas;
        }

        public int ObtenerCuentaPiezas()
        {
            return _arregloPiezas.Count;
        }

        public int ObtenerCuentaPiezasDelPozo()
        {
            return _pozoPiezas.Count;
        }

        public List<KeyValuePair<int, Pieza>> GenerarPiezasPozo()
        {
            var tempStack = new List<KeyValuePair<int, Pieza>>();

            foreach (var piezaDomino in _arregloPiezas)
            {
                tempStack.Add(new KeyValuePair<int, Pieza>(_rand.Next(1, 100), piezaDomino));
            }
            return tempStack;
        }

        public List<KeyValuePair<int, Pieza>> AsignarPiezasDeJugadores(string jugador)
        {
            if (jugador.Equals("1"))
            {
                _piezasJugador1 = ObtenerPiezasDelJugador('1');
                return _piezasJugador1;
            }
            _piezasJugador2 = ObtenerPiezasDelJugador('2');
            return _piezasJugador2;
        }

        public List<KeyValuePair<int, Pieza>> ObtenerPiezasDelJugador(char owner)
        {
            var piezasJugador = new List<KeyValuePair<int, Pieza>>();
            for (var i = 0; i < 7; i++)
            {
                var pieza = _pozoPiezas.Pop();
                pieza.Value.DuenoPieza = owner;
                piezasJugador.Add(pieza);
            }
            return piezasJugador;
        }

        public int EstablecerTurnoJugadorConPiezaDobleAltaMasAlta()
        {
            var jugadorPizaDobleAlta = 0;
            var piezaMayor = new Pieza(-1, -1) {DuenoPieza = 'M'};

            foreach (var pair in _piezasJugador1)
            {
                var piezaActual = pair.Value;
                if (!piezaActual.ValorA.Equals(piezaActual.ValorB))
                {
                    continue;
                }

                if (piezaActual.ValorA > piezaMayor.ValorA)
                {
                    piezaMayor = piezaActual;
                }
            }

            foreach (var pair in _piezasJugador2)
            {
                var piezaActual = pair.Value;
                if (!piezaActual.ValorA.Equals(piezaActual.ValorB))
                {
                    continue;
                }

                if (piezaActual.ValorA > piezaMayor.ValorA)
                {
                    piezaMayor = piezaActual;
                }
            }

            if (piezaMayor.DuenoPieza.Equals('1') || piezaMayor.ValorA == (-1))
            {
                jugadorPizaDobleAlta = 1;
                Turno = 1;
            }
            else if (piezaMayor.DuenoPieza.Equals('2'))
            {
                jugadorPizaDobleAlta = 2;
                Turno = 2;
            }
            return jugadorPizaDobleAlta;
        }

        public int EstablecerTurnoPorSumaDeValores()
        {
            var sumaJugador1 = ObtenerSumaDeValoresPiezaPorJugador(1);
            var sumaJugador2 = ObtenerSumaDeValoresPiezaPorJugador(2);
            if (sumaJugador1 == 0 && sumaJugador2 == 0)
            {
                Turno = 1;
                return 0;
            }
            return sumaJugador1 >= sumaJugador2 ? 1 : 2;
        }

        public int ObtenerSumaDeValoresPiezaPorJugador(int jugador)
        {
            var sumaPiezas = 0;
            switch (jugador)
            {
                case 1:
                    foreach (var keyValuePair in _piezasJugador1)
                    {
                        sumaPiezas += keyValuePair.Value.ValorA + keyValuePair.Value.ValorB;
                    }
                    break;
                case 2:
                    foreach (var keyValuePair in _piezasJugador1)
                    {
                        sumaPiezas += keyValuePair.Value.ValorA + keyValuePair.Value.ValorB;
                    }
                    break;
            }
            return sumaPiezas;
        }


        //ojo con open/close 
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

        public void CambiarTurno(Pieza piezaJugador)
        {
            Turno = piezaJugador.DuenoPieza.Equals('1') ? 2 : 1;
        }

        public bool ValidarPosicionPiezaEnJugador(int jugador, int posPieza)
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

        public int ObtenerCuentaPiezasJugador(int jugador)
        {
            switch (jugador)
            {
                case 1:
                    return _piezasJugador1.Count;
                case 2:
                    return _piezasJugador2.Count;
                default:
                    return -1;
            }
        }

        public bool PonerPizaEnMesaPorJugador(int jugador, int posPieza)
        {
            switch (jugador)
            {
                case 1:
                    if (!PrimeraPiezaEnMezaPorJugador(jugador, posPieza))
                    {
                        if (ValidarPosicionPiezaEnJugador(jugador, posPieza))
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
                        TomarPiezaDelPozo(jugador);
                        return false;
                    }
                    return true;
                case 2:
                    if (!PrimeraPiezaEnMezaPorJugador(jugador, posPieza))
                    {
                        if (ValidarPosicionPiezaEnJugador(jugador, posPieza))
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
                        TomarPiezaDelPozo(jugador);
                        return false;
                    }
                    return true;
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
                    CambiarTurno(piezaJugador.Value);

                    return true;
                }
                if (piezaExtremoA.Value.ValorA == piezaJugador.Value.ValorB)
                {
                    piezaJugador.Value.PiezaB = piezaExtremoA.Value;
                    piezaExtremoA.Value.PiezaA = piezaJugador.Value;
                    _mesaJuego.RemoveAt(0);
                    _mesaJuego.Insert(0, piezaJugador);
                    _mesaJuego.Insert(1, piezaExtremoA);
                    CambiarTurno(piezaJugador.Value);
                    return true;
                }
                //return false;
            }

            if (piezaExtremoB.Value.PiezaB == null)
            {
                if (piezaExtremoB.Value.ValorB == piezaJugador.Value.ValorA)
                {
                    piezaJugador.Value.PiezaA = piezaExtremoB.Value;
                    piezaExtremoB.Value.PiezaB = piezaJugador.Value;
                    _mesaJuego.RemoveAt(indiceExtremoB);
                    _mesaJuego.Add(piezaExtremoB);
                    _mesaJuego.Add(piezaJugador);
                    CambiarTurno(piezaJugador.Value);
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
                    _mesaJuego.Add(piezaExtremoB);
                    _mesaJuego.Add(piezaJugador);
                    CambiarTurno(piezaJugador.Value);
                    return true;
                }
                //return false;
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
                    else
                    {
                        DefinirGanadorPorPozoVacio();
                    }
                    break;
                case 2:
                    if (_pozoPiezas.Count != 0)
                    {
                        nuevaPieza = _pozoPiezas.Pop();
                        _piezasJugador2.Add(nuevaPieza);
                    }
                    else
                    {
                        DefinirGanadorPorPozoVacio();
                    }
                    break;
            }
        }

        public void DefinirGanadorPorFaltaDePiezas(int jugador)
        {
            switch (jugador)
            {
                case 1:
                    Console.WriteLine("Ha Ganado el Jugador 1 por quedarse antes sin piezas");
                    EscribirEstadistica(1);
                    break;
                case 2:
                    Console.WriteLine("Ha Ganado el Jugador 2 por quedarse antes sin piezas");
                    EscribirEstadistica(2);
                    break;
            }
        }

        public void DefinirGanadorPorPozoVacio()
        {
            var piezasJugador1 = _piezasJugador1.Count;
            var piezasJugador2 = _piezasJugador2.Count;
            if (piezasJugador1 == piezasJugador2)
            {
                Console.WriteLine("Ha habido un empate");
            }

            if (piezasJugador1 < piezasJugador2)
            {
                Console.WriteLine("El Jugador 1 ha Ganado la Partida por tener menos piezas");
                EscribirEstadistica(1);
            }
            else
            {
                Console.WriteLine("El Jugador 2 ha Ganado la Partida por tener menos piezas");
                EscribirEstadistica(2);
            }
        }

        public void EscribirEstadistica(int jugador)
        {
            const string fileName = "Estadisticas.jef";
            var puntosJugador1 = 0;
            var puntosJugador2 = 0;

            if (File.Exists(fileName))
            {
                using (var reader = new BinaryReader(File.Open(fileName, FileMode.OpenOrCreate)))
                {
                    puntosJugador1 = reader.ReadInt32();
                    puntosJugador2 = reader.ReadInt32();
                }
            }

            using (var writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                switch (jugador)
                {
                    case 1:
                        writer.Write(puntosJugador1 + 1);
                        writer.Write(puntosJugador2);
                       break;
                    case 2:
                        writer.Write(puntosJugador1);
                        writer.Write(puntosJugador2 + 1);
                        break;
                }
            }
            MotrarEstadisticas();
        }

        public void MotrarEstadisticas()
        {
            const string fileName = "Estadisticas.jef";
            Console.WriteLine("\n\n\t\tESTADISTICAS DE DOMINO JZ");
            if (File.Exists(fileName))
            {
                int puntosJugador1;
                int puntosJugador2;
                using (var reader = new BinaryReader(File.Open(fileName, FileMode.OpenOrCreate)))
                {
                    puntosJugador1 = reader.ReadInt32();
                    puntosJugador2 = reader.ReadInt32();
                }
                Console.WriteLine("\n\nJugador 1: "+puntosJugador1);
                Console.WriteLine("Jugador 2: " + puntosJugador2);

                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Error al abrir el archivo");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        
    }
}