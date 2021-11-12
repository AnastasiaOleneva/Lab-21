using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab_21
{
    class Program
    {
        static int[,] plot;
        static int n;
        static int m;
        
        static void Main(string[] args)
        {
            int n=12  ;
            int m=3  ;
            plot = new int[n,m];
            Thread gardener1 = new Thread(Gard1);
            Thread gardener2 = new Thread(Gard2);
            gardener1.Start();
            gardener2.Start();
            gardener1.Join();
            gardener2.Join();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(plot[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();

        }
        public static void Gard1()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (plot[i, j] == 0)
                        plot[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
           
        }

        public static void Gard2()
        {
            for (int i = m-1; i > 0; i--)
            {
                for (int j = n-1; j > 0; j--)
                {
                    if (plot[j, i] == 0) 
                        plot[j, i] = 2;
                    Thread.Sleep(1);
                }
            }

        }
    }
}
