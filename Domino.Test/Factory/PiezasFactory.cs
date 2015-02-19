using System;
using System.Collections.Generic;
using System.ComponentModel;
using Domino.Logic;

namespace Domino.Test.Factory
{
    public class PiezasFactory
    {
        public static List<KeyValuePair<int, Pieza>> GenerarPiezasExtremoA(int cantidad)
        {
            var rand = new Random(Environment.TickCount);
            var tempStack = new List<KeyValuePair<int, Pieza>>();

            for (var i = 0; i < cantidad; i++)
            {
                Pieza piezaNueva;
                if (i == 0)
                {
                    piezaNueva = new Pieza(1, rand.Next(2, 6))
                    {
                        PiezaB = new Pieza(rand.Next(2, 6), rand.Next(2, 6)),
                        PiezaA = null
                    };
                }
                else
                {
                    piezaNueva = new Pieza(1, rand.Next(2, 6))
                    {
                        PiezaA = new Pieza(rand.Next(2, 6), rand.Next(2, 6)),
                        PiezaB = new Pieza(rand.Next(2, 6), rand.Next(2, 6))
                    };
                }
                tempStack.Add(new KeyValuePair<int, Pieza>(rand.Next(1, 100), piezaNueva));
            }
            return tempStack;

        }

        public static List<KeyValuePair<int, Pieza>> GenerarPiezasExtremoB(int cantidad)
        {
            var rand = new Random(Environment.TickCount);
            var tempStack = new List<KeyValuePair<int, Pieza>>();

            for (var i = 0; i < cantidad; i++)
            {
                Pieza piezaNueva;
                if (i == cantidad - 1)
                {
                    piezaNueva = new Pieza(rand.Next(1, 5), 6)
                    {
                        PiezaA = new Pieza(rand.Next(1, 5), rand.Next(1, 5)),
                        PiezaB = null
                    };
                }
                else
                {
                    piezaNueva = new Pieza(rand.Next(1, 5), 6)
                    {
                        PiezaA = new Pieza(rand.Next(1, 5), rand.Next(1, 5)),
                        PiezaB = new Pieza(rand.Next(1, 5), rand.Next(1, 5))
                    };
                }
                tempStack.Add(new KeyValuePair<int, Pieza>(rand.Next(1, 100), piezaNueva));
            }
            return tempStack;

        }

        public static List<KeyValuePair<int, Pieza>> GenerarPiezasPozo()
        {
            var rand = new Random(Environment.TickCount);
            var tempStack = new List<KeyValuePair<int, Pieza>>();

            for (int i = 0; i < 16; i++)
            {
                tempStack.Add(new KeyValuePair<int, Pieza>(rand.Next(1,100),new Pieza(rand.Next(1,6),rand.Next(1,6))));
            }
            return tempStack;
        }
    }
}
