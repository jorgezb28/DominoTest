using System.Collections.Generic;
using Domino.Logic;

namespace Domino.Test.Mocking
{
    public class MockJugador1ConMenosPiezas
    {
        private readonly List<KeyValuePair<int, Pieza>> _piezasJugador1;
        private readonly List<KeyValuePair<int, Pieza>> _piezasJugador2;


        public MockJugador1ConMenosPiezas()
        {

            _piezasJugador1 = new List<KeyValuePair<int, Pieza>>()
            {

                new KeyValuePair<int, Pieza>(3, new Pieza(10, 30)),
                new KeyValuePair<int, Pieza>(3, new Pieza(10, 30)),
                new KeyValuePair<int, Pieza>(3, new Pieza(10, 30)),
                new KeyValuePair<int, Pieza>(3, new Pieza(10, 30))
                
            };

            _piezasJugador2 = new List<KeyValuePair<int, Pieza>>()
            {
                new KeyValuePair<int, Pieza>(3, new Pieza(11,44)), 
                new KeyValuePair<int, Pieza>(3, new Pieza(11,44)),
                new KeyValuePair<int, Pieza>(3, new Pieza(21,44)), 
                new KeyValuePair<int, Pieza>(3, new Pieza(31,44)),
                new KeyValuePair<int, Pieza>(3, new Pieza(11,44)), 
                new KeyValuePair<int, Pieza>(3, new Pieza(21,44)),
                new KeyValuePair<int, Pieza>(3, new Pieza(11,44)) 
            };
        }

        public string DefinirGanadorPorPozoVacio()
        {
            var piezasJugador1 = _piezasJugador1.Count;
            var piezasJugador2 = _piezasJugador2.Count;
            if (piezasJugador1 == piezasJugador2)
            {
                return "Empate";
            }
            return piezasJugador1 < piezasJugador2 ? "Jugador 1" : "Jugador 2";
        }



    }
}