using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PrimosTime
{
    class PrimoTime
    {
        private Timer timer;
        private Queue<int> primos = new Queue<int>();
        private bool ver = true;
        public void PrimoT()
        {
            Console.Clear();
            Console.SetWindowSize(100, 20);
            Console.SetBufferSize(100, System.Int16.MaxValue - 1);
            SQL sql = new SQL();
            Queue<int> queue = sql.SelectPrimos();
            Console.Write("Quanto tempo deseja processar?\nR: ");
            timer = new Timer
            {
                Interval = Convert.ToDouble(Console.ReadLine()) * 1000
            };
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
            Console.WriteLine("Processamento iniciado em {0}", DateTime.Now);
            int a = 2;
            int cont = 0;
            do
            {
                bool verP = false;
                for (int b = 2; b < a; b++)
                {
                    if (a % b == 0)
                    {
                        verP = true;
                        break;
                    }
                }
                if (!verP)
                {
                    primos.Enqueue(a);
                    cont++;
                }
                a++;
            } while (ver);
            Console.WriteLine("O processamento acabou em {0}", DateTime.Now);            
            foreach (int resultado in primos)
            {
                Console.Write("{0} ", resultado);
                if (!queue.Contains(resultado))
                {
                    sql.InsertTable(resultado);
                }
            }
            Console.WriteLine("\nForam descobertos {0} números primos", primos.Count);
            Console.ReadKey();
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("O evento para o termino do processamento foi eviado em {0}", e.SignalTime);
            ver = false;
            timer.Enabled = false;
        }        
    }
}
