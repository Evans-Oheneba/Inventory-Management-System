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
    public partial class user : Form
    {
        public user()
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
            string query = "select ID, UserName, Level, Contact, Email, Department, Password, Status from users;";
            //select ID, UserName, Level, case when level = 'admin' then '******************' else password end as Password from users;
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
                        if (cell.Value != null && cell.Value.ToString() == "Active")
                        {
                            cell.Style.ForeColor = Color.Green; // Change font color to Red
                        }

                        if (cell.Value != null && cell.Value.ToString() == "In Active")
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
        private void button4_Click(object sender, EventArgs e)
        {

            add_user form5 = new add_user();
            form5.ShowDialog();
        }

        private void user_Shown(object sender, EventArgs e)
        {
            this.QueeryData(this.dataGridView1);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Report Form4 = new Report();
            Form4.ShowDialog();
            this.Close();
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
            Equipments formE = new Equipments();
            formE.ShowDialog();
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

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            user form4 = new user();
            form4.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            delete_user form4 = new delete_user();
            form4.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void user_Load(object sender, EventArgs e)
        {
            adminLabel.Text = Session.AdminName;
            rankLabel.Text = Session.Level;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            user form4 = new user();
            form4.ShowDialog();
            this.Close();
        }
    }
}
