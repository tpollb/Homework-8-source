using System;

namespace test_menu
{
    public class Departaments
    {
        /// <summary>
        /// переменные
        /// </summary>
        private int dep_id;
        private string dp_name;
        private DateTime date_of_creation;
        private int emp_count;

        /// <summary>
        /// инкапсуляция
        /// </summary>
        public string Dp_name { get => dp_name; set => dp_name = value; }
        public DateTime Date_of_creation { get => date_of_creation; set => date_of_creation = value; }
        public int Emp_count { get => emp_count; set => emp_count = value; }
        public int Dep_id { get => dep_id; set => dep_id = value; }

        /// <summary>
        /// пустая инициализация
        /// </summary>
        public Departaments() { }

  /// <summary>
  /// инициализация
  /// </summary>
  /// <param name="dep_id"></param>
  /// <param name="dp_name"></param>
  /// <param name="date_of_creation"></param>
  /// <param name="emp_count"></param>
        public Departaments(int dep_id, string dp_name, DateTime date_of_creation, int emp_count) {
            this.dep_id = dep_id;
            this.dp_name = dp_name;
            this.date_of_creation = date_of_creation;
            this.emp_count = emp_count;
        }

        /// <summary>
        /// метод вывода данных на экран
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return $"Id департамента: {dep_id} " +
                $"Наименование департамента: {dp_name} " +
                $" Дата создания: {date_of_creation,-6}" +
                $" Количество сотрудников: {emp_count,-6}";
        }
        /// <summary>
        /// Метод чтения поля департамента
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string GetDepartamentField(int i)//Извлекаем данные
        {
            if (i == 0) return dep_id.ToString();
            if (i == 1) return dp_name.ToString();
            if (i == 2) return date_of_creation.ToString();
            if (i == 3) return emp_count.ToString();
            return "";
        }

        public void SetDepartamentField(int i, string str)//Помещаем данные
        {
            if (i == 0) dep_id = int.Parse(str);
            else if (i == 1) dp_name = str;
            else if (i == 2) date_of_creation = DateTime.Parse(str);
            else if (i == 3) emp_count = int.Parse(str);
        }
    }
}
