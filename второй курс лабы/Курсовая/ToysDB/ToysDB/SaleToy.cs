using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToysDB
{
    public partial class SaleToy : Form
    {
        private DataTable dataTable = new DataTable();
        MySqlDataAdapter adapter = new MySqlDataAdapter();

        private List<int> productCount = new List<int>();
        private List<int> productID = new List<int>();

        public SaleToy()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            toysComboBox.Items.Clear();
            productCount.Clear();
            productID.Clear();

            adapter.SelectCommand = new MySqlCommand($"SELECT * FROM `Toy` WHERE `ShopID` = '{Static.shopID}'", Static.dataBase.GetConnection());
            adapter.Fill(dataTable);

            foreach (DataRow row in dataTable.Rows)
            {
                toysComboBox.Items.Add(Static.GetIDRow("Product", Convert.ToInt32(row["ProductID"]), "Name"));
                productCount.Add(Convert.ToInt32(row["Count"]));
                productID.Add(Convert.ToInt32(row["ProductID"]));
            }
        }

        private void toysComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            countLabel.Text = $"Количество в магазине: {productCount[toysComboBox.SelectedIndex]}";
        }

        private void saleButton_Click(object sender, EventArgs e)
        {
            string query = "";

            try
            {
                if (productCount[toysComboBox.SelectedIndex] - Convert.ToInt32(textBox1.Text) >= 0 && Convert.ToInt32(textBox1.Text) != 0)
                {
                    DateTime date = DateTime.Now;
                    string dateString = $"{date:yyyy/MM/dd}";
                    dateString = dateString.Replace('.', '-');

                    query = $"INSERT INTO `Sale`(`SaleID`, `Price`, `Date`, `ToyID`, `Count`) VALUES ('0','{dataTable.Rows[toysComboBox.SelectedIndex]["Price"]}','{dateString}','{dataTable.Rows[toysComboBox.SelectedIndex]["ToyID"]}','{Convert.ToInt32(textBox1.Text)}')";
                    Static.mySqlCommand = new MySqlCommand(query, Static.dataBase.GetConnection());
                    MySqlDataReader reader = Static.mySqlCommand.ExecuteReader();

                    reader.Read();
                    reader.Close();

                    LoadData();
                    MessageBox.Show("Поздравляем! Вы продали игрушку(ки)!", "Победа", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
