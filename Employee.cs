
namespace test_menu
{
    public class Employee
    {
        private int emp_id;
        private string surname;
        private string firstname;
        private int age;
        private int departament;
        private int salary;
        private int project_number;

        public int Emp_id { get => emp_id; set => emp_id = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public int Age { get => age; set => age = value; }
        public int Departament { get => departament; set => departament = value; }
        public int Salary { get => salary; set => salary = value; }
        public int Project_number { get => project_number; set => project_number = value; }

        /// <summary>
        /// инициализация
        /// </summary>
        /// <param name="emp_id"></param>
        /// <param name="surname"></param>
        /// <param name="firstname"></param>
        /// <param name="age"></param>
        /// <param name="departament"></param>
        /// <param name="salary"></param>
        /// <param name="project_number"></param>
        public Employee(int emp_id, string surname, string firstname, int age, int departament, int salary, int project_number)
        {
            this.emp_id = emp_id;
            this.surname = surname;
            this.firstname = firstname;
            this.age = age;
            this.departament = departament;
            this.salary = salary;
            this.project_number = project_number;
        }

        /// <summary>
        /// инициализация
        /// </summary>
        public Employee() { }

        /// <summary>
        /// метод вывода данных на экран
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return $"id: {emp_id} " +
                $" Фамилия: {surname,-6}" +
                $" Имя: {firstname,-6}" +
                $" Возраст: {age,-6}" +
                $" Департамент: {departament,-6}" +
                $" Зарплата: {salary,-6}" +
                $" Количество проектов: {project_number,-6}";
        }

        /// <summary>
        /// Метод чтения поля сотрудника
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string GetEmployeeField(int i)//Извлекаем данные
        {
            if (i == 0) return emp_id.ToString();
            if (i == 1) return surname.ToString();
            if (i == 2) return firstname.ToString();
            if (i == 3) return age.ToString();
            if (i == 4) return departament.ToString();
            if (i == 5) return salary.ToString();
            if (i == 6) return project_number.ToString();
            return "";
        }
        /// <summary>
        /// Метод записи поля сотрудника
        /// </summary>
        /// <param name="i"></param>
        /// <param name="str"></param>
        public void SetEmployeeField(int i, string str)//Помещаем данные
        {
            if (i == 0) emp_id = int.Parse(str);
            else if (i == 1) surname = str;
            else if (i == 2) firstname = str;
            else if (i == 3) age = int.Parse(str);
            else if (i == 4) departament = int.Parse(str);
            else if (i == 5) salary = int.Parse(str);
            else if (i == 6) project_number = int.Parse(str);
        }
    }
}
