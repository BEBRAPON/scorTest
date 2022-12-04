
using System.Diagnostics;
using System.Threading;
using System.Threading.Channels;
using System.Xml.Schema;
using Newtonsoft.Json;


internal class dr
{
    private static string str = "С точки зpения банальной эpудиции, каждый пpоизвольно выбpанный пpедикативно абсоpбиpующий обьект pациональной мистической индукции можно дискpетно детеpминиpовать с аппликацией ситуационной паpадигмы коммуникативно-функционального типа пpи наличии детектоpно-аpхаического дистpибутивного обpаза в Гилбеpтовом конвеpгенционном пpостpанстве.";
    public static int pos = 0;
    public static int pos2 = 0;
    public static int symvols;
    public static ConsoleKeyInfo k;
    public static ConsoleKeyInfo k2;
    public static string raz = "";
    public static string name;
    public static void Main()
    {
        Console.WriteLine("Введите имя пользователя: ");
        name = Console.ReadLine();
        Console.Clear();
        Console.WriteLine("Для того, чтобы начать тест, нажмите \"Enter\"");
        k2 = Console.ReadKey();
        while (k2.Key != ConsoleKey.Enter)
        {
            Console.SetCursorPosition(0, 1);
            k2 = Console.ReadKey();
            Console.SetCursorPosition(0, 1);
            Console.WriteLine("       ");
        }
        Console.Clear();
        RazdelenieTexta();
    }
    public static void RazdelenieTexta()
    {
        raz = "";
        int lenght = 90;
        int n = 1;
        for (int i = 0; i < str.Length; i++)
        {
            if (i == lenght * n)
            {
                n++;
                raz += "\r\n";
                raz += str[i];
            }
            else
                raz += str[i];
        }
        Console.WriteLine(raz);
        vvodSymv();
    }
    public static void Timer()
    {
        var dateTime = DateTime.Now;
        string str1 = "1";
        DateTime dt = dateTime.AddMinutes(-1);
        pos = 0;
        pos2 = 0;
        symvols = 0;
        while (dateTime > dt)
        {
            var ticks = (dateTime - dt).Ticks;
            Console.SetCursorPosition(0, 10);
            Console.WriteLine(new DateTime(ticks).ToString($"H{str1}:ss"));
            Console.SetCursorPosition(pos, pos2);
            str1 = "0";
            Thread.Sleep(1000);
            dt = dt.AddSeconds(1);
            if (pos > 89)
            {
                pos2++;
                pos = 0;
            }
            if (symvols == str.Length || k.Key == ConsoleKey.Enter)
                break;
        }
        Console.ResetColor();
        Console.SetCursorPosition(0, 8);
        Console.WriteLine("Для повторного прохождения теста нажмите \"Enter\"");
        Console.SetCursorPosition(0, 9);
        Console.WriteLine("Стоп");
        Console.SetCursorPosition(0, 11);
        k = Console.ReadKey();
        while (k.Key != ConsoleKey.Enter)
        {
            Console.SetCursorPosition(0, 11);
            k = Console.ReadKey();
            Console.SetCursorPosition(0, 11);
            Console.WriteLine("        ");
        }
        Console.Clear();
        Tablica.Tablicaa();

        
    }
    public static void vvodSymv()
    {
        Console.SetCursorPosition(0, 0);
        pos = 0;
        pos2 = 0;
        symvols = 0;
        Thread thread = new Thread(new ThreadStart(Timer));
        thread.Start();
        while (symvols != str.Length)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            k = Console.ReadKey();
            if (k.Key == ConsoleKey.Backspace)
            {
                symvols--;
                pos--;
                Console.ResetColor();
                Console.SetCursorPosition(pos, pos2);
                Console.WriteLine(str[symvols]);
                Console.SetCursorPosition(pos, pos2);
                if (pos > 89)
                {
                    pos2++;
                    pos = 0;
                }
                if (pos == 0)
                    Console.SetCursorPosition(pos, pos2);
            }
            
            else if (k.Key == ConsoleKey.Enter)
                break;
            else
            {
                pos++;
                symvols++;
                Console.SetCursorPosition(pos, pos2);
            }
        }
        
        
    }
}
static class Tablica
{
    public static string simMin;
    public static string simSec;

    private static List<string> tabl = new List<string>();
    
    private static Humans person = new Humans();
    private static List<Humans> human = new List<Humans>();
    public static void Tablicaa()
    {
        
        float symvv;
        symvv = dr.symvols;
        simMin = Convert.ToString(symvv);
        simSec = Convert.ToString(symvv/60);
        tabl.Add("Имя: " + dr.name);
        tabl.Add("Символов в минуту: " + simMin);
        tabl.Add("Cимволов в cекунду: " + simSec);
        Console.WriteLine("Таблица рекордов");
        Console.WriteLine("=============================");
        foreach (var VARIABLE in tabl)
        {
            Console.Write(VARIABLE + " ");
            Console.WriteLine("  ");
            
        }
        Console.WriteLine("=============================");
        
        person.Name = dr.name;
        person.SimvMin = simMin;
        person.SimvSec = simSec;
        
        human.Add(person);

        string json = JsonConvert.SerializeObject(human);
        string path = "C:\\Users\\zxcpencil\\Desktop\\TablRec.json";
        if (File.Exists(path))
        {
            File.Create(path).Close();
            File.WriteAllText(path,json);
        }
        else
        {
            File.WriteAllText(path,json);
        }
        

        Console.WriteLine("Для того, чтобы повторить попытку нажмите \"Enter\".");
        dr.k2 = Console.ReadKey();
        Console.Clear();
        while (dr.k2.Key != ConsoleKey.Enter)
        {
            Console.SetCursorPosition(0,0);
            Console.WriteLine("Для того, чтобы повторить попытку нажмите \"Enter\".");
            Console.SetCursorPosition(0,1);
            dr.k2 = Console.ReadKey();
            Console.SetCursorPosition(0,1);
            Console.WriteLine("  ");
        }
        Console.Clear();
        dr.Main();
    }
}

internal class Humans
{
    public string Name;
    public string SimvMin;
    public string SimvSec;
    
}

