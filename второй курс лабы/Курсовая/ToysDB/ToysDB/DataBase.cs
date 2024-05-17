using MySql.Data.MySqlClient;

namespace ToysDB
{
    public class DataBase
    {
        private MySqlConnection connection = new MySqlConnection($"server=127.0.0.1;port=3306;username=root;password=;database=Toys");
        public bool isOpen = false;

        public void OpenConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                    isOpen = true;
                }
            }
            catch
            {
                MessageBox.Show("Невозможно открыть соединение!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                isOpen = false;
            }
        }

        public bool PingServer()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                return connection.Ping();

            return false;
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

    }

}
