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
    public partial class add_printer : Form
    {
        public add_printer()
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

        //ADD PRINTER / SCANNER

        public void AddDevice(String name, String type, String brand, String spec, String office)
        {
            string sql = "insert into scanners_printers (device_name, device_type, device_brand, device_spec, office_loc) VALUES (@name, @type, @brand, @spec, @office)";

            MySqlConnection con = GetSqlConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);

            // cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                  cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = type;
            cmd.Parameters.Add("@brand", MySqlDbType.VarChar).Value = brand;
            cmd.Parameters.Add("@spec", MySqlDbType.VarChar).Value = spec;
            cmd.Parameters.Add("@office", MySqlDbType.VarChar).Value = office;

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Device added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            try
            {
                string _name = nameTextBox.Text;
                string _brand = brandTextBox.Text;
                string _spec = specTextBox.Text;
                string _type = TypecomboBox.Text;
                string _office = officeTextBox.Text;

                this.AddDevice(_name, _type, _brand, _spec,  _office);


                this.Close();
            }
            catch
            {
                MessageBox.Show("errror");
            }
        }

        private void add_printer_Load(object sender, EventArgs e)
        {

        }
    }
}
