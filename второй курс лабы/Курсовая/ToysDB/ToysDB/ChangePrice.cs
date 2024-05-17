using MySql.Data.MySqlClient;
using System.Data;

namespace ToysDB
{
    public partial class ChangePrice : Form
    {
        private DataTable dataTable = new DataTable();
        MySqlDataAdapter adapter = new MySqlDataAdapter();

        private List<int> productID = new List<int>();
        private int oldPrice = 0;

        public ChangePrice()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            toysComboBox.Items.Clear();
            productID.Clear();

            adapter.SelectCommand = new MySqlCommand($"SELECT * FROM `Toy` WHERE `ShopID` = '{Static.shopID}'", Static.dataBase.GetConnection());
            adapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                toysComboBox.Items.Add(Static.GetIDRow("Product", Convert.ToInt32(row["ProductID"]), "Name"));
                comboBox1.Items.Add(Static.GetIDRow("Product", Convert.ToInt32(row["ProductID"]), "Name"));
                productID.Add(Convert.ToInt32(row["ProductID"]));
            }
        }

        private void toysComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = dataTable.Rows[toysComboBox.SelectedIndex]["Price"].ToString();
        }

        private void saleButton_Click(object sender, EventArgs e)
        {
            string query = "";

            try
            {
                if (Convert.ToInt32(textBox1.Text) > 0)
                {
                    query = $"UPDATE `Toy` SET `Price` = '{textBox1.Text}', `Discount` = '0' WHERE `ToyID` = '{dataTable.Rows[toysComboBox.SelectedIndex]["ToyID"]}'";
                    Static.mySqlCommand = new MySqlCommand(query, Static.dataBase.GetConnection());
                    MySqlDataReader reader = Static.mySqlCommand.ExecuteReader();

                    reader.Read();
                    reader.Close();

                    LoadData();
                    MessageBox.Show("Цена изменена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Игрушек меньше, чем вы хотите продать!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"{ex.Message}\n\nЗапрос: {query}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            oldPrice = Convert.ToInt32(dataTable.Rows[comboBox1.SelectedIndex]["Price"]) + 1;
            textBox2.Text = "";
            textBox2.Text = dataTable.Rows[comboBox1.SelectedIndex]["Discount"].ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int newPrice = 0;

            if (textBox2.Text != "")
                newPrice = (oldPrice - (oldPrice * Convert.ToInt32(textBox2.Text)) / 100) - 1;
            else
                newPrice = 0;

            textBox3.Text = newPrice.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "";

            try
            {
                if (Convert.ToInt32(textBox2.Text) > 0 && Convert.ToInt32(textBox2.Text) <= 100)
                {
                    query = $"UPDATE `Toy` SET `Price` = '{textBox3.Text}', `Discount` = '{textBox2.Text}' WHERE `ToyID` = '{dataTable.Rows[comboBox1.SelectedIndex]["ToyID"]}'";
                    Static.mySqlCommand = new MySqlCommand(query, Static.dataBase.GetConnection());
                    MySqlDataReader reader = Static.mySqlCommand.ExecuteReader();

                    reader.Read();
                    reader.Close();

                    LoadData();
                    MessageBox.Show("Цена изменена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Скидка в процентах!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"{ex.Message}\n\nЗапрос: {query}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
