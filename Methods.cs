using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace test_menu
{
    class Methods
    {
        public static void Method1()
        {

            string path = Globals.JsonFilePath1;

            List<Employee> list = new List<Employee>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(new Employee(i, "sur", "first", 10*i, i, 100*i, 3));
            }

            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText(path, json);

            Console.WriteLine($"Файл {path} создан");
        }

        public static void Method2()
        {
            string path = Globals.JsonFilePath1;

            List<Employee> list = new List<Employee>();

            string json = File.ReadAllText(path);
            list = JsonConvert.DeserializeObject<List<Employee>>(json);

            foreach (var item in list)
            {
                Console.WriteLine($"{item.Print()}");
            }

            Console.WriteLine($"2");
        }
        public static void Method3()
        {
            Console.WriteLine("Выбрано действие 3");
        }
        public static void Method4()
        {
            Console.WriteLine("Выбрано действие 4");
        }
        public static void Exit()
        {
            Console.WriteLine("Приложение заканчивает работу!");
        }
    }
}
