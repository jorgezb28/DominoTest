using System.Collections.Generic;

namespace Domino.Logic.Interfaces
{
    public interface IDomino:IJugador
    {
        int Turno { get; set; }
        List<KeyValuePair<int, Pieza>> MesaJuego { get; set; }

        List<Pieza> GenerarPiezas();
        int ObtenerCuentaPiezas();
        int ObtenerCuentaPiezasDelPozo();
        List<KeyValuePair<int, Pieza>> GenerarPiezasPozo();
        void CambiarTurno(Pieza piezaJugador);

        bool PonerPizaEnMesaPorJugador(int jugador, int posPieza);
        void MotrarEstadisticas();

    }
}