using System;
using System.Collections.Generic;
using Domino.Logic;
using Domino.Logic.Interfaces;

namespace ConsolePlayDomino
{
    public class PlayDomino
    {
        private readonly List<KeyValuePair<int, Pieza>> _jugador1;
        private readonly List<KeyValuePair<int, Pieza>> _jugador2;
        private readonly List<KeyValuePair<int, Pieza>> _mesaJuego;


        //private JuegoDomino _juegoDomino;
        public IDomino JuegoDominoJz;

        public PlayDomino(IDomino dominoJz)
        {
            JuegoDominoJz=dominoJz;
            _jugador1 = JuegoDominoJz.PiezasJugador1;
            _jugador2 = JuegoDominoJz.PiezasJugador2;
            _mesaJuego = JuegoDominoJz.MesaJuego;
        }


        public void ImprimirJuego()
        {
            Console.Clear();

            Console.WriteLine("\n\n\t\tBIENVENIDO A DOMINO JZ");
            Console.WriteLine("\nTURNO: Jugador "+JuegoDominoJz.Turno);

            var contador1 = 1;
            var contador2 = 1;
            Console.WriteLine("\nJugador1");
            foreach (var pair in _jugador1)
            {
                Console.Write(contador1+"\t");
                contador1++;
            }
            Console.WriteLine();
            foreach (var pair in _jugador1)
            {

                Console.Write("|"+pair.Value.ValorA+"-"+pair.Value.ValorB+"|   ");
            }
            Console.WriteLine("\n\n");

            
            foreach (var keyValuePair in _mesaJuego)
            {
                Console.Write("|" + keyValuePair.Value.ValorA + "-" + keyValuePair.Value.ValorB + "|");
            }



            Console.WriteLine("\n\n");
            foreach (var pair in _jugador2)
            {
                Console.Write("|" + pair.Value.ValorA + "-" + pair.Value.ValorB + "|   ");
            }
            Console.WriteLine();
            foreach (var pair in _jugador2)
            {
                Console.Write(contador2 + "\t");
                contador2++;
            }
            Console.WriteLine();
            Console.WriteLine("Jugador2");
            
            
            
        }


        public void EstablecerTurno()
        {
            if (JuegoDominoJz.EstablecerTurnoJugadorConPiezaDobleAltaMasAlta() == 0)
            {
                JuegoDominoJz.EstablecerTurnoPorSumaDeValores();
            }
        }


        public void PegungarMovimiento()
        {
            Console.WriteLine();
            switch (JuegoDominoJz.Turno)
            {
                case 1:
                    Console.Write("Jugador 1, Indique la pieza a mover de su mano(0 para pieza del pozo): ");
                    var posicionPieza1 = Console.ReadLine();

                    if (!string.IsNullOrEmpty(posicionPieza1))
                        if (!JuegoDominoJz.PonerPizaEnMesaPorJugador(1, Int32.Parse(posicionPieza1)-1))
                        {
                            Console.WriteLine("Jugador 1 tomo una pieza del pozo");
                        }

                    break;
                case 2:
                    Console.Write("Jugador 2, Indique la pieza a mover de su mano(0 para pieza del pozo): ");
                    var posicionPieza2 = Console.ReadLine();

                    if (!string.IsNullOrEmpty(posicionPieza2))
                        if (!JuegoDominoJz.PonerPizaEnMesaPorJugador(2, Int32.Parse(posicionPieza2)-1))
                        {
                            Console.WriteLine("Jugador 2 tomo una pieza del pozo");
                        }

                    break;
            }
        }

        public void MostrarEstadisticas()
        {
            JuegoDominoJz.MotrarEstadisticas();
            Console.ReadKey();
        }
    }
}
