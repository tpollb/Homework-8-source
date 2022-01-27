using System;
using test_menu;

namespace Menu
{
    class Program
    {
        delegate void method();
        static void Main(string[] args)
        {
            string[] items = { 
                $"1. Записать данные Сотрудников в файл {Globals.JsonFilePath1}",
                $"2. Прочитать данные Сотрудников из файла {Globals.JsonFilePath1}", 
                "Действие 3", 
                "Действие 4", 
                "Выход" };

            method[] methods = new method[] { Methods.Method1, Methods.Method2, Methods.Method3, Methods.Method4, Methods.Exit };
            ConsoleMenu menu = new ConsoleMenu(items);
            int menuResult;
            do
            {
                menuResult = menu.PrintMenu();
                methods[menuResult]();
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
            } while (menuResult != items.Length - 1);
        }
    }
}