using System;
using System.Threading;
using test_menu;

namespace Menu
{
    class Program
    {
        delegate void method();
        static void Main(string[] args)
        {   
                //читаем файл сотрудников в коллекцию
                Globals.List_employee = Methods.ReadEmployees(Globals.EmploeeFilePath1);
                Console.WriteLine($"Файл {Globals.EmploeeFilePath1} загружен");

                Thread.Sleep(1000);

                //читаем файл департаментов в коллекцию
                Globals.List_Departaments = Methods.ReadDepartaments(Globals.DepartmentsFilePath1);
                Console.WriteLine($"Файл {Globals.DepartmentsFilePath1} загружен");

                Thread.Sleep(1000);

                //переписываем данные поля emp_count в коллекции
                Globals.List_Departaments = Methods.EmpCoutnInDepartament(Globals.List_Departaments, Globals.List_employee);
                Methods.WriteListToFile(Globals.List_Departaments, Globals.DepartmentsFilePath1);

                string[] items = 
                {
                    $"1. Вывести данные сотрудников на экран",
                    $"2. Вывести данные департаментов на экран",
                    $"3. Записать изменения в файлы Сотрудники: {Globals.EmploeeFilePath1} и Департаменты: {Globals.DepartmentsFilePath1}",
                    $"4. Удалить сотрудника",
                    $"5. Удалить департамент",
                    $"6. Добавление сотрудника",
                    $"7. Добавление департамента",
                    $"8. Редактирование сотрудника",
                    $"9. Редактирование департамента",
                    $"10. Сортировка сотрудников сначала по департаменту, затем по зарплате",
                    "Выход" 
                };

                method[] methods = new method[] 
                    { 
                        Methods.Menu_Method1, 
                        Methods.Menu_Method2, 
                        Methods.Menu_Method3, 
                        Methods.Menu_Method4, 
                        Methods.Menu_Method5, 
                        Methods.Menu_Method6,
                        Methods.Menu_Method7,
                        Methods.Menu_Method8,
                        Methods.Menu_Method9,
                        Methods.Menu_Method10,
                        Methods.Exit 
                    };

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