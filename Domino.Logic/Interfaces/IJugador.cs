using System.Collections.Generic;

namespace Domino.Logic.Interfaces
{
    public interface IJugador
    {
        List<KeyValuePair<int, Pieza>> PiezasJugador1 { get; set; }
        List<KeyValuePair<int, Pieza>> PiezasJugador2 { get; set; }

        List<KeyValuePair<int, Pieza>> ObtenerPiezasDelJugador(char owner);
        int EstablecerTurnoJugadorConPiezaDobleAltaMasAlta();
        int EstablecerTurnoPorSumaDeValores();
        bool ValidarPosicionPiezaEnJugador(int jugador, int posPieza);
        int ObtenerCuentaPiezasJugador(int jugador);

    }
}
