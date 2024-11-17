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
    public partial class delete_computer : Form
    {
        public delete_computer()
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
            string sql = "DELETE FROM computers WHERE id=@id";

            MySqlConnection con = GetSqlConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);

            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            try
            {

                DialogResult result = MessageBox.Show("Are you sure you want to delete this Computer", "Delete Computer", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Computer Deleted Successfully");
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


        private void delete_computer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _id = idTextBox.Text;

            this.deleteUser(_id);

            this.Close();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            string message = "Kindly contact the developer on 0553473797 for assistance. Thank you.";
            string title = "Help";
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
