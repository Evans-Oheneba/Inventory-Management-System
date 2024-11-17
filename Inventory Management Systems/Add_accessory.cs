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
    public partial class Add_accessory : Form
    {
        public Add_accessory()
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


        public void AddDevice(String name, String type, String brand, String office)
        {
            string sql = "insert into accessories(acc_name, acc_type, acc_brand, office_loc) VALUES (@name, @type, @brand, @office)";

            MySqlConnection con = GetSqlConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);

            // cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = type;
            cmd.Parameters.Add("@brand", MySqlDbType.VarChar).Value = brand;
            cmd.Parameters.Add("@office", MySqlDbType.VarChar).Value = office;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Accessory added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string _name = nameTextBox.Text;
                string _brand = brandTextBox.Text;
                string _type = TypeTextBox.Text;
                string _office = officeTextBox.Text;

                this.AddDevice(_name, _type, _brand, _office);


                this.Close();
            }
            catch
            {
                MessageBox.Show("error");
            }
        }

        private void Add_accessory_Load(object sender, EventArgs e)
        {

        }
    }
    }

