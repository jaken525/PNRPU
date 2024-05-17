using MySql.Data.MySqlClient;
using System.Data;

namespace ToysDB
{
    public partial class Login : Form
    {
        private bool isAuto = false;
        string login = "";
        string password = "";

        public Login()
        {
            InitializeComponent();
        }

        public bool CheckAccount()
        {
            if (File.Exists(Static.path + "\\account.txt"))
            {
                FileInfo fileInfo = new FileInfo(Static.path + "\\account.txt");
                if (fileInfo.Length > 0)
                {
                    isAuto = true;

                    login = File.ReadLines(Static.path + "\\account.txt").Skip(0).First();
                    password = File.ReadLines(Static.path + "\\account.txt").Skip(1).First();

                    LoginAccount();

                    return true;
                }
                else
                    File.Delete(Static.path + "\\account.txt");
            }

            return false;
        }

        void LoginAccount()
        {
            DataTable employeesDataTable = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            Static.mySqlCommand = new MySqlCommand("SELECT * FROM `EmployeesData` WHERE `Login` = @ul AND `Password` = @up", Static.dataBase.GetConnection());
            Static.mySqlCommand.Parameters.Add("@ul", MySqlDbType.VarChar).Value = !isAuto ? loginTextBox.Text : login;
            Static.mySqlCommand.Parameters.Add("@up", MySqlDbType.VarChar).Value = !isAuto ? Static.GetSha1(passwordTextBox.Text) : password;

            adapter.SelectCommand = Static.mySqlCommand;
            adapter.Fill(employeesDataTable);

            if (employeesDataTable.Rows.Count > 0)
            {
                login = employeesDataTable.Rows[0][1].ToString();
                password = employeesDataTable.Rows[0][2].ToString();

                Static.employeeID = Convert.ToInt32(employeesDataTable.Rows[0]["EmployeeID"]);
                Static.accountLogin = Static.GetIDRow("Employee", Static.employeeID, "Name");

                Static.shopID = Convert.ToInt32(Static.GetIDRow("Employee", Static.employeeID, "ShopID"));
                Static.shopName = Static.GetIDRow("Shop", Static.shopID, "Name");

                Static.rights = Convert.ToInt32(employeesDataTable.Rows[0]["RightsID"]);
                Static.rightsString = Static.GetIDRow("Rights", Static.rights, "Rights");

                if (!isAuto)
                    if (rememberСheckBox.Checked)
                    {
                        File.AppendAllText(Static.path + "\\account.txt", login + "\n");
                        File.AppendAllText(Static.path + "\\account.txt", password);
                    }

                this.Close();
                MessageBox.Show($"Добро пожаловать, {Static.GetIDRow("Employee", Static.employeeID, "Surname")} {Static.GetIDRow("Employee", Static.employeeID, "Name")} {Static.GetIDRow("Employee", Static.employeeID, "Patronymic")}, в систему!");
            }
            else
                statusLabel.Text = "Неверный пароль.";
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (Static.dataBase.PingServer())
            {
                isAuto = false;
                LoginAccount();
            }
            else
                statusLabel.Text = "Нет ответа от сервера!";
        }

    }

}
