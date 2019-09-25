using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Five
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;
            Polindrom x = new Polindrom(); 
            Console.Write("Найдем числа-палиндромы до N = ");
            N = Convert.ToInt32(Console.ReadLine()); 
            if (N <= 100)
            {
                for (int i = 0; i <= N; i++)
                if (x.Palindrom(i))
                 Console.WriteLine(i); 
            }
            else
            {
                Console.Write("Число N не должно быть больше 100. Пожалуйста, повторите попытку");
            }

            Console.ReadKey();
        }
    }

    class Polindrom
    {
        public bool Palindrom(int n)
        {
            int a = 0;
            for (int i = n; i > 0; i /= 10)
                a = a * 10 + (i % 10);
            return n == a;
        }
    }
}
