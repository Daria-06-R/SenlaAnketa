using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Three
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Пожалуйста, введите текст: ");
            string[] Predloshenie;
            string text = Console.ReadLine();

            Predloshenie = text.Split(' ');

            IEnumerable<string> sortAscendingQuery = from Pr in Predloshenie orderby Pr select Pr;

            var text2 = text;
            var textInfo = new CultureInfo("ru-RU").TextInfo;
            var Text = textInfo.ToTitleCase(textInfo.ToLower(text2));

            Console.WriteLine("Количество слов: {0}" , Predloshenie.Length);

            Console.WriteLine(Environment.NewLine + "По алфавиту:");
            foreach (string s in sortAscendingQuery)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("");
            Console.WriteLine(Text);

            Console.ReadLine();
        }
    }
}
