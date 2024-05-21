using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace BD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            string loginWorker = textBoxLogin.Text;
            string passwordWorker = textBoxPassword.Text;
            Database database = new Database();
            DataTable tableLogin = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `workers` WHERE `login` = @lW AND `password` = @pW", database.getConnection());
            command.Parameters.Add("@lW", MySqlDbType.VarChar).Value = loginWorker;
            command.Parameters.Add("@pW", MySqlDbType.VarChar).Value = passwordWorker;
            adapter.SelectCommand = command;
            adapter.Fill(tableLogin);
            if (tableLogin.Rows.Count > 0)
            {
                this.Hide();
                FormWorkers formWorkers = new FormWorkers(tableLogin);
                formWorkers.Show();
            }
            else
                MessageBox.Show("Повторите попытку!");           
        }
        private void labelExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
