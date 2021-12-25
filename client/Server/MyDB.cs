using MySql.Data.MySqlClient;
using System.Configuration;

namespace Server
{
    internal static class MyDB
    {
        public const string Schema = "MySchme";
        public const string Database = "car_dealers";
        public const string SalesTable = "sales";
        public const string ModelsTable = "models";
        public const string MarksTable = "marks";
        public const string CustomersTable = "customers";
        public const string ManagersTable = "managers";
        public const string Id = "id";
        public const string Name = "name";
        public const string Price = "price";
        public const string Salary = "salary";

        private static string Host = ConfigurationManager.AppSettings.Get("AddressDB");
        private static int Port = int.Parse(ConfigurationManager.AppSettings.Get("PortDB"));
        private static string Username = ConfigurationManager.AppSettings.Get("UserDB");
        private static string Password = ConfigurationManager.AppSettings.Get("PasswordDB");
        public static string ConnString = "Server=" + Host + ";Database= " + Database + ";Charset=utf8mb4" + ";port=" + Port + ";User Id=" + Username + ";password=" + Password;

       
    }
}
