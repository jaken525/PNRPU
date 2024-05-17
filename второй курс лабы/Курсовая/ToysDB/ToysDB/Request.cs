using MySql.Data.MySqlClient;
using System.Data;

namespace ToysDB
{
    public partial class Request : Form
    {
        private DataTable productTable = new DataTable();
        private DataTable toyTable = new DataTable();
        private MySqlDataAdapter adapter = new MySqlDataAdapter();

        private List<string> voidProductsName = new List<string>();
        private List<int> productsID = new List<int>();

        public Request()
        {
            InitializeComponent();

            if (Static.buyMode == 1)
                MessageBox.Show("Закупка перспективных игрушек означает, что можно закупить только те игрушки, производитель которых выставил на них процент перспективы больше 75.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (Static.buyMode == 2)
                MessageBox.Show("Можно закупить только игрушки с самым высоким рейтингом", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();
        }

        void LoadData()
        {
            productComboBox.Items.Clear();
            richTextBox1.Clear();

            toyTable = new DataTable();

            if (Static.buyMode != 2)
            {
                adapter.SelectCommand = new MySqlCommand($"SELECT * FROM `Toy` WHERE `ShopID` = {Static.shopID}", Static.dataBase.GetConnection());
                adapter.Fill(toyTable);

                foreach (DataRow row in toyTable.Rows)
                {
                    string name = Static.GetIDRow("Product", Convert.ToInt32(row["ProductID"]), "Name");

                    voidProductsName.Add(name);

                    if (Convert.ToInt32(row["Count"]) == 0)
                        richTextBox1.Text += name + "\n";
                }
            }

            productTable = new DataTable();

            string query = "";

            switch(Static.buyMode)
            {
                default:
                    query = $"SELECT * FROM `Product`";
                    break;
                case 1:
                    query = $"SELECT * FROM `Product` WHERE `Perspective` > 75";
                    break;
                case 2:
                    query = $"SELECT * FROM `Toy` WHERE Rating = (SELECT MAX(Rating) FROM `Toy`)";
                    break;
            }

            adapter.SelectCommand = new MySqlCommand(query, Static.dataBase.GetConnection());
            adapter.Fill(productTable);

            foreach (DataRow row in productTable.Rows)
            {
                if (Static.buyMode != 2)
                    productComboBox.Items.Add(row["Name"].ToString());
                else
                    productComboBox.Items.Add(Static.GetIDRow("Product", Convert.ToInt32(row["ProductID"]), "Name"));
                productsID.Add(Convert.ToInt32(row["ProductID"]));
            }

        }

        private void requestButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date = DateTime.Now;
                string dateString = $"{date:yyyy/MM/dd}";
                dateString = dateString.Replace('.', '-');

                if (Convert.ToInt32(countTextBox.Text) > 0)
                    if (voidProductsName.Contains(productComboBox.SelectedItem) || Static.buyMode == 2)
                    {
                        string query = $"INSERT INTO `Request`(`RequestID`, `ShopID`, `EmployeeID`, `ProductID`, `Date`, `Count`) VALUES ('0','{Static.shopID}','{Static.employeeID}','{productsID[productComboBox.SelectedIndex]}','{dateString}','{countTextBox.Text}')";
                        Static.mySqlCommand = new MySqlCommand(query, Static.dataBase.GetConnection());
                        MySqlDataReader reader = Static.mySqlCommand.ExecuteReader();

                        reader.Read();
                        reader.Close();

                        LoadData();
                        MessageBox.Show("Заявка успешно выполнена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        string query = $"INSERT INTO `Toy`(`ToyID`, `ProductID`, `Price`, `Discount`, `Count`, `Rating`, `ShopID`) VALUES ('0','{productsID[productComboBox.SelectedIndex]}','0','0','0','0','{Static.shopID}')";
                        Static.mySqlCommand = new MySqlCommand(query, Static.dataBase.GetConnection());
                        MySqlDataReader reader = Static.mySqlCommand.ExecuteReader();

                        reader.Read();
                        reader.Close();

                        query = $"INSERT INTO `Request`(`RequestID`, `ShopID`, `EmployeeID`, `ProductID`, `Date`, `Count`) VALUES ('0','{Static.shopID}','{Static.employeeID}','{productsID[productComboBox.SelectedIndex]}','{dateString}','{countTextBox.Text}')";
                        Static.mySqlCommand = new MySqlCommand(query, Static.dataBase.GetConnection());
                        reader = Static.mySqlCommand.ExecuteReader();

                        reader.Read();
                        reader.Close();

                        LoadData();
                        MessageBox.Show("Заявка успешно выполнена! Новая игрушка прибудет с минуты на минуту. Не забудьте выставить на неё цену!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
