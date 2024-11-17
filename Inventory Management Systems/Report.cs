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
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
            GetComputerCount();
            GetPrinterCount();
            GetAccCount();
            GetOfficeCount();
            GetPrinter1Count();
            GetAccess1Count();
            GetUserCount();
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


        private void Report_Load(object sender, EventArgs e)
        {
            adminLabel.Text = Session.AdminName;
            rankLabel.Text = Session.Level;

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Form2 = new Form1();
            Form2.ShowDialog();
            this.Close();
        }

        private void label22_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard Form2 = new Dashboard();
            Form2.ShowDialog();
            this.Close();
        }


        private void GetComputerCount()
        {
            try
            {
                {
                
                    // SQL query to count rows in your table
                    string query = "SELECT COUNT(*) FROM computers";

                    // Execute the query
                    MySqlConnection con = GetSqlConnection();
                    MySqlCommand cmd = new MySqlCommand(query, con);
                  
                    {
                        // Retrieve the count result
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // Display the count in a label or any control
                        numberComputers.Text = $" {count}";
         
                    }
                }
            }
            catch (Exception ex)
            {
                // Display any error messages
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void GetPrinterCount()
        {
            try
            {
                {

                    // SQL query to count rows in your table
                    string query = "SELECT COUNT(*) FROM scanners_printers";

                    // Execute the query
                    MySqlConnection con = GetSqlConnection();
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    {
                        // Retrieve the count result
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // Display the count in a label or any control
                        label13.Text = $" {count}";

                    }
                }
            }
            catch (Exception ex)
            {
                // Display any error messages
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void GetAccCount()
        {
            try
            {
                {

                    // SQL query to count rows in your table
                    string query = "SELECT COUNT(*) FROM accessories";

                    // Execute the query
                    MySqlConnection con = GetSqlConnection();
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    {
                        // Retrieve the count result
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // Display the count in a label or any control
                        accessNumber.Text = $" {count}";

                    }
                }
            }
            catch (Exception ex)
            {
                // Display any error messages
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void GetUserCount()
        {
            try
            {
                {

                    // SQL query to count rows in your table
                    string query = "SELECT COUNT(*) FROM users";

                    // Execute the query
                    MySqlConnection con = GetSqlConnection();
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    {
                        // Retrieve the count result
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // Display the count in a label or any control
                        userNumber.Text = $" {count}";

                    }
                }
            }
            catch (Exception ex)
            {
                // Display any error messages
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        public void QueeryData(DataGridView gridView)
        {
            string query = "select computer_name as 'Name of Computer', computer_brand as Brand, computer_spec as Specification, computer_type as 'Type of Computer' from computers where office_loc = 'office 1';";
            MySqlConnection con = GetSqlConnection();
            MySqlCommand cmd = new MySqlCommand(query, con);

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                gridView.DataSource = table;
                // MessageBox.Show("gridview success");

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

        public void QueeryData1(DataGridView gridView)
        {
            string query = " select device_name as 'Device Name', device_type as 'Type of Device', device_brand as 'Brand', device_spec as Specification from scanners_printers where office_loc = 'office 1';";
            MySqlConnection con = GetSqlConnection();
            MySqlCommand cmd = new MySqlCommand(query, con);

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                gridView.DataSource = table;
                // MessageBox.Show("gridview success");

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

        public void QueeryData2(DataGridView gridView)
        {
          
        }

        //NUMBER OF DEPARTMENT
        private void GetOfficeCount()
        {
            try
            {
                {

                    // SQL query to count rows in your table
                    string query = "select count( DISTINCT department) from computers;";

                    // Execute the query
                    MySqlConnection con = GetSqlConnection();
                    MySqlCommand cmd = new MySqlCommand(query, con);

                    {
                        // Retrieve the count result
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        // Display the count in a label or any control
                        officeNumbers.Text = $" {count}";

                    }
                }
            }
            catch (Exception ex)
            {
                // Display any error messages
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        //NUMBER OF PRINTERS AT OFFICE 1
        private void GetPrinter1Count()
        {
           
        }

        //NUMBER OF ACCESSORIES AT OFFICE 1
        private void GetAccess1Count()
        {
           
           
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard Form2 = new Dashboard();
            Form2.ShowDialog();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Equipments Form2 = new Equipments();
            Form2.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Report_Shown(object sender, EventArgs e)
        {
         
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
        }
           
        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
        }

        private void SearchtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            user form4 = new user();
            form4.ShowDialog();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {
                    }
    }
    
    





  }

