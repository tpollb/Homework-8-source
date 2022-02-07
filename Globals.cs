
using System.Collections.Generic;

namespace test_menu
{
    /// <summary>
    /// глобальные переменные
    /// </summary>
    class Globals
    {
        private static string EmploeeFilePath = "json_db.json";
        private static string DepartmentsFilePath = "json_dep.json";
        private static List<Employee> list_employee = new List<Employee>();
        private static List<Departaments> list_departaments = new List<Departaments>();

        public static string EmploeeFilePath1 { get => EmploeeFilePath; set => EmploeeFilePath = value; }
        public static string DepartmentsFilePath1 { get => DepartmentsFilePath; set => DepartmentsFilePath = value; }
        public static List<Employee> List_employee { get => list_employee; set => list_employee = value; }
        public static List<Departaments> List_Departaments { get => list_departaments; set => list_departaments = value; }
    }
}
