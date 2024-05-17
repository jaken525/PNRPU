using MySql.Data.MySqlClient;

namespace ToysDB
{
    public partial class SqlCommandForm : Form
    {
        public SqlCommandForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Static.mySqlCommand = new MySqlCommand(richTextBox1.Text, Static.dataBase.GetConnection());
                MySqlDataReader reader = Static.mySqlCommand.ExecuteReader();

                reader.Read();

                richTextBox2.Text += $"Запрос {richTextBox1.Text} успешно выполнен! \n\n";

                reader.Close();
            } 
            catch (MySqlException ex)
            {
                richTextBox2.Text += ex.Message + "\n\n";
            }

        }

    }

}
