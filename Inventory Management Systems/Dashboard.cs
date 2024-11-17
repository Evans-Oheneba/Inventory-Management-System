using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Inventory_Management_Systems
{
    public partial class Dashboard : Form
    {
        public Dashboard()
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

        private void Dashboard_Load(object sender, EventArgs e)
        {
            adminLabel.Text = Session.AdminName;
            rankLabel.Text = Session.Level;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Report Form4 = new Report();
            Form4.ShowDialog();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Equipments formE = new Equipments();
            formE.ShowDialog();
            this.Close();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Equipments formE = new Equipments();
            formE.ShowDialog();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Equipments formE = new Equipments();
            formE.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        //DISPLAYING TRANSACTION RECORDS

        public void QueeryData(DataGridView gridView)
        {
            string query = "select id as ID, computer_name as 'Name', computer_brand as Brand, computer_spec as Specification, computer_type as 'Type', office_loc as 'Location' from computers;";
            MySqlConnection con = GetSqlConnection();
            MySqlCommand cmd = new MySqlCommand(query, con);

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                gridView.DataSource = table;
//                MessageBox.Show("gridview success");

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

        private void Dashboard_Shown(object sender, EventArgs e)
        {
            //this.QueeryData(this.dataGridView1);
        }

        private void label15_Click(object sender, EventArgs e)
        {
            string message = "Kindly contact the developer on 0553473797 for assistance. Thank you.";
            string title = "Help";
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Computer Form2 = new Add_Computer();
            Form2.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard formE = new Dashboard();
            formE.ShowDialog();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void SearchtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report Form4 = new Report();
            Form4.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report Form4 = new Report();
            Form4.ShowDialog();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            user form4 = new user();
            form4.ShowDialog();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            user form4 = new user();
            form4.ShowDialog();
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            this.Hide();
            user form4 = new user();
            form4.ShowDialog();
            this.Close();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
