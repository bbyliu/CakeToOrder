using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using TortOrder;


namespace TortOrder
{
    class Program
    {
        static int cost = 0;
        static string aboutZakaz = "";

        static void Main()
        {
            Console.WriteLine("Заказ тортиков в Кейки, выбирай любой :3");
            Console.WriteLine("Выберите желаемые параметры тортика");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
            while (true)
            {

                MenuInMenu first = new MenuInMenu("  Круг", 200);
                MenuInMenu second = new MenuInMenu("  Котик", 300);
                MenuInMenu third = new MenuInMenu("  Сердечко", 400);

                MenuInMenu small = new MenuInMenu("  Маленький", 250);
                MenuInMenu normal = new MenuInMenu("  Средний", 300);
                MenuInMenu big = new MenuInMenu("  Большой", 250);

                MenuInMenu color1 = new MenuInMenu("  Розовый", 150);
                MenuInMenu color2 = new MenuInMenu("  Голубой", 150);
                MenuInMenu color3 = new MenuInMenu("  Желтый", 150);

                MenuInMenu clubnica = new MenuInMenu("  Клубника", 400);
                MenuInMenu banana = new MenuInMenu("  Банан", 400);
                MenuInMenu choco = new MenuInMenu("  Шоколад", 400);



                MainMenu forma = new MainMenu();
                forma.MenuInMenu = new List<MenuInMenu>() { first, second, third };
                forma.Totr = "  Форма";

                MainMenu razmer = new MainMenu();
                razmer.MenuInMenu = new List<MenuInMenu>() { small, normal, big };
                razmer.Totr = "  Размер";

                MainMenu color = new MainMenu();
                color.MenuInMenu = new List<MenuInMenu>() { color1, color2, color3 };
                color.Totr = "  Цвет";

                MainMenu vkus = new MainMenu();
                vkus.MenuInMenu = new List<MenuInMenu>() { clubnica, banana, choco };
                vkus.Totr = "  Вкус";


                List<MainMenu> allmenu = new List<MainMenu>() { forma, color, razmer, vkus};

                int position = 1;
                ConsoleKeyInfo key = Console.ReadKey();
                while (key.Key != ConsoleKey.Enter)
                {
                    if (key.Key == ConsoleKey.UpArrow)
                    {
                        position--;
                    }
                    else if (key.Key == ConsoleKey.DownArrow)
                    {
                        position++;
                    }
                    else if (key.Key == ConsoleKey.S)
                    {
                        inFile();
                    }
                    Console.Clear();
                    foreach (MainMenu vibor in allmenu)
                    {
                        Console.WriteLine(vibor.Totr);
                    }
                    Console.WriteLine("Нажмите S для окончания заказа");

                    Console.WriteLine("Заказ: " + aboutZakaz);
                    Console.WriteLine("Цена: " + cost);

                    Console.SetCursorPosition(0, position);
                    Console.WriteLine("->");
                    key = Console.ReadKey();
                }
                Console.Clear();
                
                podMenu(allmenu[position]);
                
            }
            
        }
        static void podMenu(MainMenu vibor)
        {
            Console.WriteLine("Для выхода нажмите Escape");
            Console.WriteLine("Выберите пункт из меню:");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~");
            int position = 1;

            ConsoleKeyInfo key = Console.ReadKey();
            while (key.Key != ConsoleKey.Enter)
            {
                if (key.Key == ConsoleKey.UpArrow)
                {
                    position--;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    position++;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Main();
                }
                

                Console.Clear();
                foreach (MenuInMenu glav in vibor.MenuInMenu)
                {
                    Console.WriteLine(glav.Name + "-" + glav.Price);
                }
                
                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
                key = Console.ReadKey();
                Zakaz(vibor.MenuInMenu[position]);
            }
        }
        static void Zakaz(MenuInMenu fl)
        {
            cost += fl.Price;
            aboutZakaz = aboutZakaz + fl.Name;
        }
        static void inFile()
        {
            string tupoiFail = "Заказ: " + Program.aboutZakaz + " " + "Цена: "+ Program.cost;
            File.AppendAllText("/Users/liuliu/Desktop/tort.txt", tupoiFail);
        }


    }
}





