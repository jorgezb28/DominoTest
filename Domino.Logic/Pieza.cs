namespace Domino.Logic
{
    public class Pieza
    {
        public int ValorA { get; set; }
        public Pieza PiezaA { get; set; }

        public int ValorB { get; set; }
        public Pieza PiezaB { get; set; }

        public char DuenoPieza { get; set; }

        

        public Pieza(int a, int b)
        {
            ValorA = a;
            ValorB = b;
            DuenoPieza = 'M';
        }

    }
}