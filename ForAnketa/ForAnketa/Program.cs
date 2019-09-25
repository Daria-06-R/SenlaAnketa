using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAnketa 
{
    class Program
    {
        static void Main(string[] args)
        {
            ChisloInf();
            Console.ReadKey();
        }

        public static void ChisloInf()
        {
            int chislo;
            do
            {
                try
                {
                    Console.Write("Пожалуйста, введите целое число ");
                    chislo = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка! Введите целое число ");
                }
            }
            while (true);

            if (IsEven(chislo))
            {
                Console.Write("Четное ");
            }
            else
            {
                Console.Write("Нечетное ");
            }

            if (IsPrime(chislo))
            {
                Console.Write("и простое");
            }
            else
            {
                if (IsSost(chislo))
                {
                    Console.Write("и составное");
                }
                else
                {
                    Console.Write("не простое и не составное");
                }
            }
        }

        public static bool IsEven(int a)
        {
            if (a % 2 == 0)
            { return true; }
            else
            { return false; }
        }

        public static bool IsPrime(int b)
        {
            if (b <= 1)
                return false;
            if (b == 2)
                return true;
            if ((!IsEven(b)))
            {
                for (long i = 3; i < b; i += 2)
                    if (b % i == 0)
                        return false;
                return true;
            }
            else
                return false;
        }

        public static bool IsSost(int q)
        {
            if ((!IsPrime(q)) && (q > 1))
            { return true; }
            else
            { return false; }
        }
    }
}

