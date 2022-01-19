using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab21_4
{
    class Program
    {
        const int n = 3;
        const int m = 2;
        static int[,] path = new int[n, m] { { 2, 3 }, { 5, 6 }, { 4, 6 } };//время задержки садовника на работы, два садовника двигаются навстречу друг другу

        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Gardner1);// Делегат, указывающий на методы, которые вызываются при запуске потока
            Thread thread = new Thread(threadStart);//создаем поток для первого садовника
            thread.Start();// запуск

            Gardner2();// запуск потока для второго садовника
            
                for (int i=0; i<n; i++)
                {
                    for (int j=0; j<m; j++)
                    {
                        Console.Write($"{path[i, j]} ");
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();

        }

        static void Gardner1()//метод, который моделирует первого садовника
        {
            for(int i =0; i<n; i++ )
            {
                for (int j=0; j<m;j++)
                {
                    if (path[i, j]>=0)
                    {
                        int delay = path[i, j];//задержка
                        path[i, j] = -1;// заносим метку садовника
                        Thread.Sleep(delay);// вызываем и задерживаемся 

                    }
                }
            }
        }
        static void Gardner2()// метод, который моделирует второго садовника
        {
            for (int i=n-1; i>=0; i--)
            {
                for (int j=m-1; j>=0;j--)// садовник идет в обратную сторону
                {
                    if(path[i,j]>=0)
                    {
                        int delay = path[i, j];//задержка
                        path[i, j] = -2;// заносим метку садовника
                        Thread.Sleep(delay);// вызываем и задерживаемся 
                    }
                }

            }
        }
    }

}
