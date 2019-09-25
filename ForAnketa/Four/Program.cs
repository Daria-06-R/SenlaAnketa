using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Four
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Пожалуйста, введите текст: ");
            string[] Text;
            string text = Console.ReadLine();

            Text = text.Split(' ');

            Console.Write("Пожалуйста, введите слово, которое хотите посчитать: ");
            string[] Slovo;
            string slovo = Console.ReadLine();

            Slovo = slovo.Split(' ');

            int count = Text.Count(s => s.StartsWith(slovo));
            Console.WriteLine("Количество {0}: " + count, Slovo);

            Console.ReadKey();
        }
    }
}
