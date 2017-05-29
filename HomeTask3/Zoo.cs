using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask3
{
    public class Zoo : Quaries
    {
        private List<Animal> listA;

        public Zoo(List<Animal> la)
        {
            listA = la;
        }
        //Вывод начального сообщения
        public void BeginMsg()
        {
            Console.WriteLine("Для начала работы нужно добавить хотя бы одно животное.");
            Console.WriteLine("Включен режим добавления животного.");
        }
        //Считывание действия
        public string GetAction()
        {
            List<string> lstr = new List<string>() { "Add", "Feed", "Heal", "Delete", "RandChng", "Quiry" };
            Console.Write("\r\nВведите действие\r\n");
            foreach (var a in lstr)
                Console.Write(" " + a + " ");

            bool res = false;
            string locVar = "";
            while (!res)
            {
                locVar = Console.ReadLine();
                foreach (var a in lstr)
                    if (a == locVar)
                    {
                        res = true;
                        break;
                    }
                if (!res)
                    Console.WriteLine("Такого действия в списке доступных нет.");
            }
            return locVar;

        }
        //Считывание имени животного
        protected string GetName()
        {
            Console.WriteLine("Введите имя");
            return Console.ReadLine();
        }
        //Считывание вида животного
        protected string GetBreed()
        {
            List<string> lstr = new List<string>() { "Lion", "Tiger", "Elephant", "Bear", "Wolf", "Fox" };
            bool res = false;
            string locVar = "";
            Console.WriteLine("Введите вид животного\r\n");
            foreach (var a in lstr)
                Console.Write(" " + a + " ");
            while (!res)
            {
                locVar = Console.ReadLine();
                for (int i = 0; i < lstr.Count; i++)
                    if (lstr[i] == locVar)
                    {
                        res = true;
                        break;
                    }
                if (!res)
                    Console.WriteLine("Такого вида в зоопарке нет");
            }
            return locVar;
        }
        //Все животные в списке мертвы?
        public bool CheckAllDead()
        {
            bool res = true;
            for (int i = 0; i < listA.Count; i++)
                if (listA[i].State != State.dead)
                    res = false;
            return res;
        }
        //Действия с животными
        //Добавить животное в зоопарк
        public void Add()
        {
            Animal anm = new Animal();
            string name = GetName();
            string breed = GetBreed();

            switch (breed)
            {
                case "Lion": anm = new Lion(); break;
                case "Tiger": anm = new Tiger(); break;
                case "Elephant": anm = new Elephant(); break;
                case "Bear": anm = new Bear(); break;
                case "Wolf": anm = new Wolf(); break;
                case "Fox": anm = new Fox(); break;
            }

            anm.Name = name;
            listA.Add(anm);
            Console.WriteLine("Животное {0} добавлено в зоопарк.", name);
        }
        //Кормить животное
        public void Feed()
        {
            string name = GetName();
            string locvar = "Животного нет в списке и/или животное не голодное";
            foreach (var a in listA)
                if (a.Name == name & a.State == State.hungry)
                {
                    a.State = State.full;
                    locvar = "Животное " + name + " теперь сытое.";
                }
            Console.WriteLine(locvar);
        }
        //Вылечить животное
        public void Heal()
        {
            string local = "Животного нет в списке и/или его здоровье максимально";
            string name = GetName();

            foreach (var a in listA)
                if (a.Helth < a.MaxHelth & a.Name == name)
                {
                    local = "Здоровье животного " + name + " увелично на 1.";
                    a.Helth++;
                }
            Console.WriteLine(local);
        }
        //Удалить животное
        public void Delete()
        {
            string name = GetName();
            string local = "Животного с таким именим и/или нулевым здоровьем нет";

            for (int i = 0; i < listA.Count; i++)
            {
                if (listA[i].Helth == 0 & listA[i].Name == name)
                {
                    local = "Животное " + listA[i].Name + " удалено";
                    listA.RemoveAt(i--);
                }
            }
            Console.WriteLine(local);
        }
        //Изменение состояния рандомного животного
        public void RandChng()
        {
            Random rand = new Random();
            int rnd = rand.Next(0, listA.Count);
            switch (listA[rnd].State)
            {
                case State.full: listA[rnd].State = State.hungry; Console.WriteLine("\r\nЖивотное {0} изменило состояние на голоден", listA[rnd].Name); break;
                case State.hungry: listA[rnd].State = State.ill; Console.WriteLine("\r\nЖивотное {0} изменило состояние на болен", listA[rnd].Name); break;
                case State.ill: listA[rnd].Helth--; Console.WriteLine("\r\nЖивотное {0} изменило здоровье, здоровье = {1}", listA[rnd].Name, listA[rnd].Helth); break;
            }
            if (listA[rnd].Helth == 0)
            {
                Console.WriteLine("Животное {0} умерло.", listA[rnd].Name);
                listA[rnd].State = State.dead;
            }

        }
        //Вывод результата одного из заданых запросов
        public void ExecuteQuiry()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                Console.WriteLine("\r\nВведите номер варианта выборки или нажмите ? для вызова справки.");
                switch (Console.ReadKey().KeyChar)
                {
                    case '0': Quiry0(listA); break;
                    case '1': Quiry1(listA); break;
                    case '2': Quiry2(listA); break;
                    case '3': Quiry3(listA); break;
                    case '4': Quiry4(listA); break;
                    case '5': Quiry5(listA); break;
                    case '6': Quiry6(listA); break;
                    case '7': Quiry7(listA); break;
                    case '8': Quiry8(listA); break;
                    case '9': Quiry9(listA); break;
                    case '?': ShowHelp(); break;
                    default: flag = true; break;
                }
            }
        }
    }
}
