using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOK_NOD 
{
    class Program
    {
        static void Main(string[] args)
        {
            double m, n;
            do
            {
                try
                {
                    Console.Write("Введите число m = ");
                    m = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка! Введите число ");
                }
            }
            while (true);

            do
            {
                try
                {
                    Console.Write("Введите число n = ");
                    n = Convert.ToDouble(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка! Введите число ");
                }
            }
            while (true);
            
            Console.WriteLine("НОД = {0}", NOD(m, n));
            Console.WriteLine("НОК = {0}", NOK(m, n));

            Console.ReadKey();
        }

        public static double NOD(double m, double n)
        {
            while (m != n)
            {
                if (m > n)
                    m = m - n;
                else
                    n = n - m;
            }
            return m;
        }

        public static double NOK(double m, double n)
        {
            return Math.Abs(m * n) / NOD(m, n);
        }
    }
}
