
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
    public partial class scanners_printers : Form
    {
        public scanners_printers()
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
            string query = "select id as ID, device_name as 'Device Name', device_type as 'Type of Device', device_brand as 'Brand', device_spec as Specification, Department, office_assigned as 'Office Assigned', date_assigned as 'Date Assigned', Status from scanners_printers;";
            MySqlConnection con = GetSqlConnection();
            MySqlCommand cmd = new MySqlCommand(query, con);

            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                gridView.DataSource = table;
                // MessageBox.Show("gridview success");


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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Equipments Form2 = new Equipments();
            Form2.ShowDialog();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Form2 = new Form1();
            Form2.ShowDialog();
            this.Close();
        }

        private void label21_Click(object sender, EventArgs e)
        {
            string message = "Kindly contact the developer on 0553473797 for assistance. Thank you.";
            string title = "Help";
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            scanners_printers Form2 = new scanners_printers();
            Form2.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            add_printer Form2 = new add_printer();
            Form2.ShowDialog();
        }

        private void scanners_printers_Shown(object sender, EventArgs e)
        {
            this.QueeryData(this.dataGridView1);
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

        private void scanners_printers_Load(object sender, EventArgs e)
        {
            adminLabel.Text = Session.AdminName;
            rankLabel.Text = Session.Level;
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

        private void button6_Click(object sender, EventArgs e)
        {
            delete_printer Form43 = new delete_printer();
            Form43.ShowDialog();
            
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            user Form4 = new user();
            Form4.ShowDialog();
            this.Close();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Equipments Form2 = new Equipments();
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
    }
}

