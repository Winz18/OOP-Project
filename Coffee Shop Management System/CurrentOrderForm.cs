using DoAnCK;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coffee_Shop_Management_System
{
    public partial class CurrentOrderForm : Form
    {
        public Dictionary<string, int> orders;
        private Coffee[] coffee = new Coffee[6];
        public float total = 0;
        string connect =
            "Data Source=34.176.57.189;Initial Catalog=OOP;Persist Security Info=True;User ID=sqlserver;Password=Lak@2302;";
        Barista barista = new Barista();
        Customer customer = new Customer();
        public int TableNumber;
        private int coffeeQuantity = 0;
        private int freshMilkQuantity = 0;
        private int condensedMilkQuantity = 0;
        private bool[] isPrepared = new bool[13];
        private bool[] isOrdered = new bool[13];

        public CurrentOrderForm()
        {
            InitializeComponent();
        }

        internal void CurrentOrderForm_Load(object sender, EventArgs e)
        {
            total = 0;
            using (SqlConnection sqlcon = new SqlConnection(connect))
            {
                sqlcon.Open();
                string query = "SELECT * FROM Coffes";
                SqlCommand command = new SqlCommand(query, sqlcon);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        string name = reader["Name"].ToString();
                        float.TryParse(reader["Price"].ToString(), out float price);
                        coffee[i] = new Coffee(name, price);
                        i++;
                    }
                }
            }
            UpdateRichtextbox();
        }

        private void btnPrepare_Click(object sender, EventArgs e)
        {
            int coffeeQuantitydb = 0;
            int freshMilkQuantitydb = 0;
            int condensedMilkQuantitydb = 0;
            if (isOrdered[TableNumber])
            {
                using (SqlConnection sqlcon = new SqlConnection(connect))
                {
                    sqlcon.Open();
                    string query = "SELECT * FROM Inventory";
                    SqlCommand command = new SqlCommand(query, sqlcon);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            coffeeQuantitydb = int.Parse(reader["coffee"].ToString());
                            freshMilkQuantitydb = int.Parse(reader["fresh_milk"].ToString());
                            condensedMilkQuantitydb = int.Parse(reader["condensed_milk"].ToString());
                            if (coffeeQuantitydb < coffeeQuantity)
                            {
                                MessageBox.Show("Not enough coffee!", "Notification");
                                return;
                            }

                            if (freshMilkQuantitydb < freshMilkQuantity)
                            {
                                MessageBox.Show("Not enough fresh milk!", "Notification");
                                return;
                            }

                            if (condensedMilkQuantitydb < condensedMilkQuantity)
                            {
                                MessageBox.Show("Not enough condensed milk!", "Notification");
                                return;
                            }
                        }
                    }
                }

                MessageBox.Show(barista.prepare_coffee(), "Notification");
                isPrepared[TableNumber] = true;
                condensedMilkQuantitydb -= condensedMilkQuantity;
                freshMilkQuantitydb -= freshMilkQuantity;
                coffeeQuantitydb -= coffeeQuantity;
                string tableName = "Inventory";
                string columnName = "coffee";
                int newValue = coffeeQuantitydb;
                UpdateDatabaseColumn(connect, tableName, columnName, newValue);
                columnName = "fresh_milk";
                newValue = freshMilkQuantitydb;
                UpdateDatabaseColumn(connect, tableName, columnName, newValue);
                columnName = "condensed_milk";
                newValue = condensedMilkQuantitydb;
                UpdateDatabaseColumn(connect, tableName, columnName, newValue);
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            else
            {
                MessageBox.Show("Nothing to prepare!", "Notification");
            }
        }

        private void UpdateDatabaseColumn(string connectionString, string tableName, string columnName, dynamic newValue)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = $"UPDATE {tableName} SET {columnName} = @NewValue";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NewValue", newValue);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            isOrdered[TableNumber] = true; 
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void UpdateRichtextbox()
        {
            try
            {
                tbxOrder.Text = "Danh sách món đã chọn:\n";
                foreach (var key in orders)
                {
                    tbxOrder.Text += $"{key.Key} x {key.Value}\n";
                    Coffee temp = coffee.FirstOrDefault(x => x.Name == key.Key);

                    if (key.Key == "Espresso" || key.Key == "Macchiato" || key.Key == "Late")
                    {
                        coffeeQuantity += key.Value;
                        freshMilkQuantity += key.Value;
                    }

                    if (key.Key == "Mocha" || key.Key == "Americano" || key.Key == "Cappucchino")
                    {
                        coffeeQuantity += key.Value;
                        condensedMilkQuantity += key.Value;
                    }

                    if (temp != null)
                    {
                        total += temp.Price * key.Value;
                    }
                }

                tbxOrder.Text += $"Tổng tiền: {total}";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime now = DateTime.Now;
                if (isPrepared[TableNumber])
                {
                    paymentForm paymentForm = new paymentForm();
                    paymentForm.lbAmount.Text = total.ToString();
                    if (paymentForm.ShowDialog() == DialogResult.OK)
                    {
                        if (paymentForm.rbnTransfer.Checked)
                        {
                            MessageBox.Show(customer.handle_payment("Bank transfer", total.ToString()), "Notification");
                        }

                        if (paymentForm.rbnCast.Checked)
                        {
                            MessageBox.Show(customer.handle_payment("Cash", total.ToString()), "Notification");
                        }

                        MessageBox.Show(customer.generate_customer_feedback(paymentForm.tbxFeedback.Text),
                            "Notification");
                    }

                    isPrepared[TableNumber] = false;
                    isOrdered[TableNumber] = false;
                    customer.Name = paymentForm.tbxName.Text;
                    customer.Contact_inf = paymentForm.tbxContact.Text;
                    InsertData(connect, "History", "Customer_name", "Contact_inf", "Date", "Price", "Feed_back",
                        customer.Name, customer.Contact_inf, now, total, paymentForm.tbxFeedback.Text);
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nothing to pay!", "Notification");
                }
            }
            catch (Exception exception)
            {
               MessageBox.Show(exception.Message);
            }
        }

        private void InsertData(string connectionString, string tableName, 
            string columnName1, string columnName2, string columnName3, string columnName4, string columnName5,
            string Name, string contact, DateTime now, float total, dynamic fb)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = $"INSERT INTO {tableName} ({columnName1}, {columnName2}, {columnName3}, {columnName4}, {columnName5}) " +
                                         "VALUES (@Value1, @Value2, @Value3, @Value4, @Value5); SELECT SCOPE_IDENTITY()";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Value1", Name);
                        command.Parameters.AddWithValue("@Value2", contact);
                        command.Parameters.AddWithValue("@Value3", now);
                        command.Parameters.AddWithValue("@Value4", total);
                        command.Parameters.AddWithValue("@Value5", fb);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

    }
}
