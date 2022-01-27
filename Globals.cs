
namespace test_menu
{
    class Globals
    {
        private static string XmlFilePath = "xml_db.xml";
        private static string JsonFilePath = "json_db.json";

        public static string XmlFilePath1 { get => XmlFilePath; set => XmlFilePath = value; }
        public static string JsonFilePath1 { get => JsonFilePath; set => JsonFilePath = value; }
    }
}
