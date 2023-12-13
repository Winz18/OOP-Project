using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Coffee_Shop_Management_System
{
    public partial class Loginform : Form
    {
        string connection_string = "Data Source=34.176.57.189;Initial Catalog=OOP;Persist Security Info=True;User ID=sqlserver;Password=Lak@2302;";
        Encrypt encr = new Encrypt();
        public int Role;
        public Loginform()
        {
            InitializeComponent();
            try
            {
                using (SqlConnection connection = new SqlConnection(connection_string))
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }
        public event EventHandler LoginSuccessful;

        private void OnLoginSuccessful()
        {
            LoginSuccessful?.Invoke(this, EventArgs.Empty);
        }
        private void Login_button_click(object sender, EventArgs e)
        {
            try
            {
                String username = username_textbox.Text;
                String password = password_textbox.Text;
                String query = "SELECT * FROM ACCOUNTS WHERE username = @username;";
                using (SqlConnection sqlConnection = new SqlConnection(connection_string))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@username", username);
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            byte[] hashedPasswordBytes = (byte[])sqlDataReader["password"];
                            if (encr.VerifyPassword(password, hashedPasswordBytes))
                            {
                                int Role_db = (int)sqlDataReader["role"];
                                Role = Role_db;
                                OnLoginSuccessful();
                                if(Role == 1)
                                {
                                    MessageBox.Show("Login successfully as Admin!");
                                }
                                else 
                                {
                                    MessageBox.Show("Login successfully as Employee!");
                                }
                               
                                this.DialogResult = DialogResult.OK;
                                this.Close();

                            }
                            else
                            {
                                MessageBox.Show("Wrong password!");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong username!");
                        
                    }
                    sqlConnection.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Loginform_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Role = -1;
            OnLoginSuccessful();
            MessageBox.Show("Login successfully as Guest!");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}