using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask3
{
    public class Quaries
    {
        protected void Quiry0(List<Animal> la)
        {
            var q = la.GroupBy(x => GetBreed(x));
            Console.WriteLine("\r\nList of results:");
            foreach (var item in q)
            {
                Console.WriteLine("\r\nВид {0}", item.Key);
                ShowAnimals(item);
            }
        }
        protected void Quiry1(List<Animal> la)
        {
            //Задаваемое состояние
            bool flag = true;
            State _state = State.hungry;
            while (flag)
            {
                flag = false;
                Console.WriteLine("\r\nInput one of animal states - full, dead, ill or hungry:");
                switch (Console.ReadLine())
                {
                    case "full": _state = State.full; break;
                    case "dead": _state = State.dead; break;
                    case "ill": _state = State.ill; ; break;
                    case "hungry": _state = State.hungry; break;
                    default: flag = true; break;
                }
            }
            //Выборка
            Console.WriteLine("\r\nList of results");
            var q = la.Where(x => x.State == _state).Select(x => x);
            ShowAnimals(q);
        }
        protected void Quiry2(List<Animal> la)
        {
            var q = la.Where(x => x.State == State.ill)
                .Where(x => GetBreed(x) == "Tiger")
                .Select(x => x);
            Console.WriteLine("\r\nList of ill tigers:");
            ShowAnimals(q);
        }
        protected void Quiry3(List<Animal> la)
        {
            //Задаваемая кличка слона
            Console.WriteLine("\r\nInput elephant name");
            string elName = Console.ReadLine();
            Console.WriteLine("\r\nList of results:");
            //Выборка
            var q = la.Where(x => x.Name == elName).Where(x=>GetBreed(x)=="Elephant").Select(x => x);
            ShowAnimals(q);
        }
        protected void Quiry4(List<Animal> la)
        {
            var q = la.Where(x => x.State == State.hungry).Select(x => x.Name);

            Console.WriteLine("\r\nList of hungry animal names:");
            foreach (var i in q)
                Console.WriteLine(i);
        }
        protected void Quiry5(List<Animal> la)
        {
            var q = la.GroupBy(x => GetBreed(x));
            foreach (var i in q)
            {
                Console.WriteLine("\r\nAnimal with biggest helth of breed {0} is  ", i.Key);
                ShowAnimal(i.OrderByDescending(x => x.Helth).First());
            }
        }
        protected void Quiry6(List<Animal> la)
        {
            var q = la.GroupBy(x => GetBreed(x));

            foreach (var i in q)
                Console.WriteLine("\r\nDead {0} quantity is  {1}", i.Key, i.Where(x => x.State == State.dead).Count());
        }
        protected void Quiry7(List<Animal> la)
        {
            var q = la
                .Where(x => GetBreed(x) == "Wolf" || GetBreed(x) == "Bear")
                .Where(x => x.Helth > 3)
                .Select(x => x);
            Console.WriteLine("\r\nList of results:");
            ShowAnimals(q);
        }
        protected void Quiry8(List<Animal> la)
        {
            var q = la.
                Where(x => x.Helth == la.Max(a => a.Helth))
                .Take(1)
                .Concat(la.Where(x => x.Helth == la.Min(a => a.Helth))
                .Take(1));
            Console.WriteLine("\r\nAnimals with max and min helth  respectively:");
            ShowAnimals(q);
        }
        protected void Quiry9(List<Animal> la)
        {
            Console.WriteLine("\r\nAverage helth of zoo animals  = {0}", la.Average(s => s.Helth));
        }

        protected void ShowHelp()
        {
            Console.WriteLine("\r\n0 Показать всех животных, сгруппированных по виду животного");
            Console.WriteLine("1 Показать животных по состоянию - в параметрах передать состояние");
            Console.WriteLine("2 Показать всех тигров, которые больны.");
            Console.WriteLine("3 Показать слона с определенной кличкой, которая задается в параметре");
            Console.WriteLine("4 Показать список всех кличек животных, которые голодны");
            Console.WriteLine("5 Показать самых здоровых животных каждого вида (по одному на каждый вид)");
            Console.WriteLine("6 Показать количество мертвых животных каждого вида");
            Console.WriteLine("7 Показать всех волков и медведей, у которых здоровье больше 3");
            Console.WriteLine("8 Показать животное с максимальным здоровьем и животное с минимальным здоровьем (описать одним выражением)");
            Console.WriteLine("9 Показать средней количество здоровья у животных в зоопарке");
        }
        private void ShowAnimals(IEnumerable<Animal> la)
        {
            foreach (var i in la)
                ShowAnimal(i);
        }
        private void ShowAnimal(Animal la)
        {
            Console.WriteLine("\r\nName of animal is {0}, state is {1}, helth is {2}", la.Name, la.State, la.Helth);
        }
        private string GetBreed(Animal anm)
        {
            List<string> local = anm.GetType().ToString().Split('.').ToList();
            return local[local.Count - 1];
        }
    }
}
