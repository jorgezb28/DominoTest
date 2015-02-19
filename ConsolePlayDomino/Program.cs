using System;
using Domino.Logic;
using Domino.Logic.Interfaces;
using Microsoft.Practices.Unity;

namespace ConsolePlayDomino
{
    class Program
    {
        static readonly IUnityContainer Ioc = new UnityContainer();

        static void Main()
        {
            //IUnityContainer ioc=new UnityContainer();
            Ioc.RegisterType<IDomino, JuegoDomino>();
            Ioc.RegisterType<PlayDomino>();
            
            
            Jugar();
        }

        private static void Jugar()
        {
            var juegoDomino = Ioc.Resolve<PlayDomino>();
            var continuar = true;

            juegoDomino.EstablecerTurno();
            
            do
            {
                juegoDomino.ImprimirJuego();
                juegoDomino.PegungarMovimiento();
                juegoDomino.ImprimirJuego();
                

                
                
                Console.Write("\nDesea continuar jugando? (S/N) ");
                var respuesta = Console.ReadLine();
                if (!string.IsNullOrEmpty(respuesta))
                {
                    if ((!respuesta[0].Equals('N') && !respuesta[0].Equals('n'))) 
                        continue;
                    continuar = false;
                    juegoDomino.MostrarEstadisticas();
                }
                else
                {
                    Console.Clear();
                }
            } while (continuar);
            

            
        }
    }
}
