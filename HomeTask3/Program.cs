using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Timers;
using System.Reflection;

namespace HomeTask3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Обьявление и инициализация списка животных и зоопарка
            List<Animal> la = new List<Animal>();
            Zoo zoo = new Zoo(la);
            //Добавление первого животного
            zoo.BeginMsg();
            zoo.Add();
            //Установка таймера
            Timer tmr = new Timer();
            tmr.Interval = 5000;
            tmr.Elapsed += (object sender, ElapsedEventArgs e) =>
            {
                zoo.RandChng();
                if (zoo.CheckAllDead())
                {
                    Console.WriteLine("Доигрался! Все животные мертвы! Через 3 секунды произойдет выход.");
                    System.Threading.Thread.Sleep(3000);
                    tmr.Stop();
                    Environment.Exit(0);
                }
            };
            //Выбор и выполнение функций
            while (true)
            {
                switch (zoo.GetAction())
                {
                    case "Add": zoo.Add(); break;
                    case "Heal": zoo.Heal(); break;
                    case "Feed": zoo.Feed(); break;
                    case "Delete": zoo.Delete(); break;
                    case "RandChng":
                        {
                            if (!tmr.Enabled)
                                tmr.Start();
                            else
                                Console.WriteLine("Процесс уже запущен.");
                        } break;
                    case "Quiry": zoo.ExecuteQuiry(); break;
                }
            }
        }
    }  
}
