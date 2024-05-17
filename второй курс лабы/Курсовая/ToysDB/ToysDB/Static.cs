using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using System.Security.Cryptography;

namespace ToysDB
{
    public class Static
    {
        public static bool isLogin = false;

        public static int rights = 0;
        public static int employeeID = 0;
        public static int shopID = 0;
        public static int buyMode = 0;

        public static string currentTableName = "";
        public static string accountLogin = "";
        public static string shopName = "";
        public static string rightsString = "";
        public static string path = Directory.GetCurrentDirectory();
        public readonly static string[] employeeTables = { "Employee", "Product", "Request", "Sale", "Toy", "Structure" };

        public static DataBase dataBase = new DataBase();
        public static DataTable dataSet = new DataTable();
        public static MySqlDataAdapter adapter = new MySqlDataAdapter();
        public static MySqlCommand mySqlCommand = new MySqlCommand();
        public static MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder();

        public static string GetSha1(string value)
        {
            var data = Encoding.ASCII.GetBytes(value);
            var hashData = new SHA1Managed().ComputeHash(data);
            var hash = string.Empty;

            foreach (var b in hashData)
                hash += b.ToString("X2");

            return hash;
        }

        public static string GetIDRow(string table, int id, string column)
        {
            var dataTable = new DataTable();

            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            adapter1.SelectCommand = new MySqlCommand($"SELECT * FROM `{table}` WHERE `{table}ID` = '{id}'", Static.dataBase.GetConnection());
            adapter1.Fill(dataTable);

            return dataTable.Rows[0][column].ToString();
        }
    }
}
