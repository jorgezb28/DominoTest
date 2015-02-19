using System.IO;

namespace Domino.Test.Mocking
{
    public class MockEscrituraEstadistica
    {
        public bool EscribirEstadistica(int jugador)
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
                        return true;
                    case 2:
                        writer.Write(puntosJugador1);
                        writer.Write(puntosJugador2 + 1);
                        return true;
                }
            }
            return false;
        }
    }
}