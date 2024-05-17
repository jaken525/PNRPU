using MySql.Data.MySqlClient;
using System.Data;

namespace ToysDB
{
    public partial class Window : Form
    {
        Additional_Table add;
        private bool newRowAdded = false;

        public Window()
        {
            InitializeComponent();

            Static.dataBase.OpenConnection();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            loginButton.Enabled = Static.dataBase.isOpen;

            Static.isLogin = !(Static.accountLogin == "");

            if (Static.isLogin)
            {
                loginButton.Text = "Выйти";
                if (tablesComboBox.Items.Count <= 0)
                    LoadTables();

                switch (Static.rights)
                {
                    case 1:
                        queryGroupBox.Enabled = true;
                        sqlButton.Enabled = false;
                        signUpButton.Enabled = false;

                        dataGridView1.AllowUserToAddRows = false;
                        dataGridView1.AllowUserToDeleteRows = false;

                        break;

                    case 2:
                        queryGroupBox.Enabled = false;
                        sqlButton.Enabled = true;
                        signUpButton.Enabled = true;

                        dataGridView1.AllowUserToAddRows = true;
                        dataGridView1.AllowUserToDeleteRows = true;

                        break;
                }
            }
            else
            {
                loginButton.Text = "Войти";
                tablesComboBox.Items.Clear();
                dataGridView1.DataSource = 0;
            }

            tableNameGroupBox.Enabled = Static.isLogin;
            controlsGroupBox.Enabled = Static.isLogin;

            if (add != null)
                additionalButton.Enabled = !add.Visible;

            accountNameLabel.Text = "Работник: " + Static.accountLogin;
            shopLabel.Text = "Магазин: " + Static.shopName;
            rightsLabel.Text = "Права: " + Static.rightsString;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (!Static.isLogin)
            {
                Login login = new Login();

                if (!login.CheckAccount())
                    login.ShowDialog();
            }
            else
            {
                Static.accountLogin = "";
                Static.shopName = "";
                Static.rightsString = "";
                Static.rights = 0;
                Static.employeeID = 0;
                Static.shopID = 0;

                tablesComboBox.SelectedIndex = -1;

                File.Delete(Static.path + "\\account.txt");

                if (add != null)
                    add.Close();
            }
        }

        public void LoadTables()
        {
            DataTable tables = Static.dataBase.GetConnection().GetSchema("Tables");

            foreach (DataRow row in tables.Rows)
                if (Static.employeeTables.Contains(row["TABLE_NAME"].ToString()) && Static.rights == 1)
                    tablesComboBox.Items.Add(row["TABLE_NAME"].ToString());
                else if (Static.rights == 2)
                    tablesComboBox.Items.Add(row["TABLE_NAME"].ToString());
        }

        public void LoadDataGrid()
        {
            if (Static.isLogin)
                if (tablesComboBox.SelectedIndex != -1)
                {
                    tableNameGroupBox.Text = tablesComboBox.SelectedItem.ToString();
                    Static.currentTableName = tableNameGroupBox.Text;

                    Static.dataSet = new DataTable();

                    string query1 = $"SELECT *, 'Delete' AS 'Control' FROM {Static.currentTableName}";
                    string query2 = $"SELECT * FROM {Static.currentTableName}_view";

                    Static.adapter = new MySqlDataAdapter(Static.rights == 2 ? query1 : query2, Static.dataBase.GetConnection());
                    Static.mySqlCommandBuilder = new MySqlCommandBuilder(Static.adapter);

                    Static.mySqlCommandBuilder.GetDeleteCommand();
                    Static.mySqlCommandBuilder.GetInsertCommand();
                    Static.mySqlCommandBuilder.GetUpdateCommand();

                    Static.adapter.Fill(Static.dataSet);

                    dataGridView1.DataSource = Static.dataSet;

                    if (Static.rights == 2)
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell dataGridViewLinkCell = new DataGridViewLinkCell();

                            dataGridView1[dataGridView1.Columns.Count - 1, i] = dataGridViewLinkCell;
                        }
                }
        }

