using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Six_Backpack
{
    struct Item
    {
        public double mass;
        public double price;

        public override string ToString()
        {
            return String.Format("Цена {0}, масса {1}", price, mass);
        }
    }

    class Program
    {
        const int I = 5; // число предметов в рюкзаке
        const int Weight = 10; //допустимый вес

        static bool ending = false; 

        static List<Item> items;

        static Stack<Item> currentItems = new Stack<Item>(); 
        static Item current = new Item(); 
        static Item[] optItems = null; 
        static Item max = new Item(); 

        static Random rnd = new Random(); //случайная генерация 

        static void next(int i)
        {
            i++;

            if ((i > items.Count - 1) || (current.mass + items[i].mass > Weight))
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
            items = new List<Item>(I);

            for (int i = 0; i < I; i++)
            {
                Item item = new Item();
                item.mass = rnd.Next(1, 10);
                item.price = rnd.Next(1, 10);

                items.Add(item);
            }

            Console.WriteLine("Исходные данные:");
            foreach (Item item in items)
                Console.WriteLine(item);

            Console.WriteLine("");
            Console.WriteLine("Лучший набор:");

            max.price = -1;
            next(-1);

            if (optItems != null)
            {
                foreach (Item item in optItems)
                    Console.WriteLine(item);
                Console.WriteLine("");
                Console.WriteLine("Итого:");
                Console.WriteLine(max);
            }
            else
                Console.WriteLine("Решения нет!");

            Console.ReadKey();
        }
    }
}
