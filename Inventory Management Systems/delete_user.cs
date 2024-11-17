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
    public partial class delete_user : Form
    {
        public delete_user()
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


        //DELETE USER
        public void deleteUser(string id)
        {
            string sql = "DELETE FROM users WHERE password=@password";

            MySqlConnection con = GetSqlConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);

            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = id;
            try
            {
                
                DialogResult result =  MessageBox.Show("Are you sure you want to delete this user", "Delete User", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Deleted Successfully");
                }
                
                else if (result == DialogResult.No)
                {
                    MessageBox.Show("Canceled");
                    cmd.Cancel();
                }

                else if (result == DialogResult.Cancel)
                {
                    MessageBox.Show("Canceled");
                    cmd.Cancel();
                   
                }
             
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


        private void button1_Click(object sender, EventArgs e)
        {

            string _id = idTextBox.Text;

            this.deleteUser(_id);

            this.Close();




        }

        private void delete_user_Load(object sender, EventArgs e)
        {

        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
