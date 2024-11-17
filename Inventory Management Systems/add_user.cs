using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Inventory_Management_Systems
{
    public partial class add_user : Form
    {
        public add_user()
        {
            InitializeComponent();
        }

        public MySqlConnection GetSqlConnection()
        {
            string connectionString = "datasource=localhost;port=3306;username=root;password=Oheneba6080%;database=inventory";
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return connection;
        }

        //ADD USER
        public void AddUser(String name, String level, String pass)
        {
            string sql = "insert into users (username, level, password) VALUES (@name, @level, @pass)";

            MySqlConnection con = GetSqlConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);

            // cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@level", MySqlDbType.VarChar).Value = level;
            cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("User added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            string message = "Kindly contact the developer on 0553473797 for assistance. Thank you.";
            string title = "Help";
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void add_user_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string _name = nameTextBox.Text;
                string _level = LevelcomboBox.Text;
                string _pass = passTextBox.Text;
                string _pass1 = pass1TextBox.Text;

                if(_pass == _pass1)
                {
                    this.AddUser(_name, _level, _pass);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password Mismatch");
                }
           
                
            }
            catch
            {
                MessageBox.Show("error");
            }
        }
    }
}
