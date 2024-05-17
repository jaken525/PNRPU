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
    public partial class ChangeData : Form
    {
        public ChangeData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text)
                if (MessageBox.Show("Если вы измените пароль, то вам придётся заходить в следуюющий раз в аккаунт занаво!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    ChangeTableData("Password", textBox1.Text);
                    File.Delete(Static.path + "\\account.txt");
                    statusLabel.Text = "Пароль изменён!";
                }
            else
                statusLabel.Text = "Пароли не совпадают";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Если вы измените логин, то вам придётся заходить в следуюющий раз в аккаунт занаво!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                ChangeTableData("Login", textBox3.Text);
                File.Delete(Static.path + "\\account.txt");
            }
        }

        void ChangeTableData(string column, string data)
        {
            string query = $"UPDATE `EmployeesData` SET `{column}` = @up WHERE `EmployeeID` = '{Static.employeeID}'";

            Static.mySqlCommand = new MySqlCommand(query, Static.dataBase.GetConnection());
            Static.mySqlCommand.Parameters.Add("@up", MySqlDbType.VarChar).Value = column == "Password" ? Static.GetSha1(data) : data;
            MySqlDataReader reader = Static.mySqlCommand.ExecuteReader();

            reader.Read();
            reader.Close();
        }
    }
}
