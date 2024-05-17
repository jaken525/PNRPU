using MySql.Data.MySqlClient;
using System.Data;

namespace ToysDB
{
    public partial class SignUp : Form
    {
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        private List<int> shopID = new List<int>();

        public SignUp()
        {
            InitializeComponent();

            LoadShops();
        }

        void LoadShops()
        {
            shopComboBox.Items.Clear();          
            DataTable shopTable = new DataTable();

            adapter.SelectCommand = new MySqlCommand("SELECT * FROM `Shop`", Static.dataBase.GetConnection());
            adapter.Fill(shopTable);

            foreach (DataRow row in shopTable.Rows)
            {
                shopComboBox.Items.Add(row["Name"].ToString());
                shopID.Add(Convert.ToInt32(row["ShopID"]));
            }
        }

        private void signButton_Click(object sender, EventArgs e)
        {
            try
            {
                string query = $"INSERT INTO `Employee`(`EmployeeID`, `Name`, `Surname`, `Patronymic`, `Age`, `GenderID`, `ShopID`) VALUES (0,'{nameTextBox.Text}','{surnameTextBox.Text}','{patronymicTextBox.Text}','{Convert.ToInt32(ageTextBox.Text)}','{genderComboBox.SelectedIndex + 1}','{shopID[shopComboBox.SelectedIndex]}')";

                Static.mySqlCommand = new MySqlCommand(query, Static.dataBase.GetConnection());
                MySqlDataReader reader = Static.mySqlCommand.ExecuteReader();

                Random random = new Random();
                string password = Convert.ToString(random.Next(10000000, 99999999));

                reader.Read();
                reader.Close();

                DataTable employeeTable = new DataTable();
                Static.mySqlCommand = new MySqlCommand($"SELECT * FROM `Employee` WHERE `Name` = '{nameTextBox.Text}' AND `Surname` = '{surnameTextBox.Text}' AND `Patronymic` = '{patronymicTextBox.Text}' AND `Age` = '{Convert.ToInt32(ageTextBox.Text)}' AND `GenderID` = '{genderComboBox.SelectedIndex + 1}' AND `ShopID` = '{shopID[shopComboBox.SelectedIndex]}'", Static.dataBase.GetConnection());
                adapter.SelectCommand = Static.mySqlCommand;
                adapter.Fill(employeeTable);
                
                int employeeID = Convert.ToInt32(employeeTable.Rows[0]["EmployeeID"]);

                query = $"INSERT INTO `EmployeesData`(`EmployeesDataID`, `Login`, `Password`, `RightsID`, `EmployeeID`) VALUES (0,'{password}','{Static.GetSha1(password)}','1','{employeeID}')";
                Static.mySqlCommand = new MySqlCommand(query, Static.dataBase.GetConnection());
                reader = Static.mySqlCommand.ExecuteReader();

                reader.Read();
                statusRichTextBox.Text += $"Новый продавец успешно добавлен! Его логин и пароль: {password}\nЭтот пароль пользователь сможет сменить в любой момент. Также его права доступа Вы можете поменять в таблице EmployeeData.\n\n";
                reader.Close();
            }
            catch (MySqlException ex)
            {
                statusRichTextBox.Text += ex.Message + "\n\n";
            }
        }


    }
}
