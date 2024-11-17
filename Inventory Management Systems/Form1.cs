using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Inventory_Management_Systems
{

  
    public partial class Form1 : Form
    {

        private string textPassedForm1;

        public Form1()
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

        private bool LoginUser(string username, string password, string status)
        {
            bool isValidUser = false;
            try {

                MySqlConnection con = GetSqlConnection();

                {
                     string query = "SELECT COUNT(*) FROM users WHERE UserName=@username AND Password=@password AND status=@Active";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@active", status);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    isValidUser = count > 0;
                  }
               

            }


            catch (MySqlException ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("A null reference error occurred: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            return isValidUser;
        }

    


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void userTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                passwordTextbox.PasswordChar = '\0';
            }
            else
            {
                passwordTextbox.PasswordChar = '*';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string username = userTextBox.Text;
            string password = passwordTextbox.Text;
            string status = "Active";
// string level = rankcomboTextbox.Text;

            if (LoginUser(username, password, status))
            {
                Session.AdminName = username;
               // Session.Level = level;
                MessageBox.Show("Login successful!");
                // Proceed to the next form or main application
                this.Hide();
                Dashboard Form2 = new Dashboard();
                Form2.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

           /* string user = userTextBox.Text;
            string password = passwordTextbox.Text;
            string rank = rankcomboTextbox.Text;


            string userA = "Oheneba";
            string userSO = "Nii";
            string usersSM = "Maxwell";
            string passwordA = "2024";
            string passwordSO = "2024";
            string passwordSM = "2024";
            string rank1 = "Admin";
            string rank2 = "Senior Officer";
            string rank3 = "Store Keeper";


            if (userA == user && passwordA == password && rank1 == rank)
            {
                textPassedForm1 = userTextBox.Text;
                MessageBox.Show("Admin login successful");
                this.Hide();
                Dashboard Form2 = new Dashboard();
                Form2.ShowDialog();
                this.Close();
            }


            else if (userSO==user && passwordSO == password && rank2 == rank)
            {
                textPassedForm1 = userTextBox.Text;
                MessageBox.Show("Senior Officer login successful");
                this.Hide();
                Dashboard Form2 = new Dashboard();
                Form2.ShowDialog();
                this.Close();
            }


            else if (usersSM == user && passwordSM == password && rank3 == rank)
            {
                textPassedForm1 = userTextBox.Text;
                MessageBox.Show("Store keeper login successful");
                this.Hide();
                Dashboard Form2 = new Dashboard();
                Form2.ShowDialog();
                this.Close();
            }
            else
            {
                string message = "Wrong Credentials";
                string title = "Failed to login";
                MessageBox.Show(message, title, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

            }
        }*/



        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            string message = "Kindly contact the Admin to change the Password. Thank you.";
            string title = "Forgot Password";
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rankcomboTextbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void passwordTextbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

