
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace skoropechataniepract
{
    internal class ddd
    {
        public static int secs = 60;
        public static int count = 0;
        public static string name;

        public static void nachalo()
        {

            ConsoleKeyInfo key = Console.ReadKey();

            Console.WriteLine("Введите имя. Прога запишет ее в таблицу рекордов");
            Console.SetCursorPosition(0, 3);
            Console.WriteLine("Нажмите Escape, когда захотите выйти из программы");
            Console.SetCursorPosition(0, 1);
            name = Console.ReadLine();
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                test();
            }

        }

        private static void timer(object obj) // таймер
        {
            if (secs > 9)
            {
                secs--;
                Console.SetCursorPosition(0, 10);
                Console.Write($"0:{secs}");
            }

            if (secs < 10)
            {
                Console.SetCursorPosition(0, 10);
                Console.Write($"0:0{secs}");
            }
            else if ((secs < 10) && (secs > 0))
            {
                secs--;
                Console.SetCursorPosition(0, 0);
                Console.Write($"0:0{secs}");
            }
        }

        public static string samename = name; //чтобы имена в одном конструкторе были одинаковыми

        private static void test()
        {
            string text = "Я тетушка Чарли из Бразилии, где в лесах живет много-много диких обезьян. " +
                          "Я старый солдат и не знаю слов любви. Такой любезный мужчина!.. Это что-то! А давайте закурим. По-нашему, по-бразильски. Да мало ли в Бразилии Педров?! " +
                          "И не сосчитать! А кто не хочет сахару или сливок?" +
                          "Я тебя поцелую, потом, если захочешь. Ну должна же я была его помучить! Все порядочные девушки так поступают! Я им не верю. Им нужна не я, а мои миллионы!";
            var key = Console.ReadKey();
            Console.WriteLine(text);
            Console.SetCursorPosition(0, 6);
            Console.WriteLine("Нажмите Enter, чтобы начать тест");
            Console.SetCursorPosition(0, 10);
            Console.WriteLine("1:00");
            if (key.Key == ConsoleKey.Enter)
            {
                Thread.Sleep(0);
                Timer ts = new Timer(timer, null, 500, 1000); //реализация таймера

            }

            Thread thread = new Thread(_ =>
            {
                if (key.Key == ConsoleKey.Enter)
                {
                    while (count < text.Length - 1)
                    {
                        char c = Console.ReadKey(true).KeyChar;
                        if (c == text[count])
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(count, 0);
                            Console.Write(c);
                            count++;
                        }
                    }
                }
            });
            thread.Start();
            Console.WriteLine(); // для ввода текста
            if (secs == 0)
            {
                thread.Abort();
            }

        }

        public static void tabl()
        {
            if (secs == 0)
            {
                var key = Console.ReadKey();
                Human name = new Human();
                name.human = samename;
                name.min = count;
                name.sec = count / 60;
                Console.Clear();
                Console.WriteLine("** Таблица рекордов **");
                Console.WriteLine("|=====================|");
                Console.WriteLine($"{name.human}\t{name.min} Символов в минуту\t{name.sec} Символов в секунду\n");
                Console.WriteLine("Если хотите попробовать ещё раз, то нажмите Enter");
                Console.SetCursorPosition(0, 8);
                Console.WriteLine("Нажмите Escape, если хотите выйти из программы");
                List<Human> humans = new List<Human>();
                humans.Add(name);
                string json = JsonConvert.SerializeObject(humans);
                File.WriteAllText("C:\\Users\\User\\Desktop\\4json\\filik.json", json);
                List<Human> result = JsonConvert.DeserializeObject<List<Human>>(json);
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    nachalo();
                }

            }
        }

        private static void Main1m(string[] args)
        {
            var key = Console.ReadKey();
            while (key.Key != ConsoleKey.Escape)
            {
                nachalo();
            }

            if (key.Key == ConsoleKey.Escape) Environment.Exit(0);
            Console.ReadLine();

        }

    }
}

namespace skoropechataniepract
{
    internal class Human
    {
        public string human;
        public int min;
        public int sec;
        

    }
}
