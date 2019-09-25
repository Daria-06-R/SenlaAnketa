using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackPack
{
    struct Item
    {
        public double mass;
        public double price;

        public override string ToString()
        {
            return String.Format("Цена {0}, Масса: {1}", price, mass);
        }
    }

    class Program
    {
        // Число предментов в рюкзаке
        const int n = 5;
        // Ограничение по массе
        const int maxMass = 10;

        static bool ending = false;

        static List<Item> items;

        static Stack<Item> currentItems = new Stack<Item>();
        static Item current = new Item();
        static Item[] optItems = null;
        static Item max = new Item();

        static Random rnd = new Random(1);

        static int ComparerItemMass(Item a, Item b)
        {
            if (a.price / a.mass > b.price / b.mass)
                return -1;

            if (a.price / a.mass < b.price / b.mass)
                return 1;

            return 0;
        }

        static void next(int i)
        {
            i++;

            if ((i > items.Count - 1) || (current.mass + items[i].mass > maxMass))
            {
                if (current.price > max.price)
                {
                    optItems = currentItems.ToArray();
                    max = current;
                    if (current.mass == max.mass)
                        ending = true;
                    return;
                }
            }

            currentItems.Push(items[i]);
            current.mass += items[i].mass;
            current.price += items[i].price;
            next(i);

            currentItems.Pop();
            current.mass -= items[i].mass;
            current.price -= items[i].price;
            if (ending != true)
                next(i);
        }

        static void Main(string[] args)
        {
            items = new List<Item>(n);

            for (int i = 0; i < n; i++)
            {
                Item item = new Item();
                item.mass = rnd.Next(1, 10);
                item.price = rnd.Next(1, 10);

                items.Add(item);
            }

            items.Sort(ComparerItemMass);

            Console.WriteLine("Исходные данные (отсортированы по удельной стоимости):");
            foreach (Item item in items)
                Console.WriteLine(item);

            Console.WriteLine("");
            Console.WriteLine("------------------");
            Console.WriteLine("");
            Console.WriteLine("Оптимальный набор туриста:");

            max.price = -1;
            next(-1);

            if (optItems != null)
            {
                foreach (Item item in optItems)
                    Console.WriteLine(item);
                Console.WriteLine("Итого:");
                Console.WriteLine(max);
            }
            else
                Console.WriteLine("Что-то не так...");

            Console.ReadKey();
        }
    }
}
