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
    public partial class Additional_Table : Form
    {
        public Additional_Table()
        {
            InitializeComponent();

            LoadTables();
        }

        public void LoadTables()
        {
            DataTable tables = Static.dataBase.GetConnection().GetSchema("Tables");

            foreach (DataRow row in tables.Rows)
                if (Static.employeeTables.Contains(row["TABLE_NAME"].ToString()) && Static.rights == 1)
                    comboBox1.Items.Add(row["TABLE_NAME"].ToString());
                else if (Static.rights == 2)
                    comboBox1.Items.Add(row["TABLE_NAME"].ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
            {
                DataTable table = new DataTable();

                string query2 = $"SELECT * FROM {comboBox1.SelectedItem}";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query2, Static.dataBase.GetConnection());
                adapter.Fill(table);

                dataGridView1.DataSource = table;
            }
        }
    }
}
