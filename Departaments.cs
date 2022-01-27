using System;
using System.Xml.Serialization;

namespace test_menu
{
    public class Departaments
    {
        private string dp_name;
        private DateTime date_of_creation;
        private int emp_count;

        public string Dp_name { get => dp_name; set => dp_name = value; }
        public DateTime Date_of_creation { get => date_of_creation; set => date_of_creation = value; }
        public int Emp_count { get => emp_count; set => emp_count = value; }

        public Departaments() { }

        public Departaments(string dp_name, DateTime date_of_creation, int emp_count) {
            this.dp_name = dp_name;
            this.date_of_creation = date_of_creation;
            this.emp_count = emp_count;
        }
    }
}
