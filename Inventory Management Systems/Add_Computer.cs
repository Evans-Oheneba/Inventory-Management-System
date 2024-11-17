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
    public partial class Add_Computer : Form
    {
        public Add_Computer()
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard Form2 = new Dashboard();
            Form2.ShowDialog();
            this.Close();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            string message = "Kindly contact the developer on 0553473797 for assistance. Thank you.";
            string title = "Help";
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //ADD COMPUTER

        public void AddComputer(String name, String brand, String spec, String type, String department, String person_ass, String status,  String date_ass )
        {
            string sql = "insert into computers(computer_name, computer_brand, computer_spec, computer_type, department, person_assigned, status, date_assigned) VALUES (@name, @brand, @spec, @type, @department, @person_ass, @status, @date_ass)";

            MySqlConnection con = GetSqlConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);

            // cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@brand", MySqlDbType.VarChar).Value = brand;
            cmd.Parameters.Add("@spec", MySqlDbType.VarChar).Value = spec;
            cmd.Parameters.Add("@type", MySqlDbType.VarChar).Value = type;
            cmd.Parameters.Add("@department", MySqlDbType.VarChar).Value = department;
            cmd.Parameters.Add("@person_ass", MySqlDbType.VarChar).Value = person_ass;
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;
            cmd.Parameters.Add("@date_ass", MySqlDbType.VarChar).Value = date_ass;



            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Computer added successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void Add_Computer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string _name = nameTextBox.Text;
                string _brand = brandTextBox.Text;
                string _spec = specTextBox.Text;
                string _type = TypecomboBox.Text;
                string _department = DepartmentComboBox.Text;
                string _person_ass = pAtextBox.Text;
                string _status = StatusComboBox.Text;
                string _date_ass = dateTimePicker1.Text;


                this.AddComputer(_name, _brand, _spec, _type, _department, _person_ass, _status, _date_ass);

              
                this.Close();
            }
            catch
            {
                MessageBox.Show("errror");
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
