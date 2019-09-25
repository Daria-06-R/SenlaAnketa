using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Six
{
    class Backpack
    {
        private List<Predmet> bestNabor = null;
        private double maxW;
        private double bestPrice;
        public Backpack(double MAXW)
        {
            maxW = MAXW;
        }

        //создание всех наборов перестановок значений
        public void MakeAllSets(List<Predmet> Pr)
        {
            if (Pr.Count > 0)
                CheckSet(Pr);

            for (int i = 0; i < Pr.Count; i++)
            {
                List<Predmet> newSet = new List<Predmet>(Pr);

                newSet.RemoveAt(i);

                MakeAllSets(newSet);
            }

        }

        //проверка, является ли данный набор лучшим решением задачи
        private void CheckSet(List<Predmet> Pr)
        {
            if (bestNabor == null)
            {
                if (CalcWeigth(Pr) <= maxW)
                {
                    bestNabor = Pr;
                    bestPrice = CalcPrice(Pr);
                }
            }
            else
            {
                if (CalcWeigth(Pr) <= maxW && CalcPrice(Pr) > bestPrice)
                {
                    bestNabor = Pr;
                    bestPrice = CalcPrice(Pr);
                }
            }
        }

        //вычисляет общий вес набора предметов
        private double CalcWeigth(List<Predmet> Pr)
        {
            double sumW = 0;

            foreach (Predmet i in Pr)
            {
                sumW += i.weigth;
            }

            return sumW;
        }

        //вычисляет общую стоимость набора предметов
        private double CalcPrice(List<Predmet> Pr)
        {
            double sumPrice = 0;

            foreach (Predmet i in Pr)
            {
                sumPrice += i.price;
            }

            return sumPrice;
        }

        //возвращает решение задачи (набор предметов)
        public List<Predmet> GetBestSet()
        {
            return bestNabor;
        }
    }
}
