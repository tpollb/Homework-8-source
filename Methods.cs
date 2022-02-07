using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace test_menu
{
    /// <summary>
    /// класс методы
    /// </summary>
    class Methods
    {
        // МЕТОДЫ ОБРАБОТКИ //////////////////////////////////////////////////////1111111111111111111111111111111111111111111111111111
        // МЕТОДЫ ОБРАБОТКИ //////////////////////////////////////////////////////1111111111111111111111111111111111111111111111111111
        // МЕТОДЫ ОБРАБОТКИ //////////////////////////////////////////////////////1111111111111111111111111111111111111111111111111111

        /// <summary>
        /// Метод сортировки
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<Employee> SortEmployee(List<Employee> list)
        {
            List < Employee > ls = list.OrderBy(x => x.Departament).ThenBy(x => x.Salary).ToList();
            return ls;
        }

        /// <summary>
        /// метод редактирования сотрудника
        /// </summary>
        /// <param name="id"></param>
        /// <param name="list"></param>
        /// <param name="emp_id"></param>
        /// <param name="surname"></param>
        /// <param name="firstname"></param>
        /// <param name="age"></param>
        /// <param name="departament"></param>
        /// <param name="salary"></param>
        /// <param name="project_number"></param>
        /// <returns></returns>
        public static List<Employee> EditEmployeeToList(int id, List<Employee> list, int emp_id, string surname, string firstname, int age, int departament, int salary, int project_number)
        {
            Employee emp = new Employee
            {
                Emp_id = id,
                Surname = surname,
                Firstname = firstname,
                Age = age,
                Departament = departament,
                Salary = salary,
                Project_number = project_number
            };

            list[id] = emp;
            return list;
        }
        /// <summary>
        /// метод редактирования департамента
        /// </summary>
        /// <param name="id"></param>
        /// <param name="list"></param>
        /// <param name="dep_id"></param>
        /// <param name="dp_name"></param>
        /// <param name="date_of_creation"></param>
        /// <param name="emp_count"></param>
        /// <returns></returns>
        public static List<Departaments> EditDepartamentToList(int id, List<Departaments> list, int dep_id, string dp_name, DateTime date_of_creation, int emp_count)
        {
            Departaments dp = new Departaments
            {
                Dep_id = id,
                Dp_name = dp_name,
                Date_of_creation = date_of_creation,
                Emp_count = 0
            };

            list[id] = dp;
            return list;
        }
        /// <summary>
        /// Метод добавления сотрудника в коллекцию
        /// </summary>
        /// <param name="list"></param>
        /// <param name="emp_id"></param>
        /// <param name="surname"></param>
        /// <param name="firstname"></param>
        /// <param name="age"></param>
        /// <param name="departament"></param>
        /// <param name="salary"></param>
        /// <param name="project_number"></param>
        /// <returns>коллекция List<Employee></returns>
        public static List<Employee> AddEmployeeToList(List<Employee> list, int emp_id, string surname, string firstname, int age, int departament, int salary, int project_number)
        {
            Employee emp = new Employee
            {
                Emp_id = emp_id,
                Surname = surname,
                Firstname = firstname,
                Age = age,
                Departament = departament,
                Salary = salary,
                Project_number = project_number
            };

            list.Add(emp);
            return list;
        }
        /// <summary>
        /// метод дообавления записи департамент в коллекцию
        /// </summary>
        /// <param name="list"></param>
        /// <param name="dep_id"></param>
        /// <param name="dp_name"></param>
        /// <param name="date_of_creation"></param>
        /// <param name="emp_count"></param>
        /// <returns></returns>
        public static List<Departaments> AddDepartamentToList(List<Departaments> list, int dep_id, string dp_name, DateTime date_of_creation, int emp_count)
        {
            Departaments dp = new Departaments
            {
                Dep_id = dep_id,
                Dp_name = dp_name,
                Date_of_creation = date_of_creation,
                Emp_count = 0
            };

            list.Add(dp);
            return list;
        }
        /// <summary>
        /// метод удаления сотруника
        /// </summary>
        /// <param name="list"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Employee> RemoveEmployeeFromList (List<Employee> list, int id)
        {
            Console.WriteLine($"Сотрудник {list[id].Print()} удалён");
            list.RemoveAt(id);

            int ListCount = list.Count;

            for (int i = id; i < ListCount; i++)
            {
                list[i].SetEmployeeField(0, i.ToString());
            }
            PrintList(list);

            return list;
        }

        public static List<Departaments> RemoveDepartamentFromList(List<Departaments> list, int id)
        {
            Console.WriteLine($"Сотрудник {list[id].Print()} удалён");
            list.RemoveAt(id);

            int ListCount = list.Count;

            for (int i = id; i < ListCount; i++)
            {
                list[i].SetDepartamentField(0, i.ToString());
            }
            PrintList(list);

            return list;
        }
        /// <summary>
        /// Печать коллекции
        /// </summary>
        /// <param name="list"></param>
        public static void PrintList(List<Employee> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Print()}");
            }
        }
        /// <summary>
        /// Перегрузка метода PrintList
        /// </summary>
        /// <param name="list"></param>
        public static void PrintList(List<Departaments> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine($"{item.Print()}");
            }
        }
        /// <summary>
        /// метод создания файла сотрудников, если отсутствует
        /// </summary>
        public static void CreateEmployeeFile()
        {
            if (!File.Exists(Globals.EmploeeFilePath1))
            {
                Console.WriteLine($"Файлы баз данных отсутствуют. Формируем {Globals.EmploeeFilePath1} и {Globals.DepartmentsFilePath1}");

                string path = Globals.EmploeeFilePath1;

                List<Employee> list1 = new List<Employee>();

                Random rnd = new Random();

                for (int i = 0; i < 10; i++)
                {
                    list1.Add(new Employee(i, $"sur{i}", $"first{i}", 10 * i, rnd.Next(0, 10), 100 * i, 3));
                }

                string json_dep = JsonConvert.SerializeObject(list1);
                File.WriteAllText(path, json_dep);
            }
        }
        /// <summary>
        /// Метод создания файла департаментов, если отсутствует
        /// </summary>
        public static void CreateDepartamentFile()
        {
            if (!File.Exists(Globals.EmploeeFilePath1) || !File.Exists(Globals.DepartmentsFilePath1))
            {
               
                string dept_path = Globals.DepartmentsFilePath1;

                List<Departaments> list_dep = new List<Departaments>();

                for (int i = 0; i < 10; i++)
                {
                    list_dep.Add(new Departaments(i, $"Dep{i}", DateTime.Now, 0));
                }

                string json_dep = JsonConvert.SerializeObject(list_dep);
                File.WriteAllText(dept_path, json_dep);
            }
        }

        /// <summary>
        /// Метод чтения файла сотрудников
        /// </summary>
        /// <param name="filepath">путь к файлу</param>
        /// <returns>коллекция сотрудников</returns>
        public static List<Employee> ReadEmployees(string filepath)
        {
            //проверка на наличие файлов, если нет - создаём
            //проверка на наличие файлов, если нет - создаём
            CreateEmployeeFile();

            string json = File.ReadAllText(filepath);
            List<Employee> list = JsonConvert.DeserializeObject<List<Employee>>(json);

            PrintList(list);

            return list;
        }
        /// <summary>
        /// Метод чтения файла департаментов
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns>коллекция департаментов</returns>
        public static List<Departaments> ReadDepartaments(string filepath)
        {
            CreateDepartamentFile();

            string json = File.ReadAllText(filepath);
            List<Departaments> list = JsonConvert.DeserializeObject<List<Departaments>>(json);

            PrintList(list);

            return list;
        }
        
        /// <summary>
        /// метод записи коллекции в файл
        /// </summary>
        /// <param name="list"></param>
        /// <param name="filepath"></param>
        public static void WriteListToFile(List<Employee> list, string filepath)
        {
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText(filepath, json);
            Console.WriteLine($"Файл {filepath} создан");
        }
        /// <summary>
        /// перегрузка метода записи коллекции
        /// </summary>
        /// <param name="list"></param>
        /// <param name="filepath"></param>
        public static void WriteListToFile(List<Departaments> list, string filepath)
        {
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText(filepath, json);
            Console.WriteLine($"Файл {filepath} создан");
        }
       
        /// <summary>
        /// метод заполнения поля количество сотрудников в коллекции департаменты
        /// </summary>
        /// <param name="dep_list"></param>
        /// <param name="emp_list"></param>
        /// <returns></returns>
        public static List<Departaments> EmpCoutnInDepartament(List<Departaments> dep_list, List<Employee> emp_list)
        {
            int i = default;
            int j = default;
            foreach (var dep_item in dep_list)
            {
                foreach (var emp_item in emp_list)
                {
                    if (emp_item.GetEmployeeField(4) == dep_item.GetDepartamentField(0))
                    {
                        dep_list[j].SetDepartamentField(3, (i+1).ToString());
                        i++;
                        //Console.WriteLine($"i: {i} j:{j}");
                    }
                }
                i = 0;
                j++;
                //Console.WriteLine($"i: {i} j:{j}");
            }
            return dep_list;
        }
        //  МЕТОДЫ МЕНЮ (Пункты меню) ////////////////////////////////////////////////////////////////////////////////!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //  МЕТОДЫ МЕНЮ (Пункты меню) ////////////////////////////////////////////////////////////////////////////////!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //  МЕТОДЫ МЕНЮ (Пункты меню) ////////////////////////////////////////////////////////////////////////////////!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        /// <summary>
        /// поле меню 1. Вывести данные сотрудников на экран
        /// </summary>
        public static void Menu_Method1()
        {
            PrintList(Globals.List_employee);
        }

        /// <summary>
        /// поле меню 2. Вывести данные департаментов на экран
        /// </summary>
        public static void Menu_Method2()
        {
            PrintList(Globals.List_Departaments);
        }

        /// <summary>
        /// поле меню 3. Записать изменения в файлы Сотрудники: {Globals.EmploeeFilePath1} и Департаменты: {Globals.DepartmentsFilePath1}
        /// </summary>
        public static void Menu_Method3()
        {
            WriteListToFile(Globals.List_employee, Globals.EmploeeFilePath1);
            WriteListToFile(Globals.List_Departaments, Globals.DepartmentsFilePath1);
        }

        /// <summary>
        /// поле меню 4. Удалить сотрудника
        /// </summary>
        public static void Menu_Method4()
        {
            bool flag = default;
            int id = default;
            while (flag == false || id < 0 || id > Globals.List_employee.Count - 1)
            {
                Console.WriteLine($"Введите номер строки для удаления от 0 до {Globals.List_employee.Count - 1}:");
                string input = Console.ReadLine();
                flag = int.TryParse(input, out id);
            }

            RemoveEmployeeFromList(Globals.List_employee, id);
        }

        /// <summary>
        /// поле меню 5. Удалить департамент
        /// </summary>
        public static void Menu_Method5()
        {
            bool flag = default;
            int id = default;
            while (flag == false || id < 0 || id > Globals.List_Departaments.Count - 1)
            {
                Console.WriteLine($"Введите номер строки для удаления от 0 до {Globals.List_Departaments.Count - 1}:");
                string input = Console.ReadLine();
                flag = int.TryParse(input, out id);
            }
            RemoveDepartamentFromList(Globals.List_Departaments, id);
        }

        /// <summary>
        /// Поле меню 6. Добавление сотрудника
        /// </summary>
        public static void Menu_Method6()
        {
            Console.WriteLine("Введите фамилию сотрудника");
            string sur = Console.ReadLine();

            Console.WriteLine("Введите имя сотрудника");
            string fst = Console.ReadLine();

            bool flag = default;

            int age = default;
            while (flag == false || age < 1 || age > 120)
            {
                Console.WriteLine($"Введите возраст от 1 до 120");
                string input = Console.ReadLine();
                flag = int.TryParse(input, out age);
            }
            flag = default;

            int dep = default;
            while (flag == false || dep < 1 || dep > Globals.List_Departaments.Count)
            {
                PrintList(Globals.List_Departaments);
                Console.WriteLine($"Введите id departamenta от 1 до {Globals.List_Departaments.Count}");
                string input = Console.ReadLine();
                flag = int.TryParse(input, out dep);
            }
            flag = default;

            int sal = default;
            while (flag == false || sal < 1000 || sal > 100000)
            {
                Console.WriteLine($"Введите зарплату от 1000 до 100000");
                string input = Console.ReadLine();
                flag = int.TryParse(input, out sal);
            }
            flag = default;

            int prj_number = default;
            while (flag == false || prj_number < 1 || prj_number > 10)
            {
                Console.WriteLine($"Введите количество проектов от 1 до 10");
                string input = Console.ReadLine();
                flag = int.TryParse(input, out prj_number);
            }

            AddEmployeeToList(Globals.List_employee, Globals.List_employee.Count, sur, fst, age, dep, sal, prj_number);
        }
        /// <summary>
        /// Поле меню 7. Добавление департамента
        /// </summary>
        public static void Menu_Method7()
        {
            Console.WriteLine("Введите нименование департамента");
            string dp_name = Console.ReadLine();
            AddDepartamentToList(Globals.List_Departaments, Globals.List_Departaments.Count, dp_name, DateTime.Now, 0);
        }
        /// <summary>
        /// Поле меню 8. Редактирование сотрудника
        /// </summary>
        public static void Menu_Method8()
        {
            bool flag = default;

            int id = default;
            while (flag == false || id < 1 || id > Globals.List_employee.Count)
            {
                Console.WriteLine($"Введите номер сотрудника для редактирования от 1 до {Globals.List_employee.Count}");
                string input = Console.ReadLine();
                flag = int.TryParse(input, out id);
            }
            flag = default;

            Console.WriteLine("Введите фамилию сотрудника");
            string sur = Console.ReadLine();

            Console.WriteLine("Введите имя сотрудника");
            string fst = Console.ReadLine();

            int age = default;
            while (flag == false || age < 1 || age > 120)
            {
                Console.WriteLine($"Введите возраст от 1 до 120");
                string input = Console.ReadLine();
                flag = int.TryParse(input, out age);
            }
            flag = default;

            int dep = default;
            while (flag == false || dep < 1 || dep > Globals.List_Departaments.Count)
            {
                PrintList(Globals.List_Departaments);
                Console.WriteLine($"Введите id departamenta от 1 до {Globals.List_Departaments.Count}");
                string input = Console.ReadLine();
                flag = int.TryParse(input, out dep);
            }
            flag = default;

            int sal = default;
            while (flag == false || sal < 1000 || sal > 100000)
            {
                Console.WriteLine($"Введите зарплату от 1000 до 100000");
                string input = Console.ReadLine();
                flag = int.TryParse(input, out sal);
            }
            flag = default;

            int prj_number = default;
            while (flag == false || prj_number < 1 || prj_number > 10)
            {
                Console.WriteLine($"Введите количество проектов от 1 до 10");
                string input = Console.ReadLine();
                flag = int.TryParse(input, out prj_number);
            }

            EditEmployeeToList(id, Globals.List_employee, Globals.List_employee.Count, sur, fst, age, dep, sal, prj_number);
        }
        /// <summary>
        /// Поле меню 9. Редактирование департамента
        /// </summary>
        public static void Menu_Method9()
        {
            bool flag = default;

            int id = default;
            while (flag == false || id < 1 || id > Globals.List_Departaments.Count)
            {
                Console.WriteLine($"Введите номер департамента для редактирования от 1 до {Globals.List_Departaments.Count}");
                string input = Console.ReadLine();
                flag = int.TryParse(input, out id);
            }

            Console.WriteLine($"Введите новове наименование департамента");
            string dep_name = Console.ReadLine();
            EditDepartamentToList(id, Globals.List_Departaments, id, dep_name, DateTime.Now, 0);
        }

        /// <summary>
        /// Поле меню 10. Сортировка сотрудников сначала по департаменту, затем по зарплате
        /// </summary>
        public static void Menu_Method10()
        {
            Globals.List_employee = SortEmployee(Globals.List_employee);
        }
        public static void Exit()
        {
            Console.WriteLine("Приложение заканчивает работу!");
        }
    }
}