        public void UpdateDataGrid()
        {
            if (Static.isLogin)
                if (tablesComboBox.SelectedIndex != -1)
                {
                    tableNameGroupBox.Text = tablesComboBox.SelectedItem.ToString();
                    Static.currentTableName = tableNameGroupBox.Text;

                    Static.dataSet.Clear();

                    Static.adapter.Fill(Static.dataSet);

                    dataGridView1.DataSource = Static.dataSet;

                    if (Static.rights == 2)
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            DataGridViewLinkCell dataGridViewLinkCell = new DataGridViewLinkCell();

                            dataGridView1[dataGridView1.Columns.Count - 1, i] = dataGridViewLinkCell;
                        }
                }
        }

        private void tablesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            UpdateDataGrid();
            tablesComboBox.Items.Clear();
        }

        private void sqlButton_Click(object sender, EventArgs e)
        {
            SqlCommandForm sqlCommandForm = new SqlCommandForm();
            sqlCommandForm.ShowDialog();
        }

        private void saleButton_Click(object sender, EventArgs e)
        {
            SaleToy saleToy = new SaleToy();
            saleToy.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Static.rights == 2)
                    if (e.ColumnIndex == dataGridView1.Columns.Count - 1)
                    {
                        string task = dataGridView1.Rows[e.RowIndex].Cells["Control"].Value.ToString();
                        int rowIndex;

                        switch (task)
                        {
                            case "Delete":
                                {
                                    if (MessageBox.Show("Вы уверены, что хотите удалить эту строку?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                    {
                                        rowIndex = e.RowIndex;
                                        dataGridView1.Rows.RemoveAt(rowIndex);
                                        Static.dataSet.Rows[rowIndex].Delete();

                                        Static.mySqlCommandBuilder = new MySqlCommandBuilder(Static.adapter);
                                        Static.adapter.DeleteCommand = Static.mySqlCommandBuilder.GetDeleteCommand();
                                        Static.adapter.Update(Static.dataSet);
                                    }
                                }
                                break;

                            case "Insert":
                                {
                                    rowIndex = dataGridView1.Rows.Count - 2;

                                    DataRow row = Static.dataSet.NewRow();

                                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                                        row[i] = dataGridView1.Rows[rowIndex].Cells[i].Value;

                                    Static.dataSet.Rows.Add(row);
                                    Static.dataSet.Rows.RemoveAt(Static.dataSet.Rows.Count - 1);

                                    Static.mySqlCommandBuilder = new MySqlCommandBuilder(Static.adapter);
                                    Static.adapter.InsertCommand = Static.mySqlCommandBuilder.GetInsertCommand();
                                    Static.adapter.Update(Static.dataSet);


                                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                                    dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns.Count - 1].Value = "Delete";

                                    newRowAdded = false;
                                }
                                break;

                            case "Update":
                                {
                                    rowIndex = e.RowIndex;
                                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                                        Static.dataSet.Rows[rowIndex][i] = dataGridView1.Rows[rowIndex].Cells[i].Value;

                                    Static.mySqlCommandBuilder = new MySqlCommandBuilder(Static.adapter);
                                    Static.adapter.UpdateCommand = Static.mySqlCommandBuilder.GetUpdateCommand();
                                    Static.adapter.Update(Static.dataSet);

                                    dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns.Count - 1].Value = "Delete";
                                }
                                break;
                        }

                        UpdateDataGrid();
                    }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (Static.rights == 2)
                    if (!newRowAdded)
                    {
                        newRowAdded = true;

                        int lastRow = dataGridView1.Rows.Count - 2;

                        DataGridViewRow row = dataGridView1.Rows[lastRow];
                        DataGridViewLinkCell dataGridViewLinkCell = new DataGridViewLinkCell();

                        dataGridView1[dataGridView1.Columns.Count - 1, lastRow] = dataGridViewLinkCell;
                        row.Cells["Control"].Value = "Insert";
                    }
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Static.rights == 2)
                    if (!newRowAdded)
                    {
                        int rowIndex = dataGridView1.SelectedCells[0].RowIndex;

                        DataGridViewRow editingRow = dataGridView1.Rows[rowIndex];
                        DataGridViewLinkCell dataGridViewLinkCell = new DataGridViewLinkCell();

                        dataGridView1[dataGridView1.Columns.Count - 1, rowIndex] = dataGridViewLinkCell;
                        editingRow.Cells["Control"].Value = "Update";
                    }
            }
            catch
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void additionalButton_Click(object sender, EventArgs e)
        {
            add = new Additional_Table();
            add.Show();
        }

        private void signUpButton_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.ShowDialog();
        }

        private void changeDataButton_Click(object sender, EventArgs e)
        {
            ChangeData changeData = new ChangeData();
            changeData.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangePrice changePrice = new ChangePrice();
            changePrice.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tablesComboBox.SelectedIndex = -1;

            tableNameGroupBox.Text = "Toy";
            Static.currentTableName = tableNameGroupBox.Text;

            Static.dataSet = new DataTable();

            string query = $"SELECT * FROM {Static.currentTableName}_view WHERE `shopName` = '{Static.shopName}'";

            Static.adapter = new MySqlDataAdapter(query, Static.dataBase.GetConnection());
            Static.adapter.Fill(Static.dataSet);

            dataGridView1.DataSource = Static.dataSet;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Static.buyMode = 0;
            Request request = new Request();
            request.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Static.buyMode = 1;
            Request request = new Request();
            request.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tablesComboBox.SelectedIndex = -1;

            tableNameGroupBox.Text = "Toy";
            Static.currentTableName = tableNameGroupBox.Text;

            Static.dataSet = new DataTable();

            string query = $"SELECT * FROM {Static.currentTableName}_view WHERE `shopName` = '{Static.shopName}' AND `Discount` > 0";

            Static.adapter = new MySqlDataAdapter(query, Static.dataBase.GetConnection());
            Static.adapter.Fill(Static.dataSet);

            dataGridView1.DataSource = Static.dataSet;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Static.buyMode = 2;
            Request request = new Request();
            request.ShowDialog();
        }
    }

}
