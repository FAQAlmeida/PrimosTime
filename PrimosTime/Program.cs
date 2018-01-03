using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PrimosTime
{
    class Program
    {
        enum Opcoes
        {
            Tempo,
            Checar
        }
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.Title = "Números Primos do Poder Real!";
                Console.SetWindowSize(75, 18);
                Console.SetBufferSize(75, 18);
                int op = 0;
                foreach (var i in Enum.GetValues(typeof(Opcoes)))
                {
                    Console.WriteLine(String.Format("{0}) {1}", op++, i));
                }
                Console.Write("\nEscolha uma opção: ");
                int a = Convert.ToInt32(Console.ReadLine());
                switch (a)
                {
                    case 0:
                        {
                            PrimoTime pt = new PrimoTime();
                            pt.PrimoT();
                            break;
                        }
                    case 1:
                        {
                            Console.Clear();
                            Console.SetWindowSize(50, 4);
                            Console.SetBufferSize(50, 4);
                            PrimoCheck pc = new PrimoCheck();
                            Console.Write("Digite o valor a ser checkado: ");
                            Console.WriteLine("\n" + pc.check(Convert.ToInt32(Console.ReadLine())));
                            Console.ReadKey();
                            break;
                        }
                }
            } while (true);
            
        }
    }
}
