
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
        public Employee() { }

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
    }
}
