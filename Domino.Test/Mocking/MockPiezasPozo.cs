using System;
using System.Collections.Generic;
using System.Linq;
using Domino.Logic;

namespace Domino.Test.Mocking
{
    public class MockPiezasPozo
    {
        private readonly List<int> _piezasNormales; 
        private readonly Random _rand;

        public MockPiezasPozo()
        {
            _rand = new Random(Environment.TickCount);
            _piezasNormales=new List<int>()
            {
                1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28
            };
        }

        public List<KeyValuePair<int,int>>  GenerarPiezasPozo()
        {
            var tempList = new List<KeyValuePair<int, int>>();

            foreach (var piezaDomino in _piezasNormales)
            {
                tempList.Add(new KeyValuePair<int, int>(_rand.Next(1, 100), piezaDomino));
            }
            return tempList;
        }

        public List<KeyValuePair<int,int>>OrdenarPozo(List<KeyValuePair<int,int>> pozoDesordenado)
        {
            var pozoOrdenado = new List<KeyValuePair<int, int>>(pozoDesordenado.OrderBy(p => p.Key));
            return pozoOrdenado;
        }

        public int ObtenerCuentaPiezas()
        {
            return _piezasNormales.Count;
        }
    }
}
