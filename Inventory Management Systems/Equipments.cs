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
    public partial class Equipments : Form
    {
        public Equipments()
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

        public void QueeryData(DataGridView gridView)
        {
            string query = "select id as ID, computer_name as 'Name', computer_brand as Brand, computer_spec as Specification, computer_type as 'Type', Department, Person_assigned as 'Person Assigned', date_assigned as 'Date Assigned', Status from computers;";
            MySqlConnection con = GetSqlConnection();
            MySqlCommand cmd = new MySqlCommand(query, con);

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                gridView.DataSource = table;
                // MessageBox.Show("gridview success");

                //change the color of the active devices

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString() == "In Use")
                        {
                            cell.Style.ForeColor = Color.Green; // Change font color to Red
                        }

                        if (cell.Value != null && cell.Value.ToString() == "Under Maintenance")
                        {
                            cell.Style.ForeColor = Color.Red; // Change font color to Red
                        }
                    }
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
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Dashboard Form2 = new Dashboard();
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

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
            this.Close();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            string message = "Kindly contact the developer on 0553473797 for assistance. Thank you.";
            string title = "Help";
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Equipments_Shown(object sender, EventArgs e)
        {
            this.QueeryData(this.dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_Computer Form2 = new Add_Computer();
            Form2.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string _search = SearchtextBox.Text;
            string searchvalue = _search;
            bool found = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[1].Value != null && row.Cells[1].Value.ToString().Equals(searchvalue))
                {
                    row.Selected = true;

                    row.DefaultCellStyle.BackColor = Color.Red;

                    dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                    found = true;
                    break;
                }

            }
            if (!found)
            {
                MessageBox.Show("No matching data found");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Equipments formE = new Equipments();
            formE.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            scanners_printers Form2 = new scanners_printers();
            Form2.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Accessories Form3 = new Accessories();
            Form3.ShowDialog();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report Form4 = new Report();
            Form4.ShowDialog();
            this.Close();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            user form4 = new user();
            form4.ShowDialog();
            this.Close();
        }

        private void SearchtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            delete_computer form44 = new delete_computer();
            form44.ShowDialog();
        }

        private void Equipments_Load(object sender, EventArgs e)
        {
            adminLabel.Text = Session.AdminName;
            rankLabel.Text = Session.Level;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            scanners_printers Form2 = new scanners_printers();
            Form2.ShowDialog();
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Accessories Form3 = new Accessories();
            Form3.ShowDialog();
            this.Close();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }
    }

   
}
