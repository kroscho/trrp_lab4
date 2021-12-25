using MySql.Data.MySqlClient;

namespace ServerSocket
{
    internal static class MyDB
    {
        public const string Schema = "MyScheme";
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

        private const string Host = "127.0.0.1";
        private const int Port = 3306;
        private const string Username = "root";
        private const string Password = "1111";
        public static string ConnString = "Server=" + Host + ";Database= " + Database + ";Charset=utf8"
                                            + ";port=" + Port + ";User Id=" + Username + ";password=" + Password;

        public static void CreateDb()
        {
            using (var conn = new MySqlConnection(ConnString))
            {
                conn.Open();
                var sqlCommand = new MySqlCommand("select count(*) from sysdatabases where name = " + Database, conn);
                if (sqlCommand.ExecuteReader().Read().ToString() != "0")
                {
                    sqlCommand = new MySqlCommand("CREATE DATABASE " + Database + ";", conn);
                    sqlCommand.ExecuteNonQuery();
                }
                sqlCommand.Dispose();
                conn.Close();
            }

            ConnString += ";Database" + Database;
        }
    }
}
